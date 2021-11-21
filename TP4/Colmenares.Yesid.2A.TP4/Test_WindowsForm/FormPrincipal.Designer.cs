
namespace Test_WindowsForm
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btnInformes = new BControlesDeUsuario.UCButtonPrincipal();
            this.btnGestion = new BControlesDeUsuario.UCButtonPrincipal();
            this.btnCalcular = new BControlesDeUsuario.UCButtonPrincipal();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpBoxEstadoCarga = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pgrssBarEstadoCarga = new BControlesDeUsuario.UCProgressBar();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializacionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbPlataforma = new System.Windows.Forms.ComboBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlInformes = new System.Windows.Forms.Panel();
            this.rdoBtnNuevo = new System.Windows.Forms.RadioButton();
            this.rdoBtnUsado = new System.Windows.Forms.RadioButton();
            this.rdoBtnEstadoNinguno = new System.Windows.Forms.RadioButton();
            this.rdoBtnInactivo = new System.Windows.Forms.RadioButton();
            this.rdoBtnActivo = new System.Windows.Forms.RadioButton();
            this.rdoBtnConStock = new System.Windows.Forms.RadioButton();
            this.rdoBtnSinStock = new System.Windows.Forms.RadioButton();
            this.rdoBtnListaProductos = new System.Windows.Forms.RadioButton();
            this.btnGenerarInforme = new BControlesDeUsuario.UCButtonPrincipal();
            this.rdoBtnCondicionNinguno = new System.Windows.Forms.RadioButton();
            this.rdoBtnReacondicionado = new System.Windows.Forms.RadioButton();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.richTxtAnalisis = new System.Windows.Forms.RichTextBox();
            this.lstBoxEliminar = new System.Windows.Forms.ListBox();
            this.lstBoxEditar = new System.Windows.Forms.ListBox();
            this.lstBoxMostrar = new System.Windows.Forms.ListBox();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.btnAnalisis = new BControlesDeUsuario.UCButtonPrincipal();
            this.btnSalir = new BControlesDeUsuario.UCButtonPrincipal();
            this.ucButtonPrincipal2 = new BControlesDeUsuario.UCButtonPrincipal();
            this.grpBoxEstadoCarga.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.pnlInformes.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInformes
            // 
            this.btnInformes.Location = new System.Drawing.Point(-1, 174);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(215, 75);
            this.btnInformes.TabIndex = 2;
            this.btnInformes.Text = "Informes";
            this.btnInformes.UseVisualStyleBackColor = true;
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(-1, 99);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(215, 75);
            this.btnGestion.TabIndex = 1;
            this.btnGestion.Text = "Gestion";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(-1, 24);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(215, 75);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular Pausadas";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.MediumTurquoise;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(220, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(738, 23);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "BIENVENIDO";
            // 
            // grpBoxEstadoCarga
            // 
            this.grpBoxEstadoCarga.Controls.Add(this.lblNombre);
            this.grpBoxEstadoCarga.Controls.Add(this.pgrssBarEstadoCarga);
            this.grpBoxEstadoCarga.Controls.Add(this.lblNombreArchivo);
            this.grpBoxEstadoCarga.Location = new System.Drawing.Point(220, 345);
            this.grpBoxEstadoCarga.Name = "grpBoxEstadoCarga";
            this.grpBoxEstadoCarga.Size = new System.Drawing.Size(870, 52);
            this.grpBoxEstadoCarga.TabIndex = 6;
            this.grpBoxEstadoCarga.TabStop = false;
            this.grpBoxEstadoCarga.Text = "Estado de carga archivo";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(569, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 15);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // pgrssBarEstadoCarga
            // 
            this.pgrssBarEstadoCarga.Location = new System.Drawing.Point(6, 23);
            this.pgrssBarEstadoCarga.Name = "pgrssBarEstadoCarga";
            this.pgrssBarEstadoCarga.Size = new System.Drawing.Size(557, 23);
            this.pgrssBarEstadoCarga.TabIndex = 3;
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(629, 28);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(16, 15);
            this.lblNombreArchivo.TabIndex = 1;
            this.lblNombreArchivo.Text = "...";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.serializarToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1090, 24);
            this.menuPrincipal.TabIndex = 10;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializacionToolStripMenuItem});
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // serializacionToolStripMenuItem
            // 
            this.serializacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("serializacionToolStripMenuItem.Image")));
            this.serializacionToolStripMenuItem.Name = "serializacionToolStripMenuItem";
            this.serializacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serializacionToolStripMenuItem.Text = "Serializacion XML";
            this.serializacionToolStripMenuItem.Click += new System.EventHandler(this.serializacionToolStripMenuItemCargar_Click);
            // 
            // serializarToolStripMenuItem
            // 
            this.serializarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializacionToolStripMenuItem1});
            this.serializarToolStripMenuItem.Name = "serializarToolStripMenuItem";
            this.serializarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.serializarToolStripMenuItem.Text = "Guardar";
            // 
            // serializacionToolStripMenuItem1
            // 
            this.serializacionToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("serializacionToolStripMenuItem1.Image")));
            this.serializacionToolStripMenuItem1.Name = "serializacionToolStripMenuItem1";
            this.serializacionToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.serializacionToolStripMenuItem1.Text = "Serializacion XML";
            this.serializacionToolStripMenuItem1.Click += new System.EventHandler(this.serializacionToolStripMenuItemGuardar_Click);
            // 
            // cmbPlataforma
            // 
            this.cmbPlataforma.BackColor = System.Drawing.Color.MediumTurquoise;
            this.cmbPlataforma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlataforma.FormattingEnabled = true;
            this.cmbPlataforma.Location = new System.Drawing.Point(959, 25);
            this.cmbPlataforma.Name = "cmbPlataforma";
            this.cmbPlataforma.Size = new System.Drawing.Size(131, 23);
            this.cmbPlataforma.TabIndex = 4;
            this.cmbPlataforma.SelectedIndexChanged += new System.EventHandler(this.cmbPlataforma_SelectedIndexChanged);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // pnlInformes
            // 
            this.pnlInformes.Controls.Add(this.rdoBtnNuevo);
            this.pnlInformes.Controls.Add(this.rdoBtnUsado);
            this.pnlInformes.Controls.Add(this.rdoBtnEstadoNinguno);
            this.pnlInformes.Controls.Add(this.rdoBtnInactivo);
            this.pnlInformes.Controls.Add(this.rdoBtnActivo);
            this.pnlInformes.Controls.Add(this.rdoBtnConStock);
            this.pnlInformes.Controls.Add(this.rdoBtnSinStock);
            this.pnlInformes.Controls.Add(this.rdoBtnListaProductos);
            this.pnlInformes.Controls.Add(this.btnGenerarInforme);
            this.pnlInformes.Controls.Add(this.rdoBtnCondicionNinguno);
            this.pnlInformes.Controls.Add(this.rdoBtnReacondicionado);
            this.pnlInformes.Location = new System.Drawing.Point(442, 47);
            this.pnlInformes.Name = "pnlInformes";
            this.pnlInformes.Size = new System.Drawing.Size(433, 289);
            this.pnlInformes.TabIndex = 8;
            // 
            // rdoBtnNuevo
            // 
            this.rdoBtnNuevo.AutoSize = true;
            this.rdoBtnNuevo.Location = new System.Drawing.Point(223, 28);
            this.rdoBtnNuevo.Name = "rdoBtnNuevo";
            this.rdoBtnNuevo.Size = new System.Drawing.Size(118, 19);
            this.rdoBtnNuevo.TabIndex = 5;
            this.rdoBtnNuevo.TabStop = true;
            this.rdoBtnNuevo.Text = "Condicion Nuevo";
            this.rdoBtnNuevo.UseVisualStyleBackColor = true;
            // 
            // rdoBtnUsado
            // 
            this.rdoBtnUsado.AutoSize = true;
            this.rdoBtnUsado.Location = new System.Drawing.Point(223, 71);
            this.rdoBtnUsado.Name = "rdoBtnUsado";
            this.rdoBtnUsado.Size = new System.Drawing.Size(116, 19);
            this.rdoBtnUsado.TabIndex = 6;
            this.rdoBtnUsado.TabStop = true;
            this.rdoBtnUsado.Text = "Condicion Usado";
            this.rdoBtnUsado.UseVisualStyleBackColor = true;
            // 
            // rdoBtnEstadoNinguno
            // 
            this.rdoBtnEstadoNinguno.AutoSize = true;
            this.rdoBtnEstadoNinguno.Location = new System.Drawing.Point(34, 197);
            this.rdoBtnEstadoNinguno.Name = "rdoBtnEstadoNinguno";
            this.rdoBtnEstadoNinguno.Size = new System.Drawing.Size(110, 19);
            this.rdoBtnEstadoNinguno.TabIndex = 4;
            this.rdoBtnEstadoNinguno.TabStop = true;
            this.rdoBtnEstadoNinguno.Text = "Estado Ninguno";
            this.rdoBtnEstadoNinguno.UseVisualStyleBackColor = true;
            // 
            // rdoBtnInactivo
            // 
            this.rdoBtnInactivo.AutoSize = true;
            this.rdoBtnInactivo.Location = new System.Drawing.Point(34, 156);
            this.rdoBtnInactivo.Name = "rdoBtnInactivo";
            this.rdoBtnInactivo.Size = new System.Drawing.Size(105, 19);
            this.rdoBtnInactivo.TabIndex = 3;
            this.rdoBtnInactivo.TabStop = true;
            this.rdoBtnInactivo.Text = "Estado Inactivo";
            this.rdoBtnInactivo.UseVisualStyleBackColor = true;
            // 
            // rdoBtnActivo
            // 
            this.rdoBtnActivo.AutoSize = true;
            this.rdoBtnActivo.Location = new System.Drawing.Point(34, 114);
            this.rdoBtnActivo.Name = "rdoBtnActivo";
            this.rdoBtnActivo.Size = new System.Drawing.Size(97, 19);
            this.rdoBtnActivo.TabIndex = 2;
            this.rdoBtnActivo.TabStop = true;
            this.rdoBtnActivo.Text = "Estado Activo";
            this.rdoBtnActivo.UseVisualStyleBackColor = true;
            // 
            // rdoBtnConStock
            // 
            this.rdoBtnConStock.AutoSize = true;
            this.rdoBtnConStock.Location = new System.Drawing.Point(34, 71);
            this.rdoBtnConStock.Name = "rdoBtnConStock";
            this.rdoBtnConStock.Size = new System.Drawing.Size(79, 19);
            this.rdoBtnConStock.TabIndex = 1;
            this.rdoBtnConStock.TabStop = true;
            this.rdoBtnConStock.Text = "Con Stock";
            this.rdoBtnConStock.UseVisualStyleBackColor = true;
            // 
            // rdoBtnSinStock
            // 
            this.rdoBtnSinStock.AutoSize = true;
            this.rdoBtnSinStock.Location = new System.Drawing.Point(34, 28);
            this.rdoBtnSinStock.Name = "rdoBtnSinStock";
            this.rdoBtnSinStock.Size = new System.Drawing.Size(73, 19);
            this.rdoBtnSinStock.TabIndex = 0;
            this.rdoBtnSinStock.TabStop = true;
            this.rdoBtnSinStock.Text = "Sin Stock";
            this.rdoBtnSinStock.UseVisualStyleBackColor = true;
            // 
            // rdoBtnListaProductos
            // 
            this.rdoBtnListaProductos.AutoSize = true;
            this.rdoBtnListaProductos.Location = new System.Drawing.Point(223, 198);
            this.rdoBtnListaProductos.Name = "rdoBtnListaProductos";
            this.rdoBtnListaProductos.Size = new System.Drawing.Size(106, 19);
            this.rdoBtnListaProductos.TabIndex = 9;
            this.rdoBtnListaProductos.TabStop = true;
            this.rdoBtnListaProductos.Text = "Lista Productos";
            this.rdoBtnListaProductos.UseVisualStyleBackColor = true;
            // 
            // btnGenerarInforme
            // 
            this.btnGenerarInforme.Location = new System.Drawing.Point(150, 253);
            this.btnGenerarInforme.Name = "btnGenerarInforme";
            this.btnGenerarInforme.Size = new System.Drawing.Size(123, 23);
            this.btnGenerarInforme.TabIndex = 10;
            this.btnGenerarInforme.Text = "Generar Informe";
            this.btnGenerarInforme.UseVisualStyleBackColor = true;
            this.btnGenerarInforme.Click += new System.EventHandler(this.btnGenerarInforme_Click);
            // 
            // rdoBtnCondicionNinguno
            // 
            this.rdoBtnCondicionNinguno.AutoSize = true;
            this.rdoBtnCondicionNinguno.Location = new System.Drawing.Point(223, 156);
            this.rdoBtnCondicionNinguno.Name = "rdoBtnCondicionNinguno";
            this.rdoBtnCondicionNinguno.Size = new System.Drawing.Size(130, 19);
            this.rdoBtnCondicionNinguno.TabIndex = 8;
            this.rdoBtnCondicionNinguno.TabStop = true;
            this.rdoBtnCondicionNinguno.Text = "Condicion Ninguno";
            this.rdoBtnCondicionNinguno.UseVisualStyleBackColor = true;
            // 
            // rdoBtnReacondicionado
            // 
            this.rdoBtnReacondicionado.AutoSize = true;
            this.rdoBtnReacondicionado.Location = new System.Drawing.Point(223, 114);
            this.rdoBtnReacondicionado.Name = "rdoBtnReacondicionado";
            this.rdoBtnReacondicionado.Size = new System.Drawing.Size(175, 19);
            this.rdoBtnReacondicionado.TabIndex = 7;
            this.rdoBtnReacondicionado.TabStop = true;
            this.rdoBtnReacondicionado.Text = "Condicion Reacondicionado";
            this.rdoBtnReacondicionado.UseVisualStyleBackColor = true;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPrincipal.BackgroundImage")));
            this.pnlPrincipal.Controls.Add(this.richTxtAnalisis);
            this.pnlPrincipal.Controls.Add(this.lstBoxEliminar);
            this.pnlPrincipal.Controls.Add(this.lstBoxEditar);
            this.pnlPrincipal.Controls.Add(this.pnlInformes);
            this.pnlPrincipal.Controls.Add(this.lstBoxMostrar);
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1090, 397);
            this.pnlPrincipal.TabIndex = 12;
            // 
            // richTxtAnalisis
            // 
            this.richTxtAnalisis.Enabled = false;
            this.richTxtAnalisis.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTxtAnalisis.ForeColor = System.Drawing.Color.Black;
            this.richTxtAnalisis.Location = new System.Drawing.Point(220, 47);
            this.richTxtAnalisis.Name = "richTxtAnalisis";
            this.richTxtAnalisis.Size = new System.Drawing.Size(870, 289);
            this.richTxtAnalisis.TabIndex = 16;
            this.richTxtAnalisis.Text = "";
            // 
            // lstBoxEliminar
            // 
            this.lstBoxEliminar.FormattingEnabled = true;
            this.lstBoxEliminar.HorizontalScrollbar = true;
            this.lstBoxEliminar.ItemHeight = 15;
            this.lstBoxEliminar.Location = new System.Drawing.Point(220, 47);
            this.lstBoxEliminar.Name = "lstBoxEliminar";
            this.lstBoxEliminar.Size = new System.Drawing.Size(870, 289);
            this.lstBoxEliminar.TabIndex = 12;
            this.lstBoxEliminar.SelectedIndexChanged += new System.EventHandler(this.lstBoxEliminar_SelectedIndexChanged);
            // 
            // lstBoxEditar
            // 
            this.lstBoxEditar.FormattingEnabled = true;
            this.lstBoxEditar.HorizontalScrollbar = true;
            this.lstBoxEditar.ItemHeight = 15;
            this.lstBoxEditar.Location = new System.Drawing.Point(220, 47);
            this.lstBoxEditar.Name = "lstBoxEditar";
            this.lstBoxEditar.Size = new System.Drawing.Size(870, 289);
            this.lstBoxEditar.TabIndex = 11;
            this.lstBoxEditar.SelectedIndexChanged += new System.EventHandler(this.lstBoxEditar_SelectedIndexChanged);
            // 
            // lstBoxMostrar
            // 
            this.lstBoxMostrar.FormattingEnabled = true;
            this.lstBoxMostrar.HorizontalScrollbar = true;
            this.lstBoxMostrar.ItemHeight = 15;
            this.lstBoxMostrar.Location = new System.Drawing.Point(220, 47);
            this.lstBoxMostrar.Name = "lstBoxMostrar";
            this.lstBoxMostrar.Size = new System.Drawing.Size(870, 289);
            this.lstBoxMostrar.TabIndex = 10;
            // 
            // btnAnalisis
            // 
            this.btnAnalisis.Location = new System.Drawing.Point(-1, 249);
            this.btnAnalisis.Name = "btnAnalisis";
            this.btnAnalisis.Size = new System.Drawing.Size(215, 75);
            this.btnAnalisis.TabIndex = 13;
            this.btnAnalisis.Text = "Analisis";
            this.btnAnalisis.UseVisualStyleBackColor = true;
            this.btnAnalisis.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(-1, 324);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(215, 75);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ucButtonPrincipal2
            // 
            this.ucButtonPrincipal2.Location = new System.Drawing.Point(-1, 324);
            this.ucButtonPrincipal2.Name = "ucButtonPrincipal2";
            this.ucButtonPrincipal2.Size = new System.Drawing.Size(215, 75);
            this.ucButtonPrincipal2.TabIndex = 14;
            this.ucButtonPrincipal2.Text = "Informes";
            this.ucButtonPrincipal2.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1090, 399);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.ucButtonPrincipal2);
            this.Controls.Add(this.btnAnalisis);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.cmbPlataforma);
            this.Controls.Add(this.grpBoxEstadoCarga);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGestion);
            this.Controls.Add(this.btnInformes);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.grpBoxEstadoCarga.ResumeLayout(false);
            this.grpBoxEstadoCarga.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.pnlInformes.ResumeLayout(false);
            this.pnlInformes.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BControlesDeUsuario.UCButtonPrincipal btnInformes;
        private BControlesDeUsuario.UCButtonPrincipal btnGestion;
        private BControlesDeUsuario.UCButtonPrincipal btnCalcular;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpBoxEstadoCarga;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbPlataforma;
        private System.Windows.Forms.OpenFileDialog openFile;
        private BControlesDeUsuario.UCProgressBar pgrssBarEstadoCarga;
        private System.Windows.Forms.Panel pnlInformes;
        private System.Windows.Forms.RadioButton rdoBtnNuevo;
        private System.Windows.Forms.RadioButton rdoBtnUsado;
        private System.Windows.Forms.RadioButton rdoBtnEstadoNinguno;
        private System.Windows.Forms.RadioButton rdoBtnInactivo;
        private System.Windows.Forms.RadioButton rdoBtnActivo;
        private System.Windows.Forms.RadioButton rdoBtnConStock;
        private System.Windows.Forms.RadioButton rdoBtnSinStock;
        private System.Windows.Forms.RadioButton rdoBtnListaProductos;
        private BControlesDeUsuario.UCButtonPrincipal btnGenerarInforme;
        private System.Windows.Forms.RadioButton rdoBtnCondicionNinguno;
        private System.Windows.Forms.RadioButton rdoBtnReacondicionado;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.ListBox lstBoxEliminar;
        private System.Windows.Forms.ListBox lstBoxEditar;
        private System.Windows.Forms.ListBox lstBoxMostrar;
        private System.Windows.Forms.ToolStripMenuItem serializarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializacionToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ToolStripMenuItem serializacionToolStripMenuItem1;
        private System.Windows.Forms.Label lblNombre;
        private BControlesDeUsuario.UCButtonPrincipal btnAnalisis;
        private BControlesDeUsuario.UCButtonPrincipal btnSalir;
        private BControlesDeUsuario.UCButtonPrincipal ucButtonPrincipal2;
        private System.Windows.Forms.RichTextBox richTxtAnalisis;
    }
}

