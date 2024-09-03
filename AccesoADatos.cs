using System.Text.Json;

namespace tl2_tp1_2024_julietacolque
{
    public abstract class AccesoADatos
    {
        public abstract Cadeteria CargaCadeteria(string path);
    }

    public class AccesoCSV : AccesoADatos
    {
        public override Cadeteria CargaCadeteria(string path)
        {
            var cadeteria = new Cadeteria();
            if (File.Exists(path))
            {

                using var archivo = new FileStream(path, FileMode.Open);
                using var str = new StreamReader(archivo);
                var linea = str.ReadLine();
                while (linea != null)
                {
                    var linea_sep = linea.Split(",");
                    cadeteria.Nombre = linea_sep[0];
                    cadeteria.Telefono = linea_sep[1];
                    CargarCadetes(linea_sep[2], cadeteria);
                    linea = str.ReadLine();
                }
                str.Close();
                archivo.Close();
            }

            return cadeteria;
        }

        private void CargarCadetes(string path, Cadeteria cad)
        {

            if (File.Exists(path))
            {
                string[] linea_sep;
                var cadete = new Cadete();
                using var archivo = new FileStream(path, FileMode.Open);
                using var str = new StreamReader(archivo);
                var linea = str.ReadLine();
                while (linea != null)
                {
                    linea_sep = linea.Split(",");
                    cad.CargarCadete(Convert.ToInt32(linea_sep[0]), linea_sep[1], linea_sep[2], linea_sep[3]);
                    linea = str.ReadLine();

                }

                archivo.Close();
                str.Close();
            }

        }



    }



    public class AccesoJSON:AccesoADatos{
        public override Cadeteria CargaCadeteria(string path)
        {
            var cadeteria = new Cadeteria();
            if(File.Exists(path)){

                using var archivo = new FileStream(path,FileMode.Open);
                using var str = new StreamReader(archivo);
                var texto = str.ReadToEnd();
                cadeteria = JsonSerializer.Deserialize<Cadeteria>(texto);
            }
            return cadeteria;
        }

        
    }

}


