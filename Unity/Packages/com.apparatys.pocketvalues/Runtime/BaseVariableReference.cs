using System;
using UnityEngine;

namespace Apparatys.PocketValues
{
    [Serializable]
    public abstract class BaseVariableReference
    {
        #pragma warning disable 0649

        [SerializeField]
        private bool useConstant = true;

        #pragma warning restore 0649

        /// <summary>
        /// Gets a value indicating whether this variable reference is
        /// overridden by a constant.
        /// </summary>
        /// <value>True if overridden, false otherwise.</value>
        protected bool UseConstant
        {
            get
            {
                return this.useConstant;
            }
        }

        public BaseVariableReference()
        { }

        public BaseVariableReference(bool useConstant)
        {
            this.useConstant = useConstant;
        }
    }
}
