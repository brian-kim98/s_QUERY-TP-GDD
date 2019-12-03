using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas2.Clases;

namespace FrbaOfertas2.RegistroUsuario.AbmCliente
{
    public partial class ListadoClientes : Form
    {
        BaseDeDato bd = new BaseDeDato();

        public ListadoClientes()
        {
            InitializeComponent();
            this.mostrarTodos();
        }

        private void mostrarTodos()
        {
            bd.conectar();

            String query_select_rol = "SELECT clie_codigo , clie_nombre as Nombre, clie_apellido as Apellido , clie_dni as DNI, clie_mail as Email FROM S_QUERY.Cliente";
            SqlCommand comando = new SqlCommand(query_select_rol, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            this.cargarDataGridClientes(adaptador);

            bd.desconectar();

        }


        

        private void cargarDataGridClientes(SqlDataAdapter adaptador)
        {
 
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_clientes.DataSource = tabla;

        }

        private void groupBox_filtros_Enter(object sender, EventArgs e)
        {

        }

        private void button_actualizar_Click(object sender, EventArgs e)
        {
            this.mostrarTodos();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_apellido.Clear();
            textBox_nombre.Clear();
            textBox_dni.Clear();
            textBox_email.Clear();
        }


        private bool algunCampoCompleto()
        {
           
            return
                textBox_email.Text.ToString() != "" || textBox_apellido.Text.ToString() != "" ||
                textBox_nombre.Text.ToString() != "" || textBox_dni.Text.ToString() != "";
        }

        private bool chequeoDni(){

            


            if (!this.esUnCampoNumerico(textBox_dni))
            {

                if (textBox_dni.Text.ToString() == "") { return true; };

                MessageBox.Show("El campo DNI debe ser nu numero. Sin espacios ni guiones.");
                return false;
            }


            return true;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            bd.conectar();
            String query_obtener_filtrados = "SELECT clie_codigo, clie_nombre as Nombre, clie_apellido as Apellido , clie_dni as DNI, clie_mail as Email FROM S_QUERY.Cliente";


            if (this.algunCampoCompleto() && this.chequeoDni())
            {
                query_obtener_filtrados += " WHERE ";
                List<String> listaQuery = new List<string>();

                if (textBox_email.Text.ToString() != "")
                {
                    String queryMail = "clie_mail LIKE '%" + textBox_email.Text.ToString() +"%'";
                    listaQuery.Add(queryMail);
                }

                if (textBox_nombre.Text.ToString() != "")
                {
                    String queryNombre = "clie_nombre LIKE '%" + textBox_nombre.Text.ToString() +"%'";
                    listaQuery.Add(queryNombre);
                }

                if(textBox_apellido.Text.ToString() != ""){
                    String queryApellido = "clie_apellido LIKE '%" + textBox_apellido.Text.ToString() +"%'";
                    listaQuery.Add(queryApellido);
                }

                if(textBox_dni.Text.ToString() != "" ){
                    String queryMail = "clie_dni = '" + textBox_dni.Text.ToString() +"'";
                    listaQuery.Add(queryMail);
                }


                query_obtener_filtrados += listaQuery.ElementAt(0);

                for (int i = 1; i < listaQuery.Count();  i++ )
                {

                    query_obtener_filtrados += " AND " + listaQuery.ElementAt(i);
                }
                

            }

            SqlCommand comando = new SqlCommand(query_obtener_filtrados, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            cargarDataGridClientes(adaptador);

            bd.desconectar();
        }


        private bool esUnCampoNumerico(TextBox casilla_texto)
        {

            double valorDouble = 0.0;

            float valorFloat = (float)valorDouble;

            bool respuesta = float.TryParse(casilla_texto.Text, out valorFloat);

            return respuesta;

        }

        private void nuevo_cliente_Click(object sender, EventArgs e)
        {
            ListadoSeleccionUsuario clienteFormAlta = new ListadoSeleccionUsuario("Cliente");
            clienteFormAlta.FormClosed += new FormClosedEventHandler(afterCloseClienteAlta);
            clienteFormAlta.Show();
        }

        private void afterCloseClienteAlta(Object sender, FormClosedEventArgs e)
        {
            this.mostrarTodos();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            int row_index = dataGridView_clientes.CurrentCell.RowIndex;
            String row_codigo_cliente = dataGridView_clientes.CurrentRow.Cells["clie_codigo"].Value.ToString();

            try
            {
                bd.conectar();
                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.bajaLogicaCliente");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@usuario_codigo_bajacliente", SqlDbType.Int).Value = (int)Convert.ToInt32(row_codigo_cliente);

                procedure.ExecuteNonQuery();

                bd.desconectar();
                MessageBox.Show("Se elimino el Cliente.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }

            dataGridView_clientes.Rows.RemoveAt(row_index);

        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            int row_index = dataGridView_clientes.CurrentCell.RowIndex;
            String row_codigo_cliente = dataGridView_clientes.CurrentRow.Cells["clie_codigo"].Value.ToString();

            ModificarCliente formModificar = new ModificarCliente(row_codigo_cliente);
            formModificar.FormClosed += new FormClosedEventHandler(afterCloseModificacionCliente);
            formModificar.Show();
        }

        private void afterCloseModificacionCliente(Object sender, FormClosedEventArgs e)
        {
            this.mostrarTodos();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
