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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            gridReporteGeneral.Rows.Clear();
            gridReporteEfectivo.Rows.Clear();
            gridReporteMercadoPago.Rows.Clear();
            desde = dateTimeDesde.Value;
            hasta = dateTimeHasta.Value;

            decimal totalComida = 0;
            decimal totalGastoComida = 0;
            decimal totalBebida = 0;
            decimal totalGastobebida = 0;
            decimal totalCancha = 0;
            decimal totalGastoCancha = 0;
            decimal totalGastosFijos = 0;
            decimal totalVarios = 0;
            decimal totalGasto = 0;
            decimal totalEntradaEf = 0;
            decimal totalBruto = 0;
            decimal totalMercadoPago = 0;
            decimal totalEfectivo = 0;
            decimal bruto = 0;






                switch (this.tabControl.SelectedIndex)
                {
                    case 0: // Reporte General
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
                            decimal juegos = new N_Reporte().totalPorCategoria("Juegos", desde);


                        gridReporteGeneral.Rows.Add(
                                new object[]
                                {
                                    desde.ToString("dd/MM/yyyy"), //Fecha  
                                    comida, // comida
                                    kiosco + golosina  + galletitas + snack, // Kiosco
                                    bebida, // Bebida
                                    cerveza, // Cerveza
                                    canchas + torneo, // Canchas
                                    juegos, // Juegos
                                    oVenta.Gastos, // Gastos
                                    oVenta.CambioAntiguo, // Cambio
                                    oVenta.CambioNuevo, // Cambio nuevo
                                    comida + kiosco + golosina + galletitas + snack+ bebida+cerveza+canchas+torneo-oVenta.Gastos+oVenta.CambioAntiguo-oVenta.CambioNuevo, // Total Entrada
                                    oVenta.MontoTotal, // Efectivo
                                    oVenta.MercadoPago, // Mp
                                    oVenta.Otro, // Otro
                                    oVenta.Efectivo // efectivo Real

                                });
                            desde = desde.AddDays(1);
                        }
                        break;
                    case 1: // Reporte Efectivo
                        while (DateTime.Compare(desde.Date, hasta.Date) <= 0)
                        {
                            Venta oVenta = new N_Venta().TraerVenta(desde);

                            decimal efectivoComida = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Comida", "Efectivo", desde);
                            decimal efectivoBebida = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Bebida", "Efectivo", desde);
                            decimal efectivoCerveza = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Cerveza", "Efectivo", desde);
                            decimal efectivoCanchas = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Cancha", "Efectivo", desde);
                            decimal efectivoTorneo = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Torneo", "Efectivo", desde);
                            decimal efectivoKiosco = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Kiosco", "Efectivo", desde);
                            decimal efectivoGolosina = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Golosina", "Efectivo", desde);
                            decimal efectivoGalletitas = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Galletitas", "Efectivo", desde);
                            decimal efectivoSnack = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Snack", "Efectivo", desde);
                            decimal efectivoJuegos = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Juegos", "Efectivo", desde);
                            List<decimal> gastosEfectivo = ObtenerGastosPorFormaPago(oVenta, "Efectivo");

                            decimal gastoBebidaEf = gastosEfectivo[0];
                            decimal gastoComidaEf = gastosEfectivo[1];
                            decimal gastoCanchasEf = gastosEfectivo[2];
                            decimal gastoBeelupEf = gastosEfectivo[3];
                            decimal gastoCervezaEf = gastosEfectivo[4];
                            decimal gastoGolosinaEf = gastosEfectivo[5];
                            decimal gastoJuegosEf = gastosEfectivo[6];
                            decimal gastoSnackEf = gastosEfectivo[7];
                            decimal gastoGalletitasEf = gastosEfectivo[8];
                            decimal gastoKioscoEf = gastosEfectivo[9];
                            decimal gastoSueldoEf = gastosEfectivo[10];
                            decimal gastoVariosEf = gastosEfectivo[11];
                            decimal gastoImpuestosEf = gastosEfectivo[12];
                            decimal gastoSuperEf = gastosEfectivo[13];

                        decimal entradaComida = efectivoComida + efectivoKiosco + efectivoGolosina + efectivoGalletitas + efectivoSnack;
                            decimal gastoComida = gastoComidaEf + gastoKioscoEf + gastoGolosinaEf + gastoGalletitasEf + gastoSnackEf + gastoSuperEf;
                            decimal entradaBebida = efectivoBebida + efectivoCerveza;
                            decimal gastoBebida = gastoBebidaEf + gastoCervezaEf;
                            decimal entradaCancha = efectivoCanchas + efectivoJuegos + efectivoTorneo;
                            decimal gastoCancha = gastoCanchasEf + gastoBeelupEf + gastoJuegosEf;
                            decimal gastoTotal = gastoBebida + gastoCancha + gastoComida + gastoVariosEf + gastoSueldoEf;
                            decimal totalEntrada = entradaBebida + entradaCancha + entradaComida;
                            gridReporteEfectivo.Rows.Add(
                                new object[]
                                {
                                        desde.ToString("dd/MM/yyyy"), //Fecha  
                                        entradaComida, // ENTRADA COMIDA
                                        gastoComida, // GASTO COMIDA
                                        entradaBebida, // ENTRADA BEBIDA
                                        gastoBebida, // GASTO BEBIDA
                                        entradaCancha, // ENTRADA CANCHAS
                                        gastoCancha, // GASTO CANCHAS
                                        gastoImpuestosEf + gastoSueldoEf, // IMPUESTOS
                                        gastoVariosEf, // GASTOS Varios
                                        gastoTotal, // Gasto
                                        oVenta.CambioAntiguo, // Cambio
                                        oVenta.CambioNuevo, // Cambio nuevo
                                        totalEntrada,
                                        oVenta.MontoTotal, // Bruto
                                        oVenta.Efectivo, // Efectivo


                                });
                            desde = desde.AddDays(1);
                            totalComida += entradaComida;
                            totalGastoComida += gastoComida;
                            totalBebida += entradaBebida;
                            totalGastobebida += gastoBebida;
                            totalCancha += entradaCancha;
                            totalGastoCancha += gastoCancha;
                            totalGastosFijos += gastoSueldoEf + gastoImpuestosEf;
                            totalVarios += gastoVariosEf;
                            totalGasto += gastoTotal;
                            totalEntradaEf += totalEntrada;
                            totalBruto += oVenta.MontoTotal;
                            totalEfectivo += oVenta.Efectivo;
                        }
                        gridReporteEfectivo.Rows.Add(
                            new object[]
                            {
                                    "TOTALES", //Fecha  
                                    totalComida, // ENTRADA COMIDA
                                    totalGastoComida, // GASTO COMIDA
                                    totalBebida, // ENTRADA BEBIDA
                                    totalGastobebida, // GASTO BEBIDA
                                    totalCancha, // ENTRADA CANCHAS
                                    totalGastoCancha, // GASTO CANCHAS
                                    totalGastosFijos,
                                    totalVarios,
                                    totalGasto, // Gastos Efectivo
                                    "------", // 
                                    "------", //
                                    totalEntradaEf,
                                    totalBruto, // EfectivoCalc
                                    totalEfectivo, // EfectivoReal
                            });
                        break;

                    case 2: // Reporte MercadoPago
                        while (DateTime.Compare(desde.Date, hasta.Date) <= 0)
                        {
                            Venta oVenta = new N_Venta().TraerVenta(desde);

                            decimal mercadoPagoComida = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Comida", "MercadoPago", desde);
                            decimal mercadoPagoBebida = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Bebida", "MercadoPago", desde);
                            decimal mercadoPagoCerveza = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Cerveza", "MercadoPago", desde);
                            decimal mercadoPagoCanchas = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Cancha", "MercadoPago", desde);
                            decimal mercadoPagoTorneo = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Torneo", "MercadoPago", desde);
                            decimal mercadoPagoKiosco = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Kiosco", "MercadoPago", desde);
                            decimal mercadoPagoGolosina = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Golosina", "MercadoPago", desde);
                            decimal mercadoPagoGalletitas = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Galletitas", "MercadoPago", desde);
                            decimal mercadoPagoSnack = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Snack", "MercadoPago", desde);
                            decimal mercadoPagoJuegos = new N_Reporte().totalEntradaPorCategoriaFormaDePago("Juegos", "MercadoPago", desde);
                            List<decimal> gastosMercadoPago = ObtenerGastosPorFormaPago(oVenta, "MercadoPago");

                            decimal gastoBebidaMp = gastosMercadoPago[0];
                            decimal gastoComidaMp = gastosMercadoPago[1];
                            decimal gastoCanchasMp = gastosMercadoPago[2];
                            decimal gastoBeelupMp = gastosMercadoPago[3];
                            decimal gastoCervezaMp = gastosMercadoPago[4];
                            decimal gastoGolosinaMp = gastosMercadoPago[5];
                            decimal gastoJuegosMp = gastosMercadoPago[6];
                            decimal gastoSnackMp = gastosMercadoPago[7];
                            decimal gastoGalletitasMp = gastosMercadoPago[8];
                            decimal gastoKioscoMp = gastosMercadoPago[9];
                            decimal gastoSueldoMp = gastosMercadoPago[10];
                            decimal gastoVariosMp = gastosMercadoPago[11]; 
                            decimal gastoImpuestosMp = gastosMercadoPago[12];
                            decimal gastoSuperMp = gastosMercadoPago[13];

                        decimal entradaComidaMp = mercadoPagoComida + mercadoPagoKiosco + mercadoPagoGolosina + mercadoPagoGalletitas + mercadoPagoSnack;
                            decimal gastoComidaMpT = gastoComidaMp + gastoKioscoMp + gastoGolosinaMp + gastoGalletitasMp + gastoSnackMp + gastoSuperMp;
                            decimal entradaBebidaMp = mercadoPagoBebida + mercadoPagoCerveza;
                            decimal gastoBebidaMpT = gastoBebidaMp + gastoCervezaMp;
                            decimal entradaCanchaMp = mercadoPagoCanchas + mercadoPagoJuegos + mercadoPagoTorneo;
                            decimal gastoCanchaMpT = gastoCanchasMp + gastoBeelupMp + gastoJuegosMp;
                            decimal gastoTotalMp = gastoBebidaMp + gastoCanchaMpT + gastoComidaMp + gastoVariosMp + gastoSueldoMp;
                        decimal totalEntradaMp = entradaComidaMp + entradaBebidaMp + entradaCanchaMp;
                        gridReporteMercadoPago.Rows.Add(
                            new object[]
                            {
                                        desde.ToString("dd/MM/yyyy"), //Fecha  
                                        entradaComidaMp, // ENTRADA COMIDA
                                        gastoComidaMpT, // GASTO COMIDA
                                        entradaBebidaMp, // ENTRADA BEBIDA
                                        gastoBebidaMpT, // GASTO BEBIDA
                                        entradaCanchaMp, // ENTRADA CANCHAS
                                        gastoCanchaMpT, // GASTO CANCHAS
                                        gastoSueldoMp + gastoImpuestosMp, // Sueldo
                                        gastoVariosMp, // GASTOS Varios
                                        gastoTotalMp, // MercadoPago
                                        totalEntradaMp, // MercadoPago
                                        totalEntradaMp - gastoTotalMp
                            }) ;
                            desde = desde.AddDays(1);

                            totalComida += entradaComidaMp;
                            totalGastoComida += gastoComidaMpT;
                            totalBebida += entradaBebidaMp;
                            totalGastobebida += gastoBebidaMpT;
                            totalCancha += entradaCanchaMp;
                            totalGastoCancha += gastoCanchaMpT;
                            totalGastosFijos += gastoSueldoMp + gastoImpuestosMp;
                            totalVarios += gastoVariosMp;
                            totalGasto += gastoTotalMp;
                            totalMercadoPago += totalEntradaMp;
                            bruto += totalEntradaMp - gastoTotalMp;
                    }
                        gridReporteMercadoPago.Rows.Add(
                            new object[]
                            {
                                    "TOTALES", //Fecha  
                                    totalComida, // ENTRADA COMIDA
                                    totalGastoComida, // GASTO COMIDA
                                    totalBebida, // ENTRADA BEBIDA
                                    totalGastobebida, // GASTO BEBIDA
                                    totalCancha, // ENTRADA CANCHAS
                                    totalGastoCancha, // GASTO CANCHAS
                                    totalGastosFijos, // Sueldo y Impuetos
                                    totalVarios, // GASTOS Varios
                                    totalGasto, // MercadoPago
                                    totalMercadoPago, // MercadoPago
                                    bruto
                            });
                        break;

                    default:
                        break;
                }
            
            
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
                if (gridReporteGeneral.Rows.Count < 1 && gridReporteEfectivo.Rows.Count < 1 && gridReporteMercadoPago.Rows.Count < 1)
                {
                    MessageBox.Show("No hay datos para descargar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    DataGridView gridReporte = null;
                    string nombreReporte = "ResporteGeneral_{0}.xlsx";
                    switch (this.tabControl.SelectedIndex)
                    {
                        case 0:
                        gridReporte = gridReporteGeneral;
                        nombreReporte = "ResporteGeneral_{0}.xlsx";
                            break;
                        case 1:
                            gridReporte = gridReporteEfectivo;
                        nombreReporte = "ResporteEfectivo_{0}.xlsx";
                            break;
                        case 2:
                            gridReporte = gridReporteMercadoPago;
                        nombreReporte = "ResporteMercapdoPago_{0}.xlsx";
                        break;

                    }
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
                            object[] data = new object[fila.Cells.Count] ;
                        for(int i=0; i< fila.Cells.Count; i++)
                        {
                            data.SetValue(fila.Cells[i].Value.ToString().Trim().Split('.')[0], i);
                        }
                        dt.Rows.Add(data);

                        }
                    }
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.FileName = string.Format(nombreReporte, DateTime.Now.ToString("MMMMyyyy"));
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

        private List<decimal> ObtenerGastosPorFormaPago(Venta oVenta,String formaDePago) // sepodriahaceren un storedprocedre
        {
            List<Categoria> categorias = new N_Categoria().Listar();
            List<decimal> totalVarios = new List<decimal>();
            for (int i = 0; i < categorias.Count; i++)
            {
                totalVarios.Add(0);
            }
            if (oVenta.ODetalleCompra != null)
            {
                for (int i = 0; i < oVenta.ODetalleCompra.Count; i++)
                {
                    //Console.WriteLine(oVenta.ODetalleCompra[i].OProducto.Nombre);
                    //Console.WriteLine(oVenta.ODetalleCompra[i].FormaDePago);
                    //Console.WriteLine(oVenta.ODetalleCompra[i].Cantidad);
                    //Console.WriteLine(oVenta.ODetalleCompra[i].PrecioCompra);
                    //Console.WriteLine(oVenta.ODetalleCompra[i].Total);
                    Producto p = new N_Producto().TraerProducto(oVenta.ODetalleCompra[i].OProducto.IdProducto);

                    for (int x = 0; x < categorias.Count; x++)
                    {
                        if (p != null && p.OCategoria.Descripcion == categorias[x].Descripcion)
                        {
                            if (oVenta.ODetalleCompra[i].FormaDePago == formaDePago)
                            {
                                   totalVarios[x] += oVenta.ODetalleCompra[i].Total;
                            }
                        }

                    }
                }

            }
            for (int i = 0; i < categorias.Count; i++)
            {
                Console.WriteLine(categorias[i].Descripcion);
                Console.WriteLine(totalVarios[i]);
            }
            return totalVarios;
        }

    }
}
