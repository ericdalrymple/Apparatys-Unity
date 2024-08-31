using System;
using System.Collections.Generic;

namespace Apparatys.Dependencies
{
    public class DependencyManager
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

        internal void ReportDependency()
        {

        }

        internal void Register(IDependable dependable)
        {
            m_Dependables.Add(dependable.GetType(), dependable);
        }
    }
}
