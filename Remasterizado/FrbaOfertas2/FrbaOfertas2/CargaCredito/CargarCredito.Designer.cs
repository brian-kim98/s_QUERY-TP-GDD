namespace FrbaOfertas2.CargaCredito
{
    partial class CargarCredito
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
            this.label_codigoCliente = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_codigoSeguridadTarjeta = new System.Windows.Forms.TextBox();
            this.textBox_numeroTarjeta = new System.Windows.Forms.TextBox();
            this.dateTimePicker_fechaVencimientoTarjeta = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_monto = new System.Windows.Forms.TextBox();
            this.button_terminar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.comboBox_tipoDePago = new System.Windows.Forms.ComboBox();
            this.label_fechaAUsar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label_codigoCliente
            // 
            this.label_codigoCliente.AutoSize = true;
            this.label_codigoCliente.Location = new System.Drawing.Point(125, 3);
            this.label_codigoCliente.Name = "label_codigoCliente";
            this.label_codigoCliente.Size = new System.Drawing.Size(126, 17);
            this.label_codigoCliente.TabIndex = 38;
            this.label_codigoCliente.Text = "(Acá iría el codigo)";
            this.label_codigoCliente.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 17);
            this.label11.TabIndex = 37;
            this.label11.Text = "Código Cliente";
            // 
            // textBox_codigoSeguridadTarjeta
            // 
            this.textBox_codigoSeguridadTarjeta.Location = new System.Drawing.Point(181, 333);
            this.textBox_codigoSeguridadTarjeta.Name = "textBox_codigoSeguridadTarjeta";
            this.textBox_codigoSeguridadTarjeta.Size = new System.Drawing.Size(290, 22);
            this.textBox_codigoSeguridadTarjeta.TabIndex = 36;
            // 
            // textBox_numeroTarjeta
            // 
            this.textBox_numeroTarjeta.Location = new System.Drawing.Point(181, 256);
            this.textBox_numeroTarjeta.Name = "textBox_numeroTarjeta";
            this.textBox_numeroTarjeta.Size = new System.Drawing.Size(290, 22);
            this.textBox_numeroTarjeta.TabIndex = 35;
            // 
            // dateTimePicker_fechaVencimientoTarjeta
            // 
            this.dateTimePicker_fechaVencimientoTarjeta.CustomFormat = "yyyy-MM-dd HH-mm-ss";
            this.dateTimePicker_fechaVencimientoTarjeta.Location = new System.Drawing.Point(181, 291);
            this.dateTimePicker_fechaVencimientoTarjeta.Name = "dateTimePicker_fechaVencimientoTarjeta";
            this.dateTimePicker_fechaVencimientoTarjeta.Size = new System.Drawing.Size(290, 22);
            this.dateTimePicker_fechaVencimientoTarjeta.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Codigo Seguridad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Fecha Vencimiento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "Numero ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Location = new System.Drawing.Point(42, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Datos de la Tarjeta";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(19, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(500, 2);
            this.label6.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "(Tipo de dato: Entero positivo)";
            // 
            // textBox_monto
            // 
            this.textBox_monto.Location = new System.Drawing.Point(128, 133);
            this.textBox_monto.Name = "textBox_monto";
            this.textBox_monto.Size = new System.Drawing.Size(185, 22);
            this.textBox_monto.TabIndex = 27;
            // 
            // button_terminar
            // 
            this.button_terminar.Location = new System.Drawing.Point(459, 468);
            this.button_terminar.Name = "button_terminar";
            this.button_terminar.Size = new System.Drawing.Size(111, 23);
            this.button_terminar.TabIndex = 26;
            this.button_terminar.Text = "TERMINAR";
            this.button_terminar.UseVisualStyleBackColor = true;
            this.button_terminar.Click += new System.EventHandler(this.button_terminar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(7, 468);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(105, 23);
            this.button_limpiar.TabIndex = 25;
            this.button_limpiar.Text = "LIMPIAR";
            this.button_limpiar.UseVisualStyleBackColor = true;
            // 
            // comboBox_tipoDePago
            // 
            this.comboBox_tipoDePago.FormattingEnabled = true;
            this.comboBox_tipoDePago.Location = new System.Drawing.Point(128, 85);
            this.comboBox_tipoDePago.Name = "comboBox_tipoDePago";
            this.comboBox_tipoDePago.Size = new System.Drawing.Size(268, 24);
            this.comboBox_tipoDePago.TabIndex = 24;
            // 
            // label_fechaAUsar
            // 
            this.label_fechaAUsar.AutoSize = true;
            this.label_fechaAUsar.Location = new System.Drawing.Point(125, 54);
            this.label_fechaAUsar.Name = "label_fechaAUsar";
            this.label_fechaAUsar.Size = new System.Drawing.Size(275, 17);
            this.label_fechaAUsar.TabIndex = 23;
            this.label_fechaAUsar.Text = "Aca mostraría la fecha (decorativo nomas)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tipo de Pago";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(7, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(500, 2);
            this.label13.TabIndex = 39;
            // 
            // CargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 494);
            this.Controls.Add(this.label_codigoCliente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_codigoSeguridadTarjeta);
            this.Controls.Add(this.textBox_numeroTarjeta);
            this.Controls.Add(this.dateTimePicker_fechaVencimientoTarjeta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_monto);
            this.Controls.Add(this.button_terminar);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.comboBox_tipoDePago);
            this.Controls.Add(this.label_fechaAUsar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Name = "CargarCredito";
            this.Text = "CargaCredito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_codigoCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_codigoSeguridadTarjeta;
        private System.Windows.Forms.TextBox textBox_numeroTarjeta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaVencimientoTarjeta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_monto;
        private System.Windows.Forms.Button button_terminar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.ComboBox comboBox_tipoDePago;
        private System.Windows.Forms.Label label_fechaAUsar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}