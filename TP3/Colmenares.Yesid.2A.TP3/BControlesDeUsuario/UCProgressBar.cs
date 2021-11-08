using System;
using System.Drawing;
using System.Windows.Forms;

namespace BControlesDeUsuario
{
    public class UCProgressBar : ProgressBar
    {
        //CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        public UCProgressBar()
        {

        }


        //PROPIEDADES
        /// <summary>
        /// Establece el valor de la barra en 100 o 0, segun el booleano que se le asigne
        /// </summary>
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
