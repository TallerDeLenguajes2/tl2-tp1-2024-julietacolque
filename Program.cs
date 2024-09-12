﻿using bibliotecaCadeteria;
internal class Program
{
    private static void Main(string[] args)
    {
       
        string pathCSV = "Archivos/cadeteria.csv";
        string pathJSON = "Archivos/cadeteria.json";
        int opcion;
        Cadeteria cadeteria;
        Menu1();
        opcion = Convert.ToInt32(Console.ReadLine());
        if (opcion == 1)
        {
            var JSON = new AccesoJSON();
            cadeteria = JSON.CargaCadeteria(pathJSON);
        }
        else
        {
            var CSV = new AccesoCSV();
            cadeteria = CSV.CargaCadeteria(pathCSV);
        }
        opcion = 1;
        System.Console.WriteLine("\n-----------------------------");
        while (opcion == 1)
        {
            Menu2();
            opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    //cadeteria.AltaPedido(CrearPedido());
                    break;
                case 2:
                    cadeteria.AsignarCadeteAPedido(SolicitarId("cadete"), SolicitarId("pedido"));
                    break;
                case 3:
                    cadeteria.CambiarEstado(SolicitarId("pedido"), SolicitarEstado());
                    break;
                case 4:
                    cadeteria.AsignarCadeteAPedido(SolicitarId("cadete"), SolicitarId("pedido"));
                    break;
                case 5:
                    Console.WriteLine(cadeteria.Informe(SolicitarId("cadete")).ToString());
                    break;
                default:
                    Console.WriteLine("No existe la opcion");
                    break;
            }

            Console.WriteLine("Desea continuar Si: 1 / No: 0  ");
            opcion = Convert.ToInt32(Console.ReadLine());


        }
        static void Menu1()
        {
            Console.WriteLine("\n1-Cargar datos JSON.");
            Console.WriteLine("\n2-Cargar datos CSV.");
            Console.WriteLine("\nIngrese la opcion: ");


        }
        static void Menu2()
        {
            Console.WriteLine("\n1- Dar de alta pedido.");
            Console.WriteLine("\n2- Asignar pedido a cadete.");
            Console.WriteLine("\n3- Cambiar de estado un pedido.");
            Console.WriteLine("\n4- Reasignar pedido");
            Console.WriteLine("\n5- Informe");
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
            Console.WriteLine("0- En curso .\n");
            Console.WriteLine("1- Completado.\n");
            Console.WriteLine("2- Cancelado. \n");
            Console.WriteLine("Ingrese la opcion: ");
            var opc = Convert.ToInt32(Console.ReadLine());
            switch (opc)
            {
                case 0: return Estados.EnCurso;
                case 1: return Estados.Completado;
                case 2: return Estados.Cancelado;
                default: Console.WriteLine("opcion invalida"); return SolicitarEstado();
            }
        }
    

        Pedido pedido0 = new("observacion0", "pedido0", "direccion0", "telefono0", "datos0");
        Pedido pedido1 = new("observacion1", "pedido1", "direccion1", "telefono1", "datos1");
        Pedido pedido2 = new("observacion2", "pedido2", "direccion2", "telefono2", "datos2");


        //cadeteria.AltaPedido(pedido0);
        //cadeteria.AltaPedido(pedido1);
        //cadeteria.AltaPedido(pedido2);



        cadeteria.CambiarEstado(1, Estados.Completado);

        //cadeteria.Informe();




    }


}






