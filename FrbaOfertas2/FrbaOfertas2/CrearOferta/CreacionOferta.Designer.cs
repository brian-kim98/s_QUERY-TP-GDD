namespace FrbaOfertas2.CrearOferta
{
    partial class CreacionOferta
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
            this.button_crear = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.textBox_cantidad = new System.Windows.Forms.TextBox();
            this.textBox_precio_lista = new System.Windows.Forms.TextBox();
            this.textBox_precio_oferta = new System.Windows.Forms.TextBox();
            this.dateTimePicker_fecha_vencimiento = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fecha_publicacion = new System.Windows.Forms.DateTimePicker();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_maximo_compra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_codigoProveedor = new System.Windows.Forms.Label();
            this.textBox_codigoProveedor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_crear
            // 
            this.button_crear.Location = new System.Drawing.Point(477, 380);
            this.button_crear.Margin = new System.Windows.Forms.Padding(4);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(119, 37);
            this.button_crear.TabIndex = 35;
            this.button_crear.Text = "Crear";
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.button_crear_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(65, 380);
            this.button_limpiar.Margin = new System.Windows.Forms.Padding(4);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(108, 46);
            this.button_limpiar.TabIndex = 34;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // textBox_cantidad
            // 
            this.textBox_cantidad.Location = new System.Drawing.Point(193, 262);
            this.textBox_cantidad.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_cantidad.Name = "textBox_cantidad";
            this.textBox_cantidad.Size = new System.Drawing.Size(99, 22);
            this.textBox_cantidad.TabIndex = 32;
            // 
            // textBox_precio_lista
            // 
            this.textBox_precio_lista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_precio_lista.Location = new System.Drawing.Point(425, 201);
            this.textBox_precio_lista.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_precio_lista.Name = "textBox_precio_lista";
            this.textBox_precio_lista.Size = new System.Drawing.Size(121, 22);
            this.textBox_precio_lista.TabIndex = 30;
            // 
            // textBox_precio_oferta
            // 
            this.textBox_precio_oferta.Location = new System.Drawing.Point(171, 201);
            this.textBox_precio_oferta.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_precio_oferta.Name = "textBox_precio_oferta";
            this.textBox_precio_oferta.Size = new System.Drawing.Size(121, 22);
            this.textBox_precio_oferta.TabIndex = 29;
            // 
            // dateTimePicker_fecha_vencimiento
            // 
            this.dateTimePicker_fecha_vencimiento.Location = new System.Drawing.Point(211, 139);
            this.dateTimePicker_fecha_vencimiento.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_fecha_vencimiento.Name = "dateTimePicker_fecha_vencimiento";
            this.dateTimePicker_fecha_vencimiento.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker_fecha_vencimiento.TabIndex = 28;
            this.dateTimePicker_fecha_vencimiento.ValueChanged += new System.EventHandler(this.dateTimePicker_fecha_vencimiento_ValueChanged);
            // 
            // dateTimePicker_fecha_publicacion
            // 
            this.dateTimePicker_fecha_publicacion.Location = new System.Drawing.Point(211, 82);
            this.dateTimePicker_fecha_publicacion.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_fecha_publicacion.Name = "dateTimePicker_fecha_publicacion";
            this.dateTimePicker_fecha_publicacion.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker_fecha_publicacion.TabIndex = 27;
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(144, 32);
            this.textBox_descripcion.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(403, 22);
            this.textBox_descripcion.TabIndex = 26;
            this.textBox_descripcion.TextChanged += new System.EventHandler(this.textBox_descripcion_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 266);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Cantidad disponible";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Precio de lista";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Precio de oferta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fecha de vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha de publicación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Descripción";
            // 
            // textBox_maximo_compra
            // 
            this.textBox_maximo_compra.Location = new System.Drawing.Point(441, 257);
            this.textBox_maximo_compra.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_maximo_compra.Name = "textBox_maximo_compra";
            this.textBox_maximo_compra.Size = new System.Drawing.Size(106, 22);
            this.textBox_maximo_compra.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 261);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Maximo Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_codigoProveedor);
            this.groupBox1.Controls.Add(this.label_codigoProveedor);
            this.groupBox1.Controls.Add(this.textBox_maximo_compra);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_cantidad);
            this.groupBox1.Controls.Add(this.textBox_precio_lista);
            this.groupBox1.Controls.Add(this.textBox_precio_oferta);
            this.groupBox1.Controls.Add(this.dateTimePicker_fecha_vencimiento);
            this.groupBox1.Controls.Add(this.dateTimePicker_fecha_publicacion);
            this.groupBox1.Controls.Add(this.textBox_descripcion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(36, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(587, 343);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Creacion Ofertas";
            // 
            // label_codigoProveedor
            // 
            this.label_codigoProveedor.AutoSize = true;
            this.label_codigoProveedor.Location = new System.Drawing.Point(56, 302);
            this.label_codigoProveedor.Name = "label_codigoProveedor";
            this.label_codigoProveedor.Size = new System.Drawing.Size(122, 17);
            this.label_codigoProveedor.TabIndex = 38;
            this.label_codigoProveedor.Text = "Codigo Proveedor";
            this.label_codigoProveedor.Visible = false;
            // 
            // textBox_codigoProveedor
            // 
            this.textBox_codigoProveedor.Location = new System.Drawing.Point(193, 302);
            this.textBox_codigoProveedor.Name = "textBox_codigoProveedor";
            this.textBox_codigoProveedor.Size = new System.Drawing.Size(99, 22);
            this.textBox_codigoProveedor.TabIndex = 39;
            this.textBox_codigoProveedor.Visible = false;
            // 
            // CreacionOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_crear);
            this.Controls.Add(this.button_limpiar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreacionOferta";
            this.Text = "CrearOferta";
            this.Load += new System.EventHandler(this.CrearOferta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.TextBox textBox_cantidad;
        private System.Windows.Forms.TextBox textBox_precio_lista;
        private System.Windows.Forms.TextBox textBox_precio_oferta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha_vencimiento;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fecha_publicacion;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_maximo_compra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_codigoProveedor;
        private System.Windows.Forms.Label label_codigoProveedor;
    }
}