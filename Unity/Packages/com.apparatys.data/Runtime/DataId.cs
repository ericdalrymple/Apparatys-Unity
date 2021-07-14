using Newtonsoft.Json;
using System;
using System.Linq;

namespace Apparatys.Data
{
    [Serializable]
    public sealed class DataId : IComparable<DataId>
    {
        private static readonly byte[] c_InvalidId = Guid.Empty.ToByteArray();

        [JsonProperty]
        private byte[] m_Id = c_InvalidId;

        #region Operators

        public static bool operator ==(DataId a, DataId b)
            => Enumerable.SequenceEqual(a.m_Id, b.m_Id);

        public static bool operator !=(DataId a, DataId b)
            => !Enumerable.SequenceEqual(a.m_Id, b.m_Id);

        internal static DataId Generate()
        {
            DataId newId = new DataId();
            newId.Initialize();
            return newId;
        }

        #endregion

        #region Properties

        [JsonIgnore]
        public bool IsValid
        {
            get { return !Enumerable.SequenceEqual(m_Id, c_InvalidId); }
        }

        #endregion

        #region Constructors

        public DataId()
        {
            // Serialization constructor
        }

        internal DataId(DataId other)
        {
            m_Id = other.m_Id.Clone() as byte[];
        }

        #endregion

        #region IComparable<DataId> Implementation

        int IComparable<DataId>.CompareTo(DataId other)
        {
            for (int i = 0, count = m_Id.Length; i < count; ++i)
            {
                int diff = m_Id[i] - other.m_Id[i];
                if (diff != 0)
                {
                    return diff;
                }
            }

            return 0;
        }

        #endregion

        #region Object Overrides

        public override bool Equals(object obj)
        {
            DataId other = obj as DataId;
            if (other != null)
            {
                return Enumerable.SequenceEqual(m_Id, other.m_Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return new Guid(m_Id).GetHashCode();
        }

        public override string ToString()
        {
            return new Guid(m_Id).ToString("D");
        }

        #endregion

        internal void Initialize()
        {
            m_Id = Guid.NewGuid().ToByteArray();
        }
    }
}