using System.Text;

namespace tl2_tp1_2024_julietacolque
{
    public class Cadeteria
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public List<Cadete> ListadoCadetes { get; set; } = new();
        public List<Pedido> ListaPedidos { get; set; } = new();
        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
        public Cadeteria()
        {

        }
        public void AltaPedido(Pedido pedido)
        {
            ListaPedidos.Add(pedido);
        }
        public void AsignarCadeteAPedido(int id_cadete, int id_pedido)
        {
            Cadete cadete = ListadoCadetes.FirstOrDefault(c => c.Id == id_cadete);


            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Id == id_pedido)
                {
                    pedido.Cadete = cadete;
                }
            }
        }



        public void CambiarEstado(int id_pedido, Estados estado)
        {
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Id == id_pedido)
                {
                    pedido.Estado = estado;
                }
            }
        }

        public void CargarCadete(int id, string nombre, string dire, string tel)
        {

            var cadete = new Cadete(id, nombre, dire, tel);
            ListadoCadetes.Add(cadete);
        }

        public float JornalACobrar(int id_cadete)
        {
            float suma = 0;

            foreach (var pedido in ListaPedidos)
            {

                if (pedido.Estado == Estados.Completado && pedido.Cadete.Id == id_cadete)
                {
                    suma += 500;
                }
            }
            return suma;
        }
        public int CantidadPedidos(int id_cadete)
        {
            int suma = 0;
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Cadete.Id == id_cadete)
                {
                    suma += 1;
                }
            }
            return suma;
        }
        public int CantidadPedidosRealizados(int id_cadete)
        {
            int suma = 0;
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Cadete.Id == id_cadete && pedido.Estado == Estados.Completado)
                {
                    suma += 1;
                }
            }
            return suma;
        }
        public float MontoGanado()
        {
            float suma = 0;
            for (int i = 0; i < ListadoCadetes.Count; i++)
            {
                suma += JornalACobrar(ListadoCadetes[i].Id);
            }
            return suma;
        }
        public StringBuilder Informe()
        {
            StringBuilder datos = new();
            datos.AppendFormat("Monto Ganado:{0}\n", MontoGanado());
            double promedio;
            int cantPedidos, cantEnvios;

            for (int i = 0; i < ListadoCadetes.Count; i++)
            {
                cantPedidos = CantidadPedidos(ListadoCadetes[i].Id);
                cantEnvios = CantidadPedidosRealizados(ListadoCadetes[i].Id);
                promedio = (cantPedidos > 0) ? (double) cantEnvios / cantPedidos : 0;

                datos.AppendFormat("\n-----  Cadete {0}-----",ListadoCadetes[i].Id);
                datos.AppendFormat("\nCantidad de pedidos:{0}",cantPedidos);
                datos.AppendFormat("\nCantidad envios realizados: {0}",cantEnvios);
                datos.AppendFormat("\nPromedio de envios: {0}%",promedio * 100);
            }

            return datos;
        }
    }



    /*D) Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
           y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
           envíos promedio por cadete.
    */
}


/*
  public void ReasignarPedido(int id_cadete, int id_pedido, int nuevo_cadete)
        {
            Pedido pedido = null;
            foreach (var cadete in ListadoCadetes)
            {
                if (cadete.Id == id_cadete)
                {
                    pedido = ListaPedidos[id_pedido];
                    ListaPedidos.RemoveAt(id_pedido);
                    break;
                }
            }
            if (pedido != null) { AsignarPedido(pedido, nuevo_cadete); }
        }



*/

/*
public void Informe()
        {
            var cantEnvios = ListadoCadetes.Select(c => ListaPedidos.Count(p => p.Estado == Estados.Completado)).ToList();
            var promedio = ListadoCadetes.Select(c => ListaPedidos.Any() ?
                                                      ListaPedidos.Count(p => p.Estado == Estados.Completado) / (double)ListaPedidos.Count() : 0.0).ToList();


            for (int i = 0; i < ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"\n-----  Cadete {ListadoCadetes[i].Id}  -----");
                Console.WriteLine($"\nMonto Ganado: {cantEnvios[i] * 500}");
                Console.WriteLine($"\nCantidad de pedidos:{CantidadPedidos(ListadoCadetes[i].Id)}");
                Console.WriteLine($"\nCantidad envios realizados: {cantEnvios[i]}");
                Console.WriteLine($"\nPromedio de envios: {promedio[i] * 100}%");
            }

        }

*/