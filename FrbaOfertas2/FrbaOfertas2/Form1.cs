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

namespace FrbaOfertas2
{
    public partial class AltaRol_Form : Form
    {

        SqlDataAdapter generico = new SqlDataAdapter();
        private DataTable tabla_funcionalidades = new DataTable();
        private List<int> func_codigo_aux = new List<int>();


        public AltaRol_Form()
        {
            InitializeComponent();
            carga_comboBox_funcionalidades();
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void carga_comboBox_funcionalidades()
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

        private void button_aniadir_funcionalidad_Click(object sender, EventArgs e)
        {
            listBox_funcionalidades_para_rol.Items.Add(comboBox_funcionalidades.SelectedValue);

            func_codigo_aux.Add(tabla_funcionalidades.Rows[comboBox_funcionalidades.SelectedIndex].Field<int>(0));

            tabla_funcionalidades.Rows.RemoveAt(comboBox_funcionalidades.SelectedIndex);
            comboBox_funcionalidades.DataSource = tabla_funcionalidades;
        }

        private void button_crear_rol_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();
            //NO ANDA, INTERNET MENTIROSO
            //String query_insert_rol = "INSERT INTO S_QUERY.Rol(rol_nombre, rol_estado) VALUES(textBox_nombre.Text, 1)";
            //voy a probar con esto
            String query_insert_rol_nuevo = "INSERT INTO S_QUERY.Rol(rol_nombre, rol_estado) VALUES('" + textBox_nombre.Text.ToString() + "', 1)";
            //SqlDataAdapter sda_insert = new SqlDataAdapter(query_insert_rol, connection);
            generico.InsertCommand = new SqlCommand(query_insert_rol_nuevo, connection);
            generico.InsertCommand.ExecuteNonQuery();


            String query_select_rol = "SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = '" + textBox_nombre.Text.ToString() + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_rol, connection);
            DataTable data_rol = new DataTable();

            sda_select.Fill(data_rol);


            for (int i = 0; i < listBox_funcionalidades_para_rol.Items.Count; i++)
            {
                String insert_rol_x_funcionalidad =
                    "INSERT INTO S_QUERY.FuncionalidadxRol(func_codigo, rol_codigo) VALUES(" +
                    func_codigo_aux[i] + ", " +
                    data_rol.Rows[0] + ")";

                generico.InsertCommand = new SqlCommand(insert_rol_x_funcionalidad, connection);
                generico.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Se inserto una fila");
            }

        connection.Close();
            
        }

        private void listBox_funcionalidades_para_rol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

    }
}
