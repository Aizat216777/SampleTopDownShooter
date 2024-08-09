using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public abstract class Bullet : MonoBehaviourBase
    {
        private List<BulletExtraBehaviour> m_Extras = new List<BulletExtraBehaviour>();
        // Start is called before the first frame update
        public abstract int Damage { get; }
        void Start()
        {

        }
        protected virtual void Update()
        {
            for(int i = 0; i< m_Extras.Count; i++)
            {
                m_Extras[i].Update();
            }
        }
        public void AddExtra(BulletExtraBehaviour i_Extra)
        {
            m_Extras.Add(i_Extra);
        }
        public abstract void Init(WeaponBaseData i_WeaponData);
    }
}