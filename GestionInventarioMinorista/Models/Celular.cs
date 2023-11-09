using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    public class Celular : Electronica
    {
        
        public Celular(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible,
            double Precio, string sistemaOperativo)
            : base(Nombre, CodigoProducto, Descripcion, Marca, TipoProducto, CantidadDisponible, Precio)
        {

            this.sistemaOperativo = sistemaOperativo;
        }

        public Celular()
        {
            this.Nombre = "Nova5t";
            this.TipoProducto = "Nuevo";
            this.CodigoProducto = "T55";
            this.Descripcion = "Con infrarojo";
            this.Marca = "Huawei";
            this.CantidadDisponible = 19;
            this.Precio = 220000;
            this.sistemaOperativo = "Android";
        }
        public string sistemaOperativo { get; set; }
        public override string ToString()
        {
            return base.ToString() + ". Sistema Operativo: " + this.sistemaOperativo;
        }

    }
}
