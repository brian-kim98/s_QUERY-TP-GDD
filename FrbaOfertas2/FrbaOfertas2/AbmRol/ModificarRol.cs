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
    public partial class ModificarRol : Form
    {

        public String txt_codigo_viejo;
        public String txt_nombre_viejo;
        public String txt_checkeado;
        private DataTable tabla_funcionalidades = new DataTable();
        private DataTable tabla_funcionalidades_nuevas = new DataTable();
        private List<int> func_codigo_agregar = new List<int>();
        private List<int> func_codigo_quitar = new List<int>();

        public ModificarRol(String codigo_rol , String nombre_rol , String estado_rol)
        {
            InitializeComponent();

            txt_codigo_viejo = codigo_rol;
            txt_nombre_viejo = nombre_rol;
            txt_checkeado = estado_rol;

            label_codigo_viejo.Text = codigo_rol;
            label_nombre_viejo.Text = nombre_rol;
            label_estado_viejo.Text = estado_rol;

            checkBox_habilitado.Checked =  this.tildarCheckBox(estado_rol);

            this.carga_comboBox_funcionalidades_viejas();
            this.carga_comboBox_funcionalidades_nuevas();
        }

        private bool tildarCheckBox(String estado)
        {
                return estado == "True";

        }



        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private SqlConnection ConnectionWithDatabase()
        {
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=.\SQLSERVER2012;Initial Catalog = GD2C2019;User ID=sa;Password=gestiondedatos";

            connection = new SqlConnection(connectionString);

            return connection;

        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 

        private void carga_comboBox_funcionalidades_viejas()
        {
            SqlConnection connection = ConnectionWithDatabase();

            

            String query_obtenerFuncionalidades = "  SELECT a.func_codigo , func_nombre FROM GD2C2019.S_QUERY.FuncionalidadXRol a " 
            + "JOIN GD2C2019.S_QUERY.Funcionalidad b ON a.func_codigo = b.func_codigo"
            + " WHERE a.rol_codigo = '" + txt_codigo_viejo + "' "
            + "	GROUP BY a.func_codigo, func_nombre"  ;
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


            comboBox_funcionalidades_quitar.DataSource = tabla_funcionalidades;
            comboBox_funcionalidades_quitar.DisplayMember = "func_nombre";
            comboBox_funcionalidades_quitar.ValueMember = "func_nombre";

            connection.Close();
        }


        private void carga_comboBox_funcionalidades_nuevas()
        {
            SqlConnection connection = ConnectionWithDatabase();

            

            String query_obtenerFuncionalidades_nuevas = "	SELECT a.func_codigo, a.func_nombre FROM GD2C2019.S_QUERY.Funcionalidad a "
	        + " LEFT JOIN GD2C2019.S_QUERY.FuncionalidadXRol b "
	        + " ON b.func_codigo = a.func_codigo and b.rol_codigo = '" + txt_codigo_viejo + "' "
	        +" WHERE b.rol_codigo IS NULL";
            SqlDataAdapter sda = new SqlDataAdapter(query_obtenerFuncionalidades_nuevas, connection);

            try
            {
                connection.Open();
                sda.Fill(tabla_funcionalidades_nuevas);

            }

            catch (SqlException se)
            {
                MessageBox.Show("An error occured while connecting to database" + se.ToString());
            }


            comboBox1.DataSource = tabla_funcionalidades_nuevas;
            comboBox1.DisplayMember = "func_nombre";
            comboBox1.ValueMember = "func_nombre";

            connection.Close();
        }

        private void lbl_nombre_Click(object sender, EventArgs e)
        {

        }


        private void comboBox_funcionalidades_nuevo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_crear_rol_Click(object sender, EventArgs e)
        {
             SqlConnection connection = ConnectionWithDatabase();
             connection.Open();

             this.quitar_valores(connection);

             this.agregar_valores(connection);

             if(this.completosValoresModificarUpdate()){
                 this.modificarValores(connection);
             }
             

             connection.Close();

             this.Close();
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool completosValoresModificarUpdate()
        {
            
            return textBox_nombre_nuevo.Text.ToString() != "" || checkBox_habilitado.Checked.ToString() != txt_checkeado;
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void modificarValores(SqlConnection connection)
        {


            String query_select_rol = "SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = '" + txt_nombre_viejo + "' AND rol_codigo = '" + txt_codigo_viejo + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_rol, connection);
            DataTable data_rol_quitar = new DataTable();

            sda_select.Fill(data_rol_quitar);

            SqlDataAdapter adaptador_quitar = new SqlDataAdapter();


            String update_rol = "UPDATE S_QUERY.Rol SET ";
            List<String> listaUpdate = new List<string>();

            if (textBox_nombre_nuevo.Text.ToString() != "")
            {
                String updateNombre = " rol_nombre = '" + textBox_nombre_nuevo.Text + "'";
                listaUpdate.Add(updateNombre);
            }

            if (checkBox_habilitado.Checked.ToString() != txt_checkeado)
            {
 
                String updateEstado = " rol_estado = " + this.obtenerNumeroBooleano(checkBox_habilitado.Checked.ToString()) +" ";
                listaUpdate.Add(updateEstado);
            }

            update_rol += listaUpdate.ElementAt(0);

            for (int i = 1; i < listaUpdate.Count(); i++ )
            {
                update_rol += ", " + listaUpdate.ElementAt(i);
            }

            update_rol += " WHERE rol_codigo = '" + txt_codigo_viejo + "'";

            adaptador_quitar.InsertCommand = new SqlCommand(update_rol, connection);
            adaptador_quitar.InsertCommand.ExecuteNonQuery();
            adaptador_quitar.InsertCommand.Dispose();
  

        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private String obtenerNumeroBooleano(String estado)
        {
            if (estado == "True")
            {
                return "1";
            }
            else
            {
                return "0";
            }



        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void quitar_valores(SqlConnection connection)
        {
           

            String query_select_rol = "SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = '" + txt_nombre_viejo + "' AND rol_codigo = '" + txt_codigo_viejo + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_rol, connection);
            DataTable data_rol_quitar = new DataTable();

            sda_select.Fill(data_rol_quitar);

            SqlDataAdapter adaptador_quitar = new SqlDataAdapter();

            for (int i = 0; i < listBox_funcionalidades_quitar.Items.Count; i++)
            {

                String delete_rol_x_funcionalidad =
                    "DELETE FROM S_QUERY.FuncionalidadxRol WHERE" +
                    " func_codigo =  '"  +func_codigo_quitar[i] + "' AND " +
                    "rol_codigo = '" + data_rol_quitar.Rows[0].ItemArray[0] + "' ";

                adaptador_quitar.InsertCommand = new SqlCommand(delete_rol_x_funcionalidad, connection);
                adaptador_quitar.InsertCommand.ExecuteNonQuery();
                adaptador_quitar.InsertCommand.Dispose();
            }

        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void agregar_valores(SqlConnection connection)
        {

            String query_select_rol = "SELECT rol_codigo FROM S_QUERY.Rol WHERE rol_nombre = '" + txt_nombre_viejo + "' AND rol_codigo = '" + txt_codigo_viejo + "'";
            SqlDataAdapter sda_select = new SqlDataAdapter(query_select_rol, connection);
            DataTable data_rol = new DataTable();

            sda_select.Fill(data_rol);

             SqlDataAdapter adaptador = new SqlDataAdapter();

            for(int i = 0 ;  i < listBox1.Items.Count ; i++ ){

                String insert_rol_x_funcionalidad =
                    "INSERT INTO S_QUERY.FuncionalidadxRol(func_codigo,  rol_codigo) VALUES(" +
                    func_codigo_agregar[i] + ", " +
                    data_rol.Rows[0].ItemArray[0] + ")";

                adaptador.InsertCommand = new SqlCommand(insert_rol_x_funcionalidad, connection);
                adaptador.InsertCommand.ExecuteNonQuery();
                adaptador.InsertCommand.Dispose();
            }

        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button_aniadir_funcionalidad_Click(object sender, EventArgs e)
        {


            if (comboBox_funcionalidades_quitar.SelectedValue != null)
            {
                listBox_funcionalidades_quitar.Items.Add(comboBox_funcionalidades_quitar.SelectedValue);

                func_codigo_quitar.Add(tabla_funcionalidades.Rows[comboBox_funcionalidades_quitar.SelectedIndex].Field<int>(0));

                tabla_funcionalidades.Rows.RemoveAt(comboBox_funcionalidades_quitar.SelectedIndex);
                comboBox_funcionalidades_quitar.DataSource = tabla_funcionalidades;
            }



        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(comboBox1.SelectedValue != null){

                listBox1.Items.Add(comboBox1.SelectedValue);

                func_codigo_agregar.Add(tabla_funcionalidades_nuevas.Rows[comboBox1.SelectedIndex].Field<int>(0));

                tabla_funcionalidades_nuevas.Rows.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.DataSource = tabla_funcionalidades_nuevas;

            }


        }






    }
}
