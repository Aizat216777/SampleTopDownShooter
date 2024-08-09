using MKSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Game
{
    public class WeaponSpawner : MonoBehaviour
    {
        private WeaponSpawnerData m_WeaponSpawnerData;
        private float m_DelayToSpawn;
        // Start is called before the first frame update
        void Start()
        {
            m_WeaponSpawnerData = ServiceLocator.Resolve<GameConfig>().weaponSpawnerData;
            m_DelayToSpawn = m_WeaponSpawnerData.delayToSpawn;
        }

        // Update is called once per frame
        void Update()
        {
            m_DelayToSpawn -= Time.deltaTime;
            if (m_DelayToSpawn < 0)
            {
                m_DelayToSpawn = m_WeaponSpawnerData.delayToSpawn;
                Camera camera = ServiceLocator.Resolve<CameraMain>().camera;
                float orthographicSizeWidth = camera.orthographicSize * (((float)Screen.width) / Screen.height);
                Vector3 position = new Vector3(
                    camera.transform.position.x + orthographicSizeWidth * Random.Range(-1.0f, 1.0f),
                    camera.transform.position.y + camera.orthographicSize * Random.Range(-1.0f, 1.0f),
                    0);
                WeaponBonus weaponBonus = Instantiate(
                    ServiceLocator.Resolve<GameConfig>().prefabsData.weaponBonus,
                    position,
                    Quaternion.identity,
                    ServiceLocator.Resolve<ILevel>().Root);
                PlayerController playerController = ServiceLocator.Resolve<PlayerController>();
                List<WeaponBase.eType> weaponTypeValues = new List<WeaponBase.eType>();
                foreach (WeaponBase.eType weaponType in System.Enum.GetValues(typeof(WeaponBase.eType)))
                {
                    if(playerController.WeaponController.Weapon == null ||
                        playerController.WeaponController.Weapon.Type != weaponType)
                    {
                        weaponTypeValues.Add(weaponType);
                    }
                    
                }
                weaponBonus.Init(weaponTypeValues.GetRandomItem());

            }
        }
    }

}