using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BControlesDeUsuario
{
    public class UCTextBox : TextBox
    {
        private ErrorProvider error;

        public UCTextBox()
        {
            this.error = new ErrorProvider();
            this.Validating += new CancelEventHandler(this.TextBox_Validating);
            this.Validated += new EventHandler(this.TextBox_Validated);
        }


        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.error.SetError(this, "Error, ingrese un valor numerico menor o igual a 10 digitos");

            foreach (char item in this.Text)
            {
                if (char.IsNumber(item) && this.Text.Length < 11)
                {
                    e.Cancel = false;
                }
            }
        }

        private void TextBox_Validated(object sender, EventArgs e)
        {
            this.error.Clear();
        }
    }
}
