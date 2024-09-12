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
        public void AltaPedido(string obs, string nombre, string direccion, string telefono, string datos)
        {
            Pedido pedido = new(obs,nombre,direccion,telefono,datos);
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

        public string Informe(int id_cadete){
            
            int cantPedidos = CantidadPedidosRealizados(id_cadete);
            int cantEnvios = CantidadPedidos(id_cadete);
            var promedio = (cantPedidos > 0) ? (double) cantEnvios / cantPedidos : 0;

            return $"ID:{id_cadete}\nCantidad Pedidos:{cantPedidos}\nCantidad Envios:{cantEnvios}\nPromedio:{promedio}\nGanancia:{cantEnvios*500}";
        }
    



    /*D) Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
           y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
           envíos promedio por cadete.
    */
}

}


