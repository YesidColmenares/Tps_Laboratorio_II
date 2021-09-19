using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperador.Items.Add("");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Items.Add("*");
            this.Limpiar();
        }

        /// <summary>
        /// Borrará los datos de los TextBox, ComboBox y Label de la pantalla
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "";
            this.ActivarBtnConvertir(true);
        }

        /// <summary>
        /// Recibirá los dos números y el operador para luego llamar al método Operar de Entidades.Calculadora
        /// </summary>
        /// <param name="numero1">valor 1</param>
        /// <param name="numero2">valor 2</param>
        /// <param name="operador">operador</param>
        /// <returns>double con el valor de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            char.TryParse(operador, out char caracter);
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), caracter);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = this.cmbOperador.Text;
            string resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();

            if (!this.MensajeErrorDivisionCero(resultado))
            {
                double.TryParse(this.txtNumero1.Text, out double numero1);
                double.TryParse(this.txtNumero2.Text, out double numero2);

                if (operador == "")
                {
                    operador = "+";
                }

                this.lblResultado.Text = resultado;
                this.ActivarBtnConvertir(true);
                this.lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = {this.lblResultado.Text}");
            }  
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numeroDecimal = this.lblResultado.Text;

            this.lblResultado.Text = Operando.DecimalBinario(numeroDecimal);
            this.ImprimirBtnConvertir(numeroDecimal, this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = false;
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroBinario = this.lblResultado.Text;

            this.lblResultado.Text = Operando.BinarioDecimal(numeroBinario);
            this.ImprimirBtnConvertir(numeroBinario, this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = false;
        }


        /// <summary>
        /// Imprime en el ListBox el resultado de la operación de convertir a binario y viceversa 
        /// </summary>
        /// <param name="valor">Valor antes de ser convertido</param>
        /// <param name="resultado">Valor luego de ser convertido</param>
        private void ImprimirBtnConvertir(string valor, string resultado)
        {
            if (!this.lblResultado.Text.Equals("Valor inválido"))
            {
                this.lstOperaciones.Items.Add($"{valor} = {resultado}");
            }
        }

        /// <summary>
        /// Activa o desactiva los botones convertir
        /// </summary>
        /// <param name="estado">Estado del boton</param>
        private void ActivarBtnConvertir(bool estado)
        {
            this.btnConvertirABinario.Enabled = estado;
            this.btnConvertirADecimal.Enabled = estado;
        }

        /// <summary>
        /// Mensaje de error en caso que el valor ingresado sea double.MinValue
        /// </summary>
        /// <param name="valor">Valor a validar</param>
        /// <returns>true si el valor es double.MinValue, falso si es distinto de double.MinValue </returns>
        private bool MensajeErrorDivisionCero(string valor)
        {
            bool retorno = false;

            if (valor == double.MinValue.ToString())
            {
                MessageBox.Show("Asegúrese de que el divisor no sea cero o que contenga un valor inválido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = true;
            }

            return retorno;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
