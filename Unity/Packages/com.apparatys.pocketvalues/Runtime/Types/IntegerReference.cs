using System;

namespace Apparatys.PocketValues.Types
{
    [Serializable]
    public sealed class IntegerReference
    : VariableReference<IntegerVariable, int>
    {
        public IntegerReference() : base() { }
        public IntegerReference(int initialValue) : base(initialValue) { }
    }
}
