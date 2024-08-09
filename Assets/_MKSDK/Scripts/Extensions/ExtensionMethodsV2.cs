using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public static class ExtensionMethodsV2 
    {
        public static string[] Tags()
        {

#if UNITY_EDITOR
            return UnityEditorInternal.InternalEditorUtility.tags;
#endif
            return new string[0];
        }
        public static float DistanceSquare(Vector3 i_Position01, Vector3 i_Position02)
        {
            return (i_Position01 - i_Position02).sqrMagnitude;
        }
        public static string ToStringFloat3(this Vector3 i_Value)
        {
            return "x=" + i_Value.x + "y=" + i_Value.y + " z=" + i_Value.z;
        }
        #region Transform
        public static void RemoveAllChild(this Transform i_Transform)
        {
            if (!Application.isPlaying)
            {
                while (i_Transform.childCount > 0)
                {
                    Object.DestroyImmediate(i_Transform.GetChild(0).gameObject);
                }
            }
            else
            {
                int numChild = i_Transform.childCount;
                for (int i = 0; i < numChild; i++)
                {
                    Object.Destroy(i_Transform.GetChild(i).gameObject);
                }
            }
        }
        public static Transform FindDeepChild(this Transform i_Parent, string i_Name)
        {
            if (i_Parent != null)
            {
                var result = i_Parent.Find(i_Name);
                if (result != null)
                    return result;

                foreach (Transform child in i_Parent)
                {
                    result = child.FindDeepChild(i_Name);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }
        public static T FindDeepChild<T>(this Transform aParent, string aName) where T : Component
        {
            var transform = aParent.FindDeepChild(aName);

            if (transform != null)
            {
                return transform.GetComponent<T>();
            }

            return default(T); 
        }
        public static T[] FindDeepChilds<T>(this Transform aParent, string aName, bool i_IncludeInactive = true) where T :Component
        {
            var transform = aParent.FindDeepChild(aName);

            if (transform != null)
            {
                return transform.GetComponentsInChildren<T>(i_IncludeInactive);
            }

            return new T[0];
        }
        public static List<Transform> FindChildsByName(this Transform aParent, string aName, bool i_IncludeInactive = true)
        {
            List<Transform> list = new List<Transform>();
            AddChildByNameIfNeed(aParent, aName, list, i_IncludeInactive);
            return list;
        }
        private static void AddChildByNameIfNeed(Transform i_Transform, string i_Name, List<Transform> i_List, bool i_IncludeInactive)
        {
            if (i_Transform != null)
            {
                foreach (Transform child in i_Transform)
                {
                    
                    if(child.gameObject.activeSelf || i_IncludeInactive)
                    {
                        if (child.name == i_Name)
                        {
                            i_List.Add(child);
                        }
                        AddChildByNameIfNeed(child, i_Name, i_List, i_IncludeInactive);
                    }
                }
            }
        }
        public static List<T> FindChildsByName<T>(this Transform aParent, string aName, bool i_IncludeInactive = true) where T : Component
        {
            List<T> list = new List<T>();
            AddChildByNameIfNeed(aParent, aName, list, i_IncludeInactive);
            return list;
        }
        private static void AddChildByNameIfNeed<T>(Transform i_Transform, string i_Name, List<T> i_List, bool i_IncludeInactive) where T : Component
        {
            if (i_Transform != null)
            {
                foreach (Transform child in i_Transform)
                {
                    if (child.gameObject.activeSelf || i_IncludeInactive)
                    {
                        if (child.name == i_Name &&
                            child.TryGetComponent(out T component))
                        {
                            i_List.Add(component);
                        }
                        AddChildByNameIfNeed(child, i_Name, i_List, i_IncludeInactive);
                    }
                }
            }
        }
        public static void SetLayerRecursively(this Transform i_Transform, string i_LayerName)
        {
            int layerNumber = LayerMask.NameToLayer(i_LayerName);

            if (layerNumber >= 0)
            {
                i_Transform.SetLayerRecursivelyFinal(layerNumber);
            }
        }

        public static void SetLayerRecursively(this Transform i_Transform, int i_LayerNumber)
        {
            if (i_LayerNumber >= 0)
            {
                SetLayerRecursivelyFinal(i_Transform, i_LayerNumber);
            }
        }
        private static void SetLayerRecursivelyFinal(this Transform i_Transform, int i_LayerNumber)
        {
            i_Transform.gameObject.layer = i_LayerNumber;

            for (int i = 0; i < i_Transform.childCount; i++)
            {
                i_Transform.GetChild(i).SetLayerRecursivelyFinal(i_LayerNumber);
            }
        }
        #region Transform scale/position
        public static void SetLocalScaleX(this Transform i_Transform, float i_Value)
        {
            i_Transform.localScale = new Vector3(i_Value, i_Transform.localScale.y, i_Transform.localScale.z);
        }
        public static void SetLocalScaleY(this Transform i_Transform, float i_Value)
        {
            i_Transform.localScale = new Vector3(i_Transform.localScale.x, i_Value, i_Transform.localScale.z);
        }
        public static void SetLocalScaleZ(this Transform i_Transform, float i_Value)
        {
            i_Transform.localScale = new Vector3(i_Transform.localScale.x, i_Transform.localScale.y, i_Value);
        }
        public static void SetPositionX(this Transform i_Transform, float i_Value)
        {
            i_Transform.position = new Vector3(i_Value, i_Transform.position.y, i_Transform.position.z);
        }
        public static void SetPositionY(this Transform i_Transform, float i_Value)
        {
            i_Transform.position = new Vector3(i_Transform.position.x, i_Value, i_Transform.position.z);
        }
        public static void SetPositionZ(this Transform i_Transform, float i_Value)
        {
            i_Transform.position = new Vector3(i_Transform.position.x, i_Transform.position.y, i_Value);
        }
        public static void SetLocalPositionX(this Transform i_Transform, float i_Value)
        {
            i_Transform.localPosition = new Vector3(i_Value, i_Transform.localPosition.y, i_Transform.localPosition.z);
        }
        public static void SetLocalPositionY(this Transform i_Transform, float i_Value)
        {
            i_Transform.localPosition = new Vector3(i_Transform.localPosition.x, i_Value, i_Transform.localPosition.z);
        }
        public static void SetLocalPositionZ(this Transform i_Transform, float i_Value)
        {
            i_Transform.localPosition = new Vector3(i_Transform.localPosition.x, i_Transform.localPosition.y, i_Value);
        }
        #endregion
        #endregion
        public static bool Contains<T>(this T[] i_Array, T i_Item)
        {
            bool result = false;

            if (i_Array != null && i_Item != null)
            {
                foreach (var x in i_Array)
                {
                    if (x != null && x.Equals(i_Item))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        public static bool Contains<T>(this List<T> i_List, T i_Item)
        {
            bool result = false;

            if (i_List != null && i_Item != null)
            {
                foreach (var x in i_List)
                {
                    if (x != null && x.Equals(i_Item))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        public static T GetRandomEnum<T>() where T : System.Enum
        {
            return GetRandomItem(((T[])System.Enum.GetValues(typeof(T))));
        }
        public static T GetRandomItem<T>(this T[] i_List)
        {
            T result = default(T);
            if (i_List.Length > 0) result = i_List[UnityEngine.Random.Range(0, i_List.Length)];

            return result;
        }
        public static T GetRandomItem<T>(this List<T> i_List)
        {
            T result = default(T);
            if(i_List.Count > 0) result = i_List[UnityEngine.Random.Range(0, i_List.Count)];

            return result;
        }
        public static T GetRandomItemAndRemove<T>(this List<T> i_List)
        {
            T result = default(T);
            if (i_List.Count > 0)
            {
                int idnex = UnityEngine.Random.Range(0, i_List.Count);
                result = i_List[idnex];
                i_List.RemoveAt(idnex);
            }

            return result;
        }

        #region math
        public static bool ApproximatelyMore(float i_Value1, float i_Value2, float i_Epsilon = 0.0001f)
        {
            return Approximately(i_Value1, i_Value2, i_Epsilon) || i_Value1 > i_Value2;
        }
        public static bool ApproximatelyLess(float i_Value1, float i_Value2, float i_Epsilon = 0.0001f)
        {
            return Approximately(i_Value1, i_Value2, i_Epsilon) || i_Value1 < i_Value2;
        }
        public static bool Approximately(float i_Value1, float i_Value2, float i_Epsilon = 0.0001f)
        {
            return Mathf.Abs(i_Value1 - i_Value2) < i_Epsilon;
        }
        public static bool Approximately(Vector3 i_Value1, Vector3 i_Value2, float i_Epsilon = 0.0001f)
        {
            return Approximately(i_Value1.x, i_Value2.x, i_Epsilon) &&
                Approximately(i_Value1.y, i_Value2.y, i_Epsilon) &&
                Approximately(i_Value1.z, i_Value2.z, i_Epsilon);
        }
        public static bool Approximately(Vector2 i_Value1, Vector2 i_Value2, float i_Epsilon = 0.0001f)
        {
            return Approximately(i_Value1.x, i_Value2.x, i_Epsilon) &&
                Approximately(i_Value1.y, i_Value2.y, i_Epsilon);
        }
        public static float InverseLerp(Vector3 i_Start, Vector3 i_End, Vector3 i_Value)
        {
            Vector3 AB = i_End - i_Start;
            Vector3 AV = i_Value - i_Start;
            return Mathf.Clamp01(Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB));
        }
        public static bool InterrectRects(Rect i_Rect01, Rect i_Rect02)
        {
            return i_Rect01.Overlaps(i_Rect02) ||
                i_Rect02.Overlaps(i_Rect01) ||
                i_Rect01.Contains(new Vector2(i_Rect02.xMin, i_Rect02.yMin)) ||
                i_Rect01.Contains(new Vector2(i_Rect02.xMax, i_Rect02.yMin)) ||
                i_Rect01.Contains(new Vector2(i_Rect02.xMin, i_Rect02.yMax)) ||
                i_Rect01.Contains(new Vector2(i_Rect02.xMax, i_Rect02.yMax));
        }
        #endregion
        public static Color SetAlpha(this Color i_Color, float i_Alpha)
        {
            i_Color.a = i_Alpha;
            return i_Color;
        }
    }
}