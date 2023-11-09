using SistemaGestionInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    public class Sueter : Ropa
    {
     

        public Sueter(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible, double Precio) : base(Nombre, CodigoProducto, Descripcion, Marca, TipoProducto, CantidadDisponible, Precio)
        {

        }
        //constructor solo para pruebas unitarias
        public Sueter()
        {
            this.Nombre = "Sueta";
            this.TipoProducto = "Damas";
            this.CodigoProducto = "R12";
            this.Descripcion = "Con botones y capucha";
            this.Marca = "Zara";
            this.CantidadDisponible = 11;
            this.Precio = 14900;
        }
    }

}
