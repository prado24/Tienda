using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesT;
using ManejadorT;
using AccesoDatosT;

namespace PresentacionT
{
    public partial class FrmProductoAdd : Form
    {
        ManejadorProducto mp;
        public FrmProductoAdd()
        {
            InitializeComponent();
            mp = new ManejadorProducto();
            if(FrmProducto.productos.Idproducto > 0)
            {
                txtNombre.Text = FrmProducto.productos.Nombre;
                txtD.Text = FrmProducto.productos.Descripcion;
                txtPrecio.Text = FrmProducto.productos.Precio.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            mp.Guardar(new Producto(FrmProducto.productos.Idproducto,
                txtNombre.Text, txtD.Text,
                double.Parse(txtPrecio.Text)));
           Close();
        }
    }
}
