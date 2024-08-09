using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

namespace MKSDK
{
    public class FollowTransformUniversal : MonoBehaviour
    {
        public enum eUpdateType
        {
            FixedUpdate,
            Update,
            LateUpdate
        }
        public Transform target;
        public eUpdateType updateType = eUpdateType.Update;
        public float lerpPower = 8;
        public bool positionFollow = true;
        public bool rotationFollow = true;
        private void FixedUpdate()
        {
            if (updateType == eUpdateType.FixedUpdate) UpdateFollow(Time.fixedDeltaTime);
        }
        private void Update()
        {
            if (updateType == eUpdateType.Update) UpdateFollow(Time.deltaTime);
        }
        private void LateUpdate()
        {
            if (updateType == eUpdateType.LateUpdate) UpdateFollow(Time.deltaTime);
        }
        private void UpdateFollow(float i_DeltaTime)
        {
            if (target != null)
            {
                if (positionFollow)
                {
                    transform.position = Vector3.Lerp(transform.position, target.position, lerpPower * i_DeltaTime);
                }
                if (rotationFollow)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerpPower * i_DeltaTime);
                }
            }
        }
        [Button]
        private void UpdateInEditor()
        {
            UpdateFollow(9999);
        }
    }
}