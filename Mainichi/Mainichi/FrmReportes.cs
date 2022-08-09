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
using ClosedXML.Excel;
using Entidades;

namespace Mainichi
{
    public partial class FrmReportes : Form
    {
        DateTime desde;
        DateTime hasta;

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridReporte.Rows.Clear();
            desde = dateTimeDesde.Value;
            hasta = dateTimeHasta.Value;
            
            while (DateTime.Compare(desde.Date, hasta.Date) <= 0)
            {
                Venta oVenta = new N_Venta().TraerVenta(desde);
                decimal comida = new N_Reporte().totalPorCategoria("Comida", desde);
                decimal bebida = new N_Reporte().totalPorCategoria("Bebida", desde);
                decimal cerveza = new N_Reporte().totalPorCategoria("Cerveza", desde);
                decimal canchas = new N_Reporte().totalPorCategoria("Cancha", desde);
                decimal torneo = new N_Reporte().totalPorCategoria("Torneo", desde);
                decimal kiosco = new N_Reporte().totalPorCategoria("Kiosco", desde);
                decimal golosina = new N_Reporte().totalPorCategoria("Golosina", desde);
                decimal galletitas = new N_Reporte().totalPorCategoria("Galletitas", desde);
                decimal snack = new N_Reporte().totalPorCategoria("Snack", desde);

                gridReporte.Rows.Add(
                    new object[]
                    {
                         desde.ToString("dd/MM/yyyy"),
                         comida,
                         kiosco + golosina + galletitas + snack,
                         bebida,
                         cerveza,
                         canchas,
                         torneo,
                         oVenta.Gastos,
                         oVenta.CambioAntiguo,
                         oVenta.CambioNuevo,
                         comida + kiosco + golosina + galletitas + snack+ bebida+cerveza+canchas+torneo-oVenta.Gastos+oVenta.CambioAntiguo-oVenta.CambioNuevo,
                         oVenta.MontoTotal,
                         oVenta.MercadoPago,
                         oVenta.Otro,
                         oVenta.Efectivo

                    });
                desde = desde.AddDays(1);
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
                if (gridReporte.Rows.Count < 1)
                {
                    MessageBox.Show("No hay datos para descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn columna in gridReporte.Columns)
                    {
                        if (columna.HeaderText != "" && columna.Visible)
                        {
                            dt.Columns.Add(columna.HeaderText, typeof(string));
                        }

                    }
                    foreach (DataGridViewRow fila in gridReporte.Rows)
                    {
                        if (fila.Visible)
                        {
                            dt.Rows.Add(new object[]
                            {
                                fila.Cells[0].Value.ToString(),
                                fila.Cells[1].Value.ToString(),
                                fila.Cells[2].Value.ToString(),
                                fila.Cells[3].Value.ToString(),
                                fila.Cells[4].Value.ToString(),
                                fila.Cells[5].Value.ToString(),
                                fila.Cells[6].Value.ToString(),
                                fila.Cells[7].Value.ToString(),
                                fila.Cells[8].Value.ToString(),
                                fila.Cells[9].Value.ToString(),
                                fila.Cells[10].Value.ToString(),
                                fila.Cells[11].Value.ToString(),
                                fila.Cells[12].Value.ToString(),
                                fila.Cells[13].Value.ToString()
                            });

                        }
                    }
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.FileName = string.Format("ResporteGeneral_{0}.xlsx", DateTime.Now.ToString("MMMMyyyy"));
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
    }
}
