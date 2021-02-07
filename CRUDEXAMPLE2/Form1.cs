using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDEXAMPLE2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tb_empleadoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_empleadoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cRUDDB_1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cRUDDB_1DataSet.tb_empleado' Puede moverla o quitarla según sea necesario.
            this.tb_empleadoTableAdapter.Fill(this.cRUDDB_1DataSet.tb_empleado);

        }
    }
}
