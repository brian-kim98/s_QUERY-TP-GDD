namespace FrbaOfertas2.ComprarOferta
{
    partial class ListaOfertas
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
            this.dataGridView_ofertas = new System.Windows.Forms.DataGridView();
            this.button_seleccionar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_seleccion_habilitado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_texto_libre = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_maximo = new System.Windows.Forms.TextBox();
            this.textBox_minimo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ofertas)).BeginInit();
            this.groupBox_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_ofertas
            // 
            this.dataGridView_ofertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ofertas.Location = new System.Drawing.Point(12, 227);
            this.dataGridView_ofertas.Name = "dataGridView_ofertas";
            this.dataGridView_ofertas.Size = new System.Drawing.Size(458, 210);
            this.dataGridView_ofertas.TabIndex = 0;
            // 
            // button_seleccionar
            // 
            this.button_seleccionar.Location = new System.Drawing.Point(365, 443);
            this.button_seleccionar.Name = "button_seleccionar";
            this.button_seleccionar.Size = new System.Drawing.Size(106, 36);
            this.button_seleccionar.TabIndex = 1;
            this.button_seleccionar.Text = "Seleccionar";
            this.button_seleccionar.UseVisualStyleBackColor = true;
            this.button_seleccionar.Click += new System.EventHandler(this.button_seleccionar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(12, 443);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(106, 36);
            this.button_volver.TabIndex = 2;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.textBox_minimo);
            this.groupBox_filtros.Controls.Add(this.textBox_maximo);
            this.groupBox_filtros.Controls.Add(this.button_limpiar);
            this.groupBox_filtros.Controls.Add(this.label2);
            this.groupBox_filtros.Controls.Add(this.label_seleccion_habilitado);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.textBox_texto_libre);
            this.groupBox_filtros.Controls.Add(this.button_buscar);
            this.groupBox_filtros.Location = new System.Drawing.Point(25, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(433, 166);
            this.groupBox_filtros.TabIndex = 11;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de busqueda";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(271, 137);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 7;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Precio Minimo";
            // 
            // label_seleccion_habilitado
            // 
            this.label_seleccion_habilitado.AutoSize = true;
            this.label_seleccion_habilitado.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_seleccion_habilitado.Location = new System.Drawing.Point(3, 67);
            this.label_seleccion_habilitado.Name = "label_seleccion_habilitado";
            this.label_seleccion_habilitado.Size = new System.Drawing.Size(76, 13);
            this.label_seleccion_habilitado.TabIndex = 4;
            this.label_seleccion_habilitado.Text = "Precio Maximo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detalle (Texto libre)";
            // 
            // textBox_texto_libre
            // 
            this.textBox_texto_libre.Location = new System.Drawing.Point(6, 40);
            this.textBox_texto_libre.Name = "textBox_texto_libre";
            this.textBox_texto_libre.Size = new System.Drawing.Size(230, 20);
            this.textBox_texto_libre.TabIndex = 1;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(352, 137);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 0;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Seleccione una Oferta";
            // 
            // textBox_maximo
            // 
            this.textBox_maximo.Location = new System.Drawing.Point(6, 83);
            this.textBox_maximo.Name = "textBox_maximo";
            this.textBox_maximo.Size = new System.Drawing.Size(230, 20);
            this.textBox_maximo.TabIndex = 8;
            // 
            // textBox_minimo
            // 
            this.textBox_minimo.Location = new System.Drawing.Point(9, 127);
            this.textBox_minimo.Name = "textBox_minimo";
            this.textBox_minimo.Size = new System.Drawing.Size(230, 20);
            this.textBox_minimo.TabIndex = 9;
            // 
            // ListaOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 506);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_seleccionar);
            this.Controls.Add(this.dataGridView_ofertas);
            this.Name = "ListaOfertas";
            this.Text = "ListaOfertas";
            this.Load += new System.EventHandler(this.ListaOfertas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ofertas)).EndInit();
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ofertas;
        private System.Windows.Forms.Button button_seleccionar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_seleccion_habilitado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_texto_libre;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_minimo;
        private System.Windows.Forms.TextBox textBox_maximo;
    }
}