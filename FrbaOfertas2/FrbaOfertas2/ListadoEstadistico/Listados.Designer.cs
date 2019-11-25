namespace FrbaOfertas2.ListadoEstadistico
{
    partial class Listados
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
            this.comboBox_semestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_anio = new System.Windows.Forms.TextBox();
            this.button_volver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_tipoListado = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_mostrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semestre";
            // 
            // comboBox_semestre
            // 
            this.comboBox_semestre.FormattingEnabled = true;
            this.comboBox_semestre.Location = new System.Drawing.Point(223, 97);
            this.comboBox_semestre.Name = "comboBox_semestre";
            this.comboBox_semestre.Size = new System.Drawing.Size(191, 24);
            this.comboBox_semestre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año";
            // 
            // textBox1_anio
            // 
            this.textBox1_anio.Location = new System.Drawing.Point(223, 59);
            this.textBox1_anio.Name = "textBox1_anio";
            this.textBox1_anio.Size = new System.Drawing.Size(191, 22);
            this.textBox1_anio.TabIndex = 3;
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(13, 13);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(89, 23);
            this.button_volver.TabIndex = 4;
            this.button_volver.Text = "VOLVER";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Listado";
            // 
            // comboBox_tipoListado
            // 
            this.comboBox_tipoListado.FormattingEnabled = true;
            this.comboBox_tipoListado.Location = new System.Drawing.Point(223, 141);
            this.comboBox_tipoListado.Name = "comboBox_tipoListado";
            this.comboBox_tipoListado.Size = new System.Drawing.Size(191, 24);
            this.comboBox_tipoListado.TabIndex = 6;
            this.comboBox_tipoListado.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipoListado_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 181);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(432, 200);
            this.dataGridView1.TabIndex = 7;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(13, 394);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(89, 23);
            this.button_limpiar.TabIndex = 8;
            this.button_limpiar.Text = "LIMPIAR";
            this.button_limpiar.UseVisualStyleBackColor = true;
            // 
            // button_mostrar
            // 
            this.button_mostrar.Location = new System.Drawing.Point(352, 394);
            this.button_mostrar.Name = "button_mostrar";
            this.button_mostrar.Size = new System.Drawing.Size(93, 23);
            this.button_mostrar.TabIndex = 9;
            this.button_mostrar.Text = "MOSTRAR";
            this.button_mostrar.UseVisualStyleBackColor = true;
            this.button_mostrar.Click += new System.EventHandler(this.button_mostrar_Click);
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 429);
            this.Controls.Add(this.button_mostrar);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_tipoListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.textBox1_anio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_semestre);
            this.Controls.Add(this.label1);
            this.Name = "Listados";
            this.Text = "CargaDatosParaListado";
            this.Load += new System.EventHandler(this.Listados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_semestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1_anio;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_tipoListado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_mostrar;
    }
}