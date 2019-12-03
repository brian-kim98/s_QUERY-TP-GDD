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

namespace FrbaOfertas2.AdministracionUsuarios
{
    public partial class AdministrarUsuarios : Form
    {
        public AdministrarUsuarios()
        {
            InitializeComponent();
            this.cargarDataGridConUsuarios();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Visible = true;
            label3.Text = dataGridView_usuarios.CurrentRow.Cells["usuario_nombre"].Value.ToString();
        }

        private void cargarDataGridConUsuarios()
        {
            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT usuario_codigo, usuario_nombre, usuario_contraseña, usuario_habilitado FROM S_QUERY.Usuario", bd.obtenerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView_usuarios.DataSource = dt;

                bd.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AdministrarUsuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();

                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.cambiarContraseniaUsuario");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@usuario_id", SqlDbType.Int).Value = dataGridView_usuarios.CurrentRow.Cells["usuario_codigo"].Value;
                procedure.Parameters.AddWithValue("@usuario_nueva_contrasenia", SqlDbType.VarChar).Value = textBox1.Text.ToString();
                procedure.ExecuteNonQuery();
                bd.desconectar();

                MessageBox.Show("Se ha modificado con exito");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button_terminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();

                SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.darDeBajaUsuario");
                procedure.CommandType = CommandType.StoredProcedure;
                procedure.Parameters.AddWithValue("@usuario_id", SqlDbType.Int).Value = dataGridView_usuarios.CurrentRow.Cells["usuario_codigo"].Value;
                procedure.ExecuteNonQuery();
                bd.desconectar();

                MessageBox.Show("Se ha dado de baja con exito");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
