
using System.Runtime.InteropServices;

namespace tl2_tp1_2024_julietacolque
{
    public class Cadeteria
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public List<Cadete> ListadoCadetes { get; set; } = new List<Cadete>();

        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
        public Cadeteria()
        {

        }

        public void AltaPedidos(Pedido pedido, int id_cadete)
        {
            AsignarPedido(pedido, id_cadete);

        }

        public void AsignarPedido(Pedido pedido, int id_cadete)
        {
            foreach (var cadete in ListadoCadetes)
            {
                if (cadete.Id == id_cadete)
                {
                    cadete.AddPedido(pedido);
                }
            }
        }
        public void CambiarEstado(int id_pedido, int id_cadete, Estados estado)
        {
            foreach (var cadete in ListadoCadetes)
            {
                if (cadete.Id == id_cadete)
                {
                    cadete.ListaPedidos[id_pedido].Estado = estado;
                }
            }
        }

        public void ReasignarPedido(int id_cadete, int id_pedido, int nuevo_cadete)
        {
            Pedido pedido = null;
            foreach (var cadete in ListadoCadetes)
            {
                if (cadete.Id == id_cadete)
                {
                    pedido = cadete.ListaPedidos[id_pedido];
                    cadete.ListaPedidos.RemoveAt(id_pedido);
                    break;
                }
            }
            if (pedido != null) { AsignarPedido(pedido, nuevo_cadete); }
        }

        public void CargarCadete(int id, string nombre, string dire, string tel)
        {

            var cadete = new Cadete(id, nombre, dire, tel);
            ListadoCadetes.Add(cadete);
        }

        public void Informe()
        {
            var montoGanado = ListadoCadetes.Select(x => x.JornalACobrar()).ToList();
            var cantEnvios = ListadoCadetes.Select(c => c.ListaPedidos.Count(p => p.Estado == Estados.Completado)).ToList();
            var promedio = ListadoCadetes.Select(c => c.ListaPedidos.Any() ?
                                                 c.ListaPedidos.Count(p => p.Estado == Estados.Completado) / (double)c.ListaPedidos.Count() : 0.0).ToList();


            for (int i = 0; i < ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"\n-----  Cadete {ListadoCadetes[i].Id}  -----");
                Console.WriteLine($"\nMonto Ganado: {montoGanado[i]}");
                Console.WriteLine($"\nCantidad de pedidos: {ListadoCadetes[i].ListaPedidos.Count}");
                Console.WriteLine($"\nCantidad envios realizados: {cantEnvios[i]}");
                Console.WriteLine($"\nPromedio de envios: {promedio[i] * 100}%");
            }

        }
    }



    /*D) Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
           y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
           envíos promedio por cadete.
      */
}
