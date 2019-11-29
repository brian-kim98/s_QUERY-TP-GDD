namespace FrbaOfertas2.RegistroUsuario.AbmCliente
{
    partial class ListadoClientes
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
            this.button_actualizar = new System.Windows.Forms.Button();
            this.dataGridView_clientes = new System.Windows.Forms.DataGridView();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.textBox_dni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.label_seleccion_habilitado = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.nuevo_cliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clientes)).BeginInit();
            this.groupBox_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_actualizar
            // 
            this.button_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_actualizar.Location = new System.Drawing.Point(22, 193);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(90, 25);
            this.button_actualizar.TabIndex = 13;
            this.button_actualizar.Text = "Mostrar todos";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // dataGridView_clientes
            // 
            this.dataGridView_clientes.AllowUserToAddRows = false;
            this.dataGridView_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_clientes.Location = new System.Drawing.Point(22, 224);
            this.dataGridView_clientes.Name = "dataGridView_clientes";
            this.dataGridView_clientes.Size = new System.Drawing.Size(427, 167);
            this.dataGridView_clientes.TabIndex = 12;
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.textBox_dni);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.label_email);
            this.groupBox_filtros.Controls.Add(this.textBox_email);
            this.groupBox_filtros.Controls.Add(this.textBox_apellido);
            this.groupBox_filtros.Controls.Add(this.button_limpiar);
            this.groupBox_filtros.Controls.Add(this.label_seleccion_habilitado);
            this.groupBox_filtros.Controls.Add(this.label_nombre);
            this.groupBox_filtros.Controls.Add(this.textBox_nombre);
            this.groupBox_filtros.Controls.Add(this.button_buscar);
            this.groupBox_filtros.Location = new System.Drawing.Point(22, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(433, 166);
            this.groupBox_filtros.TabIndex = 14;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de busqueda";
            // 
            // textBox_dni
            // 
            this.textBox_dni.Location = new System.Drawing.Point(240, 83);
            this.textBox_dni.Name = "textBox_dni";
            this.textBox_dni.Size = new System.Drawing.Size(177, 20);
            this.textBox_dni.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(237, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "DNI (Texto Exacto)";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_email.Location = new System.Drawing.Point(240, 24);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(94, 13);
            this.label_email.TabIndex = 10;
            this.label_email.Text = "Email (Texto Libre)";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(240, 40);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(177, 20);
            this.textBox_email.TabIndex = 9;
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.Location = new System.Drawing.Point(6, 83);
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.Size = new System.Drawing.Size(195, 20);
            this.textBox_apellido.TabIndex = 8;
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
            this.label_seleccion_habilitado.Size = new System.Drawing.Size(106, 13);
            this.label_seleccion_habilitado.TabIndex = 4;
            this.label_seleccion_habilitado.Text = "Apellido (Texto Libre)";
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_nombre.Location = new System.Drawing.Point(6, 24);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(106, 13);
            this.label_nombre.TabIndex = 2;
            this.label_nombre.Text = "Nombre (Texto Libre)";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(6, 40);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(195, 20);
            this.textBox_nombre.TabIndex = 1;
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
            // nuevo_cliente
            // 
            this.nuevo_cliente.Location = new System.Drawing.Point(148, 471);
            this.nuevo_cliente.Name = "nuevo_cliente";
            this.nuevo_cliente.Size = new System.Drawing.Size(183, 35);
            this.nuevo_cliente.TabIndex = 13;
            this.nuevo_cliente.Text = "Nuevo Cliente";
            this.nuevo_cliente.UseVisualStyleBackColor = true;
            this.nuevo_cliente.Click += new System.EventHandler(this.nuevo_cliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Seleccione un Cliente";
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(70, 419);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(81, 35);
            this.button_eliminar.TabIndex = 16;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // ListadoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 518);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nuevo_cliente);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.dataGridView_clientes);
            this.Name = "ListadoClientes";
            this.Text = "ListadoClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clientes)).EndInit();
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.DataGridView dataGridView_clientes;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.TextBox textBox_dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Label label_seleccion_habilitado;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button nuevo_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_eliminar;
    }
}