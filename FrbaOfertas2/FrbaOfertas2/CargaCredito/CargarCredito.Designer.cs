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
            this.label_codigo_cliente = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_cod_seguridad = new System.Windows.Forms.TextBox();
            this.textBox_numero_tarjeta = new System.Windows.Forms.TextBox();
            this.dateTimePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_monto = new System.Windows.Forms.TextBox();
            this.button_cargar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.comboBox_tipo_pago = new System.Windows.Forms.ComboBox();
            this.label_fecha_hoy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_codigo_cliente
            // 
            this.label_codigo_cliente.AutoSize = true;
            this.label_codigo_cliente.Location = new System.Drawing.Point(96, 31);
            this.label_codigo_cliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_codigo_cliente.Name = "label_codigo_cliente";
            this.label_codigo_cliente.Size = new System.Drawing.Size(96, 13);
            this.label_codigo_cliente.TabIndex = 38;
            this.label_codigo_cliente.Text = "(Acá iría el codigo)";
            this.label_codigo_cliente.Click += new System.EventHandler(this.label_codigo_cliente_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 31);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Código Cliente";
            // 
            // textBox_cod_seguridad
            // 
            this.textBox_cod_seguridad.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_cod_seguridad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_cod_seguridad.Enabled = false;
            this.textBox_cod_seguridad.Location = new System.Drawing.Point(138, 299);
            this.textBox_cod_seguridad.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_cod_seguridad.Name = "textBox_cod_seguridad";
            this.textBox_cod_seguridad.Size = new System.Drawing.Size(218, 20);
            this.textBox_cod_seguridad.TabIndex = 36;
            // 
            // textBox_numero_tarjeta
            // 
            this.textBox_numero_tarjeta.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_numero_tarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_numero_tarjeta.Enabled = false;
            this.textBox_numero_tarjeta.Location = new System.Drawing.Point(138, 237);
            this.textBox_numero_tarjeta.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_numero_tarjeta.Name = "textBox_numero_tarjeta";
            this.textBox_numero_tarjeta.Size = new System.Drawing.Size(218, 20);
            this.textBox_numero_tarjeta.TabIndex = 35;
            // 
            // dateTimePicker_fecha
            // 
            this.dateTimePicker_fecha.Enabled = false;
            this.dateTimePicker_fecha.Location = new System.Drawing.Point(138, 265);
            this.dateTimePicker_fecha.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_fecha.Name = "dateTimePicker_fecha";
            this.dateTimePicker_fecha.Size = new System.Drawing.Size(218, 20);
            this.dateTimePicker_fecha.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 299);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Codigo Seguridad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 269);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Fecha Vencimiento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 237);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Numero ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Location = new System.Drawing.Point(33, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Datos de la Tarjeta";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(16, 214);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(375, 2);
            this.label6.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "(Tipo de dato: Entero positivo)";
            // 
            // textBox_monto
            // 
            this.textBox_monto.Location = new System.Drawing.Point(98, 137);
            this.textBox_monto.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_monto.Name = "textBox_monto";
            this.textBox_monto.Size = new System.Drawing.Size(140, 20);
            this.textBox_monto.TabIndex = 27;
            // 
            // button_cargar
            // 
            this.button_cargar.Location = new System.Drawing.Point(322, 397);
            this.button_cargar.Margin = new System.Windows.Forms.Padding(2);
            this.button_cargar.Name = "button_cargar";
            this.button_cargar.Size = new System.Drawing.Size(89, 42);
            this.button_cargar.TabIndex = 26;
            this.button_cargar.Text = "Cargar";
            this.button_cargar.UseVisualStyleBackColor = true;
            this.button_cargar.Click += new System.EventHandler(this.button_cargar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(16, 397);
            this.button_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(80, 42);
            this.button_limpiar.TabIndex = 25;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // comboBox_tipo_pago
            // 
            this.comboBox_tipo_pago.FormattingEnabled = true;
            this.comboBox_tipo_pago.Location = new System.Drawing.Point(98, 98);
            this.comboBox_tipo_pago.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_tipo_pago.Name = "comboBox_tipo_pago";
            this.comboBox_tipo_pago.Size = new System.Drawing.Size(202, 21);
            this.comboBox_tipo_pago.TabIndex = 24;
            this.comboBox_tipo_pago.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipo_pago_SelectedIndexChanged);
            // 
            // label_fecha_hoy
            // 
            this.label_fecha_hoy.AutoSize = true;
            this.label_fecha_hoy.Location = new System.Drawing.Point(96, 73);
            this.label_fecha_hoy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fecha_hoy.Name = "label_fecha_hoy";
            this.label_fecha_hoy.Size = new System.Drawing.Size(207, 13);
            this.label_fecha_hoy.TabIndex = 23;
            this.label_fecha_hoy.Text = "Aca mostraría la fecha (decorativo nomas)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tipo de Pago";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(7, 45);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(375, 2);
            this.label13.TabIndex = 39;
            // 
            // CargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 458);
            this.Controls.Add(this.label_codigo_cliente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_cod_seguridad);
            this.Controls.Add(this.textBox_numero_tarjeta);
            this.Controls.Add(this.dateTimePicker_fecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_monto);
            this.Controls.Add(this.button_cargar);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.comboBox_tipo_pago);
            this.Controls.Add(this.label_fecha_hoy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Name = "CargarCredito";
            this.Text = "CargarCredito";
            this.Load += new System.EventHandler(this.CargarCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_codigo_cliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_cod_seguridad;
        private System.Windows.Forms.TextBox textBox_numero_tarjeta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_monto;
        private System.Windows.Forms.Button button_cargar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.ComboBox comboBox_tipo_pago;
        private System.Windows.Forms.Label label_fecha_hoy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;

    }
}