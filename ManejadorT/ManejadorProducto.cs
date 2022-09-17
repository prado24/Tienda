using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesT;
using AccesoDatosT;
using Crud;
using System.Drawing;

namespace ManejadorT
{
    public class ManejadorProducto : IManejador
    {
        AccesoDatosProducto ap = new AccesoDatosProducto();
        Grafico g = new Grafico();
        public void Borrar(dynamic Entidad)
        {
            DialogResult rs = MessageBox.Show(String.Format(String.Format(
                "Estas seguro de borrar: {0}", Entidad.Nombre)
                ), "!Atencion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes)
                            ap.Borrar(Entidad);
        }

        public void Guardar(dynamic Entidad)
        {
            ap.Guardar(Entidad);
            g.Mensaje("Producto Guardado", "!Atencion",
                MessageBoxIcon.Information);
        }

        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = ap.Mostrar(filtro).Tables["producto"];
            tabla.Columns.Insert(4,g.Boton(
                "Editar", Color.Green));
            tabla.Columns.Insert(5,g.Boton("Borrar",Color.Red));
            tabla.Columns[0].Visible = false;
        }
    }
}
