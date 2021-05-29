using System;

namespace Apparatys.PocketValues.Types
{
    [Serializable]
    public sealed class BooleanReference
    : VariableReference<BooleanVariable, bool>
    {
        public BooleanReference() : base() { }
        public BooleanReference(bool initialValue) : base(initialValue) { }
    }
}
