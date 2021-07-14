using System;

namespace Apparatys.PocketValues.Types
{
    [Serializable]
    public sealed class StringReference
    : VariableReference<StringVariable, string>
    {
        public StringReference() : base() { }
        public StringReference(string initialValue) : base(initialValue) { }
    }
}
