

namespace tl2_tp1_2024_julietacolque
{
    public class Cadete
    {
        public int Id { get;set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Pedido> ListaPedidos { get; set; } = new List<Pedido>();


        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            Id = id ;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public Cadete(){ }

            

        public float JornalACobrar()
        {
            float suma = 0;

            foreach (var pedido in ListaPedidos)
            {

                if (pedido.Estado == Estados.Completado)
                {
                    suma += 500;
                }
            }
            return suma;
        }

        public void AddPedido(Pedido pedido)
        {
            ListaPedidos.Add(pedido);
        }

    }
}