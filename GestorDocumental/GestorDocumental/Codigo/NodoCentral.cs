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
        public bool cambios=true;





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
