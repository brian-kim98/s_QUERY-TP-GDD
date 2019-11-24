namespace FrbaOfertas2.Facturar
{
    partial class FacturacionAProveedor
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
            this.dateTimePicker_fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_proveedores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_generar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker_fechaInicio
            // 
            this.dateTimePicker_fechaInicio.CustomFormat = "yyyy-MM-dd HH-mm-ss";
            this.dateTimePicker_fechaInicio.Location = new System.Drawing.Point(248, 60);
            this.dateTimePicker_fechaInicio.Name = "dateTimePicker_fechaInicio";
            this.dateTimePicker_fechaInicio.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_fechaInicio.TabIndex = 0;
            // 
            // dateTimePicker_fechaFin
            // 
            this.dateTimePicker_fechaFin.CustomFormat = "yyyy-MM-dd HH-mm-ss";
            this.dateTimePicker_fechaFin.Location = new System.Drawing.Point(248, 104);
            this.dateTimePicker_fechaFin.Name = "dateTimePicker_fechaFin";
            this.dateTimePicker_fechaFin.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_fechaFin.TabIndex = 1;
            this.dateTimePicker_fechaFin.ValueChanged += new System.EventHandler(this.dateTimePicker_fechaFin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Periodo Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Periodo Fin";
            // 
            // comboBox_proveedores
            // 
            this.comboBox_proveedores.FormattingEnabled = true;
            this.comboBox_proveedores.Location = new System.Drawing.Point(248, 155);
            this.comboBox_proveedores.Name = "comboBox_proveedores";
            this.comboBox_proveedores.Size = new System.Drawing.Size(200, 24);
            this.comboBox_proveedores.TabIndex = 4;
            this.comboBox_proveedores.SelectedIndexChanged += new System.EventHandler(this.comboBox_proveedores_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Proveedor a Facturar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "LIMPIAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_generar
            // 
            this.button_generar.Location = new System.Drawing.Point(424, 249);
            this.button_generar.Name = "button_generar";
            this.button_generar.Size = new System.Drawing.Size(92, 23);
            this.button_generar.TabIndex = 7;
            this.button_generar.Text = "GENERAR";
            this.button_generar.UseVisualStyleBackColor = true;
            this.button_generar.Click += new System.EventHandler(this.button_generar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "VOLVER";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FacturacionAProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 284);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_generar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_proveedores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_fechaFin);
            this.Controls.Add(this.dateTimePicker_fechaInicio);
            this.Name = "FacturacionAProveedor";
            this.Text = "FacturacionAProveedor";
            this.Load += new System.EventHandler(this.FacturacionAProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_proveedores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_generar;
        private System.Windows.Forms.Button button3;
    }
}