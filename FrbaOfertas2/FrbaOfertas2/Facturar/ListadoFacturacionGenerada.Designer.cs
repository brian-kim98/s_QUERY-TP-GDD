﻿namespace FrbaOfertas2.Facturar
{
    partial class ListadoFacturacionGenerada
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
            this.dataGridView_listado = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button_generar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listado)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listado
            // 
            this.dataGridView_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listado.Location = new System.Drawing.Point(9, 64);
            this.dataGridView_listado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_listado.Name = "dataGridView_listado";
            this.dataGridView_listado.RowTemplate.Height = 24;
            this.dataGridView_listado.Size = new System.Drawing.Size(441, 292);
            this.dataGridView_listado.TabIndex = 0;
            this.dataGridView_listado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_listado_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "VOLVER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_generar
            // 
            this.button_generar.Location = new System.Drawing.Point(394, 377);
            this.button_generar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_generar.Name = "button_generar";
            this.button_generar.Size = new System.Drawing.Size(56, 19);
            this.button_generar.TabIndex = 2;
            this.button_generar.Text = "Generar";
            this.button_generar.UseVisualStyleBackColor = true;
            this.button_generar.Click += new System.EventHandler(this.button_generar_Click);
            // 
            // ListadoFacturacionGenerada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 405);
            this.Controls.Add(this.button_generar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_listado);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ListadoFacturacionGenerada";
            this.Text = "ListadoFacturacionGenerada";
            this.Load += new System.EventHandler(this.ListadoFacturacionGenerada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_generar;
    }
}