using UnityEngine;

namespace Apparatys.Data
{
    public abstract class DataWrapper<T> : ScriptableObject
        where T : IData
    {
        [SerializeField]
        private T m_Data = null;

        public T Data
        {
            get { return m_Data; }
        }
    }
}