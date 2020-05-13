using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.Enums
{
    public enum Airlines
    {
        [Description("Scandinavian Airlines")]
        SK,
        [Description("British Airways")]
        BA,
        [Description("Finnair")]
        AY,
        [Description("Icelandair")]
        FI,
        [Description("Lufthansa")]
        LH,
        [Description("Air Europa")]
        UX
    }
}
