namespace FrbaOfertas2.RegistroUsuario.AbmProveedor
{
    partial class ListadoProveedores
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
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_cuit = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.label_seleccion_habilitado = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.textBox_razon_social = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_actualizar = new System.Windows.Forms.Button();
            this.dataGridView_proveedor = new System.Windows.Forms.DataGridView();
            this.nuevo_cliente = new System.Windows.Forms.Button();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.groupBox_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_proveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.label_email);
            this.groupBox_filtros.Controls.Add(this.textBox_email);
            this.groupBox_filtros.Controls.Add(this.textBox_cuit);
            this.groupBox_filtros.Controls.Add(this.button_limpiar);
            this.groupBox_filtros.Controls.Add(this.label_seleccion_habilitado);
            this.groupBox_filtros.Controls.Add(this.label_nombre);
            this.groupBox_filtros.Controls.Add(this.textBox_razon_social);
            this.groupBox_filtros.Controls.Add(this.button_buscar);
            this.groupBox_filtros.Location = new System.Drawing.Point(23, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(433, 166);
            this.groupBox_filtros.TabIndex = 15;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de busqueda";
            this.groupBox_filtros.Enter += new System.EventHandler(this.groupBox_filtros_Enter);
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_email.Location = new System.Drawing.Point(6, 113);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(94, 13);
            this.label_email.TabIndex = 10;
            this.label_email.Text = "Email (Texto Libre)";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(6, 129);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(231, 20);
            this.textBox_email.TabIndex = 9;
            // 
            // textBox_cuit
            // 
            this.textBox_cuit.Location = new System.Drawing.Point(6, 83);
            this.textBox_cuit.Name = "textBox_cuit";
            this.textBox_cuit.Size = new System.Drawing.Size(231, 20);
            this.textBox_cuit.TabIndex = 8;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(271, 137);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 7;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // label_seleccion_habilitado
            // 
            this.label_seleccion_habilitado.AutoSize = true;
            this.label_seleccion_habilitado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_seleccion_habilitado.Location = new System.Drawing.Point(3, 67);
            this.label_seleccion_habilitado.Name = "label_seleccion_habilitado";
            this.label_seleccion_habilitado.Size = new System.Drawing.Size(104, 13);
            this.label_seleccion_habilitado.TabIndex = 4;
            this.label_seleccion_habilitado.Text = "CUIT (Texto Exacto)";
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_nombre.Location = new System.Drawing.Point(6, 24);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(132, 13);
            this.label_nombre.TabIndex = 2;
            this.label_nombre.Text = "Razon Social (Texto Libre)";
            // 
            // textBox_razon_social
            // 
            this.textBox_razon_social.Location = new System.Drawing.Point(6, 40);
            this.textBox_razon_social.Name = "textBox_razon_social";
            this.textBox_razon_social.Size = new System.Drawing.Size(231, 20);
            this.textBox_razon_social.TabIndex = 1;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(352, 137);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 0;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Seleccione un Proveedor";
            // 
            // button_actualizar
            // 
            this.button_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_actualizar.Location = new System.Drawing.Point(23, 197);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(96, 25);
            this.button_actualizar.TabIndex = 17;
            this.button_actualizar.Text = "Mostrar todos";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // dataGridView_proveedor
            // 
            this.dataGridView_proveedor.AllowUserToAddRows = false;
            this.dataGridView_proveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_proveedor.Location = new System.Drawing.Point(23, 228);
            this.dataGridView_proveedor.Name = "dataGridView_proveedor";
            this.dataGridView_proveedor.Size = new System.Drawing.Size(433, 167);
            this.dataGridView_proveedor.TabIndex = 16;
            // 
            // nuevo_cliente
            // 
            this.nuevo_cliente.Location = new System.Drawing.Point(142, 478);
            this.nuevo_cliente.Name = "nuevo_cliente";
            this.nuevo_cliente.Size = new System.Drawing.Size(183, 35);
            this.nuevo_cliente.TabIndex = 19;
            this.nuevo_cliente.Text = "Nuevo Proveedor";
            this.nuevo_cliente.UseVisualStyleBackColor = true;
            this.nuevo_cliente.Click += new System.EventHandler(this.nuevo_cliente_Click);
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(65, 437);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(81, 35);
            this.button_eliminar.TabIndex = 20;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(323, 437);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(81, 35);
            this.button_modificar.TabIndex = 21;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // ListadoProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 525);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.nuevo_cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.dataGridView_proveedor);
            this.Controls.Add(this.groupBox_filtros);
            this.Name = "ListadoProveedores";
            this.Text = "ListadoProveedores";
            this.Load += new System.EventHandler(this.ListadoProveedores_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_proveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_cuit;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Label label_seleccion_habilitado;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.TextBox textBox_razon_social;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.DataGridView dataGridView_proveedor;
        private System.Windows.Forms.Button nuevo_cliente;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Button button_modificar;
    }
}