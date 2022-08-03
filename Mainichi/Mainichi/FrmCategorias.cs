using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
using CapaNegocio;
using Mainichi.Utilidades;

namespace Mainichi
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

            List<Categoria> lista = new N_Categoria().Listar();

            foreach(Categoria item in lista)
            {
                gridCategorias.Rows.Add(
                    new object[]
                    {
                        "",
                        item.IdCategoria,
                        item.Descripcion
                    });
            }

            // cargo el combo box de busqueda con los titulos del data grid
            foreach(DataGridViewColumn columna in this.gridCategorias.Columns)
            {
                if(columna.Visible == true && columna.Name != "btnSeleccionar") // si la columna es visible
                {
                    this.cboBusqueda.Items.Add(new OpcionCombo()
                    {
                        MyProperty = columna.Name,
                        Texto = columna.HeaderText
                    });
                }
            }
            this.cboBusqueda.DisplayMember = "Texto";
            this.cboBusqueda.ValueMember = "MyProperty";
            this.cboBusqueda.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria objCategoria = new Categoria();
            objCategoria.Descripcion = this.txtDescripcion.Text;
            objCategoria.IdCategoria = Convert.ToInt32(this.txtId.Text);

            if(objCategoria.IdCategoria ==0)
            {

                int idGenerado = new N_Categoria().Registrar(objCategoria, out mensaje);
                if(idGenerado != 0)
                {
                    this.gridCategorias.Rows.Add(new object[]
                    {
                       "",
                       idGenerado,
                       txtDescripcion.Text,
                    });
                    Limpiar();
                }
                else
                {
                Console.WriteLine(mensaje);
                   MessageBox.Show(mensaje,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
                }
            }
            else
            {
                bool resultado = new N_Categoria().Editar(objCategoria, out mensaje);
                if(resultado)
                {
                    DataGridViewRow row = gridCategorias.Rows[Convert.ToInt32(this.txtIndice.Text)];
                    row.Cells["IdCategoria"].Value = this.txtId.Text;
                    row.Cells["Descripcion"].Value = this.txtDescripcion.Text;
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.txtId.Text = "0";
            this.txtIndice.Text = "-1";
            this.txtDescripcion.Text = "";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(this.txtId.Text) != 0)
            {
                if(MessageBox.Show("Desea Eliminar la categoria " + this.txtDescripcion.Text +"?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Categoria objCategoria = new Categoria();
                    objCategoria.IdCategoria = Convert.ToInt32(this.txtId.Text);
                    Console.WriteLine(objCategoria.IdCategoria);
                    bool respuesta = new N_Categoria().Eliminar(objCategoria, out mensaje);
                    if(respuesta)
                    {
                        gridCategorias.Rows.RemoveAt(Convert.ToInt32(this.txtIndice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        // dibuja la imagen del check en el boton del data grid
        private void gridCategorias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(!(e.RowIndex<0))
            {
                if(e.ColumnIndex == 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = Properties.Resources.check20.Width;
                    var h = Properties.Resources.check20.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                    e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                    e.Handled = true; // para que continue con el evento del click
                }

            }
        }

        // hacer que se pinta la fila cuando se toque el boton check
        private void gridCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gridCategorias.Columns[e.ColumnIndex].Name == "btnSeleccionar") // si aprestate en la columna que se llama btnSleccionar
            {

                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    this.txtIndice.Text = indice.ToString();
                    this.txtId.Text = gridCategorias.Rows[indice].Cells["idCategoria"].Value.ToString();
                    this.txtDescripcion.Text = gridCategorias.Rows[indice].Cells["descripcion"].Value.ToString();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)this.cboBusqueda.SelectedItem).MyProperty.ToString();
            Console.WriteLine(columnaFiltro);
            if(this.gridCategorias.RowCount > 0)
            {
                foreach(DataGridViewRow row in gridCategorias.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(this.txtBusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            this.txtBusqueda.Text = "";
            foreach (DataGridViewRow row in gridCategorias.Rows)
            {
               row.Visible = true;
            }
        }
    }
}
