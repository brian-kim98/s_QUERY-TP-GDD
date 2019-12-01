namespace FrbaOfertas2.ComprarOferta
{
    partial class CompraOferta
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_compratOfera = new System.Windows.Forms.GroupBox();
            this.label_precioTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.textBox_nroOferta = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_oferta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_cantidad = new System.Windows.Forms.NumericUpDown();
            this.groupBox_compratOfera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 117);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Número de oferta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha de compra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Oferta";
            // 
            // groupBox_compratOfera
            // 
            this.groupBox_compratOfera.Controls.Add(this.label_precioTotal);
            this.groupBox_compratOfera.Controls.Add(this.label6);
            this.groupBox_compratOfera.Controls.Add(this.textBox_cliente);
            this.groupBox_compratOfera.Controls.Add(this.textBox_nroOferta);
            this.groupBox_compratOfera.Controls.Add(this.button3);
            this.groupBox_compratOfera.Controls.Add(this.textBox_oferta);
            this.groupBox_compratOfera.Controls.Add(this.label1);
            this.groupBox_compratOfera.Controls.Add(this.numericUpDown_cantidad);
            this.groupBox_compratOfera.Controls.Add(this.dateTimePicker1);
            this.groupBox_compratOfera.Controls.Add(this.label5);
            this.groupBox_compratOfera.Controls.Add(this.label4);
            this.groupBox_compratOfera.Controls.Add(this.label3);
            this.groupBox_compratOfera.Controls.Add(this.label2);
            this.groupBox_compratOfera.Location = new System.Drawing.Point(21, 30);
            this.groupBox_compratOfera.Name = "groupBox_compratOfera";
            this.groupBox_compratOfera.Size = new System.Drawing.Size(360, 334);
            this.groupBox_compratOfera.TabIndex = 15;
            this.groupBox_compratOfera.TabStop = false;
            this.groupBox_compratOfera.Text = "Comprar Oferta";
            // 
            // label_precioTotal
            // 
            this.label_precioTotal.AutoSize = true;
            this.label_precioTotal.Location = new System.Drawing.Point(128, 285);
            this.label_precioTotal.Name = "label_precioTotal";
            this.label_precioTotal.Size = new System.Drawing.Size(25, 13);
            this.label_precioTotal.TabIndex = 23;
            this.label_precioTotal.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Precio";
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_cliente.Enabled = false;
            this.textBox_cliente.Location = new System.Drawing.Point(131, 202);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(200, 20);
            this.textBox_cliente.TabIndex = 21;
            // 
            // textBox_nroOferta
            // 
            this.textBox_nroOferta.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_nroOferta.Enabled = false;
            this.textBox_nroOferta.Location = new System.Drawing.Point(131, 164);
            this.textBox_nroOferta.Name = "textBox_nroOferta";
            this.textBox_nroOferta.Size = new System.Drawing.Size(200, 20);
            this.textBox_nroOferta.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(245, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Seleccionar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_oferta
            // 
            this.textBox_oferta.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_oferta.Enabled = false;
            this.textBox_oferta.Location = new System.Drawing.Point(131, 46);
            this.textBox_oferta.Name = "textBox_oferta";
            this.textBox_oferta.Size = new System.Drawing.Size(200, 20);
            this.textBox_oferta.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cantidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numericUpDown_cantidad
            // 
            this.numericUpDown_cantidad.Location = new System.Drawing.Point(131, 244);
            this.numericUpDown_cantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_cantidad.Name = "numericUpDown_cantidad";
            this.numericUpDown_cantidad.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_cantidad.TabIndex = 16;
            this.numericUpDown_cantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_cantidad.ValueChanged += new System.EventHandler(this.numericUpDown_cantidad_ValueChanged);
            // 
            // CompraOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 432);
            this.Controls.Add(this.groupBox_compratOfera);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CompraOferta";
            this.Text = "CompraOferta";
            this.Load += new System.EventHandler(this.CompraOferta_Load);
            this.groupBox_compratOfera.ResumeLayout(false);
            this.groupBox_compratOfera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_compratOfera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_cantidad;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.TextBox textBox_nroOferta;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_oferta;
        private System.Windows.Forms.Label label_precioTotal;
        private System.Windows.Forms.Label label6;
    }
}