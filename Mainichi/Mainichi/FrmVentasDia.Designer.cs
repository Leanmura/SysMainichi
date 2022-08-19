
namespace Mainichi
{
    partial class FrmVentasDia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabKiosco = new System.Windows.Forms.TabPage();
            this.tabComidas = new System.Windows.Forms.TabPage();
            this.tabBebidas = new System.Windows.Forms.TabPage();
            this.panelPagar = new System.Windows.Forms.Panel();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.btnPagar = new FontAwesome.Sharp.IconButton();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.lblPagaCon = new System.Windows.Forms.Label();
            this.txtPagaCon = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCancha = new System.Windows.Forms.TabPage();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.gridVenta = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboVentas = new System.Windows.Forms.ComboBox();
            this.btnNuevaCuenta = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.panelEfectivo = new System.Windows.Forms.Panel();
            this.rBtnMP = new System.Windows.Forms.RadioButton();
            this.panelFormaDePago = new System.Windows.Forms.Panel();
            this.rBtnOtro = new System.Windows.Forms.RadioButton();
            this.rBtnEfectivo = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.panelOtro = new System.Windows.Forms.Panel();
            this.lblOtro = new System.Windows.Forms.Label();
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.txtMercadoPago = new System.Windows.Forms.TextBox();
            this.lblMercadoPago = new System.Windows.Forms.Label();
            this.panelMercadoPago = new System.Windows.Forms.Panel();
            this.panelCambio = new System.Windows.Forms.Panel();
            this.txtCambioFinal = new System.Windows.Forms.TextBox();
            this.lblCambioAntiguo = new System.Windows.Forms.Label();
            this.txtCambioAntiguo = new System.Windows.Forms.TextBox();
            this.lblCambioFinal = new System.Windows.Forms.Label();
            this.panelPagar.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVenta)).BeginInit();
            this.panelEfectivo.SuspendLayout();
            this.panelFormaDePago.SuspendLayout();
            this.panelOtro.SuspendLayout();
            this.panelMercadoPago.SuspendLayout();
            this.panelCambio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabKiosco
            // 
            this.tabKiosco.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabKiosco.Location = new System.Drawing.Point(4, 29);
            this.tabKiosco.Name = "tabKiosco";
            this.tabKiosco.Padding = new System.Windows.Forms.Padding(3);
            this.tabKiosco.Size = new System.Drawing.Size(977, 543);
            this.tabKiosco.TabIndex = 2;
            this.tabKiosco.Text = "Kiosco";
            this.tabKiosco.UseVisualStyleBackColor = true;
            // 
            // tabComidas
            // 
            this.tabComidas.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabComidas.Location = new System.Drawing.Point(4, 29);
            this.tabComidas.Name = "tabComidas";
            this.tabComidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabComidas.Size = new System.Drawing.Size(977, 543);
            this.tabComidas.TabIndex = 1;
            this.tabComidas.Text = "Comidas";
            this.tabComidas.UseVisualStyleBackColor = true;
            // 
            // tabBebidas
            // 
            this.tabBebidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabBebidas.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabBebidas.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBebidas.Location = new System.Drawing.Point(4, 29);
            this.tabBebidas.Margin = new System.Windows.Forms.Padding(5);
            this.tabBebidas.Name = "tabBebidas";
            this.tabBebidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabBebidas.Size = new System.Drawing.Size(977, 543);
            this.tabBebidas.TabIndex = 0;
            this.tabBebidas.Text = "Bebidas";
            this.tabBebidas.UseVisualStyleBackColor = true;
            // 
            // panelPagar
            // 
            this.panelPagar.BackColor = System.Drawing.SystemColors.Window;
            this.panelPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPagar.Controls.Add(this.lblTotalPagar);
            this.panelPagar.Controls.Add(this.btnPagar);
            this.panelPagar.Controls.Add(this.txtTotalPagar);
            this.panelPagar.Controls.Add(this.lblPagaCon);
            this.panelPagar.Controls.Add(this.txtPagaCon);
            this.panelPagar.Controls.Add(this.lblVuelto);
            this.panelPagar.Controls.Add(this.txtVuelto);
            this.panelPagar.Location = new System.Drawing.Point(993, 290);
            this.panelPagar.Name = "panelPagar";
            this.panelPagar.Size = new System.Drawing.Size(285, 137);
            this.panelPagar.TabIndex = 33;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.Location = new System.Drawing.Point(24, 12);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(51, 16);
            this.lblTotalPagar.TabIndex = 38;
            this.lblTotalPagar.Text = "TOTAL:";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.btnPagar.IconColor = System.Drawing.Color.White;
            this.btnPagar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPagar.IconSize = 20;
            this.btnPagar.Location = new System.Drawing.Point(62, 100);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(169, 28);
            this.btnPagar.TabIndex = 32;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(81, 9);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(173, 20);
            this.txtTotalPagar.TabIndex = 37;
            this.txtTotalPagar.Text = "0.00";
            // 
            // lblPagaCon
            // 
            this.lblPagaCon.AutoSize = true;
            this.lblPagaCon.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagaCon.Location = new System.Drawing.Point(24, 40);
            this.lblPagaCon.Name = "lblPagaCon";
            this.lblPagaCon.Size = new System.Drawing.Size(85, 16);
            this.lblPagaCon.TabIndex = 36;
            this.lblPagaCon.Text = "PAGA CON:";
            // 
            // txtPagaCon
            // 
            this.txtPagaCon.Location = new System.Drawing.Point(115, 37);
            this.txtPagaCon.Name = "txtPagaCon";
            this.txtPagaCon.Size = new System.Drawing.Size(139, 20);
            this.txtPagaCon.TabIndex = 35;
            this.txtPagaCon.Text = "0.00";
            this.txtPagaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagaCon_KeyPress);
            this.txtPagaCon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPagaCon_KeyUp);
            this.txtPagaCon.Leave += new System.EventHandler(this.txtPagaCon_Leave);
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.Location = new System.Drawing.Point(24, 68);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(59, 16);
            this.lblVuelto.TabIndex = 34;
            this.lblVuelto.Text = "VUELTO:";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Location = new System.Drawing.Point(89, 65);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(165, 20);
            this.txtVuelto.TabIndex = 33;
            this.txtVuelto.Text = "0.00";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBebidas);
            this.tabControl.Controls.Add(this.tabComidas);
            this.tabControl.Controls.Add(this.tabKiosco);
            this.tabControl.Controls.Add(this.tabCancha);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl.ItemSize = new System.Drawing.Size(70, 25);
            this.tabControl.Location = new System.Drawing.Point(4, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(985, 576);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabCancha
            // 
            this.tabCancha.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabCancha.Location = new System.Drawing.Point(4, 29);
            this.tabCancha.Name = "tabCancha";
            this.tabCancha.Padding = new System.Windows.Forms.Padding(3);
            this.tabCancha.Size = new System.Drawing.Size(977, 543);
            this.tabCancha.TabIndex = 3;
            this.tabCancha.Text = "Canchas";
            this.tabCancha.UseVisualStyleBackColor = true;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(106, 11);
            this.txtEfectivo.Multiline = true;
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.ReadOnly = true;
            this.txtEfectivo.Size = new System.Drawing.Size(94, 29);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.Text = "0.00";
            // 
            // gridVenta
            // 
            this.gridVenta.AccessibleName = "General";
            this.gridVenta.AllowUserToAddRows = false;
            this.gridVenta.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridVenta.ColumnHeadersHeight = 30;
            this.gridVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.PrecioVenta,
            this.Cantidad,
            this.Total,
            this.FormaDePago});
            this.gridVenta.Location = new System.Drawing.Point(993, 29);
            this.gridVenta.MultiSelect = false;
            this.gridVenta.Name = "gridVenta";
            this.gridVenta.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridVenta.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.gridVenta.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridVenta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridVenta.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            this.gridVenta.RowTemplate.Height = 29;
            this.gridVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVenta.Size = new System.Drawing.Size(285, 419);
            this.gridVenta.TabIndex = 28;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "ID";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 50;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Producto.Width = 102;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrecioVenta.Width = 60;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "C";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 30;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 60;
            // 
            // FormaDePago
            // 
            this.FormaDePago.HeaderText = "P";
            this.FormaDePago.Name = "FormaDePago";
            this.FormaDePago.ReadOnly = true;
            this.FormaDePago.Width = 30;
            // 
            // cboVentas
            // 
            this.cboVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVentas.FormattingEnabled = true;
            this.cboVentas.Items.AddRange(new object[] {
            "General"});
            this.cboVentas.Location = new System.Drawing.Point(992, 4);
            this.cboVentas.Name = "cboVentas";
            this.cboVentas.Size = new System.Drawing.Size(154, 21);
            this.cboVentas.TabIndex = 29;
            this.cboVentas.SelectedIndexChanged += new System.EventHandler(this.cboVentas_SelectedIndexChanged);
            // 
            // btnNuevaCuenta
            // 
            this.btnNuevaCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCuenta.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCuenta.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevaCuenta.IconColor = System.Drawing.Color.Green;
            this.btnNuevaCuenta.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnNuevaCuenta.IconSize = 20;
            this.btnNuevaCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaCuenta.Location = new System.Drawing.Point(1157, 4);
            this.btnNuevaCuenta.Name = "btnNuevaCuenta";
            this.btnNuevaCuenta.Size = new System.Drawing.Size(120, 23);
            this.btnNuevaCuenta.TabIndex = 30;
            this.btnNuevaCuenta.Text = "Nueva Cuenta";
            this.btnNuevaCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevaCuenta.UseVisualStyleBackColor = true;
            this.btnNuevaCuenta.Click += new System.EventHandler(this.btnNuevaCuenta_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 16;
            this.btnEliminar.Location = new System.Drawing.Point(993, 545);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(285, 28);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.Location = new System.Drawing.Point(3, 15);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(97, 25);
            this.lblEfectivo.TabIndex = 32;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // panelEfectivo
            // 
            this.panelEfectivo.BackColor = System.Drawing.SystemColors.Window;
            this.panelEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEfectivo.Controls.Add(this.lblEfectivo);
            this.panelEfectivo.Controls.Add(this.txtEfectivo);
            this.panelEfectivo.Location = new System.Drawing.Point(5, 581);
            this.panelEfectivo.Name = "panelEfectivo";
            this.panelEfectivo.Size = new System.Drawing.Size(208, 51);
            this.panelEfectivo.TabIndex = 0;
            // 
            // rBtnMP
            // 
            this.rBtnMP.AccessibleName = "MercadoPago";
            this.rBtnMP.AutoSize = true;
            this.rBtnMP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rBtnMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnMP.Location = new System.Drawing.Point(11, 2);
            this.rBtnMP.Name = "rBtnMP";
            this.rBtnMP.Size = new System.Drawing.Size(119, 21);
            this.rBtnMP.TabIndex = 0;
            this.rBtnMP.TabStop = true;
            this.rBtnMP.Text = "MercadoPago";
            this.rBtnMP.UseVisualStyleBackColor = true;
            // 
            // panelFormaDePago
            // 
            this.panelFormaDePago.BackColor = System.Drawing.SystemColors.Window;
            this.panelFormaDePago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormaDePago.Controls.Add(this.rBtnOtro);
            this.panelFormaDePago.Controls.Add(this.rBtnEfectivo);
            this.panelFormaDePago.Controls.Add(this.rBtnMP);
            this.panelFormaDePago.Location = new System.Drawing.Point(993, 454);
            this.panelFormaDePago.Name = "panelFormaDePago";
            this.panelFormaDePago.Size = new System.Drawing.Size(285, 84);
            this.panelFormaDePago.TabIndex = 1;
            // 
            // rBtnOtro
            // 
            this.rBtnOtro.AccessibleName = "Otro";
            this.rBtnOtro.AutoSize = true;
            this.rBtnOtro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rBtnOtro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnOtro.Location = new System.Drawing.Point(11, 56);
            this.rBtnOtro.Name = "rBtnOtro";
            this.rBtnOtro.Size = new System.Drawing.Size(55, 21);
            this.rBtnOtro.TabIndex = 2;
            this.rBtnOtro.TabStop = true;
            this.rBtnOtro.Text = "Otro";
            this.rBtnOtro.UseVisualStyleBackColor = true;
            // 
            // rBtnEfectivo
            // 
            this.rBtnEfectivo.AccessibleName = "Efectivo";
            this.rBtnEfectivo.AutoSize = true;
            this.rBtnEfectivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rBtnEfectivo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnEfectivo.Location = new System.Drawing.Point(11, 29);
            this.rBtnEfectivo.Name = "rBtnEfectivo";
            this.rBtnEfectivo.Size = new System.Drawing.Size(78, 21);
            this.rBtnEfectivo.TabIndex = 1;
            this.rBtnEfectivo.TabStop = true;
            this.rBtnEfectivo.Text = "Efectivo";
            this.rBtnEfectivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 20;
            this.btnGuardar.Location = new System.Drawing.Point(993, 579);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(285, 51);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panelOtro
            // 
            this.panelOtro.BackColor = System.Drawing.SystemColors.Window;
            this.panelOtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOtro.Controls.Add(this.lblOtro);
            this.panelOtro.Controls.Add(this.txtOtro);
            this.panelOtro.Location = new System.Drawing.Point(419, 581);
            this.panelOtro.Name = "panelOtro";
            this.panelOtro.Size = new System.Drawing.Size(181, 51);
            this.panelOtro.TabIndex = 34;
            // 
            // lblOtro
            // 
            this.lblOtro.AutoSize = true;
            this.lblOtro.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtro.Location = new System.Drawing.Point(3, 15);
            this.lblOtro.Name = "lblOtro";
            this.lblOtro.Size = new System.Drawing.Size(62, 25);
            this.lblOtro.TabIndex = 32;
            this.lblOtro.Text = "Otro:";
            // 
            // txtOtro
            // 
            this.txtOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtro.Location = new System.Drawing.Point(71, 11);
            this.txtOtro.Multiline = true;
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.ReadOnly = true;
            this.txtOtro.Size = new System.Drawing.Size(102, 29);
            this.txtOtro.TabIndex = 1;
            this.txtOtro.Text = "0.00";
            // 
            // txtMercadoPago
            // 
            this.txtMercadoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMercadoPago.Location = new System.Drawing.Point(60, 12);
            this.txtMercadoPago.Margin = new System.Windows.Forms.Padding(5);
            this.txtMercadoPago.Multiline = true;
            this.txtMercadoPago.Name = "txtMercadoPago";
            this.txtMercadoPago.ReadOnly = true;
            this.txtMercadoPago.Size = new System.Drawing.Size(102, 29);
            this.txtMercadoPago.TabIndex = 1;
            this.txtMercadoPago.Text = "0.00";
            // 
            // lblMercadoPago
            // 
            this.lblMercadoPago.AutoSize = true;
            this.lblMercadoPago.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMercadoPago.Location = new System.Drawing.Point(3, 14);
            this.lblMercadoPago.Name = "lblMercadoPago";
            this.lblMercadoPago.Size = new System.Drawing.Size(49, 25);
            this.lblMercadoPago.TabIndex = 32;
            this.lblMercadoPago.Text = "MP:";
            // 
            // panelMercadoPago
            // 
            this.panelMercadoPago.BackColor = System.Drawing.SystemColors.Window;
            this.panelMercadoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMercadoPago.Controls.Add(this.lblMercadoPago);
            this.panelMercadoPago.Controls.Add(this.txtMercadoPago);
            this.panelMercadoPago.Location = new System.Drawing.Point(228, 582);
            this.panelMercadoPago.Name = "panelMercadoPago";
            this.panelMercadoPago.Size = new System.Drawing.Size(173, 51);
            this.panelMercadoPago.TabIndex = 33;
            // 
            // panelCambio
            // 
            this.panelCambio.BackColor = System.Drawing.SystemColors.Window;
            this.panelCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCambio.Controls.Add(this.txtCambioFinal);
            this.panelCambio.Controls.Add(this.lblCambioAntiguo);
            this.panelCambio.Controls.Add(this.txtCambioAntiguo);
            this.panelCambio.Controls.Add(this.lblCambioFinal);
            this.panelCambio.Location = new System.Drawing.Point(751, 579);
            this.panelCambio.Name = "panelCambio";
            this.panelCambio.Size = new System.Drawing.Size(234, 51);
            this.panelCambio.TabIndex = 35;
            // 
            // txtCambioFinal
            // 
            this.txtCambioFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambioFinal.Location = new System.Drawing.Point(97, 24);
            this.txtCambioFinal.Multiline = true;
            this.txtCambioFinal.Name = "txtCambioFinal";
            this.txtCambioFinal.Size = new System.Drawing.Size(112, 18);
            this.txtCambioFinal.TabIndex = 47;
            this.txtCambioFinal.Text = "0.00";
            // 
            // lblCambioAntiguo
            // 
            this.lblCambioAntiguo.AutoSize = true;
            this.lblCambioAntiguo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioAntiguo.Location = new System.Drawing.Point(3, 3);
            this.lblCambioAntiguo.Name = "lblCambioAntiguo";
            this.lblCambioAntiguo.Size = new System.Drawing.Size(58, 16);
            this.lblCambioAntiguo.TabIndex = 45;
            this.lblCambioAntiguo.Text = "Cambio:";
            // 
            // txtCambioAntiguo
            // 
            this.txtCambioAntiguo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambioAntiguo.Location = new System.Drawing.Point(97, 3);
            this.txtCambioAntiguo.Multiline = true;
            this.txtCambioAntiguo.Name = "txtCambioAntiguo";
            this.txtCambioAntiguo.ReadOnly = true;
            this.txtCambioAntiguo.Size = new System.Drawing.Size(112, 18);
            this.txtCambioAntiguo.TabIndex = 44;
            this.txtCambioAntiguo.Text = "0.00";
            // 
            // lblCambioFinal
            // 
            this.lblCambioFinal.AutoSize = true;
            this.lblCambioFinal.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioFinal.Location = new System.Drawing.Point(3, 24);
            this.lblCambioFinal.Name = "lblCambioFinal";
            this.lblCambioFinal.Size = new System.Drawing.Size(88, 16);
            this.lblCambioFinal.TabIndex = 46;
            this.lblCambioFinal.Text = "Cambio Final:";
            // 
            // FrmVentasDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 640);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panelCambio);
            this.Controls.Add(this.panelOtro);
            this.Controls.Add(this.panelMercadoPago);
            this.Controls.Add(this.panelFormaDePago);
            this.Controls.Add(this.panelEfectivo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevaCuenta);
            this.Controls.Add(this.cboVentas);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelPagar);
            this.Controls.Add(this.gridVenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVentasDia";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.Text = "FrmVentasDia";
            this.Load += new System.EventHandler(this.FrmVentasDia_Load);
            this.panelPagar.ResumeLayout(false);
            this.panelPagar.PerformLayout();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVenta)).EndInit();
            this.panelEfectivo.ResumeLayout(false);
            this.panelEfectivo.PerformLayout();
            this.panelFormaDePago.ResumeLayout(false);
            this.panelFormaDePago.PerformLayout();
            this.panelOtro.ResumeLayout(false);
            this.panelOtro.PerformLayout();
            this.panelMercadoPago.ResumeLayout(false);
            this.panelMercadoPago.PerformLayout();
            this.panelCambio.ResumeLayout(false);
            this.panelCambio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabKiosco;
        private System.Windows.Forms.TabPage tabComidas;
        private System.Windows.Forms.TabPage tabBebidas;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.DataGridView gridVenta;
        private System.Windows.Forms.ComboBox cboVentas;
        private FontAwesome.Sharp.IconButton btnNuevaCuenta;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Panel panelEfectivo;
        private FontAwesome.Sharp.IconButton btnPagar;
        private System.Windows.Forms.Panel panelPagar;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label lblPagaCon;
        private System.Windows.Forms.TextBox txtPagaCon;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.RadioButton rBtnMP;
        private System.Windows.Forms.Panel panelFormaDePago;
        private System.Windows.Forms.RadioButton rBtnOtro;
        private System.Windows.Forms.RadioButton rBtnEfectivo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.Panel panelOtro;
        private System.Windows.Forms.Label lblOtro;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaDePago;
        private System.Windows.Forms.TextBox txtMercadoPago;
        private System.Windows.Forms.Label lblMercadoPago;
        private System.Windows.Forms.Panel panelMercadoPago;
        private System.Windows.Forms.Panel panelCambio;
        private System.Windows.Forms.TextBox txtCambioFinal;
        private System.Windows.Forms.Label lblCambioAntiguo;
        private System.Windows.Forms.TextBox txtCambioAntiguo;
        private System.Windows.Forms.Label lblCambioFinal;
        private System.Windows.Forms.TabPage tabCancha;
    }
}