using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

namespace MKSDK
{
    public class ActionEffect : MonoBehaviourBase
    {
        public static void StartEffects(ActionEffect[] i_Effects)
        {
            StartEffects(i_Effects, Vector3.zero, Quaternion.identity, Vector3.forward, 1);
        }
        public static void StartEffects(ActionEffect[] i_Effects, Transform i_Data)
        {
            StartEffects(i_Effects, i_Data.position, i_Data.rotation, i_Data.forward, 1);
        }
        public static void StartEffects(ActionEffect[] i_Effects, Vector3 i_Position, Quaternion i_Rotation, Vector3 i_Dir, float i_Force)
        {
            if (i_Effects != null)
            {
                foreach (ActionEffect effect in i_Effects)
                {
                    if (effect != null && effect.isActiveAndEnabled) effect.StartEffect(i_Position, i_Rotation, i_Dir, i_Force);
                }
            }
        }
        public static void StopEffects(ActionEffect[] i_Effects)
        {
            if (i_Effects != null)
            {
                foreach (ActionEffect effect in i_Effects)
                {
                    if (effect != null && effect.isActiveAndEnabled) effect.StopEffect();
                }
            }
        }
        protected virtual void Start()
        {

        }
        public virtual void StartEffect(Vector3 i_Position, Quaternion i_Rotation, Vector3 i_Dir, float i_Force)
        {

        }
        public virtual void StopEffect()
        {

        }
        [Button]
        private void DebugStartEffect()
        {
            StartEffect(transform.position, transform.rotation, transform.forward, 1);
        }
    }
}