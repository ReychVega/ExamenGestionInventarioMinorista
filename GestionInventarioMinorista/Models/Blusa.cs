using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    public class Blusa : Ropa
    {

        public Blusa(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible, double Precio) : 
            base(Nombre, CodigoProducto, Descripcion, Marca, TipoProducto, CantidadDisponible, Precio)
        {

        }

        //constructor solo para pruebas unitarias

        public Blusa()
        {
            this.Nombre = "Top";
            this.TipoProducto = "Damas";
            this.CodigoProducto = "R84";
            this.Descripcion = "Con tirantes en seda";
            this.Marca = "Zara";
            this.CantidadDisponible = 9;
            this.Precio = 9900;
        }


    }
}
