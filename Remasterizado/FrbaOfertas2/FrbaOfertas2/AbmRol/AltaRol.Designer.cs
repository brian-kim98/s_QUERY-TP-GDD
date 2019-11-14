namespace FrbaOfertas2
{
    partial class AltaRol_Form
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
            this.button_aniadir_funcionalidad = new System.Windows.Forms.Button();
            this.button_crear_rol = new System.Windows.Forms.Button();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_funcionalidades = new System.Windows.Forms.Label();
            this.comboBox_funcionalidades = new System.Windows.Forms.ComboBox();
            this.listBox_funcionalidades_para_rol = new System.Windows.Forms.ListBox();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_aniadir_funcionalidad
            // 
            this.button_aniadir_funcionalidad.Location = new System.Drawing.Point(53, 228);
            this.button_aniadir_funcionalidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_aniadir_funcionalidad.Name = "button_aniadir_funcionalidad";
            this.button_aniadir_funcionalidad.Size = new System.Drawing.Size(75, 23);
            this.button_aniadir_funcionalidad.TabIndex = 0;
            this.button_aniadir_funcionalidad.Text = "Añadir";
            this.button_aniadir_funcionalidad.UseVisualStyleBackColor = true;
            this.button_aniadir_funcionalidad.Click += new System.EventHandler(this.button_aniadir_funcionalidad_Click);
            // 
            // button_crear_rol
            // 
            this.button_crear_rol.Location = new System.Drawing.Point(369, 386);
            this.button_crear_rol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_crear_rol.Name = "button_crear_rol";
            this.button_crear_rol.Size = new System.Drawing.Size(75, 23);
            this.button_crear_rol.TabIndex = 1;
            this.button_crear_rol.Text = "Crear";
            this.button_crear_rol.UseVisualStyleBackColor = true;
            this.button_crear_rol.Click += new System.EventHandler(this.button_crear_rol_Click);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(27, 39);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(58, 17);
            this.lbl_nombre.TabIndex = 2;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_funcionalidades
            // 
            this.lbl_funcionalidades.AutoSize = true;
            this.lbl_funcionalidades.Location = new System.Drawing.Point(27, 94);
            this.lbl_funcionalidades.Name = "lbl_funcionalidades";
            this.lbl_funcionalidades.Size = new System.Drawing.Size(111, 17);
            this.lbl_funcionalidades.TabIndex = 3;
            this.lbl_funcionalidades.Text = "Funcionalidades";
            // 
            // comboBox_funcionalidades
            // 
            this.comboBox_funcionalidades.FormattingEnabled = true;
            this.comboBox_funcionalidades.ItemHeight = 16;
            this.comboBox_funcionalidades.Location = new System.Drawing.Point(157, 91);
            this.comboBox_funcionalidades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_funcionalidades.MaxDropDownItems = 20;
            this.comboBox_funcionalidades.Name = "comboBox_funcionalidades";
            this.comboBox_funcionalidades.Size = new System.Drawing.Size(287, 24);
            this.comboBox_funcionalidades.TabIndex = 4;
            this.comboBox_funcionalidades.SelectedIndexChanged += new System.EventHandler(this.comboBox_funcionalidades_SelectedIndexChanged);
            // 
            // listBox_funcionalidades_para_rol
            // 
            this.listBox_funcionalidades_para_rol.FormattingEnabled = true;
            this.listBox_funcionalidades_para_rol.ItemHeight = 16;
            this.listBox_funcionalidades_para_rol.Location = new System.Drawing.Point(157, 228);
            this.listBox_funcionalidades_para_rol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_funcionalidades_para_rol.Name = "listBox_funcionalidades_para_rol";
            this.listBox_funcionalidades_para_rol.Size = new System.Drawing.Size(287, 132);
            this.listBox_funcionalidades_para_rol.TabIndex = 5;
            this.listBox_funcionalidades_para_rol.SelectedIndexChanged += new System.EventHandler(this.listBox_funcionalidades_para_rol_SelectedIndexChanged);
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(157, 39);
            this.textBox_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(287, 22);
            this.textBox_nombre.TabIndex = 6;
            this.textBox_nombre.TextChanged += new System.EventHandler(this.textBox_nombre_TextChanged);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(53, 386);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 7;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // AltaRol_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 503);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.listBox_funcionalidades_para_rol);
            this.Controls.Add(this.comboBox_funcionalidades);
            this.Controls.Add(this.lbl_funcionalidades);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.button_crear_rol);
            this.Controls.Add(this.button_aniadir_funcionalidad);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AltaRol_Form";
            this.Text = "Alta de Rol";
            this.Load += new System.EventHandler(this.AltaRol_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aniadir_funcionalidad;
        private System.Windows.Forms.Button button_crear_rol;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_funcionalidades;
        private System.Windows.Forms.ComboBox comboBox_funcionalidades;
        private System.Windows.Forms.ListBox listBox_funcionalidades_para_rol;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Button button_limpiar;
    }
}

