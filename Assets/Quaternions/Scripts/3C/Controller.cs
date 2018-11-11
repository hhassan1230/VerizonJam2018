using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    #region Enums

        // Reset orientation method (all axis or per axis)
        enum EResetOrientationMethod
        {
            AllAxis,
            PerAxis,
            None
        }

    #endregion

    #region Attributes

        // Character
        private Character               m_Character                 = null;
        
        // Reset orientation method
        [SerializeField]
        private EResetOrientationMethod m_ResetOrientationMethod    = EResetOrientationMethod.AllAxis;

        // Reset all axis timer
        [SerializeField]
        private float                   m_ResetAllAxisTimeToWait    = 1;
        private float                   m_ResetAllAxisTimer         = 0;

        // Reset pitch axis timer
        [SerializeField]
        private float                   m_ResetPitchAxisTimeToWait  = 1;
        private float                   m_ResetPitchAxisTimer       = 0;

        // Reset roll axis timer
        [SerializeField]
        private float                   m_ResetRollAxisTimeToWait   = 1;
        private float                   m_ResetRollAxisTimer        = 0;

        // Game camera
        [SerializeField]
        private TPSCamera               m_TPSCamera                = null;

        // FPS camera
        [SerializeField]
        private FPSCamera               m_FPSCamera                 = null;

        // Current camera
        private BaseCamera              m_CurrentCamera             = null;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            // Get character
            m_Character = GetComponent<Character>();

            // Current camera
            if (m_TPSCamera != null)
            {
                m_CurrentCamera = m_TPSCamera;

                if (m_FPSCamera != null)
                {
                    m_FPSCamera.GetComponent<Camera>().enabled = false;
                    Camera.SetupCurrent(m_CurrentCamera.CameraComponent);
                }
            }
        }

        // Called at fixed time
        void FixedUpdate()
        {
            if (m_Character != null)
            {
                // Written in foxed update to avoid camera lerp break
                if (!m_Character.IsDodging)
                {
                    // Check movement input
                    CheckMovementInput();

                    // Check action input
                    CheckActionInput();
                }

                // Check camera inputs
                CheckCameraInput();

                // Move character (in fixed update to avoid camera lerp break)
                m_Character.Move(m_Character.transform.forward, Input.GetButton("Fire1"));
            }
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Switch current camera with another camera
        /// </summary>
        private void SwitchCamera()
        {
            // Check camera null
            if (m_TPSCamera != null && m_FPSCamera != null)
            {
                // Switch camera
                if (m_CurrentCamera == m_TPSCamera)
                {
                    m_CurrentCamera = m_FPSCamera;
                    m_FPSCamera.CameraComponent.enabled = true;
                    m_TPSCamera.CameraComponent.enabled = false;
                }
                else
                {
                    m_CurrentCamera = m_TPSCamera;
                    m_FPSCamera.CameraComponent.enabled = false;
                    m_TPSCamera.CameraComponent.enabled = true;
                }

                // Set new current camera
                Camera.SetupCurrent(m_CurrentCamera.CameraComponent);

                // Set current camera to character
                if (m_Character != null)
                {
                    m_Character.BaseCamera = m_CurrentCamera;
                }
            }
        }

        /// <summary>
        /// Check camera inputs and call camera actions associated
        /// </summary>
        private void CheckCameraInput()
        {
            // Switch camera
            if (Input.GetButtonDown("SwitchCamera"))
            {
                SwitchCamera();
            }
        }

        /// <summary>
        /// Check action inputs and call character actions associated
        /// </summary>
        private void CheckActionInput()
        {
            //// Input
            //float dodgeAxis = Input.GetAxis("Dodge");

            //// Dodge
            //if (dodgeAxis != 0)
            //{
            //    m_Character.Dodge(dodgeAxis);
            //}

            // Boost effect
            if (Input.GetButtonDown("Fire1"))
            {
                if (m_CurrentCamera != null)
                {
                    m_CurrentCamera.SetBoostView(true);
                }
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                if (m_CurrentCamera != null)
                {
                    m_CurrentCamera.SetBoostView(false);
                }
            }
        }

        /// <summary>
        /// Check movement input and call character actions associated
        /// </summary>
        private void CheckMovementInput()
        {
            // Input
            float pitchAxis = Input.GetAxis("Vertical");
            float rollAxis = Input.GetAxis("Horizontal");

            // Pitch
            if (pitchAxis != 0)
            {
                m_Character.AddPitch(pitchAxis);
            }

            // Roll
            if (rollAxis != 0)
            {
                m_Character.AddRoll(-rollAxis);
            }

            // Reset pitch and roll depending on reset orientation method
            if (m_ResetOrientationMethod == EResetOrientationMethod.AllAxis)
            {
                // Check no inputs
                if (pitchAxis == 0 && rollAxis == 0)
                {
                    // Check timer
                    if (m_ResetAllAxisTimer > m_ResetAllAxisTimeToWait)
                    {
                        // Reset general orientation
                        m_Character.ResetOrientation();
                    }

                    m_ResetAllAxisTimer += Time.deltaTime;
                }
                else
                {
                    m_ResetAllAxisTimer = 0;
                }
            }
            else if (m_ResetOrientationMethod == EResetOrientationMethod.PerAxis)
            {
                // Check pitch no input
                if (pitchAxis == 0)
                {
                    // Check pitch timer
                    if (m_ResetPitchAxisTimer > m_ResetPitchAxisTimeToWait)
                    {
                        // Reset pitch orientation
                        m_Character.ResetPitch();
                    }

                    m_ResetPitchAxisTimer += Time.deltaTime;
                }
                else
                {
                    m_ResetPitchAxisTimer = 0;
                }

                // Check roll no input
                if (rollAxis == 0)
                {
                    // Check roll timer
                    if (m_ResetRollAxisTimer > m_ResetRollAxisTimeToWait)
                    {
                        m_Character.ResetRoll();
                    }

                    m_ResetRollAxisTimer += Time.deltaTime;
                }
                else
                {
                    m_ResetRollAxisTimer = 0;
                }
            }
        }

    #endregion
}
