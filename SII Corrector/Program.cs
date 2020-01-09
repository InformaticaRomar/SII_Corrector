using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SII_Corrector
{
    class Program
    {
        static void Abrir_procesar_guardar(string directorio)
        {
            string[] files = Directory.GetFiles(directorio, "*.xml");
            foreach (string file in files)
            {
                string texto = File.ReadAllText(file);
                string resultado_tmp = texto.Replace("Ã`", "Ñ");
                string resultado = System.Text.RegularExpressions.Regex.Replace(texto, @"[^\p{IsBasicLatin}áéíóúüñ¿¡]+", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                using (StreamWriter writer = new StreamWriter(file, false))
                {
                    writer.Write(resultado);
                }
            }
        }
        static void Main(string[] args)
        {
            if (args.Count() > 0)

                foreach (string dir in args)
                {
                    Abrir_procesar_guardar(dir);
                }
            else
                Abrir_procesar_guardar(Properties.Settings.Default.directorio);
        }
    }
}
