
namespace Test_WindowsForm
{
    partial class FormEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditar));
            this.lblNombreTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbTipoPublicacion = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbCondicion = new System.Windows.Forms.ComboBox();
            this.nroCantidad = new System.Windows.Forms.NumericUpDown();
            this.nroPrecio = new System.Windows.Forms.NumericUpDown();
            this.txtID = new BControlesDeUsuario.UCTextBox();
            this.btnGuardar = new BControlesDeUsuario.UCButtonPrincipal();
            this.lblTipoPublicacion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreTitulo
            // 
            this.lblNombreTitulo.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblNombreTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNombreTitulo.Location = new System.Drawing.Point(9, 10);
            this.lblNombreTitulo.Name = "lblNombreTitulo";
            this.lblNombreTitulo.Size = new System.Drawing.Size(361, 23);
            this.lblNombreTitulo.TabIndex = 0;
            this.lblNombreTitulo.Text = "Editar Producto";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.cmbTipoPublicacion);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.cmbCondicion);
            this.panel1.Controls.Add(this.nroCantidad);
            this.panel1.Controls.Add(this.nroPrecio);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.lblTipoPublicacion);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.lblCondicion);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.lblPrecio);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Location = new System.Drawing.Point(8, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 357);
            this.panel1.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.MediumTurquoise;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(124, 61);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(205, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // cmbTipoPublicacion
            // 
            this.cmbTipoPublicacion.BackColor = System.Drawing.Color.MediumTurquoise;
            this.cmbTipoPublicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPublicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTipoPublicacion.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoPublicacion.FormattingEnabled = true;
            this.cmbTipoPublicacion.Location = new System.Drawing.Point(124, 273);
            this.cmbTipoPublicacion.Name = "cmbTipoPublicacion";
            this.cmbTipoPublicacion.Size = new System.Drawing.Size(205, 23);
            this.cmbTipoPublicacion.TabIndex = 6;
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.Color.MediumTurquoise;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbEstado.ForeColor = System.Drawing.Color.Black;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(124, 231);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(205, 23);
            this.cmbEstado.TabIndex = 5;
            // 
            // cmbCondicion
            // 
            this.cmbCondicion.BackColor = System.Drawing.Color.MediumTurquoise;
            this.cmbCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCondicion.ForeColor = System.Drawing.Color.Black;
            this.cmbCondicion.FormattingEnabled = true;
            this.cmbCondicion.Location = new System.Drawing.Point(124, 191);
            this.cmbCondicion.Name = "cmbCondicion";
            this.cmbCondicion.Size = new System.Drawing.Size(205, 23);
            this.cmbCondicion.TabIndex = 4;
            // 
            // nroCantidad
            // 
            this.nroCantidad.BackColor = System.Drawing.Color.MediumTurquoise;
            this.nroCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroCantidad.ForeColor = System.Drawing.Color.Black;
            this.nroCantidad.Location = new System.Drawing.Point(124, 147);
            this.nroCantidad.Name = "nroCantidad";
            this.nroCantidad.Size = new System.Drawing.Size(205, 23);
            this.nroCantidad.TabIndex = 3;
            // 
            // nroPrecio
            // 
            this.nroPrecio.BackColor = System.Drawing.Color.MediumTurquoise;
            this.nroPrecio.DecimalPlaces = 2;
            this.nroPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nroPrecio.ForeColor = System.Drawing.Color.Black;
            this.nroPrecio.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nroPrecio.Location = new System.Drawing.Point(124, 106);
            this.nroPrecio.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nroPrecio.Name = "nroPrecio";
            this.nroPrecio.Size = new System.Drawing.Size(205, 23);
            this.nroPrecio.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.MediumTurquoise;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtID.ForeColor = System.Drawing.Color.Black;
            this.txtID.Location = new System.Drawing.Point(124, 22);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(205, 23);
            this.txtID.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(124, 319);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTipoPublicacion
            // 
            this.lblTipoPublicacion.AutoSize = true;
            this.lblTipoPublicacion.Location = new System.Drawing.Point(14, 276);
            this.lblTipoPublicacion.Name = "lblTipoPublicacion";
            this.lblTipoPublicacion.Size = new System.Drawing.Size(95, 15);
            this.lblTipoPublicacion.TabIndex = 6;
            this.lblTipoPublicacion.Text = "Tipo Publicacion";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(14, 234);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(42, 15);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Estado";
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(13, 194);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(62, 15);
            this.lblCondicion.TabIndex = 4;
            this.lblCondicion.Text = "Condicion";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(13, 149);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 15);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(14, 108);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 15);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(14, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(14, 25);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(377, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNombreTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar";
            this.Load += new System.EventHandler(this.FormEditar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroPrecio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTipoPublicacion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblID;
        private BControlesDeUsuario.UCButtonPrincipal btnGuardar;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.NumericUpDown nroCantidad;
        private System.Windows.Forms.NumericUpDown nroPrecio;
        private BControlesDeUsuario.UCTextBox txtID;
        private System.Windows.Forms.ComboBox cmbTipoPublicacion;
        private System.Windows.Forms.TextBox txtNombre;
    }
}