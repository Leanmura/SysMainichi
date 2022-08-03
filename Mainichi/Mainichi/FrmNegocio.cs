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
    public partial class FrmNegocio : Form
    {
        public FrmNegocio()
        {
            InitializeComponent();
        }

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

        private void FrmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteImagen = new N_Negocio().ObtenerLogo(out obtenido);
            if(obtenido)
            {
                this.picLogo.Image = this.ByteToImage(byteImagen);
            }

            Negocio datos = new N_Negocio().ObtenerDatos();
            this.txtNombre.Text = datos.Nombre;
            this.txtDireccion.Text = datos.Direccion;
            this.txtTelefono.Text = datos.Telefono;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Files|*.jpg;*.jpeg;*.png";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                byte[] byteImage = File.ReadAllBytes(openFile.FileName);
                    picLogo.Image = this.ByteToImage(byteImage);
      
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio();
            obj.Nombre = txtNombre.Text;
            obj.Telefono = txtTelefono.Text;
            obj.Direccion = txtDireccion.Text;
            obj.Imagen = this.ImageToByte(picLogo.Image);

            bool respuesta = new N_Negocio().GuardarDatos(obj, out mensaje);

          
            if (respuesta)
            {
                
                MessageBox.Show("Datos guardados con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
