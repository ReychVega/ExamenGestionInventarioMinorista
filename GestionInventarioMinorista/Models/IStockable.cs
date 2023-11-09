using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioMinorista.Models
{
    public interface IStockable
    {
        //Cantidades del producto
        int CantidadDisponible { get; set; }

    }
}
