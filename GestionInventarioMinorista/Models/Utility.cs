using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionInventario.Models
{
    public class Utility
    {
        public Utility()
        {

        }

        //implementar los metodos auxiliares para manejar listas u otros metodos auxiliares que sean necesarios para el menu
        public static void opcionesRopa(List<Producto> listaProductos, List<string>data) {

            foreach (Producto producto in listaProductos)
            {
                if (producto is Ropa)
                {
                    //Console.WriteLine(producto.GetType().FullName+"-");
                    string nombreClaseHija = producto.GetType().Name;
                    if (!data.Contains(nombreClaseHija))
                    {
                        data.Add(nombreClaseHija);
                    }
                }
             
            }

        }

        public static bool validaString(string PrimerDato, string SegundoDato) {

            return PrimerDato.Trim().Equals(SegundoDato.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public static void opcionesElectronica(List<Producto> listaProductos, List<string> data) {

            foreach (Producto producto in listaProductos)
            {
                if (producto is Electronica)
                {
                    string nombreClaseDaughter = producto.GetType().Name;
                    if (!data.Contains(nombreClaseDaughter))
                    {
                        data.Add(nombreClaseDaughter);
                    }
                }

            }

        }

        //buscar productos
        public static Producto getProductoPorNombre(List<Producto> listaProductos, string nombre)
        {
            bool validOperation = false;

            foreach (Producto producto in listaProductos)
            {
                if (producto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return producto;
                }
            }

            return null;
        }

        public static Producto getProductoPorCodigo(List<Producto> listaProductos, string codigo)
        {
            bool validOperation = false;

            foreach (Producto producto in listaProductos)
            {
                if (producto.CodigoProducto.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    // Console.WriteLine(producto.ToString());
                    return producto;
                }
            }

            return null;
        }
       
        public static bool getDataPorCodigo(List<Producto> listaProductos, string codigo)
        {
            bool validOperation = false;

            foreach (Producto producto in listaProductos)
            {
                if (producto.CodigoProducto.Contains(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(producto.ToString());
                    validOperation = true;
                }
            }

            return validOperation;
        }

        public static bool getDataPorNombre(List<Producto> listaProductos, string nombre)
        {
            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                if (producto.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(producto.ToString());
                    validOperation = true;
                }

            }

            return validOperation;

        }

        //Precio total del stock por producto
        public static double getPrecioTotalPorCodigo(List<Producto> listaProductos, string codigo)
        {
            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.CodigoProducto.Equals(codigo, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    return producto.CalcularPrecio();
                }

            }

            return 0;

        }

        public static double getPrecioTotalPorNombre(List<Producto> listaProductos, string nombre)
        {
            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    return producto.CalcularPrecio();
                }

            }

            return 0;

        }

        //Precio total unitario por producto

        public static double getPrecioUnitarioPorCodigo(List<Producto> listaProductos, string codigo)
        {
            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.CodigoProducto.Equals(codigo, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    Console.WriteLine(producto.ToString());
                    return producto.Precio;
                }

            }
            return 0;
        }

        public static double getPrecioUnitarioPorNombre(List<Producto> listaProductos, string nombre)
        {
            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.CodigoProducto.Equals(nombre, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    Console.WriteLine(producto.ToString());
                    return producto.Precio;
                }

            }
            return 0;
        }

        //buscar por codigo y nombre producto para borrarlo de la lista por codigo bool, if true o sino false
        public static bool borrarProductoPorCodigo(List<Producto> listaProductos, string codigo)
        {
            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.CodigoProducto.Equals(codigo, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    Console.WriteLine("Se ha eliminado el producto correctamente");
                    listaProductos.Remove(producto);
                    return true;
                }

            }
            Console.WriteLine("El producto no fue encontrado");
            return false;
        }

        //buscar por codigo y nombre producto para borrarlo de la lista por codigo bool, if true o sino false
        public static bool borrarProductoPorNombre(List<Producto> listaProductos, string nombre)
        {

            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    Console.WriteLine("Se ha eliminado el producto correctamente");
                    listaProductos.Remove(producto);
                    return true;
                }

            }
            Console.WriteLine("El producto no fue encontrado");
            return false;
        }

        public static string getStockData(List<Producto> list, Producto producto)
        {
            string data = "";
            data = producto.ToString() + "\n" +
                "Cantidad total del stock: " + producto.CantidadDisponible + "\n" +
                "Stock evaluado en:" + producto.CalcularPrecio();

            return data;
        }


        //reduce el stock 
        public static bool reducirStockPorCodigo(List<Producto> listaProductos, string codigo, int cantidad)
        {

            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.CodigoProducto.Equals(codigo, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                    if (producto.CantidadDisponible > 0)
                    {
                        producto.CantidadDisponible = producto.CantidadDisponible - cantidad;
                        Console.WriteLine("Se ha eliminado el producto correctamente");
                        Console.WriteLine("La cantidad disponible es de " + producto.CantidadDisponible + ".");
                        return true;

                    }

                }

            }
            Console.WriteLine("El producto no fue encontrado");
            return false;
        }

        //aumentar stock
        public static bool aumentarStockPorCodigo(List<Producto> listaProductos, string codigo, int cantidad)
        {

            bool validOperation = false;
            foreach (Producto producto in listaProductos)
            {
                validOperation = producto.CodigoProducto.Equals(codigo, StringComparison.OrdinalIgnoreCase);
                if (validOperation)
                {
                        producto.CantidadDisponible = producto.CantidadDisponible + cantidad;
                        Console.WriteLine("Se ha eliminado el producto correctamente");
                        Console.WriteLine("La cantidad disponible es de " + producto.CantidadDisponible + ".");
                        return true;

                }

            }
            Console.WriteLine("El producto no fue encontrado");
            return false;
        }

        public static void imprimirDatos(List<string> list)
        {
            int count = 1;
            foreach (string str in list)
            {
                Console.WriteLine(count+"-"+str + "\n");
                count++;
            }
           // list[num-1]

        }

        public static bool validaExistenciaPorCodigo(List<Producto> productos, string codigoPrenda)
        {
            foreach (Producto producto in productos)
            {
                if (producto.CodigoProducto.Equals(codigoPrenda, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool validaExistenciaPorCodigoElectro(List<Producto> productos, string codigoElectronico)
        {
            foreach (Producto producto in productos)
            {
                if (producto.CodigoProducto.Equals(codigoElectronico, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static void editarNombreProducto(List<Producto> listaDeProductos, string codigo, string nuevoNombre)
        {
            Producto productoEncontrado = null;

            foreach (Producto producto in listaDeProductos)
            {
                if (string.Equals(producto.CodigoProducto, codigo, StringComparison.OrdinalIgnoreCase))
                {
                    productoEncontrado = producto;
                    break;
                }
            }

            if (productoEncontrado != null)
            {
                productoEncontrado.Nombre = nuevoNombre;
                Console.WriteLine("Nombre del producto actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se encontró en la lista.");
            }
        }

        public static void editarPrecioProducto(List<Producto> listaDeProductos, string nombre, double nuevoPrecio)
        {
            Producto productoEncontrado = null;

            foreach (Producto producto in listaDeProductos)
            {
                if (string.Equals(producto.CodigoProducto, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    productoEncontrado = producto;
                    break;
                }
            }

            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = nuevoPrecio;
                Console.WriteLine("Precio del producto actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se encontró en la lista.");
            }
        }
        

            public static void editarDescripcionProducto(List<Producto> listaDeProductos, string nombre, string nuevaDescripcion)
        {
            Producto productoEncontrado = null;

            foreach (Producto producto in listaDeProductos)
            {
                if (string.Equals(producto.CodigoProducto, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    productoEncontrado = producto;
                    break;
                }
            }

            if (productoEncontrado != null)
            {
                productoEncontrado.Descripcion = nuevaDescripcion;
                Console.WriteLine("La descripcion del producto se ha actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se encontró en la lista.");
            }
        }


        

             public static void editarCodigoProducto(List<Producto> listaDeProductos, string nombre, string nuevoCodigo)
        {
            Producto productoEncontrado = null;

            foreach (Producto producto in listaDeProductos)
            {
                if (string.Equals(producto.CodigoProducto, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    productoEncontrado = producto;
                    break;
                }
            }

            if (productoEncontrado != null)
            {
                productoEncontrado.CodigoProducto = nuevoCodigo;
                Console.WriteLine("El codigo del producto ha sido actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se encontró en la lista.");
            }
        }



            public static void editarMarcaProducto(List<Producto> listaDeProductos, string nombre, string nuevoMarca)
        {
            Producto productoEncontrado = null;

            foreach (Producto producto in listaDeProductos)
            {
                if (string.Equals(producto.CodigoProducto, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    productoEncontrado = producto;
                    break;
                }
            }

            if (productoEncontrado != null)
            {
                productoEncontrado.Marca = nuevoMarca;
                Console.WriteLine("El codigo del producto ha sido actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se encontró en la lista.");
            }
        }

        

            public static void editarTipoProducto(List<Producto> listaDeProductos, string nombre, string nuevoTipo)
        {
            Producto productoEncontrado = null;

            foreach (Producto producto in listaDeProductos)
            {
                if (string.Equals(producto.CodigoProducto, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    productoEncontrado = producto;
                    break;
                }
            }

            if (productoEncontrado != null)
            {
                productoEncontrado.TipoProducto = nuevoTipo;
                Console.WriteLine("El codigo del producto ha sido actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("El producto no se encontró en la lista.");
            }
        }


    }

}
