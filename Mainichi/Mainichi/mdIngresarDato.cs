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
    public partial class mdIngresarDato : Form
    {
        public string respuesta;

        public mdIngresarDato(string titulo, string info)
        {
            InitializeComponent();
            this.Text = titulo;
            lblInfo.Text = info;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.respuesta = this.txtRespuesta.Text;
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void txtRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtRespuesta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;

                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;

                    }
                }
            }
        }

        private void mdIngresarDato_Load(object sender, EventArgs e)
        {
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            
            lblInfo.Location = new Point((this.Size.Width-10 - lblInfo.Size.Width)/2,27);
            txtRespuesta.Location = new Point((this.Size.Width - 10 - txtRespuesta.Size.Width) / 2, 49);
            btnIngresar.Location = new Point((this.Size.Width - 10 - btnIngresar.Size.Width) / 2, 14);
        }
    }
}
