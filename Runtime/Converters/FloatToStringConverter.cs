using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Toorah.ScriptableVariables
{
    public class FloatToStringConverter : BaseVariableConverter<float, string, FloatVariable, StringVariable>
    {
        public override void SourceToTarget(float t)
        {
            var s = t.ToString();
            if (m_target.Value != s)
                m_target.Value = s;
        }

        public override void TargetToSource(string t)
        {
            if(float.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out var f))
            {
                if (m_source.Value != f)
                    m_source.Value = f;
            }
        }
    }
}
