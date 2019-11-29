namespace FrbaOfertas2.AbmRol
{
    partial class ModificarRol
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
            this.textBox_nombre_nuevo = new System.Windows.Forms.TextBox();
            this.listBox_funcionalidades_quitar = new System.Windows.Forms.ListBox();
            this.comboBox_funcionalidades_quitar = new System.Windows.Forms.ComboBox();
            this.lbl_funcionalidades = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.button_modificar_rol = new System.Windows.Forms.Button();
            this.button_aniadir_funcionalidad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_codigo_viejo = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_nombre_viejo = new System.Windows.Forms.Label();
            this.label_estado_viejo = new System.Windows.Forms.Label();
            this.checkBox_habilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_nombre_nuevo
            // 
            this.textBox_nombre_nuevo.Location = new System.Drawing.Point(61, 120);
            this.textBox_nombre_nuevo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_nombre_nuevo.Name = "textBox_nombre_nuevo";
            this.textBox_nombre_nuevo.Size = new System.Drawing.Size(216, 20);
            this.textBox_nombre_nuevo.TabIndex = 13;
            // 
            // listBox_funcionalidades_quitar
            // 
            this.listBox_funcionalidades_quitar.FormattingEnabled = true;
            this.listBox_funcionalidades_quitar.Location = new System.Drawing.Point(143, 203);
            this.listBox_funcionalidades_quitar.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_funcionalidades_quitar.Name = "listBox_funcionalidades_quitar";
            this.listBox_funcionalidades_quitar.Size = new System.Drawing.Size(216, 69);
            this.listBox_funcionalidades_quitar.TabIndex = 12;
            // 
            // comboBox_funcionalidades_quitar
            // 
            this.comboBox_funcionalidades_quitar.FormattingEnabled = true;
            this.comboBox_funcionalidades_quitar.ItemHeight = 13;
            this.comboBox_funcionalidades_quitar.Location = new System.Drawing.Point(61, 168);
            this.comboBox_funcionalidades_quitar.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_funcionalidades_quitar.MaxDropDownItems = 20;
            this.comboBox_funcionalidades_quitar.Name = "comboBox_funcionalidades_quitar";
            this.comboBox_funcionalidades_quitar.Size = new System.Drawing.Size(298, 21);
            this.comboBox_funcionalidades_quitar.TabIndex = 11;
            this.comboBox_funcionalidades_quitar.SelectedIndexChanged += new System.EventHandler(this.comboBox_funcionalidades_nuevo_SelectedIndexChanged);
            // 
            // lbl_funcionalidades
            // 
            this.lbl_funcionalidades.AutoSize = true;
            this.lbl_funcionalidades.Location = new System.Drawing.Point(58, 153);
            this.lbl_funcionalidades.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_funcionalidades.Name = "lbl_funcionalidades";
            this.lbl_funcionalidades.Size = new System.Drawing.Size(124, 13);
            this.lbl_funcionalidades.TabIndex = 10;
            this.lbl_funcionalidades.Text = "Funcionalidades a Quitar";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(58, 105);
            this.lbl_nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 9;
            this.lbl_nombre.Text = "Nombre";
            this.lbl_nombre.Click += new System.EventHandler(this.lbl_nombre_Click);
            // 
            // button_modificar_rol
            // 
            this.button_modificar_rol.Location = new System.Drawing.Point(322, 436);
            this.button_modificar_rol.Margin = new System.Windows.Forms.Padding(2);
            this.button_modificar_rol.Name = "button_modificar_rol";
            this.button_modificar_rol.Size = new System.Drawing.Size(81, 27);
            this.button_modificar_rol.TabIndex = 8;
            this.button_modificar_rol.Text = "Modificar";
            this.button_modificar_rol.UseVisualStyleBackColor = true;
            this.button_modificar_rol.Click += new System.EventHandler(this.button_crear_rol_Click);
            // 
            // button_aniadir_funcionalidad
            // 
            this.button_aniadir_funcionalidad.Location = new System.Drawing.Point(61, 203);
            this.button_aniadir_funcionalidad.Margin = new System.Windows.Forms.Padding(2);
            this.button_aniadir_funcionalidad.Name = "button_aniadir_funcionalidad";
            this.button_aniadir_funcionalidad.Size = new System.Drawing.Size(56, 19);
            this.button_aniadir_funcionalidad.TabIndex = 7;
            this.button_aniadir_funcionalidad.Text = "Quitar";
            this.button_aniadir_funcionalidad.UseVisualStyleBackColor = true;
            this.button_aniadir_funcionalidad.Click += new System.EventHandler(this.button_aniadir_funcionalidad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Codigo Rol";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Estado Rol";
            // 
            // label_codigo_viejo
            // 
            this.label_codigo_viejo.AutoSize = true;
            this.label_codigo_viejo.Location = new System.Drawing.Point(76, 38);
            this.label_codigo_viejo.Name = "label_codigo_viejo";
            this.label_codigo_viejo.Size = new System.Drawing.Size(13, 13);
            this.label_codigo_viejo.TabIndex = 17;
            this.label_codigo_viejo.Text = "2";
            this.label_codigo_viejo.Click += new System.EventHandler(this.label4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(143, 345);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(216, 69);
            this.listBox1.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Location = new System.Drawing.Point(61, 310);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.MaxDropDownItems = 20;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(298, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 295);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Funcionalidades a Agregar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 345);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 22);
            this.button1.TabIndex = 18;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_nombre_viejo
            // 
            this.label_nombre_viejo.AutoSize = true;
            this.label_nombre_viejo.Location = new System.Drawing.Point(182, 38);
            this.label_nombre_viejo.Name = "label_nombre_viejo";
            this.label_nombre_viejo.Size = new System.Drawing.Size(63, 13);
            this.label_nombre_viejo.TabIndex = 22;
            this.label_nombre_viejo.Text = "Nombre Rol";
            // 
            // label_estado_viejo
            // 
            this.label_estado_viejo.AutoSize = true;
            this.label_estado_viejo.Location = new System.Drawing.Point(336, 38);
            this.label_estado_viejo.Name = "label_estado_viejo";
            this.label_estado_viejo.Size = new System.Drawing.Size(13, 13);
            this.label_estado_viejo.TabIndex = 23;
            this.label_estado_viejo.Text = "1";
            // 
            // checkBox_habilitado
            // 
            this.checkBox_habilitado.AutoSize = true;
            this.checkBox_habilitado.Location = new System.Drawing.Point(298, 122);
            this.checkBox_habilitado.Name = "checkBox_habilitado";
            this.checkBox_habilitado.Size = new System.Drawing.Size(92, 17);
            this.checkBox_habilitado.TabIndex = 24;
            this.checkBox_habilitado.Text = "Rol Habilitado";
            this.checkBox_habilitado.UseVisualStyleBackColor = true;
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 474);
            this.Controls.Add(this.checkBox_habilitado);
            this.Controls.Add(this.label_estado_viejo);
            this.Controls.Add(this.label_nombre_viejo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_codigo_viejo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_nombre_nuevo);
            this.Controls.Add(this.listBox_funcionalidades_quitar);
            this.Controls.Add(this.comboBox_funcionalidades_quitar);
            this.Controls.Add(this.lbl_funcionalidades);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.button_modificar_rol);
            this.Controls.Add(this.button_aniadir_funcionalidad);
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nombre_nuevo;
        private System.Windows.Forms.ListBox listBox_funcionalidades_quitar;
        private System.Windows.Forms.ComboBox comboBox_funcionalidades_quitar;
        private System.Windows.Forms.Label lbl_funcionalidades;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Button button_modificar_rol;
        private System.Windows.Forms.Button button_aniadir_funcionalidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_codigo_viejo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_nombre_viejo;
        private System.Windows.Forms.Label label_estado_viejo;
        private System.Windows.Forms.CheckBox checkBox_habilitado;
    }
}