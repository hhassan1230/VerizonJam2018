using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour
{
    #region Attributes

        // FOV on boost
        [SerializeField]
        protected float     m_FOVOnBoost                    = 80;

        // Boost view transition duration
        [SerializeField]
        protected float     m_BoostFovTransitionDuration    = 1;

        // Default FOV
        protected float     m_DefaultFOV                    = 60;

        // Camera component
        protected Camera    m_Camera                        = null;

        // Boost coroutine running
        protected Coroutine m_RunningBoostCoroutine         = null;

    #endregion

    #region Getters & Setters

        // Camera component accessors
        public Camera CameraComponent
        {
            get { return m_Camera; }
        }

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        protected void Start()
        {
            // Get camera component
            m_Camera = GetComponent<Camera>();

            // Get default FOV
            m_DefaultFOV = m_Camera.fieldOfView;
        }

    #endregion

    #region Public Manipulators

        /// <summary>
        /// Enable / Disable boost view (FOV effect)
        /// <param name="_Mode">Enabled / Disabled mode</param>
        /// </summary>
        public void SetBoostView(bool _Mode)
        {
            // Stop previous running boost coroutine
            if (m_RunningBoostCoroutine != null)
            {
                StopCoroutine(m_RunningBoostCoroutine);
            }

            // Start boost coroutine
            if (_Mode)
            {
                m_RunningBoostCoroutine = StartCoroutine(CR_SetBoostView(m_Camera.fieldOfView, m_FOVOnBoost));
            }
            else
            {
                m_RunningBoostCoroutine = StartCoroutine(CR_SetBoostView(m_Camera.fieldOfView, m_DefaultFOV));
            }
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Boost view FOV transition between 2 FOV over time
        /// </summary>
        /// <param name="_FromFOV">Start FOV</param>
        /// <param name="_ToFOV">End FOV</param>
        private IEnumerator CR_SetBoostView(float _FromFOV, float _ToFOV)
        {
            float t = 0;

            float duration = Mathf.Abs(_ToFOV - _FromFOV) / Mathf.Abs(m_FOVOnBoost - m_DefaultFOV);
            duration *= m_BoostFovTransitionDuration;

            while (t < duration)
            {
                t += Time.deltaTime;

                if (t > duration)
                {
                    t = duration;
                }

                m_Camera.fieldOfView = Mathf.Lerp(_FromFOV, _ToFOV, t / duration);

                yield return null;
            }
        }

    #endregion
}
