using System.Collections;
using UnityEngine;

namespace StartMenu
{
    public class CameraPositionStartMenu : MonoBehaviour
    {
        [LabelOverride("Transition duration")]
        [Range(0.5f,6)]
        public float m_TransistionDuration;
        [Space]
        [LabelOverride("LevelPanel")]
        public GameObject m_Panel;

        private Camera m_Camera;

        private float m_CameraX;
        private float m_CameraY;

        IEnumerator LerpFromTo(Vector3 _start, Vector3 _end, float _duration)
        {
            for(float t=0f; t < _duration; t += Time.deltaTime)
            {
                m_Camera.transform.position = Vector3.Lerp(_start, _end, t / _duration);
                yield return 0;
            }
            m_Camera.transform.position = _end;
        }

        // Use this for initialization
        void Start()
        {
            m_Camera = Camera.main;
            SetCameraToStart();
        }


        private void SetCameraToStart()
        {
           // m_Camera.orthographicSize = 2.75f;
            float orthograficSize = m_Camera.orthographicSize;
            m_CameraY = orthograficSize;
            m_CameraX = orthograficSize * m_Camera.aspect;
            float cameraZ = m_Camera.transform.position.z;

            m_Camera.transform.position = new Vector3(m_CameraX, m_CameraY, cameraZ);
        }

        public void MoveCameraToNextPositon(float _nextPositionX)
        {
            if(_nextPositionX > m_CameraX)
            {
                Vector3 newPosition = new Vector3(_nextPositionX, m_Camera.transform.position.y, -10.0f);

                StartCoroutine(LerpFromTo(m_Camera.transform.position, newPosition, m_TransistionDuration));
            }

            if(m_Panel.transform.position.x != m_Camera.transform.position.x)
            {
                m_Panel.GetComponent<PanelMovement>().MovePanel(m_Camera.transform.position.x);
            }
        }
    }
}
