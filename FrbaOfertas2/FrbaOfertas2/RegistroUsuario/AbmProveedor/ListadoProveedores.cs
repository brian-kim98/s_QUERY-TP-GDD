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

namespace FrbaOfertas2.RegistroUsuario.AbmProveedor
{
    public partial class ListadoProveedores : Form
    {
        BaseDeDato bd = new BaseDeDato();

        public ListadoProveedores()
        {
            InitializeComponent();
            this.mostrarTodos();
        }

        private void mostrarTodos()
        {
            bd.conectar();

            String query_select_rol = "SELECT prov_codigo , prov_razon_social as Razon_Social, prov_cuit as CUIT , prov_mail as Email FROM S_QUERY.Proveedor";
            SqlCommand comando = new SqlCommand(query_select_rol, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            this.cargarDataGridProveedor(adaptador);

            bd.desconectar();

        }

        private void cargarDataGridProveedor(SqlDataAdapter adaptador)
        {

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_proveedor.DataSource = tabla;

        }


        private void button_actualizar_Click(object sender, EventArgs e)
        {
            this.mostrarTodos();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {

            bd.conectar();
            String query_obtener_filtrados = "SELECT prov_codigo , prov_razon_social as Razon_Social, prov_cuit as CUIT , prov_mail as Email FROM S_QUERY.Proveedor";

            if (this.algunCampoCompleto())
            {
                query_obtener_filtrados += " WHERE ";
                List<String> listaQuery = new List<string>();

                if (textBox_email.Text.ToString() != "")
                {
                    String queryMail = "prov_mail LIKE '%" + textBox_email.Text.ToString() + "%'";
                    listaQuery.Add(queryMail);
                }


                if (textBox_razon_social.Text.ToString() != "")
                {
                    String queryRS = "prov_razon_social LIKE '%" + textBox_razon_social.Text.ToString() + "%'";
                    listaQuery.Add(queryRS);
                }


                if (textBox_cuit.Text.ToString() != "")
                {
                    String queryCUIT = "prov_cuit = '" + textBox_cuit.Text.ToString() + "'";
                    listaQuery.Add(queryCUIT);
                }

                query_obtener_filtrados += listaQuery.ElementAt(0);

                for (int i = 1; i < listaQuery.Count(); i++)
                {
                    query_obtener_filtrados += " AND " + listaQuery.ElementAt(i);
                }

            }

            SqlCommand comando = new SqlCommand(query_obtener_filtrados, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            cargarDataGridProveedor(adaptador);

            bd.desconectar();


        }

        private bool algunCampoCompleto()
        {

            return
                textBox_email.Text.ToString() != "" || textBox_razon_social.Text.ToString() != "" ||
                textBox_cuit.Text.ToString() != "" ;
        }

        private void nuevo_cliente_Click(object sender, EventArgs e)
        {
            ListadoSeleccionUsuario formAltaProve = new ListadoSeleccionUsuario("Proveedor");
            formAltaProve.FormClosed += new FormClosedEventHandler(afterCloseProveeAlta);
            formAltaProve.Show();
        }


        private void afterCloseProveeAlta(Object sender, FormClosedEventArgs e)
        {
            this.mostrarTodos();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            int row_index = dataGridView_proveedor.CurrentCell.RowIndex;
            String row_codigo_prove= dataGridView_proveedor.CurrentRow.Cells["prov_codigo"].Value.ToString();
            String row_rs_cliente = dataGridView_proveedor.CurrentRow.Cells["Razon_Social"].Value.ToString();

            try
            {
                bd.conectar();
                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.bajaLogicaProveedor");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@usuario_codigo_bajaproveedor", SqlDbType.Int).Value = (int)Convert.ToInt32(row_codigo_prove);

                procedure.ExecuteNonQuery();

                bd.desconectar();
                MessageBox.Show("Se elimino el Proveedor " + row_rs_cliente + ".");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }

            dataGridView_proveedor.Rows.RemoveAt(row_index);
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            int row_index = dataGridView_proveedor.CurrentCell.RowIndex;
            String row_codigo_prove = dataGridView_proveedor.CurrentRow.Cells["prov_codigo"].Value.ToString();

            ModificarProveedor formModificarProve = new ModificarProveedor(row_codigo_prove);
            formModificarProve.Show();
            formModificarProve.FormClosed += new FormClosedEventHandler(afterCloseProveeAlta);

        }

        private void groupBox_filtros_Enter(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_cuit.Clear();
            textBox_email.Clear();
            textBox_razon_social.Clear();
        }

        private void ListadoProveedores_Load(object sender, EventArgs e)
        {

        }

    }
}
