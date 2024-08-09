using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class HealthData
    {
        public delegate void DiedEvent(HealthData i_HealthData);
        public event DiedEvent OnDied = delegate { };
        public delegate void DamagedEvent(HealthData i_HealthData, int i_Health, int i_OldHealth, int i_Damage);
        public event DamagedEvent OnDamaged = delegate { };

        private int m_Health;
        public bool IsAlive => m_Health > 0;
        public bool IsDie => !IsAlive;
        public HealthData(int i_health)
        {
            m_Health = i_health;
        }
        public void Hit(int i_Damage)
        {
            if (IsAlive)
            {
                int oldHealth = m_Health;
                m_Health -= i_Damage;
                m_Health = Mathf.Max(m_Health, 0);
                OnDamaged(this, m_Health, oldHealth, i_Damage);
                if (IsDie)
                {
                    OnDied(this);
                }
            }
        }
        public void Reset(int i_Health)
        {
            m_Health = i_Health;
        }
    }
}