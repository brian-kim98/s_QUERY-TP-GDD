﻿namespace FrbaOfertas2.EntregaOferta
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
            this.label3 = new System.Windows.Forms.Label();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_finalizar = new System.Windows.Forms.Button();
            this.dateTimePicker_fechaConsumo = new System.Windows.Forms.DateTimePicker();
            this.textBox_codigoCupon = new System.Windows.Forms.TextBox();
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Consumo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código de Cupon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(15, 283);
            this.button_limpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(92, 36);
            this.button_limpiar.TabIndex = 3;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_finalizar
            // 
            this.button_finalizar.Location = new System.Drawing.Point(345, 283);
            this.button_finalizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_finalizar.Name = "button_finalizar";
            this.button_finalizar.Size = new System.Drawing.Size(96, 36);
            this.button_finalizar.TabIndex = 4;
            this.button_finalizar.Text = "Finalizar";
            this.button_finalizar.UseVisualStyleBackColor = true;
            this.button_finalizar.Click += new System.EventHandler(this.button_finalizar_Click);
            // 
            // dateTimePicker_fechaConsumo
            // 
            this.dateTimePicker_fechaConsumo.CustomFormat = "yyyy-MM-dd HH-mm-ss";
            this.dateTimePicker_fechaConsumo.Location = new System.Drawing.Point(197, 38);
            this.dateTimePicker_fechaConsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker_fechaConsumo.Name = "dateTimePicker_fechaConsumo";
            this.dateTimePicker_fechaConsumo.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_fechaConsumo.TabIndex = 5;
            // 
            // textBox_codigoCupon
            // 
            this.textBox_codigoCupon.Location = new System.Drawing.Point(197, 81);
            this.textBox_codigoCupon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_codigoCupon.Name = "textBox_codigoCupon";
            this.textBox_codigoCupon.Size = new System.Drawing.Size(200, 22);
            this.textBox_codigoCupon.TabIndex = 6;
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.Location = new System.Drawing.Point(197, 119);
            this.textBox_cliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(200, 22);
            this.textBox_cliente.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_cliente);
            this.groupBox1.Controls.Add(this.textBox_codigoCupon);
            this.groupBox1.Controls.Add(this.dateTimePicker_fechaConsumo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(428, 182);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrega Oferta";
            // 
            // EntregarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_finalizar);
            this.Controls.Add(this.button_limpiar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EntregarOferta";
            this.Text = "EntregarOferta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_finalizar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaConsumo;
        private System.Windows.Forms.TextBox textBox_codigoCupon;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}