using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKSDK
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> s_Services = new Dictionary<Type, object>();
        public static void Register<T>(object i_ServiceInstance)
        {
            s_Services[typeof(T)] = i_ServiceInstance;
        }

        public static T Resolve<T>()
        {
            if(s_Services.ContainsKey(typeof(T)))
                return (T)s_Services[typeof(T)];
            return default(T);
        }
        public static void Reset()
        {
            s_Services.Clear();
        }
    }
}