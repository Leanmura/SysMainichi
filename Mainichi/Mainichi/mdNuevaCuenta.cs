using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainichi
{
    public partial class mdNuevaCuenta : Form
    {
        public string nombre;

        public mdNuevaCuenta()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            nombre = this.txtNombre.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                nombre = this.txtNombre.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }

        }

        private void mdNuevaCuenta_Load(object sender, EventArgs e)
        {
            txtNombre.Select();
        }
    }
}
