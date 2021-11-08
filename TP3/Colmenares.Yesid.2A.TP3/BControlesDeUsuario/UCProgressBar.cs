using System;
using System.Drawing;
using System.Windows.Forms;

namespace BControlesDeUsuario
{
    public class UCProgressBar : ProgressBar
    {
        public UCProgressBar()
        {

        }


        public bool EstadoBarra
        {
            set
            {
                if (value)
                {
                    this.Value = 100;
                }
                else
                {
                    this.Value = 0;
                }
            }
        }
    }
}
