using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class ExtraMoveInField : MovementStateBase.IExtraBehaviour
    {
        private IGameField m_GameField;
        private float m_Radius;
        public ExtraMoveInField(IGameField i_GameField, float i_Radius)
        {
            m_GameField = i_GameField;
            m_Radius = i_Radius;    
        }

        public Vector3 GetNewPosition(Vector3 i_Position)
        {
            if (m_GameField != null)
            {
                i_Position.x = Mathf.Clamp(i_Position.x, m_GameField.Left + m_Radius, m_GameField.Right - m_Radius);
                i_Position.y = Mathf.Clamp(i_Position.y, m_GameField.Bottom + m_Radius, m_GameField.Top - m_Radius);
            }
            return i_Position;
        }
    }
}