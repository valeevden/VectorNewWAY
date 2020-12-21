using System;
using System.Collections.Generic;
using VectorNewWAY.Mode.Modifier;

namespace VectorNewWAY.Mode
{
    public class ScaleAMode : AModifierIMode
    {
        public ScaleAMode()
        {
            Modifier = new ScaleIModifier();
        }
    }
}
