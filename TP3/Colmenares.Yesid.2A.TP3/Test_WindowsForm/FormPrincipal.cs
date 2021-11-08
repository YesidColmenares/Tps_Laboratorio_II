using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_WindowsForm
{
    public partial class FormPrincipal : Form
    {
        //ATRIBUTO
        /// <summary>
        /// Deposito
        /// </summary>
        private Deposito<Producto> deposito;

        
        //CONSTRUCTOR
        /// <summary>
        /// Inicializa los componentes e inicializa el deposito
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            this.deposito = new Deposito<Producto>();
        }


        //METODOS PROPIOS
        /// <summary>
        /// Desactiva todos los paneles que hay dentro del panel principal
        /// </summary>
        private void DesactivarPaneles()
        {
            foreach (Control item in this.pnlPrincipal.Controls)
            {
                if (item is Panel || item is ListBox)
                {
                    item.Visible = false;
                }
            }
        }

        /// <summary>
        /// Desactiva los paneles y activa el que se pasa por parametro
        /// </summary>
        /// <param name="c">Control a activar</param>
        /// <param name="titulo">Titulo de la ventana a abrir</param>
        private void EstablecerPanelYTitulo(Control c, string titulo)
        {
            this.DesactivarPaneles();
            this.lblTitulo.Text = titulo;
            c.Visible = true;
        }

        /// <summary>
        /// Agrega de una lista de productos al ListBox
        /// </summary>
        /// <param name="c">List Box donde se va a agregar los elementos</param>
        /// <param name="lista">Lista con los elementos</param>
        private void LlenarListBox(ListBox c, List<Producto> lista)
        {
            c.Items.Clear();
            foreach (Producto item in lista)
            {
                if (item.GetType().Name == this.PlataformaActual.ToString())
                {
                    c.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Abre una ventana Modal y obtiene la ruta al archivo
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        private string AbrirArchivo(string nombre, string extension, out string nombreArchivo)
        {
            string path = null;
            nombreArchivo = null;

            this.openFile.Title = "Abrir archivo";
            this.openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.openFile.DefaultExt = extension;
            this.openFile.FileName = nombre + extension;
            this.openFile.Filter = $"Archivos {extension} (*{extension})|*{extension}";

            if (this.openFile.ShowDialog() == DialogResult.OK)
            {
                path = this.openFile.FileName;
                this.Path = path;
                nombreArchivo = this.openFile.SafeFileName;
            }
            return path;
        }

        /// <summary>
        /// Abre una ventana Modal y obtiene la ruta al archivo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private string GuardarArchivo(string nombre, string extension)
        {
            string path = null;

            this.saveFile.Title = "Guardar archivo";
            this.saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.saveFile.DefaultExt = extension;
            this.saveFile.FileName = nombre + extension;
            this.saveFile.Filter = $"Archivos {extension} (*{extension})|*{extension}";

            if (this.saveFile.ShowDialog() == DialogResult.OK)
            {
                path = this.saveFile.FileName;
            }
            return path;
        }


        //EVENTOS MENU PRINCIPAL
        /// <summary>
        /// Invoca al metodo DesactivarPaneles()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.DesactivarPaneles();
            this.cmbPlataforma.DataSource = Enum.GetValues(typeof(EPlataforma));
        }

        /// <summary>
        /// Boton de calcular pausadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            this.EstablecerPanelYTitulo(this.lstBoxMostrar, "CONTROL DE PAUSADAS");

            this.LlenarListBox(this.lstBoxMostrar, this.Deposito.ControlPausadas());
        }

        /// <summary>
        /// Boton que gestiona los productos de Mercado Libre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGestion_Click(object sender, EventArgs e)
        {
            this.EstablecerPanelYTitulo(this.pnlGestion, "GESTION DE PRODUCTOS");
        }

        /// <summary>
        /// Boton que me permite generar informes segun se seleccione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInformes_Click(object sender, EventArgs e)
        {
            this.EstablecerPanelYTitulo(this.pnlInformes, "INFORMES DEL DEPOSITO");
        }

        /// <summary>
        /// Boton que cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Cambia la propiedad PlataformaActual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PlataformaActual = (EPlataforma)this.cmbPlataforma.SelectedItem;
        }

        /// <summary>
        /// Obtiene la ruta al archivo txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mercadoLibreToolStripMenuItemCargar_Click(object sender, EventArgs e)
        {
            this.pgrssBarEstadoCarga.EstadoBarra = false;
            string path = this.AbrirArchivo("MercadoLibre", ".txt", out string nombreArchivo);

            try
            {
                this.lblNombreArchivo.Text = nombreArchivo;
                this.deposito.AgregarLista(Archivo.CargarTxt(path, EPlataforma.MercadoLibre));
                this.pgrssBarEstadoCarga.EstadoBarra = true;
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda el archivo de los productos de Mercado Libre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mercadoLibreToolStripMenuItemGuardar_Click(object sender, EventArgs e)
        {
            string path = this.GuardarArchivo("MercadoLibre", ".txt");

            try
            {
                if(Archivo.GuardarTxt(path, this.Deposito.Productos, EPlataforma.MercadoLibre))
                {
                    MessageBox.Show("Archivo guardado correctamente");
                }
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene la ruta al archivo txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void amazonToolStripMenuItemCargar_Click(object sender, EventArgs e)
        {
            this.pgrssBarEstadoCarga.EstadoBarra = false;
            string path = this.AbrirArchivo("Amazon", ".txt", out string nombreArchivo);

            try
            {
                this.lblNombreArchivo.Text = nombreArchivo;
                this.deposito.AgregarLista(Archivo.CargarTxt(path, EPlataforma.Amazon));
                this.pgrssBarEstadoCarga.EstadoBarra = true;
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda el archivo de los productos de Amazon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void amazonToolStripMenuItemGuardar_Click(object sender, EventArgs e)
        {
            string path = this.GuardarArchivo("Amazon", ".txt");

            try
            {
                if(Archivo.GuardarTxt(path, this.Deposito.Productos, EPlataforma.Amazon))
                {
                    MessageBox.Show("Archivo guardado correctamente");
                }
                
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga una serializacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serializacionToolStripMenuItemCargar_Click(object sender, EventArgs e)
        {
            this.pgrssBarEstadoCarga.EstadoBarra = false;
            this.Path = this.AbrirArchivo("Serializacion", ".xml", out string nombreArchivo);

            this.lblNombreArchivo.Text = nombreArchivo;
            try
            {
                if (this.deposito.AgregarLista(Archivo.CargarXml(this.Path, typeof(List<Producto>))))
                {
                    this.pgrssBarEstadoCarga.EstadoBarra = true;
                }
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda una serializacion del deposito actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serializacionToolStripMenuItemGuardar_Click(object sender, EventArgs e)
        {
            string path = this.GuardarArchivo("Serializacion", ".xml");

            try
            {
                if (Archivo.GuardarXml(path, this.deposito.Productos, typeof(List<Producto>)))
                {
                    MessageBox.Show("Serializacion guardada correctamente");
                }
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //EVENTOS SUB-MENU GESTION
        /// <summary>
        /// Edita un producto seleccionado de la lista para corregirlo y luego refresca la lista para ver si se soluciono o no el error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)this.lstBoxEditar.SelectedItem;

            if (seleccionado is not null)
            {
                FormEditar editar = new FormEditar("Editar Producto", this.PlataformaActual);

                editar.ModoEditar = true;
                editar.Producto = seleccionado;

                if (editar.ShowDialog() == DialogResult.OK)
                {
                    this.Deposito.Remplazar(editar.Producto);
                    this.LlenarListBox(this.lstBoxEditar, this.Deposito.ControlPausadas());
                }
            }
        }

        /// <summary>
        /// Lista de productos, cuando se hace click sobre alguno de la lista se elimina del deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)this.lstBoxEliminar.SelectedItem;

            if (seleccionado is not null)
            {
                DialogResult dialog = MessageBox.Show("Estas seguro de querer eliminar este producto?", "ADVERTENCIA",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    this.Deposito.Eliminar(seleccionado);
                    this.LlenarListBox(this.lstBoxEliminar, this.Deposito.Productos);
                }        
            }
            else
            {
                MessageBox.Show("Ningun producto seleccionado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Agrega un producto al deposito y se guarda en el archivo txt
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
                    this.Deposito.Agregar(editar.Producto);
                }
                catch (DepositoExistException exception)
                {
                    MessageBox.Show($"{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Boton que me permite modificar productos que tengo en el deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.EstablecerPanelYTitulo(this.lstBoxEditar, "MODIFICAR PRODUCTOS");

            this.LlenarListBox(this.lstBoxEditar, this.Deposito.Productos);
        }

        /// <summary>
        /// Elimina productos de un deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.EstablecerPanelYTitulo(this.lstBoxEliminar, "ELIMINAR PRODUCTO");

            this.LlenarListBox(this.lstBoxEliminar, this.Deposito.Productos);
        }

        /// <summary>
        /// Limpia el deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarDeposito_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas seguro de querer limpiar el deposito?", "ADVERTENCIA",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                this.Deposito.Limpiar();
            }
        }


        //EVENTOS SUB-MENU INFORMES
        /// <summary>
        /// Activa el panel Informes y da la opcion de generar distintos informes de los productos del deposito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.pnlInformes.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rdoButton = ((RadioButton)item);
                    if (rdoButton.Checked == true)
                    {
                        switch (rdoButton.Name)
                        {
                            case "rdoBtnSinStock":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS SIN STOCK");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoSinStock());
                                break;

                            case "rdoBtnConStock":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS CON STOCK");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoConStock());
                                break;

                            case "rdoBtnActivo":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS ACTIVOS");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoEstadoActivo());
                                break;

                            case "rdoBtnInactivo":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS INACTIVOS");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoEstadoInactivo());
                                break;

                            case "rdoBtnEstadoNinguno":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS SIN ESTADO");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoEstadoNinguno());
                                break;

                            case "rdoBtnNuevo":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS NUEVOS");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoCondicionNuevo());
                                break;

                            case "rdoBtnUsado":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS USADOS");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoCondicionUsado());
                                break;

                            case "rdoBtnReacondicionado":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS REACONDICIONADOS");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoCondicionReacondicionado());
                                break;

                            case "rdoBtnCondicionNinguno":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS SIN CONDICION");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoCondicionNinguno());
                                break;

                            case "rdoBtnListaProductos":
                                this.EstablecerPanelYTitulo(this.lstBoxMostrar, "PRODUCTOS");
                                this.LlenarListBox(this.lstBoxMostrar, this.deposito.InfoListaProductos());
                                break;
                        }
                        break;
                    }
                }
            }
        }


        //PROPIEDADES
        /// <summary>
        /// Guarda y retorna el path del archivo txt
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Retorna el deposito
        /// </summary>
        public Deposito<Producto> Deposito
        {
            get
            {
                return this.deposito;
            }
        }
        /// <summary>
        /// Guarda y retorna la actual plataforma
        /// </summary>
        private EPlataforma PlataformaActual
        {
            get; set;
        }
    }
}
