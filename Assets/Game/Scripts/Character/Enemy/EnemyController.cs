using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class EnemyController : MonoBehaviourBase, MovementStateBase.IDirection, MovementStateBase.ISpeed, RotationStateMachine.IRotationData
    {
        [SerializeField]
        private CharacterBase m_Character;
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        private EnemyData m_EnemyData;

        public Vector3 MoveDir 
        {
            get
            {
                PlayerController player = ServiceLocator.Resolve<PlayerController>();
                if (player != null &&
                    player.Character.HealthData.IsAlive)
                {
                    return (player.transform.position - transform.position).normalized;
                }
                return Vector3.zero;
            }
        }
        public int Damage => 999;
        public float Speed => m_EnemyData != null ? m_EnemyData.speed : 2;
        public float SpeedRotation => 480;
        public Quaternion Target
        {
            get
            {
                if (MoveDir.sqrMagnitude < 0.01f)
                {
                    return transform.rotation;
                }
                float angle = Mathf.Atan2(MoveDir.y, MoveDir.x) * Mathf.Rad2Deg - 90;
                return Quaternion.AngleAxis(angle, Vector3.forward);
            }
        } 

        // Start is called before the first frame update
        void Start()
        {

        }
        public void Init(EnemyData i_EnemyData)
        {
            m_EnemyData = i_EnemyData;
            m_SpriteRenderer.sprite = m_EnemyData.icon;
            m_Character.Init(
                m_EnemyData.health,
                this,
                this,
                null,
                this);
            m_Character.StartMove();

        }
        protected override void SetRefs()
        {
            base.SetRefs();
            m_Character = GetComponent<CharacterBase>();
            m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
}