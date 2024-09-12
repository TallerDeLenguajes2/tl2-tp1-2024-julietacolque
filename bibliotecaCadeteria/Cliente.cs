namespace bibliotecaCadeteria
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string DatosReferencia { get; set; }

        public Cliente(string nombre, string direccion, string telefono, string datosReferencia)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            DatosReferencia = datosReferencia;
        }

    }
}