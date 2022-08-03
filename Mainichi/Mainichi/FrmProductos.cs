using ClosedXML.Excel;
using Entidades;
using Mainichi.Utilidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mainichi
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            List<Producto> lista = new N_Producto().Listar();
            Image img = null;

            foreach (Producto item in lista)
            {
                if (item.Imagen != null)
                    img = ByteToImage(item.Imagen);
                gridProductos.Rows.Add(
                    new object[]
                    {
                        "",
                        item.IdProducto,
                        item.Nombre,
                        item.Descripcion,
                        item.OCategoria.IdCategoria,
                        item.OCategoria.Descripcion,
                        item.PrecioVenta,
                        item.PrecioCompra,
                        img
                    });
                img = null; // reseteo la img del foreach
            }

            // cargar combo Categoria
            List<Categoria> listaProducto = new N_Categoria().Listar();

            foreach (Categoria item in listaProducto)
            {
                cboCategoria.Items.Add(new OpcionCombo()
                {
                    MyProperty = item.IdCategoria,
                    Texto = item.Descripcion
                });
            }
            this.cboCategoria.DisplayMember = "Texto";
            this.cboCategoria.ValueMember = "MyProperty";
            this.cboCategoria.SelectedIndex = 0; // SI NO HAY NINGUNA CATEGORIA INGRESADA TIRA UNA EXEPCION


            // cargo el combo box de busqueda con los titulos del data grid
            foreach (DataGridViewColumn columna in this.gridProductos.Columns)
            {
                if (columna.Visible == true &&
                    columna.Name != "btnSeleccionar" &&
                    columna.Name != "Imagen" &&
                    columna.Name != "PrecioVenta" &&
                    columna.Name != "PrecioCompra") // si la columna es visible
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

        private void gridProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                if (e.ColumnIndex == 0)
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

        private void Limpiar()
        {
            this.txtId.Text = "0";
            this.txtIndice.Text = "-1";
            this.txtDescripcion.Text = "";
            this.txtNombre.Text = "";
            this.txtVenta.Text = "";
            this.picImagen.Image = null;
            this.cboCategoria.SelectedIndex = 0;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            decimal precioVenta = 0;

            Producto objProducto = new Producto();
            objProducto.IdProducto = Convert.ToInt32(this.txtId.Text);
            objProducto.Nombre = this.txtNombre.Text;
            objProducto.Descripcion = this.txtDescripcion.Text;
            if (decimal.TryParse(this.txtVenta.Text, out precioVenta))
                objProducto.PrecioVenta = precioVenta;
            else
            {
                MessageBox.Show("Debe ingresar precio de venta.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenta.Select();
                return;
            }
            objProducto.PrecioCompra = decimal.Parse(this.txtPrecioCompra.Text);
            objProducto.OCategoria = new Categoria();
            objProducto.OCategoria.IdCategoria = Convert.ToInt32(((OpcionCombo)cboCategoria.SelectedItem).MyProperty);

            if (picImagen.Image == null)
                picImagen.Image = Properties.Resources.error;
            objProducto.Imagen = this.ImageToByte(picImagen.Image);

            if (objProducto.IdProducto == 0)
            {
                int idGenerado = new N_Producto().Registrar(objProducto, out mensaje);
                if (idGenerado != 0)
                {
                    this.gridProductos.Rows.Add(new object[]
                    {
                       "",
                       idGenerado,
                       txtNombre.Text,
                       txtDescripcion.Text,
                       ((OpcionCombo)cboCategoria.SelectedItem).MyProperty.ToString(),
                       ((OpcionCombo)cboCategoria.SelectedItem).Texto.ToString(),
                       this.txtVenta.Text,
                       "0.00",
                       picImagen.Image

                });
                    Limpiar();
                }
                else
                {
                    Console.WriteLine(mensaje);
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                bool resultado = new N_Producto().Editar(objProducto, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = gridProductos.Rows[Convert.ToInt32(this.txtIndice.Text)];
                    row.Cells["IdProducto"].Value = this.txtId.Text;
                    row.Cells["Nombre"].Value = this.txtNombre.Text;
                    row.Cells["Descripcion"].Value = this.txtDescripcion.Text;
                    row.Cells["PrecioVenta"].Value = this.txtVenta.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)(this.cboCategoria.SelectedItem)).MyProperty.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)(this.cboCategoria.SelectedItem)).Texto.ToString();

                    row.Cells["Imagen"].Value = this.picImagen.Image;

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void gridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProductos.Columns[e.ColumnIndex].Name == "btnSeleccionar") // si aprestate en la columna que se llama btnSleccionar
            {

                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    this.txtIndice.Text = indice.ToString();
                    this.txtId.Text = gridProductos.Rows[indice].Cells["idProducto"].Value.ToString();
                    this.txtNombre.Text = gridProductos.Rows[indice].Cells["Nombre"].Value.ToString();
                    this.txtDescripcion.Text = gridProductos.Rows[indice].Cells["Descripcion"].Value.ToString();
                    this.txtVenta.Text = gridProductos.Rows[indice].Cells["PrecioVenta"].Value.ToString();
                    this.txtPrecioCompra.Text = gridProductos.Rows[indice].Cells["PrecioCompra"].Value.ToString();
                    this.picImagen.Image = (Image)gridProductos.Rows[indice].Cells["Imagen"].Value;


                    foreach (OpcionCombo oc in this.cboCategoria.Items)
                    {
                        if (Convert.ToInt32(oc.MyProperty) == Convert.ToInt32(gridProductos.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            this.cboCategoria.SelectedIndex = cboCategoria.Items.IndexOf(oc);
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.txtId.Text) != 0)
            {
                if (MessageBox.Show("Desea Eliminar el producto " + this.txtNombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto objProducto = new Producto();
                    objProducto.IdProducto = Convert.ToInt32(this.txtId.Text);
                    Console.WriteLine(objProducto.IdProducto);
                    bool respuesta = new N_Producto().Eliminar(objProducto, out mensaje);
                    if (respuesta)
                    {
                        gridProductos.Rows.RemoveAt(Convert.ToInt32(this.txtIndice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)this.cboBusqueda.SelectedItem).MyProperty.ToString();
            Console.WriteLine(columnaFiltro);
            if (this.gridProductos.RowCount > 0)
            {
                foreach (DataGridViewRow row in gridProductos.Rows)
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
            foreach (DataGridViewRow row in gridProductos.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (gridProductos.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in gridProductos.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }

                }
                foreach (DataGridViewRow fila in gridProductos.Rows)
                {
                    if (fila.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            fila.Cells[1].Value.ToString(),
                            fila.Cells[2].Value.ToString(),
                            fila.Cells[3].Value.ToString(),
                            fila.Cells[5].Value.ToString(),
                            fila.Cells[6].Value.ToString(),
                            fila.Cells[7].Value.ToString()

                        });

                    }
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ResporteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *xlsx";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte descargado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error. No se pudo descargar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Files|*.jpg;*.jpeg;*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage = File.ReadAllBytes(openFile.FileName);
                picImagen.Image = this.ByteToImage(byteImage);

            }
        }

        //funciones 
        // convierte un array de byte a imagen
        public Image ByteToImage(byte[] byteImage)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(byteImage, 0, byteImage.Length);
            Image image = new Bitmap(ms);
            return image;

        }

        public byte[] ImageToByte(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
        }
    }
}
