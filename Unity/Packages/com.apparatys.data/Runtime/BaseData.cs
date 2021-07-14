using Newtonsoft.Json;
using System;

namespace Apparatys.Data
{
    [Serializable]
    public abstract class BaseData : IData
    {
        [JsonProperty]
        private DataId m_Id = DataId.Generate();

        [JsonIgnore]
        public override DataId Id
        {
            get { return m_Id; }
        }
    }
}
