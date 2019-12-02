namespace FrbaOfertas2.AdministracionUsuarios
{
    partial class ModificarContrasenia
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
            this.label_contraAnterior = new System.Windows.Forms.Label();
            this.label_nuevaContra = new System.Windows.Forms.Label();
            this.label_confirmeNuevaContra = new System.Windows.Forms.Label();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.textBox_viejaContra = new System.Windows.Forms.TextBox();
            this.textBox_nuevaContra = new System.Windows.Forms.TextBox();
            this.textBox_validacionNuevaContra = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_contraAnterior
            // 
            this.label_contraAnterior.AutoSize = true;
            this.label_contraAnterior.Location = new System.Drawing.Point(12, 67);
            this.label_contraAnterior.Name = "label_contraAnterior";
            this.label_contraAnterior.Size = new System.Drawing.Size(135, 17);
            this.label_contraAnterior.TabIndex = 0;
            this.label_contraAnterior.Text = "Contraseña Anterior";
            // 
            // label_nuevaContra
            // 
            this.label_nuevaContra.AutoSize = true;
            this.label_nuevaContra.Location = new System.Drawing.Point(12, 106);
            this.label_nuevaContra.Name = "label_nuevaContra";
            this.label_nuevaContra.Size = new System.Drawing.Size(126, 17);
            this.label_nuevaContra.TabIndex = 1;
            this.label_nuevaContra.Text = "Nueva Contraseña";
            // 
            // label_confirmeNuevaContra
            // 
            this.label_confirmeNuevaContra.AutoSize = true;
            this.label_confirmeNuevaContra.Location = new System.Drawing.Point(12, 148);
            this.label_confirmeNuevaContra.Name = "label_confirmeNuevaContra";
            this.label_confirmeNuevaContra.Size = new System.Drawing.Size(186, 17);
            this.label_confirmeNuevaContra.TabIndex = 2;
            this.label_confirmeNuevaContra.Text = "Confirme Nueva Contraseña";
            // 
            // button_confirmar
            // 
            this.button_confirmar.Location = new System.Drawing.Point(276, 202);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(126, 50);
            this.button_confirmar.TabIndex = 3;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = true;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // textBox_viejaContra
            // 
            this.textBox_viejaContra.Location = new System.Drawing.Point(220, 62);
            this.textBox_viejaContra.Name = "textBox_viejaContra";
            this.textBox_viejaContra.Size = new System.Drawing.Size(182, 22);
            this.textBox_viejaContra.TabIndex = 4;
            // 
            // textBox_nuevaContra
            // 
            this.textBox_nuevaContra.Location = new System.Drawing.Point(220, 106);
            this.textBox_nuevaContra.Name = "textBox_nuevaContra";
            this.textBox_nuevaContra.Size = new System.Drawing.Size(182, 22);
            this.textBox_nuevaContra.TabIndex = 5;
            // 
            // textBox_validacionNuevaContra
            // 
            this.textBox_validacionNuevaContra.Location = new System.Drawing.Point(220, 148);
            this.textBox_validacionNuevaContra.Name = "textBox_validacionNuevaContra";
            this.textBox_validacionNuevaContra.Size = new System.Drawing.Size(182, 22);
            this.textBox_validacionNuevaContra.TabIndex = 6;
            // 
            // ModificarContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 270);
            this.Controls.Add(this.textBox_validacionNuevaContra);
            this.Controls.Add(this.textBox_nuevaContra);
            this.Controls.Add(this.textBox_viejaContra);
            this.Controls.Add(this.button_confirmar);
            this.Controls.Add(this.label_confirmeNuevaContra);
            this.Controls.Add(this.label_nuevaContra);
            this.Controls.Add(this.label_contraAnterior);
            this.Name = "ModificarContrasenia";
            this.Text = "ModificarContrasenia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_contraAnterior;
        private System.Windows.Forms.Label label_nuevaContra;
        private System.Windows.Forms.Label label_confirmeNuevaContra;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.TextBox textBox_viejaContra;
        private System.Windows.Forms.TextBox textBox_nuevaContra;
        private System.Windows.Forms.TextBox textBox_validacionNuevaContra;
    }
}