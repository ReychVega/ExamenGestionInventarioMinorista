using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    public class Ropa : Producto
    {
        //vamos a usar por el momento solo 3 tallas de forma estandar
        public List<string> tallas;
        public string tallaDefinida;

        public Ropa(string Nombre, string CodigoProducto, string Descripcion, string Marca, string TipoProducto, int CantidadDisponible, double Precio)
            : base(Nombre, CodigoProducto, Descripcion, Marca, TipoProducto, CantidadDisponible, Precio)
        {
            this.inicializarTallas();
            this.tallaDefinida = this.ElegirTalla();

        }

        //constructor solo para pruebas unitarias
        public Ropa()
        {
            this.inicializarTallas();
            this.tallaDefinida = this.tallas[tallas.Count - 1];
        }

        public void inicializarTallas()
        {
            this.tallas = new List<String>();
            this.tallas.Add("S");
            this.tallas.Add("M");
            this.tallas.Add("L");

        }

        private string ElegirTalla()
        {
            string aux = "";
            bool flag = true;
            int count;
            do
            {
                count = 0;
                try
                {
                    Console.WriteLine("Las opciones de tallas son las siguientes:");
                    foreach (string data in this.tallas)
                    {
                        Console.WriteLine(count + "-" + data + "\n");
                        count++;
                    }
                    Console.WriteLine("Indique el indice para saber la talla en especifico");
                    int talla = int.Parse(Console.ReadLine());
                    if (talla <= this.tallas.Count-1 && talla >= 0)
                    {
                        aux = this.tallas[talla];
                        //Console.WriteLine("---" + aux);
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
            Console.Clear();

            return aux;
        }

        public override string ToString()
        {
            return base.ToString() + "Talla: " + this.tallaDefinida;
        }

    }
}
