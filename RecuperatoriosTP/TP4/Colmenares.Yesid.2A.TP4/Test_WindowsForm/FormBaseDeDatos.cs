using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_WindowsForm
{
    public partial class FormBaseDeDatos : Form
    {
        //CONSTRUCTOR
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deposito">Deposito de productos</param>
        public FormBaseDeDatos(Deposito<Producto> deposito)
        {
            InitializeComponent();
            this.Deposito = deposito;
        }

        //METODOS
        /// <summary>
        /// Activa y Establece el panel del control pasado como parametro, y tambien establece el titulo
        /// </summary>
        /// <param name="c">Control que se va activar</param>
        /// <param name="titulo">Titulo del panel</param>
        private void ActivarYEstablecerTitulo(Control c, string titulo)
        {
            foreach (Control item in this.pnlPrincipal.Controls)
            {
                item.Visible = false;
            }

            this.lblTitulo.Text = titulo;
            c.Visible = true;
        }
        /// <summary>
        /// Llena un ListBox con la lista pasada como parametro
        /// </summary>
        /// <param name="c">ListBox a llenar</param>
        /// <param name="lista">Lista con los productos</param>
        private void LlenarListBox(ListBox c, List<Producto> lista)
        {
            c.Items.Clear();

            foreach (Producto item in lista)
            {
                c.Items.Add(item);
            }
        }
        /// <summary>
        /// Activa y desactiva los botones de gestion
        /// </summary>
        /// <param name="valor"></param>
        private void ActivarBotonesGestion(bool valor)
        {
            this.btnAgregar.Visible = valor;
            this.btnEliminar.Visible = valor;
            this.btnModificar.Visible = valor;
        }


        //MANEJADOR DE EVENTOS PROPIOS
        /// <summary>
        /// Captura el evento que es generado cuando un producto es eliminado del deposito,
        /// mostrando en un MessageBox el nombre y el id del producto.
        /// </summary>
        /// <param name="id">Id del producto eliminado</param>
        /// <param name="nombre">Nombre del producto eliminado</param>
        private void Deposito_ProductoEliminadoEvent(string id, string nombre)
        {
            MessageBox.Show($"Eliminaste el producto ID: {id}, Nombre: {nombre}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Captura el evento que es generado cuando se crea un producto sin cantidad de stock,
        /// avisa en un MessageBox
        /// </summary>
        private void Deposito_CantidadCeroEvent()
        {
            MessageBox.Show("Agregaste un producto con cantidad: 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Me permite establecer una conexion con la base de datos para probar que la conexion sea exitosa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEstablecerConexion_Evento(object sender, EventArgs e)
        {
            try
            {
                if (this.Sql.ProbarConexion(this.txtNombreServidor.Text, this.txtNombreBaseDatos.Text))
                {
                    this.pgrssBarEstadoConexion.EstadoBarra = true;
                    this.txtNombreBaseDatos.Enabled = false;
                    this.txtNombreServidor.Enabled = false;
                    this.grpGestion.Visible = true;
                    this.Deposito.AgregarLista(this.Sql.ObtenerLista("Amazon"));
                    this.Deposito.AgregarLista(this.Sql.ObtenerLista("MercadoLibre"));
                }
                else
                {
                    throw new Exception("Error al realizar la conexion con la base de datos");
                }
            }
            catch (DepositoListZeroAggregateException exception)
            {
                MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //MANEJADOR DE EVENTOS
        /// <summary>
        /// Agrega los manejadores de evento:<br/>
        /// 1. EventHandler<br/>
        /// 2. CantidadCeroEvent<br/>
        /// 3. ProductoEliminadoEvent<br/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormBaseDeDatos_Load(object sender, EventArgs e)
        {
            this.btnEstablecerConexion.Click += new EventHandler(this.BtnEstablecerConexion_Evento);
            this.Deposito.CantidadCeroEvent += new CantidadCeroEvent(this.Deposito_CantidadCeroEvent);
            this.Deposito.ProductoEliminadoEvent += new ProductoEliminadoEvent(this.Deposito_ProductoEliminadoEvent);
            this.cmbDeposito.DataSource = Enum.GetValues(typeof(EPlataforma));
        }
        /// <summary>
        /// Agrega un producto al deposito y a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormEditar editar = new FormEditar("Agregar Producto", this.PlataformaActual);

            if (editar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.Sql.Agregar(editar.Producto))
                    {
                        this.Deposito.Agregar(editar.Producto);
                        this.ActivarYEstablecerTitulo(this.lstBoxMostrar, "LISTA DE PRODUCTOS");
                        this.LlenarListBox(this.lstBoxMostrar, this.Sql.ObtenerLista(this.cmbDeposito.Text));
                    }
                }
                catch (DepositoExistException exception)
                {
                    MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Obtiene la lista de los productos que estan en el deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObtenerLista_Click(object sender, EventArgs e)
        {
            List<Producto> lista = this.Sql.ObtenerLista(this.cmbDeposito.Text);

            if (lista is not null)
            {
                this.ActivarYEstablecerTitulo(this.lstBoxMostrar, "LISTA DE PRODUCTOS");
                this.cmbDeposito.Enabled = false;
                this.ActivarBotonesGestion(true);
                this.PlataformaActual = (EPlataforma)Enum.Parse(typeof(EPlataforma), this.cmbDeposito.Text);
                this.LlenarListBox(this.lstBoxMostrar, lista);
            }
            else
            {
                MessageBox.Show($"Tabla no existe o el campo esta vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Modifica un producto de la base de datos y del deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.ActivarYEstablecerTitulo(this.lstBoxModificar, "MODIFICAR PRODUCTOS");
            this.LlenarListBox(this.lstBoxModificar, this.Sql.ObtenerLista(this.cmbDeposito.Text));
        }
        /// <summary>
        /// Elimina un producto de la base de datos y del deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.ActivarYEstablecerTitulo(this.lstBoxEliminar, "ELIMINAR PRODUCTOS");
            this.LlenarListBox(this.lstBoxEliminar, this.Sql.ObtenerLista(this.cmbDeposito.Text));
        }
        /// <summary>
        /// Me permite cambiar de tabla en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarTabla_Click(object sender, EventArgs e)
        {
            this.ActivarBotonesGestion(false);
            this.lstBoxMostrar.Items.Clear();
            this.ActivarYEstablecerTitulo(this.lstBoxMostrar, "CAMBIAR TABLA");
            this.cmbDeposito.Enabled = true;
        }
        /// <summary>
        /// Sale hacia el menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }


        /// <summary>
        /// El producto seleccionado del ListBox es eliminado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)this.lstBoxEliminar.SelectedItem;

            if (seleccionado is not null)
            {
                DialogResult dialog = MessageBox.Show("Estas seguro de querer eliminar este producto?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        if (this.Sql.Eliminar(seleccionado))
                        {
                            this.Deposito.Eliminar(seleccionado);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.LlenarListBox(this.lstBoxEliminar, this.Sql.ObtenerLista(this.cmbDeposito.Text));
        }
        /// <summary>
        /// El producto seleccionado del ListBox se podra modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)this.lstBoxModificar.SelectedItem;

            if (seleccionado is not null)
            {
                FormEditar editar = new FormEditar("Editar Producto", this.PlataformaActual);

                editar.ModoEditar = true;
                editar.Producto = seleccionado;

                if (editar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (this.Sql.Modificar(editar.Producto))
                        {
                            this.Deposito.Remplazar(editar.Producto);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.LlenarListBox(this.lstBoxModificar, this.Sql.ObtenerLista(this.cmbDeposito.Text));
        }


        //PROPIEDADES
        /// <summary>
        /// Deposito de productos
        /// </summary>
        public Deposito<Producto> Deposito
        {
            get; set;
        }
        /// <summary>
        /// Guarda y retorna la plataforma actual 
        /// </summary>
        public EPlataforma PlataformaActual
        {
            get; set;
        }
        /// <summary>
        /// Retorna una instancia de SQL dependiendo el servidor, la base de datos y el nombre actual de la tabla
        /// </summary>
        public Sql Sql
        {
            get
            {
                return new Sql(this.txtNombreServidor.Text, this.txtNombreBaseDatos.Text, this.cmbDeposito.Text);
            }
        }
        /// <summary>
        /// Me permite saber si la base de datos esta en modo predeterminado
        /// </summary>
        public bool BDPredeterminada
        {
            set
            {
                if (value)
                {
                    this.txtNombreServidor.Text = "YESIDMOR7";
                    this.txtNombreBaseDatos.Text = "Productos";
                    this.cmbDeposito.Text = "MercadoLibre";
                    this.groupDatosDDBB.Visible = false;
                    this.Deposito.AgregarLista(this.Sql.ObtenerLista("Amazon"));
                    this.Deposito.AgregarLista(this.Sql.ObtenerLista("MercadoLibre"));
                }
                else
                {
                    this.grpGestion.Visible = false;
                }
            }
        }

    }
}
