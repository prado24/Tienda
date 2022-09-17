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
using System.IO;

namespace PresentacionT
{
    public partial class FrmProducto : Form
    {
        ManejadorProducto mp;
        public static Producto productos = new Producto(0, "", "", 0.0);
        int fila = 0, col = 0;
        public static string paisa = "";
        public FrmProducto()
        {
            InitializeComponent();
            mp = new ManejadorProducto();
        }

        private void dtgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productos.Idproducto = int.Parse(dtgProducto.Rows[fila].
             Cells[0].Value.ToString());
            productos.Nombre = dtgProducto.Rows[fila]
                .Cells[1].Value.ToString();
            productos.Descripcion = dtgProducto.Rows[fila]
                .Cells[2].Value.ToString();
            productos.Precio = double.Parse(dtgProducto.Rows[fila]
                .Cells[3].Value.ToString());
            switch(col)
            {
                case 4:
                    {
                        FrmProductoAdd pade = new FrmProductoAdd();
                        pade.ShowDialog();
                        Actualizar();
                    }
                    break;
                case 5:
                    {
                        mp.Borrar(productos);
                        Actualizar();
                    }
                    break;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            productos.Idproducto = -1;
            FrmProductoAdd pade = new FrmProductoAdd();
            pade.ShowDialog();
            Actualizar();
        }

        private void dtgProducto_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            mp.Mostrar(dtgProducto, txtBuscar.Text);
        }
    }
}
