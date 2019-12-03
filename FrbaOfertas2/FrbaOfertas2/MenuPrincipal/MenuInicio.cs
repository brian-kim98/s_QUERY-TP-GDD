using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas2.Clases;
using System.Data.SqlClient;
using FrbaOfertas2.CrearOferta;
using FrbaOfertas2.AbmRol;
using FrbaOfertas2.CargaCredito;
using FrbaOfertas2.RegistroUsuario.AbmProveedor;
using FrbaOfertas2.RegistroUsuario.AbmCliente;
using FrbaOfertas2.ListadoEstadistico;
using FrbaOfertas2.ComprarOferta;
using FrbaOfertas2.Facturar;
using FrbaOfertas2.EntregaOferta;
using FrbaOfertas2.AdministracionUsuarios;
using FrbaOfertas2.LoginYSeguridad;

namespace FrbaOfertas2.MenuPrincipal
{
    public partial class MenuInicio : Form
    {
        private BaseDeDato bd = new BaseDeDato();
        SqlDataAdapter adapter;
        int codigo_user;
        bool sosAdmin;
        Login volverAlLogin;

        public MenuInicio(int codigo_usuario, Login login)
        {
            InitializeComponent();
            codigo_user = codigo_usuario;
            this.habilitar_funcionalidades(codigo_usuario);
            sosAdmin = this.sosUsuarioAdministrador(codigo_usuario);
            volverAlLogin = login;
        
        }

        private void habilitar_funcionalidades(int codigo_usuario)
        {
            List<String> listaFuncionalidades;

            listaFuncionalidades = this.obtenerListaFuncionalidades(codigo_usuario);

            if (listaFuncionalidades.Contains("Confeccion y publicacion de Ofertas"))
            {
                this.habilitar_boton(button_crear_oferta);
            }


            if ( listaFuncionalidades.Contains("Comprar Oferta"))
            {
                this.habilitar_boton(button_comprar_oferta);
            }

            if (listaFuncionalidades.Contains("Cargar Credito"))
            {

                this.habilitar_boton(button_carga_credito);
            }


            if (listaFuncionalidades.Contains("ABM de Cliente"))
            {
                this.habilitar_boton(button_abmClientes);
            }

            if (listaFuncionalidades.Contains("ABM de Proveedor"))
            {
                this.habilitar_boton(button_abmProvee);
            }


            if (listaFuncionalidades.Contains("ABM de Rol"))
            {
                this.habilitar_boton(button_roles);
            }

            if (listaFuncionalidades.Contains("Listado Estadistico"))
            {
                this.habilitar_boton(button_listadoEstadistico);
            }

            if (listaFuncionalidades.Contains("Entrega/Consumo de Oferta"))
            {
                this.habilitar_boton(button_entregaOferta);
            }


            if (listaFuncionalidades.Contains("Facturacion a Proveedor"))
            {
                this.habilitar_boton(button_facturacion);
            }

            if (listaFuncionalidades.Contains("Registro de Usuario"))
            {
                this.habilitar_boton(button_registrar_user);
            }

            this.habilitarFuncionalidadExtra();

        }

        private void habilitarFuncionalidadExtra()
        {
            if (this.sosUsuarioAdministrador(codigo_user))
            {
                this.habilitar_boton(button_administrarUsuarios);
                this.habilitar_boton(button_crear_oferta);

            }
            else
            {
                this.habilitar_boton(button_modificarContrasenia);
            }
        }

        private bool sosUsuarioAdministrador(int codigo_usuario)
        {
            BaseDeDato bd = new BaseDeDato();
            bd.conectar();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT S_QUERY.sosUsuarioAdministrador(@usuario_codigo)", bd.obtenerConexion());
            SqlParameter usuario_codigo = new SqlParameter("@usuario_codigo", SqlDbType.Int);
            usuario_codigo.Value = codigo_user;

            command.Parameters.Add(usuario_codigo);

            if ((int)command.ExecuteScalar() == 1)
            {
                bd.desconectar();
                return true;
            }

            else
            {
                bd.desconectar();
                return false;
            }

            


        }


        private List<String> obtenerListaFuncionalidades(int codigo_usuario)
        {
            List<String> funcionalidades = new List<String>();

            

            String selectFuncionalidadesQuery = "SELECT f.func_nombre FROM S_QUERY.Funcionalidad f "
                + "JOIN S_QUERY.FuncionalidadXRol fr ON fr.func_codigo = f.func_codigo "
                + "JOIN S_QUERY.Rol r ON r.rol_codigo = fr.rol_codigo "
                + "JOIN S_QUERY.RolXUsuario u ON r.rol_codigo = u.rol_codigo "
                + "WHERE u.usuario_codigo = '" + codigo_usuario.ToString() + "'" 
                + "AND u.rol_habilitado = 1";
           

            try
            {
                using (SqlCommand cmd = new SqlCommand(selectFuncionalidadesQuery, bd.obtenerConexion()))
                {
                    //Empleados a = new Empleados();
                    SqlDataReader dr;
                    cmd.Connection = bd.obtenerConexion();
                    cmd.Connection.Open();
                    dr = cmd.ExecuteReader();
                    //dr = Empleado.Adaptador.ObtenerTodosEmpleados();
                    if (dr.HasRows == true)
                        while (dr.Read())
                            //ListaEmpleado.Add(new TraerEmpleado(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
                            funcionalidades.Add(dr[0].ToString());

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           
            return funcionalidades;
        }

        public void inhabilitar_button(Button botonAModificar)
        {


            botonAModificar.BackColor = SystemColors.ControlDark;

            botonAModificar.FlatStyle = FlatStyle.Popup;
         
            botonAModificar.Enabled = true;

            botonAModificar.Visible = true;

        }


        public void habilitar_boton(Button botonAModificar)
        {

            
            botonAModificar.BackColor = SystemColors.Control;
            
            botonAModificar.FlatStyle = FlatStyle.Standard;
      
            botonAModificar.Enabled = true;
       
            botonAModificar.Visible = true;
          
        }

        private void button_crear_oferta_Click(object sender, EventArgs e)
        {
            if (this.sosAdmin)
            {
                CreacionOferta crearOferta = new CreacionOferta();
                crearOferta.Show();
            }

            else
            {
                CreacionOferta crearOferta = new CreacionOferta(codigo_user);
                crearOferta.Show();
            }
            
        
        }

        private void button_comprar_oferta_Click(object sender, EventArgs e)
        {
            CompraOferta comprarOferta = new CompraOferta(codigo_user.ToString());
            comprarOferta.Show();
        }

        private void button_roles_Click(object sender, EventArgs e)
        {
            ListadoRoles listaRoles = new ListadoRoles();
            listaRoles.Show();
        }

        private void button_carga_credito_Click(object sender, EventArgs e)
        {
            CargarCredito nuevaCarga = new CargarCredito(codigo_user);
            nuevaCarga.Show();
//            this.Close();
        }

        private void MenuInicio_Load(object sender, EventArgs e)
        {

        }

        private void button_abmProvee_Click(object sender, EventArgs e)
        {
            ListadoProveedores abmProveedor = new ListadoProveedores();
            abmProveedor.Show();
        }

        private void button_abmClientes_Click(object sender, EventArgs e)
        {
            ListadoClientes abmClientes = new ListadoClientes();
            abmClientes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listados listadoEst = new Listados();
            listadoEst.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacturacionAProveedor facturacion = new FacturacionAProveedor();
            facturacion.Show();
        }

        private void button_registrar_user_Click(object sender, EventArgs e)
        {
            RegistrarUsuario nuevoRegistro = new RegistrarUsuario();
            nuevoRegistro.Show();
        }

        private void button_modificarContrasenia_Click(object sender, EventArgs e)
        {
            ModificarContrasenia modificar = new ModificarContrasenia(codigo_user);
            modificar.Show();
        }

        private void button_administrarUsuarios_Click(object sender, EventArgs e)
        {
            AdministrarUsuarios administrador = new AdministrarUsuarios();
            administrador.Show();
        }

        private void button_entregaOferta_Click(object sender, EventArgs e)
        {
            EntregarOferta entrega = new EntregarOferta(codigo_user);
            entrega.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MenuInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Se cierra la sesión ! \nHasta luego !");
            volverAlLogin.limpiate();
            volverAlLogin.Show();
        }
    }
}
