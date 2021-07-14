using Apparatys.Data;
using UnityEngine;

namespace Apparatys.DataEditor
{
    public abstract class DataWrapper<T> : ScriptableObject, IDataWrapper
        where T : IData, new()
    {
        [SerializeField]
        private T m_Data = new T();

        public T Data
        {
            get { return m_Data; }
        }

        void IDataWrapper.Initialize()
        {
            InitializeData();
        }

        protected internal virtual void InitializeData() {}
    }
}