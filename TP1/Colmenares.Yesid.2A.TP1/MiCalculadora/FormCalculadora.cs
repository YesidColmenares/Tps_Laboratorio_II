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

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "";
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            char caracter = ' ';
            char.TryParse(operador, out caracter);
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), caracter);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultado;
            double numero1;
            double numero2;
            string operador = this.cmbOperador.Text;

            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.lblResultado.Text = resultado;

            double.TryParse(this.txtNumero1.Text, out numero1);
            double.TryParse(this.txtNumero2.Text, out numero2);

            if (operador == "")
            {
                operador = "+";
            }
            this.lstOperaciones.Items.Add($"{numero1} {operador} {numero2} = {resultado}");
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

            if (!this.lblResultado.Text.Equals("Valor Invalido"))
            {
                this.lstOperaciones.Items.Add($"{numeroDecimal} = {this.lblResultado.Text}");
            }
            
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroBinario = this.lblResultado.Text;
            this.lblResultado.Text = Operando.BinarioDecimal(numeroBinario);

            if (!this.lblResultado.Text.Equals("Valor Invalido"))
            {
                this.lstOperaciones.Items.Add($"{numeroBinario} = {this.lblResultado.Text}");
            }
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
