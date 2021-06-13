using System;

namespace Apparatys.Data
{
    [Serializable]
    public abstract class BaseData : IData
    {
        DataId m_Id = new DataId();

        public override DataId Id
        {
            get { return m_Id; }
        }
    }
}
