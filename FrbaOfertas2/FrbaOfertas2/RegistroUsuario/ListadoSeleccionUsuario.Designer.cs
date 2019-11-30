namespace FrbaOfertas2.RegistroUsuario
{
    partial class ListadoSeleccionUsuario
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
            this.label2 = new System.Windows.Forms.Label();
            this.button_actualizar = new System.Windows.Forms.Button();
            this.dataGridView_usuarios = new System.Windows.Forms.DataGridView();
            this.button_seleccionar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.label_username = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).BeginInit();
            this.groupBox_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Seleccione un Usuario";
            // 
            // button_actualizar
            // 
            this.button_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_actualizar.Location = new System.Drawing.Point(22, 161);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(90, 25);
            this.button_actualizar.TabIndex = 17;
            this.button_actualizar.Text = "Mostrar todos";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // dataGridView_usuarios
            // 
            this.dataGridView_usuarios.AllowUserToAddRows = false;
            this.dataGridView_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_usuarios.Location = new System.Drawing.Point(51, 192);
            this.dataGridView_usuarios.Name = "dataGridView_usuarios";
            this.dataGridView_usuarios.Size = new System.Drawing.Size(357, 167);
            this.dataGridView_usuarios.TabIndex = 16;
            // 
            // button_seleccionar
            // 
            this.button_seleccionar.Location = new System.Drawing.Point(357, 388);
            this.button_seleccionar.Name = "button_seleccionar";
            this.button_seleccionar.Size = new System.Drawing.Size(92, 38);
            this.button_seleccionar.TabIndex = 19;
            this.button_seleccionar.Text = "Seleccionar";
            this.button_seleccionar.UseVisualStyleBackColor = true;
            this.button_seleccionar.Click += new System.EventHandler(this.button_seleccionar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(22, 388);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(92, 38);
            this.button_volver.TabIndex = 20;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.button_limpiar);
            this.groupBox_filtros.Controls.Add(this.label_username);
            this.groupBox_filtros.Controls.Add(this.textBox_nombre);
            this.groupBox_filtros.Controls.Add(this.button_buscar);
            this.groupBox_filtros.Location = new System.Drawing.Point(22, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(433, 128);
            this.groupBox_filtros.TabIndex = 21;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de busqueda";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(259, 89);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 7;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_username.Location = new System.Drawing.Point(26, 37);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(117, 13);
            this.label_username.TabIndex = 2;
            this.label_username.Text = "Username (Texto Libre)";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(29, 53);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(305, 20);
            this.textBox_nombre.TabIndex = 1;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(340, 89);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 0;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // ListadoSeleccionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 472);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_seleccionar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.dataGridView_usuarios);
            this.Name = "ListadoSeleccionUsuario";
            this.Text = "ListadoSeleccionUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).EndInit();
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.DataGridView dataGridView_usuarios;
        private System.Windows.Forms.Button button_seleccionar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Button button_buscar;
    }
}