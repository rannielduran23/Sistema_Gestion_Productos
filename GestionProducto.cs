using System;
using System.Collections.Generic;

// Clase Producto
public class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(string codigo, string nombre, double precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Código: {Codigo} | Nombre: {Nombre} | Precio: {Precio}";
    }
}

// Clase Almacen
public class Almacen
{
    private List<Producto> productos = new List<Producto>();

    // Agregar producto (evitando duplicados)
    public bool AgregarProducto(Producto producto)
    {
        foreach (var p in productos)
        {
            if (p.Codigo == producto.Codigo)
            {
                return false;
            }
        }

        productos.Add(producto);
        return true;
    }

    // Buscar producto
    public Producto BuscarProducto(string codigo)
    {
        foreach (var p in productos)
        {
            if (p.Codigo == codigo)
            {
                return p;
            }
        }

        return null;
    }

    // Eliminar producto
    public bool EliminarProducto(string codigo)
    {
        Producto producto = BuscarProducto(codigo);

        if (producto != null)
        {
            productos.Remove(producto);
            return true;
        }

        return false;
    }

    // Obtener lista de productos
    public List<Producto> ObtenerProductos()
    {
        return productos;
    }

    // Cantidad total
    public int CantidadProductos()
    {
        return productos.Count;
    }
}

// ===== Programa Principal =====
public class Program
{
    public static void Main()
    {
        Almacen almacen = new Almacen();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== SISTEMA DE GESTIÓN DE PRODUCTOS =====");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Buscar producto");
            Console.WriteLine("3. Eliminar producto");
            Console.WriteLine("4. Listar productos");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":

                        Console.Write("Código: ");
                        string codigo = Console.ReadLine();

                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Precio: ");
                        double precio = double.Parse(Console.ReadLine());

                        Producto producto = new Producto(codigo, nombre, precio);

                        if (almacen.AgregarProducto(producto))
                            Console.WriteLine("Producto agregado correctamente.");
                        else
                            Console.WriteLine("Error: ya existe un producto con ese código.");

                        break;

                    case "2":

                        Console.Write("Ingrese el código del producto: ");
                        string codBuscar = Console.ReadLine();

                        Producto encontrado = almacen.BuscarProducto(codBuscar);

                        if (encontrado != null)
                            Console.WriteLine(encontrado);
                        else
                            Console.WriteLine("Producto no encontrado.");

                        break;

                    case "3":

                        Console.Write("Código del producto a eliminar: ");
                        string codEliminar = Console.ReadLine();

                        if (almacen.EliminarProducto(codEliminar))
                            Console.WriteLine("Producto eliminado.");
                        else
                            Console.WriteLine("Producto no encontrado.");

                        break;

                    case "4":

                        Console.WriteLine("\nLISTA DE PRODUCTOS:");

                        foreach (var p in almacen.ObtenerProductos())
                        {
                            Console.WriteLine(p);
                        }

                        Console.WriteLine("Total productos: " + almacen.CantidadProductos());

                        break;

                    case "5":

                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:

                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error en la entrada de datos. Intente nuevamente.");
            }
        }
    }
}