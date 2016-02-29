using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GestorDocumental.Codigo
{
    [Serializable()]
    public class NodoCentral
    {
        public List<Nodo> nodos;
        public bool cambios = true;


        public NodoCentral()
        {
            nodos = new List<Nodo>();
            cambios = true;

        }



        public NodoCentral leer(String filename)
        {
            XmlTextReader xmlReader = new XmlTextReader(filename);
            NodoCentral aux = new NodoCentral();
            try
            {
                
                XmlSerializer objreader = new XmlSerializer(this.GetType());
                aux = (NodoCentral)objreader.Deserialize(xmlReader);


            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar fichero, ojo! al salir");
            }
            finally
            {
                xmlReader.Close();
               
            }

            return aux;

        }

        public List<Nodo> buscar(string v)
        {
            List<Nodo> aux = new List<Nodo>();


            foreach (var nodo in nodos)
                if (nodo.buscar(v))
                    aux.Add(nodo);

            return aux;

            
        }



        public List<Resultado> buscarResultados(string texto, bool subnodos = false)
        {
            List<Resultado> aux = new List<Resultado>();


            foreach (var nodo in nodos)
                if (nodo.buscar(texto))
                {
                    Resultado re = new Resultado();
                    re.cargaDesdeNodo(nodo);
                    aux.Add(re);

                    if (subnodos)
                    {
                        List<String> resultados = nodo.buscarNodosContienenTexto(texto);
                        foreach (var result in resultados)
                        {
                            Resultado re2 = new Resultado();
                            re2.cargaDesdeString("subnodo", result.ToString());
                            aux.Add(re2);
                        }
                    }

                }

            return aux;
        }




        public bool grabar(String filename)
        {
            try
            {
                if (cambios == true)
                {

                    XmlSerializer objWriter = new XmlSerializer(this.GetType());
                    StreamWriter objfile = new StreamWriter(filename);
                    objWriter.Serialize(objfile, this);
                    objfile.Close();
                    cambios = false;
                }

                return true;

            }
            catch
            {
                return false;
            }
        }

    }
}
