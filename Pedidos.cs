
namespace tl2_tp1_2024_julietacolque
{
    public class Pedido
    {
        private static int incremento = 0;
        public int Id { get; }

        public string Obs { get; set; }
        public Cliente ClienteP { get; set; }

        public Estados Estado { get; set; }


        public Pedido(string obs, string nombre, string direccion, string telefono, string datos)
        {
            Id = ++incremento;
            Obs = obs;
            Estado = Estados.EnCurso;
            ClienteP = new(nombre, direccion, telefono, datos);
        }

        public string VerDireccionCliente()
        {
            return ClienteP.Direccion;
        }
        public string VerDatosCliente()
        {
            var cadenaDatos = $"Nombre:{ClienteP.Nombre}\nDireccion:{ClienteP.Direccion}\nTelefono:{ClienteP.Telefono}\nDatosReferencia:{ClienteP.DatosReferencia}";
            return cadenaDatos;

        }

    }
}

public enum Estados
{
    EnCurso,
    Completado,
    Cancelado
}
