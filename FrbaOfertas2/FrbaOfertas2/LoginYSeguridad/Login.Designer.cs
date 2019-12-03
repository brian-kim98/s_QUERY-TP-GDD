namespace FrbaOfertas2.LoginYSeguridad
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_intentos = new System.Windows.Forms.Label();
            this.button_ingresar = new System.Windows.Forms.Button();
            this.button_registrarse = new System.Windows.Forms.Button();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_contrasenia = new System.Windows.Forms.TextBox();
            this.label_alerta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label_intentos
            // 
            this.label_intentos.AutoSize = true;
            this.label_intentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_intentos.ForeColor = System.Drawing.Color.Black;
            this.label_intentos.Location = new System.Drawing.Point(44, 152);
            this.label_intentos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_intentos.Name = "label_intentos";
            this.label_intentos.Size = new System.Drawing.Size(201, 13);
            this.label_intentos.TabIndex = 2;
            this.label_intentos.Text = "Cantidad de Intentos Fallidos Realizados:";
            this.label_intentos.Visible = false;
            this.label_intentos.Click += new System.EventHandler(this.label3_Click);
            // 
            // button_ingresar
            // 
            this.button_ingresar.Location = new System.Drawing.Point(213, 213);
            this.button_ingresar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_ingresar.Name = "button_ingresar";
            this.button_ingresar.Size = new System.Drawing.Size(66, 26);
            this.button_ingresar.TabIndex = 3;
            this.button_ingresar.Text = "Ingresar";
            this.button_ingresar.UseVisualStyleBackColor = true;
            this.button_ingresar.Click += new System.EventHandler(this.button_ingresar_Click);
            // 
            // button_registrarse
            // 
            this.button_registrarse.Location = new System.Drawing.Point(11, 213);
            this.button_registrarse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_registrarse.Name = "button_registrarse";
            this.button_registrarse.Size = new System.Drawing.Size(85, 26);
            this.button_registrarse.TabIndex = 4;
            this.button_registrarse.Text = "Registrarse";
            this.button_registrarse.UseVisualStyleBackColor = true;
            this.button_registrarse.Click += new System.EventHandler(this.button_registrarse_Click);
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(89, 44);
            this.textBox_usuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(171, 20);
            this.textBox_usuario.TabIndex = 5;
            this.textBox_usuario.TextChanged += new System.EventHandler(this.textBox_usuario_TextChanged);
            // 
            // textBox_contrasenia
            // 
            this.textBox_contrasenia.Location = new System.Drawing.Point(89, 110);
            this.textBox_contrasenia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_contrasenia.Name = "textBox_contrasenia";
            this.textBox_contrasenia.PasswordChar = '*';
            this.textBox_contrasenia.Size = new System.Drawing.Size(171, 20);
            this.textBox_contrasenia.TabIndex = 6;
            this.textBox_contrasenia.TextChanged += new System.EventHandler(this.textBox_contrasenia_TextChanged);
            // 
            // label_alerta
            // 
            this.label_alerta.AutoSize = true;
            this.label_alerta.Location = new System.Drawing.Point(44, 176);
            this.label_alerta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_alerta.Name = "label_alerta";
            this.label_alerta.Size = new System.Drawing.Size(61, 13);
            this.label_alerta.TabIndex = 7;
            this.label_alerta.Text = "label_alerta";
            this.label_alerta.Visible = false;
            this.label_alerta.Click += new System.EventHandler(this.label_alerta_Click_1);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 250);
            this.Controls.Add(this.label_alerta);
            this.Controls.Add(this.textBox_contrasenia);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.button_registrarse);
            this.Controls.Add(this.button_ingresar);
            this.Controls.Add(this.label_intentos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.Text = "LoginYSeguridad";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_intentos;
        private System.Windows.Forms.Button button_ingresar;
        private System.Windows.Forms.Button button_registrarse;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_contrasenia;
        private System.Windows.Forms.Label label_alerta;
    }
}