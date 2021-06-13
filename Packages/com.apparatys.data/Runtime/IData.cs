using System;

namespace Apparatys.Data
{
    [Serializable]
    public abstract class IData
    {
        public abstract DataId Id { get; }
    }
}