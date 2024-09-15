using System;
using UnityEngine;

namespace Apparatys.PocketValues.Types
{
    [Serializable]
    public sealed class ColorReference
    : VariableReference<ColorVariable, Color>
    {
        public ColorReference() : base() { }
        public ColorReference(Color initialValue) : base(initialValue) { }
    }
}
