using System;
using System.Windows.Forms;

namespace BControlesDeUsuario
{
    public class UCButtonPrincipal : Button
    {
        //CONSTRUCTOR
        /// <summary>
        /// Constructor que agrega los eventos al control heredado
        /// </summary>
        public UCButtonPrincipal()
        {
            this.MouseMove += new MouseEventHandler(this.UCButtonPrincipal_MouseMove);
            this.MouseLeave += new EventHandler(this.UCButtonPrincipal_MouseLeave);
        }


        //EVENTOS
        /// <summary>
        /// Cuando el mouse pasa por encima del boton cambia de color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCButtonPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = System.Drawing.Color.LightBlue;
        }

        /// <summary>
        /// Cuando el mouse se retira del boton cambia de color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCButtonPrincipal_MouseLeave(object sender, EventArgs e)
        {
            this.UseVisualStyleBackColor = true;
        }
    }
}
