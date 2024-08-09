using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public abstract class BulletExtraBehaviour 
    {
        protected Bullet m_Bullet;
        public BulletExtraBehaviour(Bullet i_Bullet)
        {
            m_Bullet = i_Bullet;
        }
        public abstract void Update();
    }
}