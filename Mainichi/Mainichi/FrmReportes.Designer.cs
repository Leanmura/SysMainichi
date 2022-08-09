
namespace Mainichi
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDescargar = new FontAwesome.Sharp.IconButton();
            this.gridReporte = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bebida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cerveza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Canchas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Torneo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CambioAntiguo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CambioNuevo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MercadoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Otro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblReporteGeneral = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDescargar
            // 
            this.btnDescargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDescargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.ForeColor = System.Drawing.Color.Black;
            this.btnDescargar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDescargar.IconColor = System.Drawing.Color.Black;
            this.btnDescargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargar.IconSize = 18;
            this.btnDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargar.Location = new System.Drawing.Point(1147, 667);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDescargar.Size = new System.Drawing.Size(105, 28);
            this.btnDescargar.TabIndex = 49;
            this.btnDescargar.Text = "Descargar ";
            this.btnDescargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // gridReporte
            // 
            this.gridReporte.AllowUserToAddRows = false;
            this.gridReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReporte.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Comida,
            this.Bebida,
            this.Cerveza,
            this.Canchas,
            this.Torneo,
            this.Gastos,
            this.CambioAntiguo,
            this.CambioNuevo,
            this.Total,
            this.Efectivo,
            this.MercadoPago,
            this.Otro,
            this.TotalReal});
            this.gridReporte.Location = new System.Drawing.Point(12, 92);
            this.gridReporte.MultiSelect = false;
            this.gridReporte.Name = "gridReporte";
            this.gridReporte.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReporte.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridReporte.RowHeadersVisible = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.gridReporte.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gridReporte.RowTemplate.Height = 25;
            this.gridReporte.Size = new System.Drawing.Size(1240, 569);
            this.gridReporte.TabIndex = 42;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 147;
            // 
            // Comida
            // 
            this.Comida.HeaderText = "Comida";
            this.Comida.Name = "Comida";
            this.Comida.ReadOnly = true;
            this.Comida.Width = 75;
            // 
            // Bebida
            // 
            this.Bebida.HeaderText = "Bebida";
            this.Bebida.Name = "Bebida";
            this.Bebida.ReadOnly = true;
            this.Bebida.Width = 75;
            // 
            // Cerveza
            // 
            this.Cerveza.HeaderText = "Cerveza";
            this.Cerveza.Name = "Cerveza";
            this.Cerveza.ReadOnly = true;
            this.Cerveza.Width = 75;
            // 
            // Canchas
            // 
            this.Canchas.HeaderText = "Canchas";
            this.Canchas.Name = "Canchas";
            this.Canchas.ReadOnly = true;
            this.Canchas.Width = 75;
            // 
            // Torneo
            // 
            this.Torneo.HeaderText = "Torneo";
            this.Torneo.Name = "Torneo";
            this.Torneo.ReadOnly = true;
            this.Torneo.Width = 75;
            // 
            // Gastos
            // 
            this.Gastos.HeaderText = "Gastos";
            this.Gastos.Name = "Gastos";
            this.Gastos.ReadOnly = true;
            this.Gastos.Width = 75;
            // 
            // CambioAntiguo
            // 
            this.CambioAntiguo.HeaderText = "Cambio";
            this.CambioAntiguo.Name = "CambioAntiguo";
            this.CambioAntiguo.ReadOnly = true;
            this.CambioAntiguo.Width = 75;
            // 
            // CambioNuevo
            // 
            this.CambioNuevo.HeaderText = "Cambio Nuevo";
            this.CambioNuevo.Name = "CambioNuevo";
            this.CambioNuevo.ReadOnly = true;
            this.CambioNuevo.Width = 75;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total Entrada";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 75;
            // 
            // Efectivo
            // 
            this.Efectivo.HeaderText = "Efectivo";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.ReadOnly = true;
            this.Efectivo.Width = 75;
            // 
            // MercadoPago
            // 
            this.MercadoPago.HeaderText = "MP";
            this.MercadoPago.Name = "MercadoPago";
            this.MercadoPago.ReadOnly = true;
            this.MercadoPago.Width = 75;
            // 
            // Otro
            // 
            this.Otro.HeaderText = "Otro";
            this.Otro.Name = "Otro";
            this.Otro.ReadOnly = true;
            this.Otro.Width = 75;
            // 
            // TotalReal
            // 
            this.TotalReal.HeaderText = "Total Real";
            this.TotalReal.Name = "TotalReal";
            this.TotalReal.ReadOnly = true;
            this.TotalReal.Width = 75;
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.CustomFormat = "dd/MM/yyyy";
            this.dateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDesde.Location = new System.Drawing.Point(892, 30);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(97, 20);
            this.dateTimeDesde.TabIndex = 50;
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.CustomFormat = "dd/MM/yyyy";
            this.dateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeHasta.Location = new System.Drawing.Point(1059, 30);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(97, 20);
            this.dateTimeHasta.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.lblDesde);
            this.panel1.Controls.Add(this.lblReporteGeneral);
            this.panel1.Controls.Add(this.dateTimeHasta);
            this.panel1.Controls.Add(this.dateTimeDesde);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 74);
            this.panel1.TabIndex = 52;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 16;
            this.btnBuscar.Location = new System.Drawing.Point(1169, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(45, 20);
            this.btnBuscar.TabIndex = 55;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.BackColor = System.Drawing.Color.White;
            this.lblHasta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(1004, 31);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(49, 17);
            this.lblHasta.TabIndex = 54;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.BackColor = System.Drawing.Color.White;
            this.lblDesde.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(834, 30);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(52, 17);
            this.lblDesde.TabIndex = 53;
            this.lblDesde.Text = "Desde:";
            // 
            // lblReporteGeneral
            // 
            this.lblReporteGeneral.AutoSize = true;
            this.lblReporteGeneral.BackColor = System.Drawing.Color.White;
            this.lblReporteGeneral.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporteGeneral.Location = new System.Drawing.Point(23, 25);
            this.lblReporteGeneral.Name = "lblReporteGeneral";
            this.lblReporteGeneral.Size = new System.Drawing.Size(179, 25);
            this.lblReporteGeneral.TabIndex = 52;
            this.lblReporteGeneral.Text = "Reporte General";
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 711);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.gridReporte);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnDescargar;
        private System.Windows.Forms.DataGridView gridReporte;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReporteGeneral;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bebida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cerveza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Canchas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Torneo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CambioAntiguo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CambioNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MercadoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Otro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalReal;
    }
}