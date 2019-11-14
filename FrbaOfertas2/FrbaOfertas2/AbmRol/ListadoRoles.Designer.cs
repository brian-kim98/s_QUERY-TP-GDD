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
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rol)).BeginInit();
            this.SuspendLayout();
            // 
            // button_actualizar
            // 
            this.button_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_actualizar.Location = new System.Drawing.Point(218, 52);
            this.button_actualizar.Name = "button_actualizar";
            this.button_actualizar.Size = new System.Drawing.Size(90, 41);
            this.button_actualizar.TabIndex = 9;
            this.button_actualizar.Text = "Actualizar";
            this.button_actualizar.UseVisualStyleBackColor = true;
            this.button_actualizar.Click += new System.EventHandler(this.button_actualizar_Click);
            // 
            // Nuevo_Rol
            // 
            this.Nuevo_Rol.Location = new System.Drawing.Point(167, 407);
            this.Nuevo_Rol.Name = "Nuevo_Rol";
            this.Nuevo_Rol.Size = new System.Drawing.Size(183, 35);
            this.Nuevo_Rol.TabIndex = 8;
            this.Nuevo_Rol.Text = "Nuevo Rol";
            this.Nuevo_Rol.UseVisualStyleBackColor = true;
            this.Nuevo_Rol.Click += new System.EventHandler(this.Nuevo_Rol_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_rol
            // 
            this.dataGridView_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_rol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Estado});
            this.dataGridView_rol.Location = new System.Drawing.Point(88, 112);
            this.dataGridView_rol.Name = "dataGridView_rol";
            this.dataGridView_rol.Size = new System.Drawing.Size(342, 150);
            this.dataGridView_rol.TabIndex = 5;
            this.dataGridView_rol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_rol_CellContentClick);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "rol_codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "rol_nombre";
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
            this.ClientSize = new System.Drawing.Size(519, 494);
            this.Controls.Add(this.button_actualizar);
            this.Controls.Add(this.Nuevo_Rol);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_rol);
            this.Name = "ListadoRoles";
            this.Text = "ListadoRoles";
            this.Load += new System.EventHandler(this.ListadoRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_rol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_actualizar;
        private System.Windows.Forms.Button Nuevo_Rol;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView_rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;

    }
}