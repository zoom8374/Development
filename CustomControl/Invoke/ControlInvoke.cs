using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public static class ControlInvoke
    {
        public static void GradientLabelText(GradientLabel _Control, string _Text)
        {
            if (_Control.InvokeRequired)
            {
                _Control.Invoke(new MethodInvoker(delegate () { _Control.Text = _Text; }));
            }
            else
            {
                _Control.Text = _Text;
            }
        }
    }
}
