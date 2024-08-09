using MKSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class CameraTargetController : MonoBehaviour
    {
        private Camera m_Camera;
        private PlayerController m_Player;
        private IGameField m_GameField;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnEnable()
        {
            m_Player = ServiceLocator.Resolve<PlayerController>();
            m_Camera = ServiceLocator.Resolve<CameraMain>().camera;
            m_GameField = ServiceLocator.Resolve<IGameField>();
        }
        private void LateUpdate()
        {
            if (m_Player != null &&
                m_Camera != null &&
                m_GameField != null)
            {
                Vector3 position = m_Player.transform.position;
                position.z = 0;
                position.y = Mathf.Clamp(position.y, m_GameField.Bottom + m_Camera.orthographicSize, m_GameField.Top - m_Camera.orthographicSize);
                float orthographicSizeWidth = m_Camera.orthographicSize * (((float)Screen.width) / Screen.height);
                position.x = Mathf.Clamp(position.x, m_GameField.Left + orthographicSizeWidth, m_GameField.Right - orthographicSizeWidth);
                transform.position = position;

            }
        }
    }
}