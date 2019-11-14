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

namespace FrbaOfertas2.AbmRol
{
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
            this.actualizar_tabla();
        }

        private void actualizar_tabla()
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_rol = "SELECT * FROM S_QUERY.Rol";
            SqlCommand comando = new SqlCommand(query_select_rol, connection);

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_rol.DataSource = tabla;
        }


        private void button_actualizar_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            String query_select_rol = "SELECT * FROM S_QUERY.Rol";
            SqlCommand comando = new SqlCommand(query_select_rol, connection);

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_rol.DataSource = tabla;
        }


        private void dataGridView_rol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //NO ME SALE QUE SE BORRREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE LA CONCHA DE TU MADRE ALL BOYS
            SqlConnection connection = ConnectionWithDatabase();
            connection.Open();

            int row_index = dataGridView_rol.CurrentCell.RowIndex;

            String row_codigo = dataGridView_rol.CurrentRow.Cells["rol_codigo"].Value.ToString();
            String row_nombre = dataGridView_rol.CurrentRow.Cells["rol_nombre"].Value.ToString();
            String row_estado = dataGridView_rol.CurrentRow.Cells["rol_estado"].Value.ToString();

            
            String query_delete_FuncionalidadxRol = "DELETE FROM S_QUERY.FuncionalidadxRol WHERE rol_codigo = '" + row_codigo +"'";

            String query_delete_rol = "DELETE FROM S_QUERY.Rol WHERE rol_codigo='" + row_codigo +"';";

            SqlCommand comando_delete_rol = new SqlCommand(query_delete_rol, connection);
            SqlCommand comando_delete_funcionalidadxrol = new SqlCommand(query_delete_FuncionalidadxRol , connection);

            SqlDataAdapter adaptador = new SqlDataAdapter();

            adaptador.DeleteCommand = comando_delete_funcionalidadxrol;
            adaptador.DeleteCommand.ExecuteNonQuery();
            adaptador.DeleteCommand.Dispose();

            adaptador.DeleteCommand = comando_delete_rol;
            adaptador.DeleteCommand.ExecuteNonQuery();
            adaptador.DeleteCommand.Dispose();

            
            MessageBox.Show("Se elimino el Rol elegido.");

            dataGridView_rol.Rows.RemoveAt(row_index);
        }


        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }

        private void Nuevo_Rol_Click(object sender, EventArgs e)
        {
            AltaRol_Form alta = new AltaRol_Form();
            alta.Show();

            this.actualizar_tabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String row_codigo = dataGridView_rol.CurrentRow.Cells["rol_codigo"].Value.ToString();
            String row_nombre = dataGridView_rol.CurrentRow.Cells["rol_nombre"].Value.ToString();

            ModificarRol modificar = new ModificarRol(row_codigo, row_nombre);
            modificar.Show();
        }







    }
}
