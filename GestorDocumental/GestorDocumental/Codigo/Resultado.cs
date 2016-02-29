using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumental.Codigo
{
   public  class Resultado
    {
        public String tipo { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String ruta { get; set; }




        public void cargaDesdeNodo (Nodo aux)
        {
            tipo = "Nodo";
            nombre = aux.codigo;
            descripcion = aux.descripción;
            if (aux.carpeta != "")
                ruta = aux.carpeta;
            else
                ruta = aux.enlace;
           
        } 

        public void cargaDesdeString(String tipo,String carpeta)
        {
            this.tipo = tipo;
            this.descripcion = "";
            this.ruta = carpeta;
            this.nombre = carpeta;

        }
    }
}
