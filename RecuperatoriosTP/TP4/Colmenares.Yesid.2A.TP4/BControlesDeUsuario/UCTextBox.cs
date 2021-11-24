using System;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;

namespace BControlesDeUsuario
{
    public class UCTextBox : TextBox
    {
        //ATRIBUTOS
        /// <summary>
        /// Lanzara un error cuando el usuario este ingresado un valor incorrecto
        /// </summary>
        private ErrorProvider error;


        //CONSTRUCTOR
        /// <summary>
        /// Constructor que agrega los eventos al control heredado e inicializa el ErrorProvider
        /// </summary>
        public UCTextBox()
        {
            this.error = new ErrorProvider();
            this.Validating += new CancelEventHandler(this.TextBox_Validating);
            this.Validated += new EventHandler(this.TextBox_Validated);
            this.Leave += new EventHandler(this.TextBox_Leave);
        }


        //EVENTOS
        /// <summary>
        /// Valida que no se ingresen valores invalidos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            foreach (char item in this.Text)
            {
                if (!char.IsNumber(item) || this.Text.Length > 11 || char.IsWhiteSpace(item))
                {
                    e.Cancel = true;
                    SystemSounds.Exclamation.Play();
                    this.error.SetError(this, "Error, ingrese un valor numerico menor o igual a 10 digitos");
                }
            }
        }

        /// <summary>
        /// Valida que cuando el usuario haga click en el control, escriba un valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (this.Text == "")
            {
                SystemSounds.Exclamation.Play();
                this.Focus();
            }
        }

        /// <summary>
        /// Una vez que el evento Validating sea cancelado, entonces elimino el ErrorProvider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Validated(object sender, EventArgs e)
        {
            this.error.Clear();
        }
    }
}
