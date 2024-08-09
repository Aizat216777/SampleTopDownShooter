using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class WeaponShotgun : WeaponBase
    {
        public override eType Type => eType.Shotgun;
        public override void Shoot()
        {
            WeaponShotgunData weaponShotgunData = m_WeaponData as WeaponShotgunData;
            if (weaponShotgunData != null)
            {
                for(int i = 0; i< weaponShotgunData.bulletAmount; i++)
                {
                    Bullet bullet = CreateBullet(transform.rotation * Quaternion.Euler(0, 0, Random.Range(-weaponShotgunData.angle, weaponShotgunData.angle)));
                    bullet.AddExtra(new BulletExtraBehaviourDistance((m_WeaponData as WeaponShotgunData).distance, bullet));
                }
            }
        }
    }
}