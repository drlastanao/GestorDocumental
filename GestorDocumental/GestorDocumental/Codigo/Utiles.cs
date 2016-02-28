using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumental.Codigo
{
    public class Utiles
    {

        public static bool Contains(string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }


        public static bool ContainsIgnore (string source, string toCheck)
        {
            return source!=null && toCheck != null && source.IndexOf(toCheck, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }


        public static List<String> RecorrerDirectorios(string ruta)
        {

            System.IO.DirectoryInfo[] subDirs = null;
            List<String> directorios = new List<String>();


            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(ruta);

            try
            {



                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    directorios.Add(dirInfo.FullName);
                }

                return directorios;

            }
            catch (Exception)
            { 
                return new List<string>();
            }
        }
    }

}

