namespace FrbaOfertas2.MenuPrincipal
{
    partial class MenuInicio
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
            this.label_texto = new System.Windows.Forms.Label();
            this.button_carga_credito = new System.Windows.Forms.Button();
            this.button_comprar_oferta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_entregaOferta = new System.Windows.Forms.Button();
            this.button_modificarContrasenia = new System.Windows.Forms.Button();
            this.button_administrarUsuarios = new System.Windows.Forms.Button();
            this.button_facturacion = new System.Windows.Forms.Button();
            this.button_registrar_user = new System.Windows.Forms.Button();
            this.button_listadoEstadistico = new System.Windows.Forms.Button();
            this.button_abmProvee = new System.Windows.Forms.Button();
            this.button_abmClientes = new System.Windows.Forms.Button();
            this.button_roles = new System.Windows.Forms.Button();
            this.button_crear_oferta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_texto
            // 
            this.label_texto.AutoSize = true;
            this.label_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_texto.Location = new System.Drawing.Point(152, 26);
            this.label_texto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_texto.Name = "label_texto";
            this.label_texto.Size = new System.Drawing.Size(173, 29);
            this.label_texto.TabIndex = 1;
            this.label_texto.Text = "Menu Principal";
            // 
            // button_carga_credito
            // 
            this.button_carga_credito.BackColor = System.Drawing.SystemColors.Control;
            this.button_carga_credito.Enabled = false;
            this.button_carga_credito.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_carga_credito.Location = new System.Drawing.Point(20, 73);
            this.button_carga_credito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_carga_credito.Name = "button_carga_credito";
            this.button_carga_credito.Size = new System.Drawing.Size(408, 43);
            this.button_carga_credito.TabIndex = 2;
            this.button_carga_credito.Text = "Cargar Credito";
            this.button_carga_credito.UseVisualStyleBackColor = false;
            this.button_carga_credito.Visible = false;
            this.button_carga_credito.Click += new System.EventHandler(this.button_carga_credito_Click);
            // 
            // button_comprar_oferta
            // 
            this.button_comprar_oferta.BackColor = System.Drawing.SystemColors.Control;
            this.button_comprar_oferta.Enabled = false;
            this.button_comprar_oferta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_comprar_oferta.Location = new System.Drawing.Point(20, 123);
            this.button_comprar_oferta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_comprar_oferta.Name = "button_comprar_oferta";
            this.button_comprar_oferta.Size = new System.Drawing.Size(408, 43);
            this.button_comprar_oferta.TabIndex = 3;
            this.button_comprar_oferta.Text = "Comprar Oferta";
            this.button_comprar_oferta.UseVisualStyleBackColor = false;
            this.button_comprar_oferta.Visible = false;
            this.button_comprar_oferta.Click += new System.EventHandler(this.button_comprar_oferta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_crear_oferta);
            this.groupBox1.Controls.Add(this.button_entregaOferta);
            this.groupBox1.Controls.Add(this.button_modificarContrasenia);
            this.groupBox1.Controls.Add(this.button_administrarUsuarios);
            this.groupBox1.Controls.Add(this.button_facturacion);
            this.groupBox1.Controls.Add(this.button_registrar_user);
            this.groupBox1.Controls.Add(this.button_listadoEstadistico);
            this.groupBox1.Controls.Add(this.button_abmProvee);
            this.groupBox1.Controls.Add(this.button_abmClientes);
            this.groupBox1.Controls.Add(this.button_roles);
            this.groupBox1.Controls.Add(this.button_comprar_oferta);
            this.groupBox1.Controls.Add(this.button_carga_credito);
            this.groupBox1.Location = new System.Drawing.Point(31, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(449, 641);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades disponibles";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button_entregaOferta
            // 
            this.button_entregaOferta.Enabled = false;
            this.button_entregaOferta.Location = new System.Drawing.Point(20, 476);
            this.button_entregaOferta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_entregaOferta.Name = "button_entregaOferta";
            this.button_entregaOferta.Size = new System.Drawing.Size(408, 44);
            this.button_entregaOferta.TabIndex = 12;
            this.button_entregaOferta.Text = "Entrega/Consumo de Oferta";
            this.button_entregaOferta.UseVisualStyleBackColor = true;
            this.button_entregaOferta.Visible = false;
            this.button_entregaOferta.Click += new System.EventHandler(this.button_entregaOferta_Click);
            // 
            // button_modificarContrasenia
            // 
            this.button_modificarContrasenia.Enabled = false;
            this.button_modificarContrasenia.Location = new System.Drawing.Point(20, 542);
            this.button_modificarContrasenia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_modificarContrasenia.Name = "button_modificarContrasenia";
            this.button_modificarContrasenia.Size = new System.Drawing.Size(408, 43);
            this.button_modificarContrasenia.TabIndex = 11;
            this.button_modificarContrasenia.Text = "Modificar Contraseña";
            this.button_modificarContrasenia.UseVisualStyleBackColor = true;
            this.button_modificarContrasenia.Visible = false;
            this.button_modificarContrasenia.Click += new System.EventHandler(this.button_modificarContrasenia_Click);
            // 
            // button_administrarUsuarios
            // 
            this.button_administrarUsuarios.Enabled = false;
            this.button_administrarUsuarios.Location = new System.Drawing.Point(20, 591);
            this.button_administrarUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_administrarUsuarios.Name = "button_administrarUsuarios";
            this.button_administrarUsuarios.Size = new System.Drawing.Size(408, 43);
            this.button_administrarUsuarios.TabIndex = 10;
            this.button_administrarUsuarios.Text = "Administrar Usuarios";
            this.button_administrarUsuarios.UseVisualStyleBackColor = true;
            this.button_administrarUsuarios.Visible = false;
            this.button_administrarUsuarios.Click += new System.EventHandler(this.button_administrarUsuarios_Click);
            // 
            // button_facturacion
            // 
            this.button_facturacion.BackColor = System.Drawing.SystemColors.Control;
            this.button_facturacion.Enabled = false;
            this.button_facturacion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_facturacion.Location = new System.Drawing.Point(20, 426);
            this.button_facturacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_facturacion.Name = "button_facturacion";
            this.button_facturacion.Size = new System.Drawing.Size(408, 43);
            this.button_facturacion.TabIndex = 9;
            this.button_facturacion.Text = "Facturacion a Proveedor";
            this.button_facturacion.UseVisualStyleBackColor = false;
            this.button_facturacion.Visible = false;
            this.button_facturacion.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_registrar_user
            // 
            this.button_registrar_user.BackColor = System.Drawing.SystemColors.Control;
            this.button_registrar_user.Enabled = false;
            this.button_registrar_user.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_registrar_user.Location = new System.Drawing.Point(20, 375);
            this.button_registrar_user.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_registrar_user.Name = "button_registrar_user";
            this.button_registrar_user.Size = new System.Drawing.Size(408, 43);
            this.button_registrar_user.TabIndex = 8;
            this.button_registrar_user.Text = "Registrar Usuario";
            this.button_registrar_user.UseVisualStyleBackColor = false;
            this.button_registrar_user.Visible = false;
            this.button_registrar_user.Click += new System.EventHandler(this.button_registrar_user_Click);
            // 
            // button_listadoEstadistico
            // 
            this.button_listadoEstadistico.BackColor = System.Drawing.SystemColors.Control;
            this.button_listadoEstadistico.Enabled = false;
            this.button_listadoEstadistico.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_listadoEstadistico.Location = new System.Drawing.Point(20, 325);
            this.button_listadoEstadistico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_listadoEstadistico.Name = "button_listadoEstadistico";
            this.button_listadoEstadistico.Size = new System.Drawing.Size(408, 43);
            this.button_listadoEstadistico.TabIndex = 7;
            this.button_listadoEstadistico.Text = "Listados Estadisticos";
            this.button_listadoEstadistico.UseVisualStyleBackColor = false;
            this.button_listadoEstadistico.Visible = false;
            this.button_listadoEstadistico.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_abmProvee
            // 
            this.button_abmProvee.BackColor = System.Drawing.SystemColors.Control;
            this.button_abmProvee.Enabled = false;
            this.button_abmProvee.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_abmProvee.Location = new System.Drawing.Point(20, 274);
            this.button_abmProvee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_abmProvee.Name = "button_abmProvee";
            this.button_abmProvee.Size = new System.Drawing.Size(408, 43);
            this.button_abmProvee.TabIndex = 6;
            this.button_abmProvee.Text = "ABM Proveedores";
            this.button_abmProvee.UseVisualStyleBackColor = false;
            this.button_abmProvee.Visible = false;
            this.button_abmProvee.Click += new System.EventHandler(this.button_abmProvee_Click);
            // 
            // button_abmClientes
            // 
            this.button_abmClientes.BackColor = System.Drawing.SystemColors.Control;
            this.button_abmClientes.Enabled = false;
            this.button_abmClientes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_abmClientes.Location = new System.Drawing.Point(20, 224);
            this.button_abmClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_abmClientes.Name = "button_abmClientes";
            this.button_abmClientes.Size = new System.Drawing.Size(408, 43);
            this.button_abmClientes.TabIndex = 5;
            this.button_abmClientes.Text = "ABM Clientes";
            this.button_abmClientes.UseVisualStyleBackColor = false;
            this.button_abmClientes.Visible = false;
            this.button_abmClientes.Click += new System.EventHandler(this.button_abmClientes_Click);
            // 
            // button_roles
            // 
            this.button_roles.BackColor = System.Drawing.SystemColors.Control;
            this.button_roles.Enabled = false;
            this.button_roles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_roles.Location = new System.Drawing.Point(20, 174);
            this.button_roles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_roles.Name = "button_roles";
            this.button_roles.Size = new System.Drawing.Size(408, 43);
            this.button_roles.TabIndex = 4;
            this.button_roles.Text = "ABM Roles";
            this.button_roles.UseVisualStyleBackColor = false;
            this.button_roles.Visible = false;
            this.button_roles.Click += new System.EventHandler(this.button_roles_Click);
            // 
            // button_crear_oferta
            // 
            this.button_crear_oferta.BackColor = System.Drawing.SystemColors.Control;
            this.button_crear_oferta.Enabled = false;
            this.button_crear_oferta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_crear_oferta.Location = new System.Drawing.Point(20, 23);
            this.button_crear_oferta.Margin = new System.Windows.Forms.Padding(4);
            this.button_crear_oferta.Name = "button_crear_oferta";
            this.button_crear_oferta.Size = new System.Drawing.Size(408, 43);
            this.button_crear_oferta.TabIndex = 13;
            this.button_crear_oferta.Text = "Confeccion y Creacion de Ofertas";
            this.button_crear_oferta.UseVisualStyleBackColor = false;
            this.button_crear_oferta.Visible = false;
            this.button_crear_oferta.Click += new System.EventHandler(this.button_crear_oferta_Click);
            // 
            // MenuInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 711);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_texto);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuInicio";
            this.Text = "MenuPrincipal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuInicio_FormClosed);
            this.Load += new System.EventHandler(this.MenuInicio_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_texto;
        private System.Windows.Forms.Button button_carga_credito;
        private System.Windows.Forms.Button button_comprar_oferta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_roles;
        private System.Windows.Forms.Button button_abmProvee;
        private System.Windows.Forms.Button button_abmClientes;
        private System.Windows.Forms.Button button_listadoEstadistico;
        private System.Windows.Forms.Button button_facturacion;
        private System.Windows.Forms.Button button_registrar_user;
        private System.Windows.Forms.Button button_modificarContrasenia;
        private System.Windows.Forms.Button button_administrarUsuarios;
        private System.Windows.Forms.Button button_entregaOferta;
        private System.Windows.Forms.Button button_crear_oferta;
    }
}