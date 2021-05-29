using System;
using UnityEngine;

namespace Apparatys.PocketValues
{
    [Serializable]
    public class VariableReference<VariableType, ValueType>
    : BaseVariableReference
    where VariableType : Variable<ValueType>
    {
        #pragma warning disable 0649

        [SerializeField]
        private ValueType constant;

        [SerializeField]
        private VariableType variable;

        #pragma warning restore 0649

        /// <summary>
        /// Gets the current value assigned to this variable.
        /// </summary>
        /// <value>A value.</value>
        public ValueType Value
        {
            get
            {
                if (this.UseConstant)
                {
                    return this.constant;
                }
                else
                {
                    return this.variable.Value;
                }
            }
        }

        public VariableReference()
            : base()
        { }

        public VariableReference(ValueType initialValue)
            : base(true)
        {
            constant = initialValue;
        }
    }
}

