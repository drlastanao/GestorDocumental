using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumental.Codigo
{
    [Serializable()]
    public class Nodo
    {
        public String codigo { get; set; }
        public String descripción { get; set; }
        public String otros { get; set; }

        public String enlace { get; set; }
        public List<String> enlaces { get; set; }

        public String carpeta { get; set; }
        public List<String> subcarpetas { get; set; }




        public bool buscar(String texto)
        {
            bool encontrado = false;

            string[] palabras = texto.Split(' ');


            foreach (var palabra in palabras)
            {
                encontrado = encontrado | Utiles.ContainsIgnore(codigo, texto) | Utiles.ContainsIgnore(descripción, texto)
                                        | Utiles.ContainsIgnore(otros, texto) | Utiles.ContainsIgnore(enlace, texto) | Utiles.ContainsIgnore(carpeta, texto);

                if (encontrado == false)
                    encontrado = encontrado | buscarLista(enlaces, texto);

                if (encontrado == false)
                    encontrado = encontrado | buscarLista(subcarpetas, texto);


                if (encontrado) break;

            }



            return encontrado;


        }


        //devuelve todos los enlaces o carpetas que tienen alguna de las palabras   (sin repetir)

        public List<String> buscarNodosContienenTexto(String texto)
        {
            List<String> nodos = new List<String>();

            string[] palabras = texto.Split(' ');


            foreach (var palabra in palabras)
            {
                List<String> aux;

                aux = nodosContienen(subcarpetas, palabra);
                nodos.AddRange(aux);
                aux = nodosContienen(enlaces, palabra);
                nodos.AddRange(aux);
            }

            List<String> devolver = new List<String>();
            devolver.AddRange(nodos.Distinct());
            return devolver;

        }


        //busca en una lista el texto y dice si está o no
        private bool buscarLista(List<string> lista, string texto)
        {
            foreach (var item in lista)
                if (Utiles.ContainsIgnore(item.ToString(), texto))
                    return true;

            return false;


        }

        //devuelve los elementos de la lista que tienen el texto
        private List<String> nodosContienen(List<string> lista, string texto)
        {
            List<String> devuelvelista = new List<string>();

            foreach (var item in lista)
                if (Utiles.ContainsIgnore(item.ToString(), texto))
                    devuelvelista.Add(item.ToString());

            return devuelvelista;

        }
    }
}

