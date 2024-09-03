using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using tl2_tp1_2024_julietacolque;
internal class Program
{
    private static void Main(string[] args)
    {

        var cadeteria = CargaDatos.CSVCadeteria("cadeteria.csv");

        CargaDatos.CSVCadetes("cadetes.csv", cadeteria);


        // RECORRE LOS DATOS DE LOS CADETES Y LOS MUESTRA.
        /*
        foreach (var cadete in cadeteria.ListadoCadetes)
        {
            var muestra = $"Id:{cadete.Id}\nNombre:{cadete.Nombre}\ndireccion:{cadete.Direccion}\ntelefono:{cadete.Telefono}\n";
            Console.WriteLine(muestra);
        }*/

        int opcion = 0;

        while (opcion == 1)
        {
            Menu();
            opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    cadeteria.AltaPedidos(CrearPedido(), SolicitarId("cadete"));
                    break;
                case 2:
                    cadeteria.AsignarPedido(CrearPedido(), SolicitarId("cadete"));
                    break;
                case 3:
                    cadeteria.CambiarEstado(SolicitarId("pedido"), SolicitarId("cadete"), SolicitarEstado());
                    break;
                case 4:
                    cadeteria.ReasignarPedido(SolicitarId("cadete"), SolicitarId("pedido"), SolicitarId("Nuevo cadete"));
                    break;
                default:
                    Console.WriteLine("No existe la opcion");
                    break;
            }

            Console.WriteLine("Desea continuar Si: 1 / No: 0  ");
            opcion = Convert.ToInt32(Console.ReadLine());


        }

        static void Menu()
        {
            Console.WriteLine("\n1- Dar de alta pedido.");
            Console.WriteLine("\n2- Asignar pedido a cadete.");
            Console.WriteLine("\n3- Cambiar de estado un pedido.");
            Console.WriteLine("\n4- Reasignar pedido");
            Console.WriteLine("\nIngrese la opcion: ");
        }

        static Pedido CrearPedido()
        {
            Console.WriteLine("\nIngrese la observacion: ");
            var obs = Console.ReadLine();
            Console.WriteLine(" \nIngrese nombre cliente:");
            var nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese direccion: ");
            var dire = Console.ReadLine();
            Console.WriteLine("\nIngrese telefono : ");
            var tel = Console.ReadLine();
            Console.WriteLine("\nIngrese datos: ");
            var datos = Console.ReadLine();
            var pedido = new Pedido(obs, nombre, dire, tel, datos);
            return pedido;
        }

        static int SolicitarId(string para)
        {
            string msj = $"Ingrese el id de {para}: \n";
            Console.WriteLine(msj);
            return Convert.ToInt32(Console.ReadLine());
        }

        static Estados SolicitarEstado()
        {
            Console.WriteLine("1- En curso .\n");
            Console.WriteLine("2- Completado.\n");
            Console.WriteLine("3- Cancelado. \n");
            Console.WriteLine("Ingrese la opcion: ");
            var opc = Convert.ToInt32(Console.ReadLine());
            switch (opc)
            {
                case 1: return Estados.EnCurso;
                case 2: return Estados.Completado;
                case 3: return Estados.Cancelado;
                default: Console.WriteLine("opcion invalida"); return SolicitarEstado();
            }
        }
        //prueba

        Pedido pedido = new("observacion", "pedido", "direccion", "telefono", "datos");
        Pedido pedido1 = new("observacion", "pedido", "direccion", "telefono", "datos");

        cadeteria.AsignarPedido(pedido, 1);

        cadeteria.AsignarPedido(pedido1, 2);
        cadeteria.AsignarPedido(pedido, 2);

        cadeteria.AsignarPedido(pedido, 3);
        cadeteria.AsignarPedido(pedido, 4);

      /*  cadeteria.AsignarPedido(pedido1, 5);
        cadeteria.AsignarPedido(pedido, 5);
*/
        cadeteria.CambiarEstado(0, 1, Estados.Completado);

        cadeteria.Informe();





    }


}


/*
  var montoGanado = cadeteria.ListadoCadetes.Select(x => x.JornalACobrar()).ToList();
  var cantEnvios = cadeteria.ListadoCadetes.Select(c => c.ListaPedidos.Count(p => p.Estado == Estados.Completado)).ToList();
  var promedio = cadeteria.ListadoCadetes.Select(c => c.ListaPedidos.Count(p => p.Estado == Estados.Completado) / (double) c.ListaPedidos.Count()).ToList();
  foreach (var prom in promedio)
        {
            System.Console.WriteLine(prom * 100);
        }
        var totalEnvios = cantEnvios.Sum();

        var totalRecaudacion = montoGanado.Sum();

        //System.Console.WriteLine(promedio);

*/




