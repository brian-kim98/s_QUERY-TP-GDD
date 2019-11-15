namespace FrbaOfertas2.MenuPrincipal
{
    partial class MenuProveedor
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
            this.label_bienvenido = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_crear_oferta
            // 
            this.button_crear_oferta.Location = new System.Drawing.Point(74, 56);
            this.button_crear_oferta.Margin = new System.Windows.Forms.Padding(2);
            this.button_crear_oferta.Name = "button_crear_oferta";
            this.button_crear_oferta.Size = new System.Drawing.Size(183, 44);
            this.button_crear_oferta.TabIndex = 0;
            this.button_crear_oferta.Text = "Crear Oferta";
            this.button_crear_oferta.UseVisualStyleBackColor = true;
            this.button_crear_oferta.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_bienvenido
            // 
            this.label_bienvenido.AutoSize = true;
            this.label_bienvenido.Font = new System.Drawing.Font("Orator Std", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bienvenido.Location = new System.Drawing.Point(55, 9);
            this.label_bienvenido.Name = "label_bienvenido";
            this.label_bienvenido.Size = new System.Drawing.Size(230, 21);
            this.label_bienvenido.TabIndex = 1;
            this.label_bienvenido.Text = "¡Bienvenido Proveedor!";
            this.label_bienvenido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MenuProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 325);
            this.Controls.Add(this.label_bienvenido);
            this.Controls.Add(this.button_crear_oferta);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuProveedor";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_crear_oferta;
        private System.Windows.Forms.Label label_bienvenido;
    }
}