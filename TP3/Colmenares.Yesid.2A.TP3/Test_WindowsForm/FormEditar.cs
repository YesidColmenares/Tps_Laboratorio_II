using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_WindowsForm
{
    public partial class FormEditar : Form
    {
        //CONSTRUCTOR
        /// <summary>
        /// Inicializa los componentes y establece el nombre del titulo, tambien establece el tipo de plataforma del producto a crear
        /// </summary>
        /// <param name="nombreTitulo"></param>
        public FormEditar(string nombreTitulo, EPlataforma plataforma)
        {
            InitializeComponent();
            this.lblNombreTitulo.Text = nombreTitulo;
            this.Plataforma = plataforma;
        }


        //METODOS
        /// <summary>
        /// Metodo que establece los datos del producto en cada uno de sus casillas del formulario
        /// </summary>
        private void EstablecerDatosProducto()
        {
            if (this.Producto is not null)
            {
                this.txtNombre.Text = this.Producto.Nombre;
                this.txtID.Text = this.Producto.Id;
                this.nroCantidad.Value = this.Producto.Cantidad;
                this.cmbCondicion.SelectedIndex = (int)Enum.Parse(typeof(Producto.ECondicion), this.Producto.Condicion);
                this.cmbEstado.SelectedIndex = (int)Enum.Parse(typeof(Producto.EEstado), this.Producto.Estado);
                this.cmbTipoPublicacion.SelectedIndex = (int)Enum.Parse(typeof(Producto.ETipoPublicacion), this.Producto.TipoPublicacion);
                this.nroPrecio.Value = (Decimal)this.Producto.Precio;
            }
        }


        //EVENTOS
        /// <summary>
        /// Cargar los combo box con los correspondientes enumerados, si la propiedad ModoEditar es true se inactiva el campo ID
        /// para no poder ser modificado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEditar_Load(object sender, EventArgs e)
        {
            this.cmbCondicion.DataSource = Enum.GetValues(typeof(Producto.ECondicion));
            this.cmbEstado.DataSource = Enum.GetValues(typeof(Producto.EEstado));
            this.cmbTipoPublicacion.DataSource = Enum.GetValues(typeof(Producto.ETipoPublicacion));

            if (this.ModoEditar)
            {
                this.txtID.Enabled = false;
                this.EstablecerDatosProducto();
            }
        }

        /// <summary>
        /// Boton que genera un nuevo producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text != "" && this.txtNombre.Text != "")
            {
                if (this.Plataforma == EPlataforma.MercadoLibre)
                {
                    this.Producto = new MercadoLibre(this.txtID.Text, this.txtNombre.Text, (float)this.nroPrecio.Value,
                    (int)this.nroCantidad.Value, this.cmbCondicion.Text, this.cmbEstado.Text, this.cmbTipoPublicacion.Text);
                }
                else
                {
                    if (this.Plataforma == EPlataforma.Amazon)
                    {
                        this.Producto = new Amazon(this.txtID.Text, this.txtNombre.Text, (float)this.nroPrecio.Value,
                        (int)this.nroCantidad.Value, this.cmbCondicion.Text, this.cmbEstado.Text, this.cmbTipoPublicacion.Text);
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor ingrese el nombre y/o ID del producto", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        //PROPIEDADES
        /// <summary>
        /// Eestablece y retorna un producto
        /// </summary>
        public Producto Producto { get; set; }
        /// <summary>
        /// Propiedad que indica si el Formulario esta en modo editar
        /// </summary>
        public bool ModoEditar
        {
            set; get;
        }
        /// <summary>
        /// Retorna y establece el tipo de plataforma del producto
        /// </summary>
        public EPlataforma Plataforma { get; set; }
    }
}
