﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesT
{
    public class Producto
    {
        public Producto(int idproducto, string nombre, string descripcion, double precio)
        {
            Idproducto = idproducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
    }
}
