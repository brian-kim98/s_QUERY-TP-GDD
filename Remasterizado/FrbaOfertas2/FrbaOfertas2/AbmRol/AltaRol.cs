using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using FrbaOfertas2.Clases;

namespace FrbaOfertas2
{
    public partial class AltaRol_Form : Form
    {
/*
        SqlDataAdapter generico = new SqlDataAdapter();
        SqlDataAdapter generico2 = new SqlDataAdapter();
        private DataTable tabla_funcionalidades = new DataTable();
        private List<int> func_codigo_aux = new List<int>();
*/
        private BaseDeDato bd = new BaseDeDato();
        private DataTable tabla_funcionalidades = new DataTable();
        private DataTable dt;
        private List<int> func_codigo_aux = new List<int>();
        SqlDataAdapter adapter;


        public AltaRol_Form()
        {
            InitializeComponent();
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

/*        private void carga_comboBox_funcionalidades()
        {
            SqlConnection connection = ConnectionWithDatabase();

            String query_obtenerFuncionalidades = "SELECT func_codigo, func_nombre FROM S_QUERY.Funcionalidad";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerFuncionalidades, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_funcionalidades);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }


            comboBox_funcionalidades.DataSource = tabla_funcionalidades;
            comboBox_funcionalidades.DisplayMember = "func_nombre";
            comboBox_funcionalidades.ValueMember = "func_nombre";

            connection.Close();
        }
*/
        private void button_aniadir_funcionalidad_Click(object sender, EventArgs e)
        {
            listBox_funcionalidades_para_rol.Items.Add(comboBox_funcionalidades.SelectedValue);

            func_codigo_aux.Add(dt.Rows[comboBox_funcionalidades.SelectedIndex].Field<int>(0));

            dt.Rows.RemoveAt(comboBox_funcionalidades.SelectedIndex);
            comboBox_funcionalidades.DataSource = dt;
        }

        private void button_crear_rol_Click(object sender, EventArgs e)
        {
            if (this.todosLosCamposEstanCompletos())
            {
                textBox_nombre.Enabled = false;
                BaseDeDato bd = new BaseDeDato();
                try
                {
                    SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.insertarRolNuevo");
                    procedure.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@rol_nombre", SqlDbType.VarChar).Value = textBox_nombre.Text;
                    int idRol = bd.ejecutarConsultaDevuelveInt(procedure);
                    MessageBox.Show("ID encontrado = " + idRol);
                    for (int i = 0; i < listBox_funcionalidades_para_rol.Items.Count; i++)
                    {
                        SqlCommand procedure2 = Clases.BaseDeDato.crearConsulta("S_QUERY.insertarFuncionalidadPorRol");
                        procedure2.CommandType = CommandType.StoredProcedure;
                        procedure2.Parameters.AddWithValue("@func_codigo", SqlDbType.Int).Value = func_codigo_aux[i];
                        procedure2.Parameters.AddWithValue("@rol_codigo", SqlDbType.Int).Value = idRol;
                        bd.ejecutarConsultaSinResultado(procedure);
                    }
                    bd.desconectar();
                    MessageBox.Show("Rol creado con exito!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    textBox_nombre.Enabled = true;
                    bd.desconectar();
                }

            }

            else
            {
                MessageBox.Show("Complete el nombre de rol y seleccione al menos una funcionalidad", "FrbaOfertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
/*
            String query_select_rol = "SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = '" + textBox_nombre.Text.ToString() + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_rol, connection);
            DataTable data_rol = new DataTable();

            sda_select.Fill(data_rol);

            for (int i = 0; i < listBox_funcionalidades_para_rol.Items.Count; i++)
            {
                String insert_rol_x_funcionalidad =
                    "INSERT INTO S_QUERY.FuncionalidadxRol(func_codigo, rol_codigo) VALUES(" +
                    func_codigo_aux[i] + ", " +
                    data_rol.Rows[0].ItemArray[0] + ")";

                MessageBox.Show("Codigo de la funcion = " + func_codigo_aux[i]);
                MessageBox.Show("Codigo del rol buscado = " + data_rol.Rows[0].ItemArray[0]);

                generico.InsertCommand = new SqlCommand(insert_rol_x_funcionalidad, connection);
                generico.InsertCommand.ExecuteNonQuery();
                generico.InsertCommand.Dispose();
                MessageBox.Show("Se inserto una fila");
            }

        connection.Close();
*/            
        }

        private void listBox_funcionalidades_para_rol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

/*        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }
*/
        private void AltaRol_Form_Load(object sender, EventArgs e)
        {
            bd.conectar();
            adapter = new SqlDataAdapter("SELECT func_codigo, func_nombre FROM S_QUERY.Funcionalidad", bd.obtenerConexion());
            dt = new DataTable();
            adapter.Fill(dt);
            comboBox_funcionalidades.DataSource = dt;
            comboBox_funcionalidades.ValueMember = "func_nombre";
            comboBox_funcionalidades.DisplayMember = "func_nombre";
            bd.desconectar();
        }

        private void vaciarFuncionalidades()
        {
            listBox_funcionalidades_para_rol.DataSource = null;
            while (listBox_funcionalidades_para_rol.Items.Count > 0)
            {
                listBox_funcionalidades_para_rol.Items.RemoveAt(0);
            }

            func_codigo_aux.Clear();
        }

        private bool todosLosCamposEstanCompletos()
        {
            return textBox_nombre.Text != "" && func_codigo_aux.Count() > 0;
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_nombre.Clear();
            textBox_nombre.Enabled = true;
            this.vaciarFuncionalidades();
        }

        

    }
}
