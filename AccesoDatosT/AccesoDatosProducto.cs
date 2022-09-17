using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesT;
using ConectarBd;
using System.Data;

namespace AccesoDatosT
{
    public class AccesoDatosProducto:IEntidades
    {
        Base b = new Base("Localhost", "root", "", "tienda", 3306);

        public void Borrar(dynamic Entidad)
        {
            b.comando(String.Format("call deleteProducto({0})",
            Entidad.Idproducto));
        }

        public void Guardar(dynamic Entidad)
        {
            b.comando(string.Format("call insertProducto(" +
              "'{0}','{1}',{2},{3})", Entidad.Nombre,
              Entidad.Descripcion, Entidad.Precio, Entidad.Idproducto));
        }

        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
            (string.Format("call showProducto('%{0}%')",
            filtro), "producto");
        }
    }
}
