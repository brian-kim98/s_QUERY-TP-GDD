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
            this.button_crear_oferta = new System.Windows.Forms.Button();
            this.label_texto = new System.Windows.Forms.Label();
            this.button_carga_credito = new System.Windows.Forms.Button();
            this.button_comprar_oferta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_crear_oferta
            // 
            this.button_crear_oferta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button_crear_oferta.Enabled = false;
            this.button_crear_oferta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_crear_oferta.Location = new System.Drawing.Point(38, 65);
            this.button_crear_oferta.Name = "button_crear_oferta";
            this.button_crear_oferta.Size = new System.Drawing.Size(306, 35);
            this.button_crear_oferta.TabIndex = 0;
            this.button_crear_oferta.Text = "Crear Oferta";
            this.button_crear_oferta.UseVisualStyleBackColor = false;
            this.button_crear_oferta.Click += new System.EventHandler(this.button_crear_oferta_Click);
            // 
            // label_texto
            // 
            this.label_texto.AutoSize = true;
            this.label_texto.Font = new System.Drawing.Font("Russo One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_texto.Location = new System.Drawing.Point(128, 25);
            this.label_texto.Name = "label_texto";
            this.label_texto.Size = new System.Drawing.Size(153, 23);
            this.label_texto.TabIndex = 1;
            this.label_texto.Text = "Menu Principal";
            // 
            // button_carga_credito
            // 
            this.button_carga_credito.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button_carga_credito.Enabled = false;
            this.button_carga_credito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_carga_credito.Location = new System.Drawing.Point(38, 106);
            this.button_carga_credito.Name = "button_carga_credito";
            this.button_carga_credito.Size = new System.Drawing.Size(306, 35);
            this.button_carga_credito.TabIndex = 2;
            this.button_carga_credito.Text = "Cargar Credito";
            this.button_carga_credito.UseVisualStyleBackColor = false;
            // 
            // button_comprar_oferta
            // 
            this.button_comprar_oferta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button_comprar_oferta.Enabled = false;
            this.button_comprar_oferta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_comprar_oferta.Location = new System.Drawing.Point(38, 147);
            this.button_comprar_oferta.Name = "button_comprar_oferta";
            this.button_comprar_oferta.Size = new System.Drawing.Size(306, 35);
            this.button_comprar_oferta.TabIndex = 3;
            this.button_comprar_oferta.Text = "Crear Oferta";
            this.button_comprar_oferta.UseVisualStyleBackColor = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 371);
            this.Controls.Add(this.button_comprar_oferta);
            this.Controls.Add(this.button_carga_credito);
            this.Controls.Add(this.label_texto);
            this.Controls.Add(this.button_crear_oferta);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_crear_oferta;
        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Button button_carga_credito;
        private System.Windows.Forms.Button button_comprar_oferta;
    }
}