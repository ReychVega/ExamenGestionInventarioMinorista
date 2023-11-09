/*
 Idea de estructura

+IPrecio                    el precio total del inventario y proporcionar información detallada sobre los  
+IStockable
    Producto                 implementar IStockable, IPrecio, Debes garantizar que el sistema pueda calcular automáticamente el precio total del inventario y proporcionar información detallada sobre los 
                                productos. 

        Ropa                 todas deben heredar de una clase base "Producto", 

        Electronicos         todas deben heredar de una clase base "Producto"




2. Mostrar un menú con las opciones disponibles para que el usuario seleccione.
    do while                         Un mecanismo para que el usuario ingrese su elección.
                                      Un switch o una estructura de control similar para manejar las diferentes opciones seleccionadas por el usuario y llamar a los 
                                        métodos correspondientes.
                                        Posibles opciones:
                                                    1-Buscar productos. 
                                                    2-Eliminar productos definitivamente. 
                                                    3-Generar informe del stock con precio calculado.
                                                    4-Editar producto. 
                                                    5-Agregar productos.
                                                    6-Reducir stock de un producto.
                                                    7-Agregar stock de un producto 
                                                    8-Salir
Polimorfismo en el manejo de los objetos de productos y clases hijas.
 */

using GestionInventarioMinorista.Models;
using SistemaGestionInventario.Models;
using System.Collections;
using System.Reflection;


//testing
//Polimorfismo
List<Producto> productos = new List<Producto>();
//productos por defecto para probar
productos.Add(new Blusa());//codigo=R84 nombre=Top
productos.Add(new Sueter()); //codigo=R12  nombre=Sueta
productos.Add(new Celular()); //codigo=T55 nombre=Nova5t
productos.Add(new Laptop()); //codigo=T98 nombre=Inspiron62
//menu
bool menu = true;
do
{
    Console.Clear();
    try
    {
        Console.WriteLine("********Empresa minorista********");
        Console.WriteLine("Ingrese del 1 al 5 de las siguientes opciones del menu. \n" +
            "1-Buscar productos. \n" +
            "2-Eliminar productos definitivamente. \n" +
            "3-Generar informe del stock con precio calculado. \n" +
            "4-Editar producto. \n" +
            "5-Agregar productos \n" +
            "6-Reducir stock de un producto \n" +
            "7-Agregar stock de un producto \n" +
            "8-Salir. \n");
        int opcionMenu = int.Parse(Console.ReadLine());
        switch (opcionMenu)
        {
            //Buscar un producto. Rey
            case 1:
                bool menuPrimeraOpcion = true;

                do
                {
                    Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu.\n" +
                       "1-Buscar un producto por codigo o parte de un codigo. \n" +
                        "2-Buscar un producto por nombre o parte del nombre. \n");
                    try
                    {
                        int opcionBuscar = int.Parse(Console.ReadLine()+"\n");
                        bool validBusqueda = false;
                        //Caso 1.1 Por codigo
                        if (opcionBuscar == 1)
                        {
                            Console.WriteLine("Ingrese el codigo");
                            validBusqueda = Utility.getDataPorCodigo(productos, Console.ReadLine());

                        } //Caso 1.2 Por nombre
                        else if (opcionBuscar == 2)
                        {
                            Console.WriteLine("Ingrese el nombre");
                            validBusqueda = Utility.getDataPorNombre(productos, Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Opcion no valida. Intente de nuevo");
                        }
                        if (validBusqueda == false)
                        {
                            Console.WriteLine("Producto no encontrado");
                        }
                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu. \n" +
                       "1-Continuar \n" +
                       "2-Salir");
                        int continuarPrimerMenu = int.Parse(Console.ReadLine());
                        if (continuarPrimerMenu == 2)
                        {
                            menuPrimeraOpcion = false;
                            Console.Clear();
                        }
                        else if (continuarPrimerMenu != 1 && continuarPrimerMenu != 2)
                        {
                            Console.WriteLine("Opcion no valida. Intente de nuevo");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Datos invalidos, ingrese solo las opciones del menu");
                    }

                } while (menuPrimeraOpcion);

                break;


            //Eliminar. Moiso
            case 2:
                bool menuBorrado = true;
                do
                {
                    try
                    {
                        Console.WriteLine(" BORRAR: Ingrese la forma en la que desea buscar el producto a borrar \n"
                        + "1. Por Codigo \n" +
                        "  2. Por Nombre");
                        string opcionBorrado = Console.ReadLine();
                        if (opcionBorrado == "1")
                        {
                            Console.WriteLine("Coloca el codigo del producto a borrar");
                            Utility.borrarProductoPorCodigo(productos, Console.ReadLine());
                        }
                        else if (opcionBorrado == "2")
                        {
                            Console.WriteLine("Coloca el nombre del producto a borrar");
                            Utility.borrarProductoPorNombre(productos, Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Opciones invalidas. Intente de nuevo con las opciones del menu");
                        }

                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu. \n" +
                           "1-Continuar \n" +
                           "2-Salir");
                        int continuarSegundoMenu = int.Parse(Console.ReadLine());
                        if (continuarSegundoMenu == 2)
                        {
                            menuBorrado = false;
                            Console.Clear();
                        }
                        else if (continuarSegundoMenu != 1 && continuarSegundoMenu != 2)
                        {
                            Console.WriteLine("Opcion no valida. Intente de nuevo");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Operacion no valida. Intente de nuevo, el error fue: " + e.Message);
                    }

                } while (menuBorrado);

                break;


            //Generar informe: Reych
            case 3:
                bool menuGenerarInforme = true;
                do
                {
                    Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu para generar informe del stock de un producto en especial.\n" +
                        "1-Buscar por codigo \n" +
                        "2-Buscar por nombre");
                    string opcionInforme = Console.ReadLine();
                    Producto productoEncontrado = null;
                    string searchData = "";
                    if (opcionInforme == "1")
                    {
                        Console.WriteLine("Ingrese el codigo");
                        searchData = Console.ReadLine();
                        productoEncontrado = Utility.getProductoPorCodigo(productos, searchData);

                    }
                    else if (opcionInforme == "2")
                    {
                        Console.WriteLine("Ingrese el nombre");
                        searchData = Console.ReadLine();
                        productoEncontrado = Utility.getProductoPorNombre(productos, searchData);

                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida, intente de nuevo.");
                    }

                    if (productoEncontrado == null)
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                    else
                    {
                        Console.WriteLine(Utility.getStockData(productos, productoEncontrado));
                    }

                    Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu. \n" +
                           "1-Continuar \n" +
                           "2-Salir");
                    int continuarTercerMenu = int.Parse(Console.ReadLine());
                    if (continuarTercerMenu == 2)
                    {
                        menuGenerarInforme = false;
                        Console.Clear();
                    }
                    else if (continuarTercerMenu != 1 && continuarTercerMenu != 2)
                    {
                        Console.WriteLine("Opcion no valida. Intente de nuevo");
                    }

                } while (menuGenerarInforme);

                break;


            //Editar propiedades: Moiso
            // no puse modificacion del total del inventario ya que no lo vi necesario debido a que para eso y tenemos los metodos de añadir y quitar más abajo

            case 4:
                bool menuEdicion = true;
                do
                {
                    try
                    {
                        Console.WriteLine("Elija la informacion que desea editar: \n" +
                            "1- Nombre de producto \n" +
                            "2- Precio del producto } \n" +
                            "3- Descripcion del producto \n" +
                            "4- Codigo del producto \n" +
                            "5- Marca del producto \n" +
                            "6- Tipo de producto \n" +
                            "7- Salir");
                        int eleccionEdicion = int.Parse(Console.ReadLine());

                        switch (eleccionEdicion)
                        {
                            case 1:
                                Console.Write("Ingrese el codigo del producto que desea editar: ");
                                string codigo = Console.ReadLine();
                                Console.Write("Ingrese el nuevo nombre: ");
                                string nuevoNombre = Console.ReadLine();

                                Utility.editarNombreProducto(productos, codigo, nuevoNombre);
                                

                                break;

                            case 2:
                                Console.Write("Ingrese el codigo del producto cuyo precio desea editar: ");
                                string codigoProductoPrecio = Console.ReadLine();
                                Console.Write("Ingrese el nuevo precio del producto: ");
                                if (double.TryParse(Console.ReadLine(), out double nuevoPrecio))
                                {
                                    Utility.editarPrecioProducto(productos, codigoProductoPrecio, nuevoPrecio);
                                }
                                else
                                {
                                    Console.WriteLine("El valor del precio no es válido.");
                                }


                                break;

                            case 3:
                                Console.Write("Ingrese el codigo del producto que desea editar: ");
                                string codigoProductoDescripcion = Console.ReadLine();
                                Console.Write("Ingrese la nueva descripcion del producto: ");
                                string nuevoDescripcion = Console.ReadLine();

                                Utility.editarDescripcionProducto(productos, codigoProductoDescripcion, nuevoDescripcion);


                                break;

                            case 4:

                                Console.Write("Ingrese el codigo del producto que desea editar: ");
                                string codigoProductoCodigo = Console.ReadLine();
                                Console.Write("Ingrese el nuevo codigo del producto: ");
                                string nuevoCodigo = Console.ReadLine();

                                Utility.editarCodigoProducto(productos, codigoProductoCodigo, nuevoCodigo);

                                break;

                            case 5:

                                Console.Write("Ingrese el codigo del producto que desea editar: ");
                                string codigoProductoMarca = Console.ReadLine();
                                Console.Write("Ingrese la nueva marca del producto: ");
                                string nuevaMarca = Console.ReadLine();

                                Utility.editarMarcaProducto(productos, codigoProductoMarca, nuevaMarca);


                                break;

                            case 6:
                                Console.Write("Ingrese el codigo del producto que desea editar: ");
                                string codigoProductoTipo = Console.ReadLine();
                                Console.Write("Ingrese el nuevo tipo del producto: ");
                                string nuevoTipo = Console.ReadLine();

                                Utility.editarTipoProducto(productos, codigoProductoTipo, nuevoTipo);


                                break;

                            case 7:
                                menuEdicion = false;
                                break;
                        }




                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Operacion no valida. Intente de nuevo, el error fue: " + e.Message);
                    }
                } while (menuEdicion);

                break;

            //agregar productos: Moiso & Rey
            case 5:
                // Considerar el tipo de producto.
                bool menuAgregarProductos = true;
                do
                {
                    try
                    {

                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menú para agregar productos:\n" +
                       "1 - Agregar un articulo en la sesion de Ropa\n" +
                       "2 - Agregar un articulo en la sesion de Electronica");
                        int opcionAgregarProducto = int.Parse(Console.ReadLine());

                        //Reych (Ropa)
                        if (opcionAgregarProducto == 1)
                        {
                            List<string> dataRopa = new List<string>();
                            Utility.opcionesRopa(productos, dataRopa);

                            Console.WriteLine("Ingrese el digito correspondiente a las siguientes opciones de la seccion de Ropa, para agregar producto");
                            Utility.imprimirDatos(dataRopa);
                            Console.WriteLine("Ingrese el indice:");

                            int tipoRopa = int.Parse(Console.ReadLine());
                            if (tipoRopa >= 1 && tipoRopa <= dataRopa.Count)
                            {

                                Console.WriteLine("Ingrese el nombre de la prenda:");
                                string nombrePrenda = Console.ReadLine();
                                Console.WriteLine("Ingrese el código de la prenda:");
                                string codigoPrenda = Console.ReadLine();
                                Console.WriteLine("Ingrese la descripción de la prenda:");
                                string descripcionPrenda = Console.ReadLine();
                                Console.WriteLine("Ingrese la marca de la prenda:");
                                string marcaPrenda = Console.ReadLine();
                                Console.WriteLine("Ingrese el tipo de prenda (Damas o Caballeros):");
                                string tipoPrenda = Console.ReadLine();
                                Console.WriteLine("Ingrese la cantidad disponible de la prenda:");
                                int cantidadPrenda = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese el precio de la prenda:");
                                double precioPrenda = double.Parse(Console.ReadLine());

                                string className = "SistemaGestionInventario.Models." + dataRopa[tipoRopa - 1].Trim();
                                //aqui sacamos el name de la clase hija para definir el objeto exacto en caso de que existan muchos articulos de la seccion ropa
                                Type claseHija = Type.GetType(className);
                                //valida que no se repita cod
                                if (Utility.validaExistenciaPorCodigo(productos, codigoPrenda) == false)
                                {
                                    if (claseHija != null)
                                    {
                                        ConstructorInfo constructorRopa = claseHija.GetConstructor(new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(double) });

                                        if (constructorRopa != null)
                                        {
                                            Ropa nuevaPrenda = (Ropa)constructorRopa.Invoke(new object[] { nombrePrenda, codigoPrenda, descripcionPrenda, marcaPrenda, tipoPrenda, cantidadPrenda, precioPrenda });
                                            productos.Add(nuevaPrenda);

                                            Console.WriteLine(nuevaPrenda.ToString() + "\n" +
                                                "Producto agregado");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No se pudo crear el objeto de la clase especificada.");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Operacion no valida, intente de nuevo");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Codigo existente, intente de nuevo");
                                }
                            }





                        }//Moiso (Electronica)
                        else if (opcionAgregarProducto == 2)
                        {
                            List<string> dataElectronica = new List<string>();
                            Utility.opcionesElectronica(productos, dataElectronica);

                            Console.WriteLine("Ingrese el digito correspondiente a las siguientes opciones de la seccion de Electrodomesticos, para agregar producto");
                            Utility.imprimirDatos(dataElectronica);
                            Console.WriteLine("Ingrese el indice:");

                            int tipoElectronica = int.Parse(Console.ReadLine());
                            if (tipoElectronica >= 1 && tipoElectronica <= dataElectronica.Count)
                            {

                                Console.WriteLine("Ingrese el nombre del producto electronico:");
                                string nombreElectronico = Console.ReadLine();
                                Console.WriteLine("Ingrese el código del producto electronico:");
                                string codigoElectronico = Console.ReadLine();
                                Console.WriteLine("Ingrese la descripción del producto electronico:");
                                string descripcionElectronico = Console.ReadLine();
                                Console.WriteLine("Ingrese la marca del producto electronico:");
                                string marcaElectronico = Console.ReadLine();
                                Console.WriteLine("Ingrese el sistema operativo del producto electronico: ");
                                string sistemaOperativoElectro = Console.ReadLine();
                                Console.WriteLine("Ingrese el tipo del producto electronico (Usado o Nuevo):");
                                string tipoElectronico = Console.ReadLine();
                                if (Utility.validaString(tipoElectronico, "usado") == true || Utility.validaString(tipoElectronico, "nuevo") == true)
                                {


                                    Console.WriteLine("Ingrese la cantidad disponible del producto electronico:");
                                    int cantidadElectronico = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese el precio del producto electronico:");
                                    double precioElectronico = double.Parse(Console.ReadLine());

                                    string className = "SistemaGestionInventario.Models." + dataElectronica[tipoElectronica - 1].Trim();
                                    Type claseDaughter = Type.GetType(className);

                                    if (Utility.validaExistenciaPorCodigoElectro(productos, codigoElectronico) == false)
                                    {
                                        if (claseDaughter != null)
                                        {
                                           
                                            ConstructorInfo constructorInfo = 
                                      claseDaughter.GetConstructor(new[] { typeof(string), typeof(string), typeof(string), typeof(string), 
                                      typeof(string), typeof(int), typeof(double), typeof(string) });
                                            
                                            if (constructorInfo != null)
                                            {
                                                Electronica nuevoElectronico = (Electronica)constructorInfo.Invoke(new object[]
                                                { nombreElectronico, codigoElectronico, descripcionElectronico, marcaElectronico, 
                                                    tipoElectronico, cantidadElectronico, precioElectronico, sistemaOperativoElectro });
                                                productos.Add(nuevoElectronico);

                                                Console.WriteLine(nuevoElectronico.ToString() + "\n" +
                                                    "Producto agregado");
                                            }
                                            else
                                            {
                                                Console.WriteLine("No se pudo crear el objeto de la clase especificada.");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Operacion no valida, intente de nuevo");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Codigo existente, intente de nuevo");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Utiliza solamente la palabra Usado o Nuevo");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opción no válida. Intente de nuevo.");
                            }

                        }
                        
                            Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menú:\n" +
                                            "1 - Continuar\n" +
                                            "2 - Salir");
                            int continuarQuintoMenu = int.Parse(Console.ReadLine());
                            if (continuarQuintoMenu == 2)
                            {
                                menuAgregarProductos = false;
                                Console.Clear();
                            }
                            else if (continuarQuintoMenu != 1 && continuarQuintoMenu != 2)
                            {
                                Console.WriteLine("Opción no válida. Intente de nuevo.");
                            }

                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Datos ingresados no cumplen con el formato indicado. Intente de nuevo. El error fue: " + e.Message);
                    }

                } while (menuAgregarProductos);

             break;

            //Reducir stock(disminuye el stock y no lo elimina). Rey
            case 6:
                bool menuReducirStock = true;
                do
                {

                    try
                    {
                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu para generar informe del stock de un producto en especial.\n" +
                               "1-Buscar por codigo \n" +
                               "2-Buscar por nombre");
                        string productoStock = Console.ReadLine();
                        string search = "";
                        Producto productoEncontradoStock = null;

                        if (productoStock == "1")
                        {
                            Console.WriteLine("Ingrese el codigo");
                            search = Console.ReadLine();
                            productoEncontradoStock = Utility.getProductoPorCodigo(productos, search);

                        }
                        else if (productoStock == "2")
                        {
                            Console.WriteLine("Ingrese el nombre");
                            search = Console.ReadLine();
                            productoEncontradoStock = Utility.getProductoPorNombre(productos, search);

                        }
                        else
                        {
                            Console.WriteLine("Opcion no valida, intente de nuevo.");
                        }

                        if (productoEncontradoStock == null)
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        else
                        {
                            Console.WriteLine(Utility.getStockData(productos, productoEncontradoStock));
                            Console.WriteLine("Ingrese la cantidad que quiere reducir de la cantidad disponible");
                            int reducirStock = int.Parse(Console.ReadLine());
                            if (reducirStock > 0 && reducirStock <= productoEncontradoStock.CantidadDisponible)
                            {
                                Utility.reducirStockPorCodigo(productos, productoEncontradoStock.CodigoProducto, reducirStock);
                                //mostramos el producto con el stock modificado
                                Console.WriteLine(Utility.getStockData(productos, productoEncontradoStock));
                            }
                            else
                            {
                                Console.WriteLine("Cantidad no valida. Intente de nuevo. ");
                            }

                        }

                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu. \n" +
                               "1-Continuar \n" +
                               "2-Salir");
                        int continuarSextoMenu = int.Parse(Console.ReadLine());
                        if (continuarSextoMenu == 2)
                        {
                            menuReducirStock = false;
                            Console.Clear();
                        }
                        else if (continuarSextoMenu != 1 && continuarSextoMenu != 2)
                        {
                            Console.WriteLine("Opcion no valida. Intente de nuevo");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Opcion no valida. Intente de nuevo");
                    }

                } while (menuReducirStock);
                break;

            //Agregar stock de un producto. Rey
            case 7:
                bool menuAumentarStock = true;
                do
                {

                    try
                    {
                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu para generar informe del stock de un producto en especial.\n" +
                               "1-Buscar por codigo \n" +
                               "2-Buscar por nombre");
                        string productoStock = Console.ReadLine();
                        string search = "";
                        Producto productoEncontradoStock = null;

                        if (productoStock == "1")
                        {
                            Console.WriteLine("Ingrese el codigo");
                            search = Console.ReadLine();
                            productoEncontradoStock = Utility.getProductoPorCodigo(productos, search);

                        }
                        else if (productoStock == "2")
                        {
                            Console.WriteLine("Ingrese el nombre");
                            search = Console.ReadLine();
                            productoEncontradoStock = Utility.getProductoPorNombre(productos, search);

                        }
                        else
                        {
                            Console.WriteLine("Opcion no valida, intente de nuevo.");
                        }

                        if (productoEncontradoStock == null)
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        else
                        {
                            Console.WriteLine(Utility.getStockData(productos, productoEncontradoStock));
                            Console.WriteLine("Ingrese la cantidad que quiere aumentar de la cantidad disponible");
                            int reducirStock = int.Parse(Console.ReadLine());
                            if (reducirStock > 0)
                            {
                                Utility.aumentarStockPorCodigo(productos, productoEncontradoStock.CodigoProducto, reducirStock);
                                //mostramos el producto con el stock modificado
                                Console.WriteLine(Utility.getStockData(productos, productoEncontradoStock));
                            }
                            else
                            {
                                Console.WriteLine("Cantidad no valida. Intente de nuevo. ");
                            }

                        }

                        Console.WriteLine("Ingrese del 1 al 2 de las siguientes opciones del menu. \n" +
                               "1-Continuar \n" +
                               "2-Salir");
                        int continuarSeptimoMenu = int.Parse(Console.ReadLine());
                        if (continuarSeptimoMenu == 2)
                        {
                            menuAumentarStock = false;
                            Console.Clear();
                        }
                        else if (continuarSeptimoMenu != 1 && continuarSeptimoMenu != 2)
                        {
                            Console.WriteLine("Opcion no valida. Intente de nuevo");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Opcion no valida. Intente de nuevo");
                    }

                } while (menuAumentarStock);


                break;

            case 8:
                menu = false;
                break;
            default:
                Console.WriteLine("");
                break;
        }

    }
    catch (Exception e)
    {
        Console.WriteLine("Datos ingresados no cumplen con el formato indicado, intente de nuevo.");
    }

} while (menu);
