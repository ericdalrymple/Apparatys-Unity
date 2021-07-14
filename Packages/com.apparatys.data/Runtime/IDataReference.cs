using System;

namespace Apparatys.Data
{
    [Serializable]
    public abstract class IDataReference
    {
        public abstract DataId Id { get; }
    }
}
