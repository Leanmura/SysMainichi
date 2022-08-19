using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Entidades;
using FontAwesome.Sharp;
namespace Mainichi
{
    public partial class FrmPrincipal : Form
    {

        private static Form frmActivo;
        private static IconMenuItem menuActivo = null;
        private FrmVentasDia frmVentasDia = null;
        private FrmCompras frmCompras = null;


        public FrmPrincipal()
        {
            InitializeComponent();

            this.frmCompras = new FrmCompras();

            this.frmVentasDia = new FrmVentasDia(this.dateTimePicker.Value, this.frmCompras);
            
        }

        private void AbrirFrmHijo(IconMenuItem menu ,Form formHijo)
        {
            if(FrmPrincipal.menuActivo != null)
            {
                FrmPrincipal.menuActivo.BackColor = SystemColors.Control;
            }
            menu.BackColor = Color.Silver;
            FrmPrincipal.menuActivo = menu;

            if(FrmPrincipal.frmActivo != null )
            {
                if (FrmPrincipal.frmActivo != this.frmVentasDia && FrmPrincipal.frmActivo != this.frmCompras)
                    FrmPrincipal.frmActivo.Close();
                else
                    if (FrmPrincipal.frmActivo == this.frmVentasDia)
                        this.frmVentasDia.Visible = false;
                    else
                        this.frmCompras.Visible = false;
            }
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            
            FrmPrincipal.frmActivo = formHijo;
            /*if (this.panel.Controls.Count > 0)
            {
                this.panel.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel.Controls.Add(fh);
            this.panel.Tag = fh;
            fh.Show();*/

            this.panel.Controls.Add(FrmPrincipal.frmActivo);
            FrmPrincipal.frmActivo.Show();
            
        }


        private void menuVentas_Click(object sender, EventArgs e)
        {
            this.AbrirFrmHijo((IconMenuItem) sender ,this.frmVentasDia);
        }

        private void menuCompras_Click(object sender, EventArgs e)
        {
            this.AbrirFrmHijo((IconMenuItem)sender, this.frmCompras);
        }


        private void menuReportes_Click(object sender, EventArgs e)
        {
            this.AbrirFrmHijo((IconMenuItem)sender, new FrmReportes());

        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            new mdAcercaDe().ShowDialog();

        }

        private void subMenuCategorias_Click(object sender, EventArgs e)
        {
            this.AbrirFrmHijo(this.menuProductos, new FrmCategorias());
        }

        private void subMenuProductos_Click(object sender, EventArgs e)
        {
            this.AbrirFrmHijo(this.menuProductos, new FrmProductos());
        }

        private void menuConfiguracion_Click(object sender, EventArgs e)
        {
            this.AbrirFrmHijo(this.menuConfiguracion, new FrmNegocio());

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Venta oVenta = new N_Venta().TraerVenta(((DateTimePicker)sender).Value);

            // copio mis detalles de compras en un datatable
            DataTable detalleCompra = new DataTable();
            detalleCompra.Columns.Add("IdProducto", typeof(int));
            detalleCompra.Columns.Add("PrecioCompra", typeof(decimal));
            detalleCompra.Columns.Add("Cantidad", typeof(int));
            detalleCompra.Columns.Add("Total", typeof(decimal));
            detalleCompra.Columns.Add("FormaDePago", typeof(string));
            if (oVenta.IdVenta != 0)
            {
                foreach (DetalleCompra item in oVenta.ODetalleCompra)
                {
                    detalleCompra.Rows.Add( // añado a la tabla el item actual 
                     new object[]
                     {
                            item.OProducto.IdProducto,
                            item.PrecioCompra,
                            item.Cantidad,
                            item.Cantidad*item.PrecioCompra,
                            item.FormaDePago

                     });

                }

            }
            if (FrmPrincipal.frmActivo == this.frmVentasDia)
            {
                this.frmCompras.Close();
                this.frmCompras = new FrmCompras(); // es al pedo crear simpr euna instancia nueva, solo hay que borrar el datagrid

                this.frmCompras.detalleCompra = detalleCompra;

                this.frmVentasDia.Close();
                FrmPrincipal.frmActivo = new FrmVentasDia(((DateTimePicker)sender).Value, this.frmCompras);
                FrmPrincipal.frmActivo.TopLevel = false;

                this.frmVentasDia = (FrmVentasDia)frmActivo;
                this.panel.Controls.Add(this.frmVentasDia);

                FrmPrincipal.frmActivo.Show();
            }
            else
            {
                if (FrmPrincipal.frmActivo == this.frmCompras)
                {
                    FrmPrincipal.frmActivo = new FrmCompras();
                    FrmPrincipal.frmActivo.TopLevel = false;
                    this.frmCompras.Close();
                    this.frmCompras = (FrmCompras)frmActivo;
                    this.frmCompras.detalleCompra = detalleCompra;
                    this.panel.Controls.Add(this.frmCompras);
                    FrmPrincipal.frmActivo.Show();
                }
                else
                {
                    this.frmCompras.Close();
                   this.frmCompras = new FrmCompras();
                    this.frmCompras.detalleCompra = detalleCompra;
                }

                this.frmVentasDia.Close();
                this.frmVentasDia = new FrmVentasDia(((DateTimePicker)sender).Value, this.frmCompras);
            }

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Venta oVenta = new N_Venta().TraerVenta(this.dateTimePicker.Value);

            //this.frmCompras = new FrmCompras(); // es al pedo crear simpr euna instancia nueva, solo hay que borrar el datagrid

            // copio mis detalles de compras en un datatable
                DataTable detalleCompra = new DataTable();
                detalleCompra.Columns.Add("IdProducto", typeof(int));
                detalleCompra.Columns.Add("PrecioCompra", typeof(decimal));
                detalleCompra.Columns.Add("Cantidad", typeof(int));
                detalleCompra.Columns.Add("Total", typeof(decimal));
                detalleCompra.Columns.Add("FormaDePago", typeof(string));
            if (oVenta.IdVenta != 0) // si es distinto de 0 es por que ahayo una venta
            {
                foreach (DetalleCompra item in oVenta.ODetalleCompra)
                {
                    detalleCompra.Rows.Add( // añado a la tabla el item actual 
                     new object[]
                     {
                    item.OProducto.IdProducto,
                    item.PrecioCompra,
                    item.Cantidad,
                    item.Cantidad*item.PrecioCompra,
                    item.FormaDePago

                     });

                }
            }
                this.frmCompras.detalleCompra = detalleCompra;
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(frmVentasDia.hasChange || frmCompras.hasChange)
            {
                DialogResult respuesta = MessageBox.Show("Hay cambios que no han sido guardados. Desea cerrar igualmente?", "SysMainichi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }

            }
        }


    }
}
