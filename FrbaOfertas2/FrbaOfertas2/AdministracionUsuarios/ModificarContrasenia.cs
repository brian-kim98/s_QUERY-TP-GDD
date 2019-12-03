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

namespace FrbaOfertas2.AdministracionUsuarios
{
    public partial class ModificarContrasenia : Form
    {
        int codigo_user;

        public ModificarContrasenia(int codigo_usuario)
        {
            InitializeComponent();
            codigo_user = codigo_usuario;
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            if (this.seVerificoLaNuevaContrasenia() && this.laContraseniaViejaEsCorrecta())
            {
                BaseDeDato bd = new BaseDeDato();
 
                try
                {
                    bd.conectar();
    
                    SqlCommand procedure = Clases.BaseDeDato.crearConsulta("S_QUERY.cambiarContraseniaUsuario");
                    procedure.CommandType = CommandType.StoredProcedure;
                    procedure.Parameters.AddWithValue("@usuario_id", SqlDbType.Int).Value = codigo_user;
                    procedure.Parameters.AddWithValue("@usuario_nueva_contrasenia", SqlDbType.VarChar).Value = textBox_nuevaContra.Text.ToString();
      
                    procedure.ExecuteNonQuery();
                    bd.desconectar();

                    MessageBox.Show("Se ha modificado con exito");
                    this.Close();
                }

                catch (Exception ex)
                {
                    bd.desconectar();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool seVerificoLaNuevaContrasenia()
        {
            return textBox_nuevaContra.Text.ToString() == textBox_validacionNuevaContra.Text.ToString();
        }

        private bool laContraseniaViejaEsCorrecta()
        {
            BaseDeDato bd = new BaseDeDato();

            try
            {
                bd.conectar();
                SqlCommand command = new SqlCommand("SELECT S_QUERY.compararContrasenias(@usuario_id, @contrasenia_prevista)", bd.obtenerConexion());
                SqlParameter usuario = new SqlParameter("@usuario_id", SqlDbType.Int);
                SqlParameter contraseniaNueva = new SqlParameter("@contrasenia_prevista", SqlDbType.VarChar);
                usuario.Value = codigo_user;
                contraseniaNueva.Value = textBox_viejaContra.Text.ToString();
                command.Parameters.Add(usuario);
                command.Parameters.Add(contraseniaNueva);

                int retorno = (int)command.ExecuteScalar();

                bd.desconectar();

                if (retorno == 1)
                {

                    return true;
                }
                else
                {
                    MessageBox.Show("Contraseña previa incorrecta.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                bd.desconectar();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
