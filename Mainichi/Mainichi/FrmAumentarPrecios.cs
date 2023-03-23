using CapaNegocio;
using Entidades;
using Mainichi.Utilidades;
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
    public partial class FrmAumentarPrecios : Form
    {
        private List<Producto> lista;

        public FrmAumentarPrecios()
        {
            InitializeComponent();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void FrmAumentarPrecios_Load(object sender, EventArgs e)
        {
            lista = new N_Producto().Listar();

            // cargar combo Categoria
            List<Categoria> listaProducto = new N_Categoria().Listar();

            foreach (Categoria item in listaProducto)
            {
                this.cboCategoria.Items.Add(new OpcionCombo()
                {
                    MyProperty = item.IdCategoria,
                    Texto = item.Descripcion
                });
            }
            this.cboCategoria.DisplayMember = "Texto";
            this.cboCategoria.ValueMember = "MyProperty";
            this.cboCategoria.SelectedIndex = 0; // SI NO HAY NINGUNA CATEGORIA INGRESADA TIRA UNA EXEPCION

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int porcentaje = 0;
            string mensaje = "No hay error";
            bool error = false;

            if(txtPorcentaje.Text.Trim() != "")
            {
                if( Int32.TryParse(txtPorcentaje.Text.Trim(), out porcentaje))
                {
                    foreach (Producto item in lista)
                    {
                        if(item.OCategoria.Descripcion == cboCategoria.Text)
                        {
                            item.PrecioVenta += (porcentaje * item.PrecioVenta) / 100;
                            bool resultado = new N_Producto().Editar(item, out mensaje);
                            if (resultado == false)
                            {
                                error = true;
                            }
                        }
                    }
                if(!error)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Abort;
                }
                }
                else
                {
                    MessageBox.Show("Error, no es un numero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPorcentaje.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {

                        if (e.KeyChar.ToString() == "\b")
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
