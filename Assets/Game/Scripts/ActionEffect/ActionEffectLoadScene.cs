using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using UnityEngine.SceneManagement;

namespace MK.Game
{
    public class ActionEffectLoadScene : ActionEffect
    {
        [SerializeField]
        private eScenes m_Scene;
        public override void StartEffect(Vector3 i_Position, Quaternion i_Rotation, Vector3 i_Dir, float i_Force)
        {
            base.StartEffect(i_Position, i_Rotation, i_Dir, i_Force);
            SceneManager.LoadScene(m_Scene.ToString());
        }
    }
}