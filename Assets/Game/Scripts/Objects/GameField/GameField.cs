using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class GameField : MonoBehaviourBase, IGameField
    {
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        public Vector2 Size
        {
            get
            {
                if (m_SpriteRenderer != null)
                {
                    return m_SpriteRenderer.size;
                }
                return transform.localScale;
            }
        }
        public float Left => transform.position.x - Size.x * 0.5f;
        public float Right => transform.position.x + Size.x * 0.5f;
        public float Top => transform.position.y + Size.y * 0.5f;
        public float Bottom => transform.position.y - Size.y * 0.5f;
        protected override void SetRefs()
        {
            base.SetRefs();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

    }
}