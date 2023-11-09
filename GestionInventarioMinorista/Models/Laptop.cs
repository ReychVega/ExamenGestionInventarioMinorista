using SistemaGestionInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//SistemaGestionInventario
namespace SistemaGestionInventario.Models
{
    public class Laptop : Electronica
    {
        
        public Laptop(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible,
            double Precio, string sistemaOperativo)
            : base(Nombre, CodigoProducto, Descripcion, Marca, TipoProducto, CantidadDisponible, Precio)
        {

            this.sistemaOperativo = sistemaOperativo;
        }
        public string sistemaOperativo { get; set; }
        
        public Laptop()
        {
            this.Nombre = "Inspiron62";
            this.TipoProducto = "Usado";
            this.CodigoProducto = "T98";
            this.Descripcion = "Tarjeta grafica ultmax3900";
            this.Marca = "Dell";
            this.CantidadDisponible = 25;
            this.Precio = 300000;
            this.sistemaOperativo = "Windows";
        }

        public override string ToString()
        {
            return base.ToString() + ". Sistema Operativo: " + this.sistemaOperativo;
        }

    }


}

