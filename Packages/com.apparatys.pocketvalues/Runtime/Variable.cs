using UnityEngine;

namespace PocketValues
{
    public abstract class Variable<ValueType>
    : BaseVariable
    {
        #pragma warning disable 0649

        [SerializeField]
        private ValueType value;

        #pragma warning restore 0649

        public ValueType Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
