namespace FrbaOfertas2.MenuPrincipal
{
    partial class MenuInicio
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
            this.label_texto = new System.Windows.Forms.Label();
            this.button_crear_oferta = new System.Windows.Forms.Button();
            this.button_carga_credito = new System.Windows.Forms.Button();
            this.button_comprar_oferta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_roles = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_texto
            // 
            this.label_texto.AutoSize = true;
            this.label_texto.Font = new System.Drawing.Font("Russo One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_texto.Location = new System.Drawing.Point(114, 21);
            this.label_texto.Name = "label_texto";
            this.label_texto.Size = new System.Drawing.Size(153, 23);
            this.label_texto.TabIndex = 1;
            this.label_texto.Text = "Menu Principal";
            // 
            // button_crear_oferta
            // 
            this.button_crear_oferta.BackColor = System.Drawing.SystemColors.Control;
            this.button_crear_oferta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_crear_oferta.Location = new System.Drawing.Point(15, 19);
            this.button_crear_oferta.Name = "button_crear_oferta";
            this.button_crear_oferta.Size = new System.Drawing.Size(306, 35);
            this.button_crear_oferta.TabIndex = 0;
            this.button_crear_oferta.Text = "Crear Oferta";
            this.button_crear_oferta.UseVisualStyleBackColor = false;
            this.button_crear_oferta.VisibleChanged += new System.EventHandler(this.button_crear_oferta_Click);
            this.button_crear_oferta.Click += new System.EventHandler(this.button_crear_oferta_Click);
            // 
            // button_carga_credito
            // 
            this.button_carga_credito.BackColor = System.Drawing.SystemColors.Control;
            this.button_carga_credito.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_carga_credito.Location = new System.Drawing.Point(15, 59);
            this.button_carga_credito.Name = "button_carga_credito";
            this.button_carga_credito.Size = new System.Drawing.Size(306, 35);
            this.button_carga_credito.TabIndex = 2;
            this.button_carga_credito.Text = "Cargar Credito";
            this.button_carga_credito.UseVisualStyleBackColor = false;
            this.button_carga_credito.Click += new System.EventHandler(this.button_carga_credito_Click);
            // 
            // button_comprar_oferta
            // 
            this.button_comprar_oferta.BackColor = System.Drawing.SystemColors.Control;
            this.button_comprar_oferta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_comprar_oferta.Location = new System.Drawing.Point(15, 100);
            this.button_comprar_oferta.Name = "button_comprar_oferta";
            this.button_comprar_oferta.Size = new System.Drawing.Size(306, 35);
            this.button_comprar_oferta.TabIndex = 3;
            this.button_comprar_oferta.Text = "Comprar Oferta";
            this.button_comprar_oferta.UseVisualStyleBackColor = false;
            this.button_comprar_oferta.Click += new System.EventHandler(this.button_comprar_oferta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_roles);
            this.groupBox1.Controls.Add(this.button_comprar_oferta);
            this.groupBox1.Controls.Add(this.button_carga_credito);
            this.groupBox1.Controls.Add(this.button_crear_oferta);
            this.groupBox1.Location = new System.Drawing.Point(23, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 320);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades disponibles";
            // 
            // button_roles
            // 
            this.button_roles.BackColor = System.Drawing.SystemColors.Control;
            this.button_roles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_roles.Location = new System.Drawing.Point(15, 141);
            this.button_roles.Name = "button_roles";
            this.button_roles.Size = new System.Drawing.Size(306, 35);
            this.button_roles.TabIndex = 4;
            this.button_roles.Text = "Roles";
            this.button_roles.UseVisualStyleBackColor = false;
            this.button_roles.Click += new System.EventHandler(this.button_roles_Click);
            // 
            // MenuInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_texto);
            this.Name = "MenuInicio";
            this.Text = "MenuPrincipal";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Button button_crear_oferta;
        private System.Windows.Forms.Button button_carga_credito;
        private System.Windows.Forms.Button button_comprar_oferta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_roles;
    }
}