using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MK.Game
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private WeaponBase m_Weapon;
        private float m_DelayToShoot;
        private bool m_IsShoot;
        public WeaponBase Weapon=>m_Weapon;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void Update()
        {
            m_DelayToShoot += Time.deltaTime;
            if(m_Weapon!=null &&
                m_DelayToShoot > m_Weapon.delayToAttack &&
                m_IsShoot)
            {
                m_DelayToShoot = 0;
                m_Weapon.Shoot();
            }
        }
        public void UpdateIsShoot(bool i_IsShoot)
        {
            m_IsShoot = i_IsShoot;
        }
        public void SetNewWeapon(WeaponBase i_NewWeapon)
        {
            if (m_Weapon != null)
            {
                Destroy(m_Weapon.gameObject);
            }
            m_Weapon = i_NewWeapon;
            if (m_Weapon != null)
            {
                m_Weapon.transform.SetParent(transform);
                m_Weapon.transform.localPosition = Vector3.zero;
                m_Weapon.transform.localRotation = Quaternion.identity;
            }
        }
    }
}