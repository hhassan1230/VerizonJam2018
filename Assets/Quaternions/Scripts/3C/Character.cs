using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    #region Attributes

        // Controller
        private Controller  m_Controller            = null;

        // Movement speed
        [SerializeField]
        private float       m_MovementSpeed         = 10;

        // Sprint scale
        [SerializeField]
        private float       m_SprintScale           = 3;

        // Rotation speed
        [SerializeField]
        private float       m_RotationSpeed         = 60;

        // Dodge speed
        [SerializeField]
        private float       m_DodgeRollSpeed        = 80;
        [SerializeField]
        private float       m_DodgeMovementSpeed    = 100;

        // Rigidbody
        private Rigidbody   m_Rigidbody             = null;

        // Rotation limit
        [SerializeField]
        [Range(0, 90)]
        private float       m_PitchLimit            = 45;
        [SerializeField]
        [Range(0, 90)]
        private float       m_RollLimit             = 45;

        // Yaw sensibility on roll
        [SerializeField]
        [Range(0, 1)]
        private float       m_YawSensibilityOnRoll  = 0.33f;

        // Is dodging
        private bool        m_IsDodging             = false;

        // Game camera
        private BaseCamera  m_Camera             = null;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            // Get controller
            m_Controller = GetComponent<Controller>();

            // Get rigidbody
            m_Rigidbody = GetComponent<Rigidbody>();

            if (m_Rigidbody != null)
            {
                m_Rigidbody.useGravity = false;
            }

        }

        // Called at fixed time
        void FixedUpdate()
        {
            // Update yaw from roll angle. Writtent in fixed update to avoid camera lerp break
            UpdateYawFromRoll();
        }

        // On collision enter
        void OnCollisionEnter(Collision collision)
        {
            if (m_Rigidbody != null)
            {
                /*
                // Falling
                m_Rigidbody.useGravity = true;

                // Disable controller
                m_Controller.enabled = false;

                // Stop boost view
                if (m_Camera != null)
                {
                    m_Camera.SetBoostView(false);
                }
                 * */
            }
        }

    #endregion

    #region Getters & Setters

        // Base camera accessors
        public BaseCamera BaseCamera
        {
            get { return m_Camera; }
            set { m_Camera = value; }
        }

        // Is dodging
        public bool IsDodging
        {
            get { return m_IsDodging; }
        }

        // Controller accessors
        public Controller Controller
        {
            get { return m_Controller; }
        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Start coroutine responsible of dodge
        /// </summary>
        /// <param name="_Input">Input value on [-1, 1]</param>
        public void Dodge(float _Input)
        {
            // Dodge event on camera
            if (m_Camera != null)
            {
                if (m_Camera is TPSCamera)
                {
                    ((TPSCamera)m_Camera).OnCharacterDodge();
                }
            }

            // Start dodge
            StartCoroutine(CR_Dodge(_Input));
        }

        /// <summary>
        /// Move character in specified direction. Move the rigidboy
        /// </summary>
        /// <param name="_Direction">Movement direction (world space)</param>
        /// <param name="_Sprint">Bosst speed</param>
        /// <param name="_Dodge">Is a dodge movement</param>
        public void Move(Vector3 _Direction, bool _Sprint, bool _Dodge = false)
        {
            if (m_Rigidbody != null)
            {
                // Speed management
                float speed = m_MovementSpeed;

                if (_Dodge)
                {
                    speed = m_DodgeMovementSpeed;
                }

                if (_Sprint)
                {
                    speed *= m_SprintScale;
                }

                // Movement
                m_Rigidbody.MovePosition(m_Rigidbody.position + _Direction.normalized * Time.deltaTime * speed);
            }
        }

        /// <summary>
        /// Reset roll rotation with SLerp over time
        /// </summary>
        public void ResetRoll()
        {
            // Calculate rotation
            Vector3 rightNoY = Vector3.Cross(Vector3.up, transform.forward);
            rightNoY.y = 0;
            Quaternion rotator = Quaternion.FromToRotation(transform.right, rightNoY);

            // Apply rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rotator * transform.rotation, Time.deltaTime);
        }

        /// <summary>
        /// Reset pitch rotation with SLerp over time
        /// </summary>
        public void ResetPitch()
        {
            // Calculate rotation
            Vector3 forwardNoY = transform.forward;
            forwardNoY.y = 0;
            Quaternion rotator = Quaternion.FromToRotation(transform.forward, forwardNoY);

            // Apply rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rotator * transform.rotation, Time.deltaTime);
        }

        /// <summary>
        /// Reset pitch and roll to 0
        /// </summary>
        public void ResetOrientation()
        {
            // Projected forward
            Vector3 forwardNoY = transform.forward;
            forwardNoY.y = 0;
            forwardNoY.Normalize();

            // Apply projected forward
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(forwardNoY), Time.deltaTime);
        }

        /// <summary>
        /// Add roll to character rotation
        /// </summary>
        /// <param name="_AdditiveRoll">Roll value to add</param>
        public void AddRoll(float _AdditiveRoll, bool _Dodge = false)
        {
            // Check roll limit
            /*
            if (m_RollLimit > 0)
            {
                if (!CheckRollLimit(_AdditiveRoll))
                {
                    return;
                }
            }*/

            // Time based rotation
            if (!_Dodge)
            {
                _AdditiveRoll *= Time.deltaTime * m_RotationSpeed;
            }
            else
            {
                _AdditiveRoll *= Time.deltaTime * m_DodgeRollSpeed;
            }

            // Add rotation
            Quaternion rotator = Quaternion.AngleAxis(_AdditiveRoll, transform.forward);
            transform.rotation = rotator * transform.rotation;
        }

        /// <summary>
        /// Add pitch to character rotation
        /// </summary>
        /// <param name="_AdditivePitch">Pitch value to add</param>
        public void AddPitch(float _AdditivePitch)
        {
            // Check pitch limit
            /*
            if (m_PitchLimit > 0)
            {
                if (!CheckPitchLimit(_AdditivePitch))
                {
                    return;
                }
            }*/

            // Time based rotation
            _AdditivePitch *= Time.deltaTime * m_RotationSpeed;

            // Add rotation
            Quaternion rotator = Quaternion.AngleAxis(_AdditivePitch, transform.right);
            transform.rotation = rotator * transform.rotation;
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Dodge on left or right depending of input
        /// </summary>
        /// <param name="_Input"></param>
        /// <returns></returns>
        private IEnumerator CR_Dodge(float _Input)
        {
            float sumInput = 0;
            m_IsDodging = true;

            // Get old right local axis
            Vector3 oldRight = transform.right;

            // Wait entire roll
            while (Mathf.Abs(sumInput) < 360)
            {
                // Roll
                AddRoll(-_Input, true);

                // Movement
                Move(oldRight * _Input, false, true);

                sumInput += _Input * m_DodgeRollSpeed * Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }

            m_IsDodging = false;
        }

        /// <summary>
        /// Check next pitch operation will not go out pitch limit
        /// </summary>
        /// <param name="_AdditivePitch">Next pitch added</param>
        /// <returns>True if roll can be applied, False otherwise</returns>
        private bool CheckPitchLimit(float _AdditivePitch)
        {
            // Project local right on "flat" right
            Vector3 forwardNoY = transform.forward;
            forwardNoY.y = 0;
            forwardNoY.Normalize();

            // Get roll angle
            float pitch = Vector3.Angle(transform.forward, forwardNoY);

            if (Vector3.Cross(transform.right, forwardNoY).y < 0)
            {
                pitch *= -1;
            }

            // Check roll limit
            if (m_PitchLimit > 0)
            {
                if (pitch + _AdditivePitch > m_RollLimit)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check next roll operation will not go out roll limit
        /// </summary>
        /// <param name="_AdditiveRoll">Next roll added</param>
        /// <returns>True if roll can be applied, False otherwise</returns>
        private bool CheckRollLimit(float _AdditiveRoll)
        {
            // Project local right on "flat" right
            Vector3 rightNoY = transform.right;
            rightNoY.y = 0;
            rightNoY.Normalize();

            // Get roll angle
            float roll = Vector3.Angle(transform.right, rightNoY);

            if (Vector3.Cross(transform.forward, rightNoY).y < 0)
            {
                roll *= -1;
            }

            // Check roll limit
            if (m_RollLimit > 0)
            {
                if (roll + _AdditiveRoll > m_RollLimit)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Update the rotation on world Yaw axis depending on roll value.
        /// Represents the turn left / right effect on airplane rolling.
        /// </summary>
        private void UpdateYawFromRoll()
        {
            if (!m_IsDodging)
            {
                float upSign = 1;

                if (transform.up.y < 0)
                {
                    upSign = -1;
                }

                float yawSensibility = m_YawSensibilityOnRoll;
                Vector3 rightNoY = transform.right;
                rightNoY.y = 0;
                rightNoY.Normalize();
                float dot = Vector3.Dot(transform.up, rightNoY);

                yawSensibility *= dot * upSign;

                Quaternion rotator = Quaternion.AngleAxis(yawSensibility, Vector3.up);
                transform.rotation = rotator * transform.rotation;
            }
        }

    #endregion
}
