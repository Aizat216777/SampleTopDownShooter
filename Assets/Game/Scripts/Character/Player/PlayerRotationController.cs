using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class PlayerRotationController : RotationStateMachine.IRotationData
    {
        private PlayerController m_PlayerController;
        private bool m_IsShoot;
        public float Speed => m_PlayerController != null && m_PlayerController.PlayerData != null ? m_PlayerController.PlayerData.speedRotation : 180;

        public Quaternion Target
        {
            get
            {
                if (m_IsShoot)
                {
                    IInputManager inputManager = ServiceLocator.Resolve<IInputManager>();
                    Camera camera = ServiceLocator.Resolve<CameraMain>().camera;
                    Vector3 mousePosition = camera.ScreenToWorldPoint(inputManager.MouseScreenPosition);
                    mousePosition.z = m_PlayerController.transform.position.z;
                    Vector3 dir = mousePosition - m_PlayerController.transform.position;
                    float angleInput = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                    return Quaternion.AngleAxis(angleInput, Vector3.forward);
                }
                if (m_PlayerController.MoveDir.sqrMagnitude < 0.01f)
                {
                    return m_PlayerController.transform.rotation;
                }
                float angle = Mathf.Atan2(m_PlayerController.MoveDir.y, m_PlayerController.MoveDir.x) * Mathf.Rad2Deg - 90;
                return Quaternion.AngleAxis(angle, Vector3.forward);
                //return Quaternion.LookRotation(m_PlayerController.MoveDir, Vector3.left ); 
            }
        } 
        public PlayerRotationController(PlayerController i_PlayerController)
        {
            m_PlayerController = i_PlayerController;

        }
        public void UpdateIsShoot(bool i_IsShoot)
        {
            m_IsShoot = i_IsShoot;
        }
    }
}