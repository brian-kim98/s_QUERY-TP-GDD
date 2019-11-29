namespace FrbaOfertas2.AbmRol
{
    partial class ListadoRoles
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
            this.Nuevo_Rol = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_rol = new System.Windows.Forms.DataGridView();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_funcionalidades = new System.Windows.Forms.ComboBox();
            this.label_seleccion_habilitado = new System.Windows.Forms.Label();
            this.comboBox_habilitados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_texto_libre = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rol)).BeginInit();
            this.groupBox_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_actualizar
            // 
            this.button_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_actualizar.Location = new System.Drawing.Point(83, 202);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(90, 25);
            this.button_actualizar.TabIndex = 9;
            this.button_actualizar.Text = "Mostrar todos";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // Nuevo_Rol
            // 
            this.Nuevo_Rol.Location = new System.Drawing.Point(162, 475);
            this.Nuevo_Rol.Name = "Nuevo_Rol";
            this.Nuevo_Rol.Size = new System.Drawing.Size(183, 35);
            this.Nuevo_Rol.TabIndex = 8;
            this.Nuevo_Rol.Text = "Nuevo Rol";
            this.Nuevo_Rol.UseVisualStyleBackColor = true;
            this.Nuevo_Rol.Click += new System.EventHandler(this.Nuevo_Rol_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(83, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_rol
            // 
            this.dataGridView_rol.AllowUserToAddRows = false;
            this.dataGridView_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Estado});
            this.dataGridView_rol.Location = new System.Drawing.Point(83, 233);
            this.dataGridView_rol.Name = "dataGridView_rol";
            this.dataGridView_rol.Size = new System.Drawing.Size(342, 150);
            this.dataGridView_rol.TabIndex = 5;
            this.dataGridView_rol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_rol_CellContentClick);
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.button_limpiar);
            this.groupBox_filtros.Controls.Add(this.label2);
            this.groupBox_filtros.Controls.Add(this.comboBox_funcionalidades);
            this.groupBox_filtros.Controls.Add(this.label_seleccion_habilitado);
            this.groupBox_filtros.Controls.Add(this.comboBox_habilitados);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.textBox_texto_libre);
            this.groupBox_filtros.Controls.Add(this.button_buscar);
            this.groupBox_filtros.Location = new System.Drawing.Point(49, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(433, 166);
            this.groupBox_filtros.TabIndex = 10;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de busqueda";
            this.groupBox_filtros.Enter += new System.EventHandler(this.groupBox_filtros_Enter);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buscar por funcionalidad";
            // 
            // comboBox_funcionalidades
            // 
            this.comboBox_funcionalidades.FormattingEnabled = true;
            this.comboBox_funcionalidades.Location = new System.Drawing.Point(6, 127);
            this.comboBox_funcionalidades.Name = "comboBox_funcionalidades";
            this.comboBox_funcionalidades.Size = new System.Drawing.Size(230, 21);
            this.comboBox_funcionalidades.TabIndex = 5;
            // 
            // label_seleccion_habilitado
            // 
            this.label_seleccion_habilitado.AutoSize = true;
            this.label_seleccion_habilitado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_seleccion_habilitado.Location = new System.Drawing.Point(3, 67);
            this.label_seleccion_habilitado.Name = "label_seleccion_habilitado";
            this.label_seleccion_habilitado.Size = new System.Drawing.Size(58, 13);
            this.label_seleccion_habilitado.TabIndex = 4;
            this.label_seleccion_habilitado.Text = "Buscar por";
            // 
            // comboBox_habilitados
            // 
            this.comboBox_habilitados.FormattingEnabled = true;
            this.comboBox_habilitados.Location = new System.Drawing.Point(6, 83);
            this.comboBox_habilitados.Name = "comboBox_habilitados";
            this.comboBox_habilitados.Size = new System.Drawing.Size(230, 21);
            this.comboBox_habilitados.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Texto libre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_texto_libre
            // 
            this.textBox_texto_libre.Location = new System.Drawing.Point(6, 40);
            this.textBox_texto_libre.Name = "textBox_texto_libre";
            this.textBox_texto_libre.Size = new System.Drawing.Size(230, 20);
            this.textBox_texto_libre.TabIndex = 1;
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
            // Codigo
            // 
            this.Codigo.HeaderText = "rol_codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Visible = false;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 547);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.Nuevo_Rol);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_rol);
            this.Name = "ListadoRoles";
            this.Text = "ListadoRoles";
            this.Load += new System.EventHandler(this.ListadoRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rol)).EndInit();
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.Button Nuevo_Rol;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView_rol;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_texto_libre;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label_seleccion_habilitado;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_funcionalidades;
        private System.Windows.Forms.ComboBox comboBox_habilitados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;

    }
}