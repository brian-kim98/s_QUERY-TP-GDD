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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semestre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox_semestre
            // 
            this.comboBox_semestre.FormattingEnabled = true;
            this.comboBox_semestre.Location = new System.Drawing.Point(141, 51);
            this.comboBox_semestre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_semestre.Name = "comboBox_semestre";
            this.comboBox_semestre.Size = new System.Drawing.Size(177, 21);
            this.comboBox_semestre.TabIndex = 1;
            this.comboBox_semestre.SelectedIndexChanged += new System.EventHandler(this.comboBox_semestre_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año";
            // 
            // textBox1_anio
            // 
            this.textBox1_anio.Location = new System.Drawing.Point(141, 20);
            this.textBox1_anio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1_anio.Name = "textBox1_anio";
            this.textBox1_anio.Size = new System.Drawing.Size(177, 20);
            this.textBox1_anio.TabIndex = 3;
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(11, 11);
            this.button_volver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(84, 30);
            this.button_volver.TabIndex = 4;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Listado";
            // 
            // comboBox_tipoListado
            // 
            this.comboBox_tipoListado.FormattingEnabled = true;
            this.comboBox_tipoListado.Location = new System.Drawing.Point(141, 87);
            this.comboBox_tipoListado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_tipoListado.Name = "comboBox_tipoListado";
            this.comboBox_tipoListado.Size = new System.Drawing.Size(177, 21);
            this.comboBox_tipoListado.TabIndex = 6;
            this.comboBox_tipoListado.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipoListado_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 119);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(324, 189);
            this.dataGridView1.TabIndex = 7;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(33, 417);
            this.button_limpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(79, 30);
            this.button_limpiar.TabIndex = 8;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_mostrar
            // 
            this.button_mostrar.Location = new System.Drawing.Point(308, 417);
            this.button_mostrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_mostrar.Name = "button_mostrar";
            this.button_mostrar.Size = new System.Drawing.Size(81, 30);
            this.button_mostrar.TabIndex = 9;
            this.button_mostrar.Text = "Mostrar";
            this.button_mostrar.UseVisualStyleBackColor = true;
            this.button_mostrar.Click += new System.EventHandler(this.button_mostrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.comboBox_tipoListado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1_anio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_semestre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 332);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado Estadisticos";
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_mostrar);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_volver);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Listados";
            this.Text = "CargaDatosParaListado";
            this.Load += new System.EventHandler(this.Listados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}