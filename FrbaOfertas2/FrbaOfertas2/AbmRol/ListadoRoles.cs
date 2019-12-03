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

namespace FrbaOfertas2.AbmRol
{
    public partial class ListadoRoles : Form
    {

        BaseDeDato bd = new BaseDeDato();
           
        public ListadoRoles()
        {
            InitializeComponent();
            this.cargarComboBoxHabilitacion();
            this.cargarComboBoxFuncionalidades();
            this.actualizar_tabla();
            
        }

           private void cargarComboBoxFuncionalidades(){
           
               DataTable tabla_rol = new DataTable();

                String query_obtenerRoles = "SELECT rol_codigo, rol_nombre FROM S_QUERY.Rol";
                SqlDataAdapter sda = new SqlDataAdapter(query_obtenerRoles, bd.obtenerConexion());

                try
                {
                    bd.conectar();
                    sda.Fill(tabla_rol);

                }

                catch (SqlException se)
                {
                    MessageBox.Show("An error occured while connecting to database" + se.ToString());
                }


                

                comboBox_funcionalidades.DataSource = tabla_rol;
                comboBox_funcionalidades.DisplayMember = "rol_nombre";
                comboBox_funcionalidades.ValueMember = "";

                comboBox_funcionalidades.SelectedItem = null;


                bd.desconectar();
            }

        void cargarComboBoxHabilitacion()
        {

            comboBox_habilitados.Items.Add("Roles Habilitados");
            comboBox_habilitados.Items.Add("Roles No Habilitados");
        }

        private void actualizar_tabla()
        {
            bd.conectar();

            String query_select_rol = "SELECT * FROM S_QUERY.Rol";
            SqlCommand comando = new SqlCommand(query_select_rol, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_rol.DataSource = tabla;

            //AGREGAMOS EL BOTON de eliminar
            /*DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Eliminar";
            btngrid.HeaderText = "Eliminar";
            dataGridView_rol.Columns.Add(btngrid);*/



            bd.desconectar();
        }


        private void button_actualizar_Click(object sender, EventArgs e)
        {
            this.actualizar_tabla();
        }


        private void dataGridView_rol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3){

                MessageBox.Show("SEEEEEE");


            }
            

        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int row_index = dataGridView_rol.CurrentCell.RowIndex;
            String row_codigo_rol = dataGridView_rol.CurrentRow.Cells["rol_codigo"].Value.ToString();

            try
            {
                bd.conectar();
                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.eliminarRol");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@codigo_rol_eliminar", SqlDbType.Int).Value = (int)Convert.ToInt32(row_codigo_rol);

                procedure.ExecuteNonQuery();

                bd.desconectar();
                MessageBox.Show("Se elimino el Rol.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bd.desconectar();
            }

           
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
            alta.FormClosed += new FormClosedEventHandler(afterClose);
            alta.Show();

            this.actualizar_tabla();
        }

        private void afterClose(Object sender, FormClosedEventArgs e)
        {

            this.actualizar_tabla();
            this.cargarComboBoxFuncionalidades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String row_codigo = dataGridView_rol.CurrentRow.Cells["rol_codigo"].Value.ToString();
            String row_nombre = dataGridView_rol.CurrentRow.Cells["rol_nombre"].Value.ToString();
            String row_estado = dataGridView_rol.CurrentRow.Cells["rol_estado"].Value.ToString();


            ModificarRol modificar = new ModificarRol(row_codigo, row_nombre, row_estado);
            modificar.FormClosed += new FormClosedEventHandler(afterClose);
            modificar.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        bool hayAlgunCampoLleno()
        {
            return textBox_texto_libre.Text.ToString() != "" || comboBox_habilitados.Text.ToString() != ""; 
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            bd.conectar();

            String query_select_rol = "SELECT * FROM S_QUERY.Rol";

            if(this.hayAlgunCampoLleno()){
                
                List<String> listaQuery = new List<string>();
                query_select_rol += " WHERE ";

                if (textBox_texto_libre.Text.ToString() != "")
                {
                    String query_texto_libre = "rol_nombre LIKE '%" + textBox_texto_libre.Text + "%'";
                    listaQuery.Add(query_texto_libre);
                }

                if (comboBox_habilitados.Text.ToString() != "")
                {
                    String query_habilitacion = "rol_estado = '" + this.obtener_habilitacion(comboBox_habilitados.Text.ToString()) + "'";
                    listaQuery.Add(query_habilitacion);
                }


                 query_select_rol += listaQuery.ElementAt(0);       

                for(int i = 1 ;  i < listaQuery.Count() ; i++){
                    query_select_rol += " AND " + listaQuery.ElementAt(i);
                }
                
            }

            SqlCommand comando = new SqlCommand(query_select_rol, bd.obtenerConexion());

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dataGridView_rol.DataSource = tabla;

            bd.desconectar();
        }

        private bool obtener_habilitacion(String habilitacion)
        {
            return habilitacion == "Roles Habilitados";
        }


        private bool ambosCamposLlenos(){
            return textBox_texto_libre.Text.ToString() != "" && comboBox_habilitados.Text.ToString() != "";
 
        }

        private void comboBox_funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_texto_libre.Clear();
            comboBox_funcionalidades.SelectedItem = null;
            comboBox_habilitados.SelectedItem = null;

        }

        private void groupBox_filtros_Enter(object sender, EventArgs e)
        {

        }









    }
}
