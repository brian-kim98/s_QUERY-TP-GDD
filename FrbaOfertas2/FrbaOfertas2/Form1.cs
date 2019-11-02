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

        private DataTable tabla_funcionalidades = new DataTable();


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

            String query_obtenerFuncionalidades = "SELECT func_nombre FROM S_QUERY.Funcionalidad";
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

            tabla_funcionalidades.Rows.RemoveAt(comboBox_funcionalidades.SelectedIndex);
            comboBox_funcionalidades.DataSource = tabla_funcionalidades;
        }

        private void button_crear_rol_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectionWithDatabase();
            String insert_rol_string = "INSERT INTO S_QUERY.Rol(rol_nombre, rol_estado) VALUES(textBox_nombre.Text, 1)";
            String insert_rol_x_funcionalidad_string = "INSERT INTO S_QUERY.FuncionalidadxRol";
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
