using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainichi
{
    public partial class FrmVentasDia : Form
    {
        private List<Producto> lista;
        private DataGridView gridActivo;
        private DateTime fecha;
        private FrmCompras frmCompras;
        private bool isNew = true;

        public FrmVentasDia(DateTime fecha, FrmCompras frmCompras)
        {
            this.frmCompras = frmCompras;
            this.fecha = fecha;
            InitializeComponent();
        }

        private void FrmVentasDia_Load(object sender, EventArgs e)
        {
            if(this.lista != null)
            {
                return;
            }
            this.lista = new N_Producto().Listar();
            FrmVentasDia frm = sender as FrmVentasDia;

            int contH =0;
            int contV = 0;
            int x = 4;
            int y = 4;
            int contHB = 0;
            int contVB = 0;
            int xB = 4;
            int yB = 4;
            int contHC = 0;
            int contVC = 0;
            int xC = 4;
            int yC = 4;
            int contHG = 0;
            int contVG = 0;
            int xG = 4;
            int yG = 4;
            int height = 103; //130;
            int width = 158;//163;
            foreach (Producto prod in this.lista)
            {
                if(prod.PrecioVenta !=0)
                {

                    Button btnPrueba = new Button();
                    if (prod.Imagen != null)
                        btnPrueba.BackgroundImage = ByteToImage(prod.Imagen);
                    else
                        btnPrueba.Image = null;


                    btnPrueba.AccessibleName = prod.Nombre;
                    btnPrueba.Text = "\n\n\n\n\n" + prod.Nombre;
                    btnPrueba.Font = new Font(new FontFamily("Perpetua Titling MT"),9, FontStyle.Bold);
                    btnPrueba.Height = height;
                    btnPrueba.Width = width;
                    btnPrueba.BackgroundImageLayout = ImageLayout.Stretch;




                    btnPrueba.Click+=button_Click;
                    switch(prod.OCategoria.Descripcion)
                    {
                        case "COMIDA":
                            if (contHC == 6)
                            {
                                contVC++;
                                contHC = 0;
                                xC = 4;
                                yC = 4 + contVC * (height + 4);
                            }
                            btnPrueba.Location = new Point(xC, yC);
                            contHC++;
                            xC = 4 + contHC * (width + 4);
                            frm.tabComidas.Controls.Add(btnPrueba);
                            
                            break;
                        case "KIOSCO":
                        case "GALLETITAS":
                        case "GOLOSINA":
                        case "SNACK":
                            if (contHG == 6)
                            {
                                contVG++;
                                contHG = 0;
                                xC = 4;
                                yC = 4 + contVG * (height + 4);
                            }
                            btnPrueba.Location = new Point(xG, yG);
                            contHG++;
                            xG = 4 + contHG * (width + 4);
                            frm.tabKiosco.Controls.Add(btnPrueba);

                            break;

                        case "BEBIDA":
                        case "GASEOSA":
                        case "CERVEZA":
                        case "VINO":
                            if (contHB == 6)
                            {
                                contVB++;
                                contHB   = 0;
                                xB = 4;
                                yB = 4 + contVB * (height + 4);
                            }
                        
                            btnPrueba.Location = new Point(xB, yB);
                            contHB++;
                            xB = 4 + contHB * (width + 4);
                            frm.tabBebidas.Controls.Add(btnPrueba);
                            break;
                        default:
                            if (contH == 6)
                            {
                                contV++;
                                contH = 0;
                                x = 4;
                                y = 4 + contV * (height + 4);
                            }
                            btnPrueba.Location = new Point(x, y);
                            contH++;
                            x = 4 + contH * (width + 4);
                            frm.tabCancha.Controls.Add(btnPrueba);
                            break;

                    }
                }
            }

            this.cboVentas.SelectedIndex = 0;
            this.gridVenta.Font = new Font(new FontFamily("Century Gothic"), 9);
            this.rBtnEfectivo.Checked = true;

            // Cargo las ventas del dia, si es que el dia ya fue cargado
            Venta oVenta = new N_Venta().TraerVenta(fecha);
            List<DetalleVenta> listaDetalleVenta = oVenta.ODetalleVenta;
            if(oVenta.CambioAntiguo == 0)
                this.txtCambioAntiguo.Text = new N_Venta().TraerVenta(fecha.AddDays(-1)).CambioNuevo.ToString();
            else
                this.txtCambioAntiguo.Text = oVenta.CambioAntiguo.ToString();
            this.txtCambioFinal.Text = oVenta.CambioNuevo.ToString();
            
            if (listaDetalleVenta != null &&listaDetalleVenta.Count > 0)
            {             
                foreach (DetalleVenta item in listaDetalleVenta)
                {
                    int.TryParse(item.Cantidad.ToString(), out int cantidad);
                    gridVenta.Rows.Add( // añado al grid compra
                     new object[]
                     {
                        item.OProducto.IdProducto,
                        item.OProducto.Nombre,
                        item.PrecioVenta,
                        cantidad,
                        cantidad*(decimal)item.PrecioVenta,
                        item.FormaDePago

                     });
                }
                this.isNew = false;
                this.btnGuardar.BackColor = Color.DarkGreen;
            }
            else
            {
                this.isNew = true;
            }

            calcularTotal(txtEfectivo, "Efectivo");
            calcularTotal(txtMercadoPago, "MercadoPago");
            calcularTotal(txtOtro, "Otro");
        }


        private void button_Click(object sender, EventArgs e)
        {
            //Producto prod = this.lista[this.index];
            Button boton = sender as Button;
            int index = this.lista.FindIndex(obj => obj.Nombre == boton.AccessibleName); // obj es x elemento de la lista\\
            // si apreta el boton qeu se llama efectivo, abre un md para ingresar monto
            if(this.lista[index].Nombre.Split(' ')[0].ToLower() == "efectivo" ||
                this.lista[index].Nombre.Split(' ')[0].ToLower() == "escuelita")
            {
                mdIngresarDato md = new mdIngresarDato("Monto Personalizado", "Ingresar monto:");
                if (md.ShowDialog() == DialogResult.OK)
                {
                    if (decimal.TryParse(md.respuesta, out decimal d))
                        this.lista[index].PrecioVenta = d;
                    else
                        return;
                }
                else
                {
                    return;
                }
            }
            string formaDePago = string.Empty;
            foreach (RadioButton rBtn in panelFormaDePago.Controls)
            {
                if (rBtn.Checked)
                {
                    formaDePago = rBtn.AccessibleName;
                }
            }
            gridActivo.Rows.Add(
            new object[]
            {
                this.lista[index].IdProducto,
                this.lista[index].Nombre,
                this.lista[index].PrecioVenta,
                1,
                1*this.lista[index].PrecioVenta,
                formaDePago
            }) ;
            if (gridActivo.AccessibleName != "General")
            {
                calcularTotal(txtTotalPagar, "");

            }
            else
            {
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

        private void btnNuevaCuenta_Click(object sender, EventArgs e)
        {
            mdNuevaCuenta mdNuevaCuenta = new mdNuevaCuenta();
            mdNuevaCuenta.ShowDialog();
            if (mdNuevaCuenta.DialogResult == DialogResult.OK && mdNuevaCuenta.nombre != "" && this.cboVentas.Items.IndexOf(mdNuevaCuenta.nombre) < 0)
            {
                int index = this.cboVentas.Items.Add(mdNuevaCuenta.nombre);
                this.cboVentas.SelectedIndex = index;
                this.gridVenta.Visible = false;
                DataGridView nuevoGrid = new DataGridView();
                nuevoGrid.Location = new Point(993, 29);
                nuevoGrid.Size = new Size(285, 337); 
                nuevoGrid.Columns.Add("Id", "ID");
                nuevoGrid.Columns[0].Visible = false;
                nuevoGrid.Columns.Add("Producto", "Producto");
                nuevoGrid.Columns[1].Width = 118;
                nuevoGrid.Columns[1].Resizable = DataGridViewTriState.False;
                nuevoGrid.Columns.Add("PrecioVenta", "Precio");
                nuevoGrid.Columns[2].Width = 55;
                nuevoGrid.Columns[2].Resizable = DataGridViewTriState.False;

                nuevoGrid.Columns.Add("Cantidad", "Cant");
                nuevoGrid.Columns[3].Width = 48;
                nuevoGrid.Columns[3].Resizable = DataGridViewTriState.False;

                nuevoGrid.Columns.Add("Total", "Total");
                nuevoGrid.Columns[4].Width = 60;
                nuevoGrid.Columns[4].Resizable = DataGridViewTriState.False;

                nuevoGrid.ColumnHeadersHeight = 30;
                nuevoGrid.Font = new Font(new FontFamily("Century Gothic"), 9);
                nuevoGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                nuevoGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption;
                nuevoGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = SystemColors.MenuText;
                nuevoGrid.RowTemplate.Height = 29;
                nuevoGrid.RowHeadersVisible = false;
                nuevoGrid.AccessibleName = mdNuevaCuenta.nombre;
                nuevoGrid.BackgroundColor = Color.White;
                nuevoGrid.AllowUserToAddRows = false;
                nuevoGrid.MultiSelect = false;
                nuevoGrid.ReadOnly = true;

                this.Controls.Add(nuevoGrid);
                gridActivo = nuevoGrid;


                panelEfectivo.Visible = false;
                panelMercadoPago.Visible = false;
                panelOtro.Visible = false;
                panelCambio.Visible = false;
                btnGuardar.Visible = false;
                btnEliminar.Location = new Point(993, 287 + 29 + 51 +5); // 372
                panelFormaDePago.Location = new Point(993, 287 + 5+ 51 + 29 + 28 + 5); // 405
                panelPagar.Location = new Point(993, 287 + 5 + 29 + 51 + 28+5 + 84+ 5); // 494
                panelPagar.Visible = true;
                txtTotalPagar.Text = "0.00";
                txtVuelto.Text = "0.00";
                txtPagaCon.Text = "0.00";
            }
        }

        private void cboVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox =  sender as ComboBox;
            foreach (Control item in this.Controls)
            {
                if(item.GetType().Name == "DataGridView")
                {
                    DataGridView grid = item as DataGridView;
                    if(comboBox.SelectedItem.ToString() == grid.AccessibleName)
                    {
                        grid.Visible = true;
                        gridActivo = grid;

                        if(gridActivo.AccessibleName != "General")
                        {
                            btnGuardar.Visible = false;
                            panelEfectivo.Visible = false;
                            panelMercadoPago.Visible = false;
                            panelOtro.Visible = false;
                            panelCambio.Visible = false;
                            btnEliminar.Location = new Point(993, 372);
                            panelPagar.Visible = true;
                            panelFormaDePago.Location = new Point(993, 405);

                            calcularTotal(txtTotalPagar,"");
                        }
                        else
                        {
                            panelEfectivo.Visible = true;
                            panelMercadoPago.Visible = true;
                            panelOtro.Visible = true;
                            btnGuardar.Visible = true;
                            panelCambio.Visible = true;
                            btnEliminar.Location = new Point(993, 544);
                            panelPagar.Visible = false;
                            panelFormaDePago.Location = new Point(993, 454);
                        }
                    }
                    else
                    {
                        grid.Visible = false;
                    }
                }

            }
        }

        private void calcularTotal(TextBox txt, string FormaDePago)
        {
            decimal total = 0;
            if (gridActivo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in gridActivo.Rows)
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

        private void calcularVuelto()
        {
            decimal vuelto = 0;
            decimal pagaCon;
            if (Decimal.TryParse(txtPagaCon.Text, out pagaCon))
            {
               vuelto =  pagaCon - Convert.ToDecimal(txtTotalPagar.Text) ;

            }
            else
            {
                MessageBox.Show("No se ingreso monto de pago.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtVuelto.Text = vuelto.ToString("0.00");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.gridActivo.SelectedRows.Count > 0)
            {
                gridActivo.Rows.RemoveAt(this.gridActivo.SelectedRows[0].Index);
                if (gridActivo.AccessibleName != "General")
                {
                    calcularTotal(txtTotalPagar, "");
                }
                else
                {

                    calcularTotal(txtEfectivo, "Efectivo");
                    calcularTotal(txtMercadoPago, "MercadoPago");
                    calcularTotal(txtOtro, "Otro");


                }
            }
        }

        private void txtPagaCon_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                calcularVuelto();
            }
        }

        private void txtPagaCon_Leave(object sender, EventArgs e)
        {
            calcularVuelto();

        }

        private void txtPagaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPagaCon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void btnPagar_Click(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow item in gridActivo.Rows)
            {


               gridVenta.Rows.Add(
                new object[]
                {
                    item.Cells[0].Value.ToString(),
                    item.Cells[1].Value.ToString(),
                    item.Cells[2].Value.ToString()

                });

            }*/
            string formaDePago = string.Empty;
            foreach (RadioButton rBtn in panelFormaDePago.Controls)
            {
                if (rBtn.Checked)
                {
                    formaDePago = rBtn.AccessibleName;
                }
            }

            for (int i = 0; i < gridActivo.Rows.Count; i++)
            {
                int cantidad = 1;
                for (int x = i+1; x < gridActivo.Rows.Count; x++)
                {
                    if(gridActivo.Rows[i].Cells[1].Value.ToString() == gridActivo.Rows[x].Cells[1].Value.ToString() && 
                        gridActivo.Rows[i].Cells[1].Value.ToString().Split(' ')[0] != "Efectivo") // si los nombres de los productos son los mismos y el nombre es diferente de efectivo
                    {
                        cantidad++; // sumo la cantidad
                        gridActivo.Rows.RemoveAt(x); // saco el producto que sume en la cantidad
                        x--; // vuelvo a pasar por el mismo indice actualizado
                    }
                }

                gridVenta.Rows.Add(
                new object[]
                {
                   gridActivo.Rows[i].Cells[0].Value.ToString(),
                   gridActivo.Rows[i].Cells[1].Value.ToString(),
                   (decimal)gridActivo.Rows[i].Cells[2].Value,
                   cantidad,
                   cantidad*(decimal)gridActivo.Rows[i].Cells[2].Value,
                   formaDePago
                }) ;

            }

            this.Controls.Remove(gridActivo); // elimino el grid de la cuenta activa
            gridActivo = gridVenta; // pongo como grid acctivo al grid de ventas general
            cboVentas.Items.RemoveAt(cboVentas.SelectedIndex); // saco del combobox la cuenta finalizada

            this.cboVentas.SelectedIndex = 0; // seteo la ceunta de ventas general en el combobox
            gridActivo.Visible = true;
            panelEfectivo.Visible = true;
            panelCambio.Visible = true;
            panelMercadoPago.Visible = true;
            panelOtro.Visible = true;

            btnEliminar.Location = new Point(993, 544);
            panelPagar.Visible = false;
            txtVuelto.Text = "0.00";
            txtPagaCon.Text = "0.00";

            switch (formaDePago)
            {
                case "Efectivo":
                calcularTotal(txtEfectivo,formaDePago);
                    break;

                case "MercadoPago":
                    calcularTotal(txtMercadoPago, formaDePago);

                    break;

                default://"Otro"
                    calcularTotal(txtOtro, formaDePago);

                    break;
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

                DataTable detalleVenta = new DataTable();
                detalleVenta.Columns.Add("IdProducto", typeof(int));
                detalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
                detalleVenta.Columns.Add("Cantidad", typeof(int));
                detalleVenta.Columns.Add("Total", typeof(decimal));
                detalleVenta.Columns.Add("FormaDePago", typeof(string));
                int i = 0;
                foreach (DataGridViewRow item in gridActivo.Rows)
                {
                    int cantidad = (int)item.Cells["Cantidad"].Value;
                    for (int x = i + 1; x < gridActivo.Rows.Count; x++) //  junta todos los productos iguales en una sola fila
                    {
                        if (item.Cells["IdProducto"].Value.ToString() == gridActivo.Rows[x].Cells["IdProducto"].Value.ToString() && // si el id es el mismo
                            item.Cells["FormaDePago"].Value.ToString() == gridActivo.Rows[x].Cells["FormaDePago"].Value.ToString() && // y la forma de pago tamb
                            item.Cells["Producto"].Value.ToString().Split(' ')[0] != "Efectivo") // y el nombre es diferente de Efectivo
                        {
                            cantidad += (int)gridActivo.Rows[x].Cells["Cantidad"].Value; // sumo la cantidad
                            gridActivo.Rows.RemoveAt(x); // saco el producto que sume en la cantidad
                            x--; // vuelvo a pasar por el mismo indice actualizado
                        }
                    }
                    item.Cells["Cantidad"].Value = cantidad;
                    item.Cells["Total"].Value = cantidad * (decimal)item.Cells["PrecioVenta"].Value;


                    detalleVenta.Rows.Add( // añado a la tabla el item actual 
                     new object[]
                     {
                    int.Parse(item.Cells["IdProducto"].Value.ToString()),
                    decimal.Parse(item.Cells["PrecioVenta"].Value.ToString()),
                    cantidad,
                    cantidad*(decimal)item.Cells["PrecioVenta"].Value,
                    item.Cells["FormaDePago"].Value.ToString()

                     });
                    i++;

                }

                Venta oVenta = new Venta();
                oVenta.Fecha = fecha;
                oVenta.CambioAntiguo = decimal.Parse(this.txtCambioAntiguo.Text);
                oVenta.CambioNuevo = decimal.Parse(this.txtCambioFinal.Text);
                oVenta.Gastos = frmCompras.efectivo + frmCompras.mercadoPago + frmCompras.otro;
                oVenta.MontoTotal = Decimal.Parse(txtEfectivo.Text) - frmCompras.efectivo + oVenta.CambioAntiguo - oVenta.CambioNuevo; // este total es el efectivo total registrado en el programa
                oVenta.MercadoPago = Decimal.Parse(txtMercadoPago.Text) - frmCompras.mercadoPago;
                oVenta.Otro = Decimal.Parse(txtOtro.Text) - frmCompras.otro;
                mdIngresarDato md = new mdIngresarDato("Efectivo", "Ingresar efectivo del dia:");
            decimal efectivo;
            if (md.ShowDialog() == DialogResult.OK)
                decimal.TryParse(md.respuesta, out efectivo);
            else
                return;
            oVenta.Efectivo = efectivo; // este es el efectivo real contado a mano

            if (this.isNew)
            {
                if (new N_Venta().Registrar(oVenta, detalleVenta, frmCompras.detalleCompra, out string mensaje))
                    MessageBox.Show("Venta del " + this.fecha.ToString("dd MMMM") + " guardada.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (new N_Venta().Editar(oVenta, detalleVenta, frmCompras.detalleCompra, out string mensaje))
                    MessageBox.Show("Venta del " + this.fecha.ToString("dd MMMM") + " editada.", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

    }
}
