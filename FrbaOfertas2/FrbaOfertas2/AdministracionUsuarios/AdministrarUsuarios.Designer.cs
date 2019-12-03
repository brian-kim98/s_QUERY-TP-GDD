namespace FrbaOfertas2.AdministracionUsuarios
{
    partial class AdministrarUsuarios
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
            this.dataGridView_usuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_terminar = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_usuarios
            // 
            this.dataGridView_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_usuarios.Location = new System.Drawing.Point(9, 204);
            this.dataGridView_usuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_usuarios.Name = "dataGridView_usuarios";
            this.dataGridView_usuarios.RowTemplate.Height = 24;
            this.dataGridView_usuarios.Size = new System.Drawing.Size(410, 166);
            this.dataGridView_usuarios.TabIndex = 0;
            this.dataGridView_usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña Nueva";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "usuario_elegido";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 67);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button_terminar
            // 
            this.button_terminar.Location = new System.Drawing.Point(330, 387);
            this.button_terminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_terminar.Name = "button_terminar";
            this.button_terminar.Size = new System.Drawing.Size(89, 37);
            this.button_terminar.TabIndex = 5;
            this.button_terminar.Text = "Terminar";
            this.button_terminar.UseVisualStyleBackColor = true;
            this.button_terminar.Click += new System.EventHandler(this.button_terminar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(164, 106);
            this.button_modificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(89, 37);
            this.button_modificar.TabIndex = 6;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // AdministrarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 433);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_terminar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_usuarios);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdministrarUsuarios";
            this.Text = "AdministrarUsuarios";
            this.Load += new System.EventHandler(this.AdministrarUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_usuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_terminar;
        private System.Windows.Forms.Button button_modificar;
    }
}