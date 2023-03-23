
namespace Mainichi
{
    partial class FrmAumentarPrecios
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
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnActualizar = new FontAwesome.Sharp.IconButton();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(342, 33);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPorcentaje.Size = new System.Drawing.Size(42, 20);
            this.txtPorcentaje.TabIndex = 32;
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // cboCategoria
            // 
            this.cboCategoria.AllowDrop = true;
            this.cboCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.cboCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(193, 33);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboCategoria.Size = new System.Drawing.Size(143, 21);
            this.cboCategoria.TabIndex = 31;
            // 
            // lblBuscar
            // 
            this.lblBuscar.BackColor = System.Drawing.Color.White;
            this.lblBuscar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(12, 9);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(415, 117);
            this.lblBuscar.TabIndex = 36;
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btnActualizar.IconColor = System.Drawing.Color.White;
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.IconSize = 16;
            this.btnActualizar.Location = new System.Drawing.Point(161, 70);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(250, 28);
            this.btnActualizar.TabIndex = 38;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(26, 34);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(161, 20);
            this.lblNombre.TabIndex = 39;
            this.lblNombre.Text = "Actualizar precio de ";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.BackColor = System.Drawing.Color.White;
            this.lblPorcentaje.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(390, 31);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(21, 20);
            this.lblPorcentaje.TabIndex = 40;
            this.lblPorcentaje.Text = "%";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.btnCancelar.IconColor = System.Drawing.Color.White;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 1;
            this.btnCancelar.Location = new System.Drawing.Point(30, 70);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 28);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAumentarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 136);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblBuscar);
            this.Name = "FrmAumentarPrecios";
            this.Text = "FrmAumentarPrecios";
            this.Load += new System.EventHandler(this.FrmAumentarPrecios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblBuscar;
        private FontAwesome.Sharp.IconButton btnActualizar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPorcentaje;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}