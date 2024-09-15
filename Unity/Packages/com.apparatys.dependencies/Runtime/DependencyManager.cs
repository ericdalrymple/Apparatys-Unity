using System;
using System.Collections.Generic;

namespace Apparatys.Dependencies
{
    public static class DependencyManager
    {
        private static Dictionary<Type, IDependable> m_Dependables = new Dictionary<Type, IDependable>();

        internal static T GetDependable<T>() where T : class, IDependable
        {
            T result = null;

            if (m_Dependables.TryGetValue(typeof(T), out IDependable dependable))
            {
                result = dependable as T;
            }

            // TODO: Add assert

            return result;
        }

        internal static void ReportDependency()
        {

        }

        public static void Register<T>(T dependable) where T : IDependable
        {
            m_Dependables.Add(typeof(T), dependable);
        }
    }
}
