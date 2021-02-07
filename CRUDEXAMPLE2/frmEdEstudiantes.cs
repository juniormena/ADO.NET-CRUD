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

namespace CRUDEXAMPLE2
{
    public partial class frmEdEstudiantes : Form
    {
        public SqlConnection con { get; set; }
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string carrera { get; set; }
        public string modalidad { get; set; }

        public frmEdEstudiantes()
        {
            InitializeComponent();
        }

        private void frmEdEstudiantes_Load(object sender, EventArgs e)
        {
            try
            {
                txtMatricula.Text = matricula;
                txtNombre.Text = nombre;
                txtDireccion.Text = direccion;
                txtCarrera.Text = carrera;
                txtMatricula.Enabled = modalidad.Equals("C");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al asignar valores");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                if (modalidad.Equals("C"))
                {
                    sql = "INSERT INTO tb_estudiantes (Matricula, Nombre, Carrera, Direccion) VALUES (@Matricula, @Nombre, @Carrera, @Direccion)";
                }
                else 
                {
                    sql = "UPDATE tb_estudiantes SET Nombre = @Nombre, Direccion = @Direccion, Carrera = @Carrera WHERE Matricula = @Matricula";
                }
                
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar, 50).Value = txtMatricula.Text;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = txtNombre.Text;
                cmd.Parameters.Add("@Carrera", SqlDbType.VarChar, 50).Value = txtCarrera.Text;
                cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 50).Value = txtDireccion.Text;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro guardado con exito");
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("error al guardar registro " + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE tb_estudiantes WHERE Matricula = @Matricula";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@Matricula", SqlDbType.VarChar, 50).Value = txtMatricula.Text;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado con exito");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el registro");
            }
        }
    }
}
