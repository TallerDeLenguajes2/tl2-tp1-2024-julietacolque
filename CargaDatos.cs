namespace tl2_tp1_2024_julietacolque
{
    public static class CargaDatos
    {
        public static Cadeteria CSVCadeteria(string path)
        {

            string linea, delimitador = ",";

            var cadeteria = new Cadeteria();

            if (File.Exists(path))
            {
                using var archivo = new FileStream(path, FileMode.Open);
                using var sr = new StreamReader(archivo);
                linea = sr.ReadLine();
                if (linea != null)
                {
                    string[] cadena = linea.Split(delimitador);
                    cadeteria.Nombre = cadena[0];
                    cadeteria.Telefono = cadena[1];
                }
            }
            return cadeteria;
        }


        public static void CSVCadetes(string path, Cadeteria cadeteria){
            var lista = new List<Cadete>();
           
            string linea,delimitador = ",";

            if(File.Exists(path)){
                using var archivo = new FileStream(path,FileMode.Open);
                using var str = new StreamReader(archivo);
                linea = str.ReadLine();
                while(linea!= null){

                    var cadete = new Cadete();

                    string[] linea_res = linea.Split(delimitador);

                    cadeteria.CargarCadete(Convert.ToInt32(linea_res[0]),linea_res[1],linea_res[2],linea_res[3]);
                    
                    linea = str.ReadLine();
                }
            }




        }
    }
}