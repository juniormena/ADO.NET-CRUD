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
    public partial class Form2 : Form
    {
        SqlConnection conn = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=Junior-Mena;Initial Catalog=CRUDDB_1;Integrated Security=True");
                conn.Open();
                cbxCriterio.SelectedIndex = 0;
                ejecutarConsulta();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("error al conectar con db" + ex.Message);
            }
        }

        private void ejecutarConsulta() 
        {
            try
            {
                string query = "SELECT * FROM tb_estudiantes WHERE " + cbxCriterio.Text + " like " + "'%" + txtBuscar.Text + "%'";
                SqlDataAdapter data = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dvgEstudiante.DataSource = dt;
                dvgEstudiante.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al realizar la consulta" + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ejecutarConsulta();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEdEstudiantes formulario = new frmEdEstudiantes();
            formulario.con = conn;
            formulario.modalidad = "C";
            formulario.ShowDialog();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            ejecutarConsulta();
        }

        private void dvgEstudiante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dvgEstudiante.SelectedRows[0];
                frmEdEstudiantes formulario = new frmEdEstudiantes();
                formulario.nombre = row.Cells[1].Value.ToString();
                formulario.matricula = row.Cells[0].Value.ToString();
                formulario.direccion = row.Cells[3].Value.ToString();
                formulario.carrera = row.Cells[2].Value.ToString();
                formulario.modalidad = "U";
                formulario.con = conn;
                formulario.ShowDialog();


            }
            catch(Exception ex) {
                MessageBox.Show("Error al editar registro: " + ex.Message);
            }
        }
    }
}
