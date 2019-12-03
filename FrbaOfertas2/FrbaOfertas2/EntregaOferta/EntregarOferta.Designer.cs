namespace FrbaOfertas2.EntregaOferta
{
    partial class EntregarOferta
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
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_finalizar = new System.Windows.Forms.Button();
            this.dateTimePicker_fechaConsumo = new System.Windows.Forms.DateTimePicker();
            this.textBox_codigoCupon = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Consumo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código de Cupon";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(11, 230);
            this.button_limpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(69, 29);
            this.button_limpiar.TabIndex = 3;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_finalizar
            // 
            this.button_finalizar.Location = new System.Drawing.Point(259, 230);
            this.button_finalizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_finalizar.Name = "button_finalizar";
            this.button_finalizar.Size = new System.Drawing.Size(72, 29);
            this.button_finalizar.TabIndex = 4;
            this.button_finalizar.Text = "Finalizar";
            this.button_finalizar.UseVisualStyleBackColor = true;
            this.button_finalizar.Click += new System.EventHandler(this.button_finalizar_Click);
            // 
            // dateTimePicker_fechaConsumo
            // 
            this.dateTimePicker_fechaConsumo.CustomFormat = "yyyy-MM-dd HH-mm-ss";
            this.dateTimePicker_fechaConsumo.Location = new System.Drawing.Point(148, 31);
            this.dateTimePicker_fechaConsumo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_fechaConsumo.Name = "dateTimePicker_fechaConsumo";
            this.dateTimePicker_fechaConsumo.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker_fechaConsumo.TabIndex = 5;
            // 
            // textBox_codigoCupon
            // 
            this.textBox_codigoCupon.Location = new System.Drawing.Point(148, 66);
            this.textBox_codigoCupon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_codigoCupon.Name = "textBox_codigoCupon";
            this.textBox_codigoCupon.Size = new System.Drawing.Size(151, 20);
            this.textBox_codigoCupon.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_codigoCupon);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaConsumo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 148);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrega Oferta";
            // 
            // EntregarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 270);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_finalizar);
            this.Controls.Add(this.button_limpiar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EntregarOferta";
            this.Text = "EntregarOferta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_finalizar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaConsumo;
        private System.Windows.Forms.TextBox textBox_codigoCupon;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}