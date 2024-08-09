using MKSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class BulletExtraBehaviourDistance : BulletExtraBehaviour
    {
        private float m_DistanceSquare;
        private Vector3 m_PositionSpawn;
        public BulletExtraBehaviourDistance(float i_Distance, Bullet i_Bullet) : base(i_Bullet)
        {
            m_PositionSpawn = m_Bullet.transform.position;
            m_DistanceSquare = i_Distance * i_Distance;
        }

        public override void Update()
        {
            if(ExtensionMethodsV2.DistanceSquare(m_PositionSpawn, m_Bullet.transform.position) > m_DistanceSquare)
            {
                Object.Destroy(m_Bullet.gameObject);
            }
        }
    }
}