namespace bibliotecaCadeteria
{
    public class Pedido
    {
        private static int incremento = 1;
        public int Id { get; }

        public string Obs { get; set; }
        public Cliente ClienteP { get; set; }

        public Estados Estado { get; set; }

        public Cadete Cadete {get;set;}
        public Pedido(string obs, string nombre, string direccion, string telefono, string datos)
        {
            Id = incremento++;
            Obs = obs;
            Estado = Estados.EnCurso;
            ClienteP = new(nombre, direccion, telefono, datos);
            Cadete = new Cadete();
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
    EnCurso = 0,
    Completado = 1,
    Cancelado = 2
}
