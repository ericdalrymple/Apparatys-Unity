using System;

namespace Apparatys.Data
{
    [Serializable]
    public sealed class DataId
    {
        private Guid m_Id = Guid.NewGuid();

        public override string ToString()
        {
            return m_Id.ToString("D");
        }

        internal void Reset()
        {
            m_Id = Guid.NewGuid();
        }
    }
}