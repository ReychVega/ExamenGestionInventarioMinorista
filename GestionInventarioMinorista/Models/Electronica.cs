using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    //tienda solo vende telefonos y compus
    public class Electronica : Producto
    {
        public List<string> unidadesMedida;
        public double MemoriaGigas { get; set; }
        public string unidadMedidaMemoria { get; set; }
        public Electronica(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible, double Precio)
            : base(Nombre, CodigoProducto, Descripcion, Marca, TipoProducto, CantidadDisponible, Precio)

        {
            this.inicializarUnidadesMedidades();
            this.unidadMedidaMemoria = this.ElegirUnidadMemoria();
            this.MemoriaGigas = this.asignarCantidadMemoria();

        }

        //constructor solo para pruebas unitarias
        public Electronica()
        {
            this.inicializarUnidadesMedidades();
            this.unidadMedidaMemoria = this.unidadesMedida[unidadesMedida.Count - 1];
            this.MemoriaGigas = 5;

        }

        public void inicializarUnidadesMedidades()
        {
            this.unidadesMedida = new List<string>();
            this.unidadesMedida.Add("mb");
            this.unidadesMedida.Add("gb");
            this.unidadesMedida.Add("tb");

        }

        public string ElegirUnidadMemoria()
        {
            string aux = "";
            bool flag = true;
            int count;
            do
            {
                Console.Clear();
                count = 1;
                try
                {
                    Console.WriteLine("Las opciones de unidades de medida son las siguientes:");
                    foreach (string data in this.unidadesMedida)
                    {
                        Console.WriteLine(count + "-" + data + "\n");
                        count++;
                    }
                    Console.WriteLine("Indique el indice para saber la unidad de medida en especifico");
                    int unidad = int.Parse(Console.ReadLine());
                    if (unidad <= this.unidadesMedida.Count && unidad >= 1)
                    {
                        aux = this.unidadesMedida[unidad-1];
                        // Console.WriteLine("---" + aux);
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Indice erroneo");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Datos no validos, intente de nuevo");

                }

            } while (flag);
            return aux;
        }

        public double asignarCantidadMemoria()
        {
            this.MemoriaGigas = 0;
            do
            {
                try
                {
                    Console.WriteLine(" Tomando en cuenta la unidad previamente seleccionada ingrese la cantidad ");
                    this.MemoriaGigas = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Datos no validos, intente de nuevo");
                }

            } while (this.MemoriaGigas <= 0);



            return this.MemoriaGigas;
        }

        public override string ToString()
        {
            return base.ToString() + "Memoria: " + this.MemoriaGigas + " " + this.unidadMedidaMemoria;
        }

    }
}
