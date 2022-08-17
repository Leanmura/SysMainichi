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
    public partial class FrmCompras : Form
    {
        public decimal efectivo;
        public decimal otro;
        public decimal mercadoPago;
        public DataTable detalleCompra;
        public bool hasChange = false;

        public FrmCompras( )
        {
            InitializeComponent();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            cargarProductosCompra();

            // cargo el combo box de busqueda con los titulos del data grid
            foreach (DataGridViewColumn columna in this.gridProductos.Columns)
            {
                if (columna.Visible == true &&
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

            // cargo el combo box de Forma de pago
            Array arrayFormaDePago = Enum.GetValues(typeof(FormaDePago));

            for (int i = 0; i < arrayFormaDePago.Length; i++)
            {
                this.cboFormaDePago.Items.Add(new OpcionCombo()
                {
                    MyProperty = i,
                    Texto = arrayFormaDePago.GetValue(i).ToString()
                });
            }
            this.cboFormaDePago.DisplayMember = "Texto";
            this.cboFormaDePago.ValueMember = "MyProperty";
            this.cboFormaDePago.SelectedIndex = 0;

            if(this.detalleCompra != null) // la parte de detalle de venta esta hecha de otra forma pero con la misma finalidad
            {
                foreach (DataRow item in this.detalleCompra.Rows)
                {
                    int.TryParse(item["Cantidad"].ToString(), out int cantidad);
                    Producto oProducto = new N_Producto().TraerProducto(int.Parse(item["IdProducto"].ToString()));
                    gridCompra.Rows.Add( // añado al grid compra
                     new object[]
                     {
                        (int)item["IdProducto"],
                        oProducto.Nombre,
                        item["PrecioCompra"],
                        cantidad,
                        cantidad*(decimal)item["PrecioCompra"],
                        item["FormaDePago"]

                     }) ;
                }
            }

            calcularTotal(txtEfectivo, "Efectivo");
            calcularTotal(txtMercadoPago, "MercadoPago");
            calcularTotal(txtOtro, "Otro");
            this.mercadoPago = decimal.Parse(this.txtMercadoPago.Text);
            this.efectivo = decimal.Parse(this.txtEfectivo.Text);
            this.otro = decimal.Parse(this.txtOtro.Text);
        }

        private void cargarProductosCompra()
        {
            this.gridProductos.Rows.Clear();
            List<Producto> lista = new N_Producto().Listar();

            foreach (Producto item in lista)
            {
                if (item.PrecioVenta == 0)
                {
                    gridProductos.Rows.Add(
                        new object[]
                        {
                            item.IdProducto,
                            item.Nombre,
                            item.Descripcion,
                            item.OCategoria.IdCategoria,
                            item.OCategoria.Descripcion,
                            item.PrecioVenta,
                            item.PrecioCompra,
                            item.Imagen
                        });

                }
            }
    
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)this.cboBusqueda.SelectedItem).MyProperty.ToString();
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Producto prod = this.lista[this.index];

            Button boton = sender as Button;
            string formaDePago = ((OpcionCombo)this.cboFormaDePago.SelectedItem).Texto;

            if (Decimal.Parse(this.txtPrecioCompra.Text) == 0)
            {
                MessageBox.Show("Falta precio.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Decimal.Parse(this.numericCantidad.Text) == 0)
            {
                MessageBox.Show("La cantidad no puede ser 0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                gridCompra.Rows.Add(
                new object[]
                {
                    this.gridProductos.SelectedRows[0].Cells["Id"].Value.ToString(),
                    this.gridProductos.SelectedRows[0].Cells["Nombre"].Value.ToString(),
                    Decimal.Parse(this.txtPrecioCompra.Text),
                    this.numericCantidad.Value,
                    this.numericCantidad.Value*Decimal.Parse(this.txtPrecioCompra.Text),
                    formaDePago
                }) ;
           
                    switch (formaDePago)
                    {
                        case "Efectivo":
                            calcularTotal(txtEfectivo, formaDePago);
                            break;

                        case "MercadoPago":
                            calcularTotal(txtMercadoPago, formaDePago);

                            break;

                        default://"Otro"
                            calcularTotal(txtOtro, formaDePago);

                            break;
                    }

            DataTable detalleCompra = new DataTable();
            detalleCompra.Columns.Add("IdProducto", typeof(int));
            detalleCompra.Columns.Add("PrecioCompra", typeof(decimal));
            detalleCompra.Columns.Add("Cantidad", typeof(int));
            detalleCompra.Columns.Add("Total", typeof(decimal));
            detalleCompra.Columns.Add("FormaDePago", typeof(string));

            foreach (DataGridViewRow item in gridCompra.Rows)
            {
                int.TryParse(item.Cells["Cantidad"].Value.ToString(), out int cantidad) ;

                detalleCompra.Rows.Add( // añado a la tabla el item actual 
                 new object[]
                 {
                    int.Parse(item.Cells["IdProducto"].Value.ToString()),
                    decimal.Parse(item.Cells["Precio"].Value.ToString()),
                    cantidad,
                    cantidad*(decimal)item.Cells["Precio"].Value,
                    item.Cells["FormaDePago"].Value.ToString()

                 });

            }

            this.detalleCompra = detalleCompra;
            this.mercadoPago = decimal.Parse(this.txtMercadoPago.Text);
            this.efectivo = decimal.Parse(this.txtEfectivo.Text);
            this.otro = decimal.Parse(this.txtOtro.Text);

            // Actuzalizo el precio de compra del producto
            Producto prod = new Producto();
            prod.IdProducto = (int)this.gridProductos.SelectedRows[0].Cells["Id"].Value;
            prod.Nombre = this.gridProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();
            prod.Descripcion = this.gridProductos.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            prod.OCategoria = new Categoria()
            {
                IdCategoria = (int)this.gridProductos.SelectedRows[0].Cells["IdCategoria"].Value,
                Descripcion = this.gridProductos.SelectedRows[0].Cells["Categoria"].Value.ToString()
            };
            prod.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
            prod.PrecioVenta = 0;
            prod.Imagen = (byte[])this.gridProductos.SelectedRows[0].Cells["Imagen"].Value;
            if (!new N_Producto().Editar(prod, out string mensaje))
            {
                MessageBox.Show("No se pudo actuzalizar el precio de compra del producto.\n" + mensaje, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cargarProductosCompra();
            hasChange = true;
        }

        private void calcularTotal(TextBox txt, string FormaDePago)
        {
            decimal total = 0;
            if (gridCompra.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in gridCompra.Rows)
                {
                    if (FormaDePago == "")
                    {
                        total += Convert.ToDecimal(row.Cells[4].Value.ToString());
                    }
                    else
                    {
                        if (FormaDePago == row.Cells["FormaDePago"].Value.ToString())
                            total += Convert.ToDecimal(row.Cells[4].Value.ToString());

                    }

                }

            }
            txt.Text = total.ToString("0.00");
        }

        private void gridCompra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.remove_20.Width;
                var h = Properties.Resources.remove_20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.remove_20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if ( e.KeyChar.ToString() == ".")
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

        private void gridCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCompra.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    gridCompra.Rows.RemoveAt(index);
                    calcularTotal(txtEfectivo, "Efectivo");
                    calcularTotal(txtMercadoPago, "MercadoPago");
                    calcularTotal(txtOtro, "Otro");

                }
            }
        }

        private void gridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                this.txtPrecioCompra.Text = gridProductos.Rows[indice].Cells["PrecioCompra"].Value.ToString();
            }
        }
    }
}
