using GestionInventarioMinorista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    public abstract class Producto : IStockable, IPrecio
    {
        //atributos
        public string Nombre { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }

        public string TipoProducto { get; set; }
        public int CantidadDisponible { get; set; }
        public double Precio { get; set; }


        //Constructor
        public Producto(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible, double Precio)
        {
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.CodigoProducto = CodigoProducto;
            this.Descripcion = Descripcion;
            this.Marca = Marca;
            this.TipoProducto = TipoProducto;
            this.CantidadDisponible = CantidadDisponible;
        }

        //constructor para pruebas unitarias con datos predefinidos
        public Producto()
        {
        }

        //metodos
        public double CalcularPrecio()
        {
            return Precio * CantidadDisponible;
        }

        //para informe por producto
        public override string ToString()
        {
            return "Producto: Codigo: " + this.CodigoProducto + ". Tipo: " + this.TipoProducto + ". " +
                "Nombre: " + this.Nombre + ". Descripcion: " + this.Descripcion + "\n" +
                "Marca: " + this.Marca + ". Precio unitario: " + this.Precio+"\n";
        }

    }
}
