using System;
using System.Windows.Forms;

namespace BControlesDeUsuario
{
    public class UCButtonPrincipal : Button
    {
        public UCButtonPrincipal()
        {
            this.MouseMove += new MouseEventHandler(this.UCButtonPrincipal_MouseMove);
            this.MouseLeave += new EventHandler(this.UCButtonPrincipal_MouseLeave);
        }

        private void UCButtonPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = System.Drawing.Color.LightBlue;
        }
        private void UCButtonPrincipal_MouseLeave(object sender, EventArgs e)
        {
            this.UseVisualStyleBackColor = true;
        }
    }
}
