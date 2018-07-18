using System.Collections;
using UnityEngine;

namespace StartMenu
{
    public class CameraPositionStartMenu : MonoBehaviour
    {

        public float m_TransistionDuration;
        private Camera m_Camera;

        IEnumerator LerpFromTo(Vector2 _start, Vector2 _end, float _duration)
        {
            for(float t=0f; t < _duration; t += Time.deltaTime)
            {
                m_Camera.transform.position = transform.position = Vector2.Lerp(_start, _end, t / _duration);
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
            float startY = orthograficSize;
            float startX = orthograficSize * m_Camera.aspect;
            float cameraZ = m_Camera.transform.position.z;

            m_Camera.transform.position = new Vector3(startX, startY, cameraZ);
        }

        public void MoveCameraToNextPositon(Vector2 _nextPosition)
        {
            float newPositionX = _nextPosition.x;
            Vector2 newPosition = new Vector2(newPositionX, m_Camera.transform.position.y);

            StartCoroutine(LerpFromTo(m_Camera.transform.position, newPosition, m_TransistionDuration));
        }
    }
}
