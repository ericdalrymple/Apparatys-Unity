using System;

namespace Apparatys.Data
{
    [Serializable]
    public class DataId
    {
        Guid m_Id = Guid.NewGuid();
    }
}