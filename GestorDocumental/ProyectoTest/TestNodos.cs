﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorDocumental.Codigo;


namespace ProyectoTest
{
    [TestClass]
    public class TestNodos
    {
        [TestMethod]
        public void General()
        {
            NodoCentral aux = new NodoCentral();
            Assert.AreNotEqual(null, aux);


            Nodo n = new Nodo();
            n.codigo = "google";
            n.descripción = "El mejor buscador";
            n.enlace = "http://www.google.es";
            n.carpeta = "";



            Nodo n2 = new Nodo();
            n2.codigo = "fotos";
            n2.descripción = "Sobre fotos";
            n2.enlace = "";
            n2.carpeta = "d:\\seg fotos\\";



            aux.nodos.Add(n);
            aux.nodos.Add(n2);


            Assert.AreEqual(1, aux.buscar("google").Count);
            Assert.AreEqual(1, aux.buscar("palabraimposible fotos").Count);
            Assert.AreEqual(0, aux.buscar("otrapalabraimposible otramasimposible").Count);


        }

        [TestMethod]
        public void ExhaustivoRecorrerDirectorios()
        {
            NodoCentral aux = new NodoCentral();
            Assert.AreNotEqual(null, aux);


            Nodo n = new Nodo();
            n.codigo = "Seg fotos";
            n.descripción = "Relacionado con fotos";
            n.enlace = "";
            n.carpeta = "d:\\seg fotos\\";

            n.subcarpetas.AddRange(Utiles.RecorrerDirectorios(n.carpeta));

            aux.nodos.Add(n);


            Assert.AreEqual(0, aux.buscar("google").Count);
            Assert.AreEqual(1, aux.buscar("palabraimposible bilbao").Count);
            Assert.AreEqual(1, aux.buscar("andorra").Count);

           

        }

        [TestMethod]

        public void ExhaustivoComprobarSubNodos()
        {
            NodoCentral aux = new NodoCentral();
            Assert.AreNotEqual(null, aux);


            Nodo n = new Nodo();
            n.codigo = "Seg fotos";
            n.descripción = "Relacionado con fotos";
            n.enlace = "http://www.heraldo.es";
            n.enlaces.Add("http://www.heraldo.es/sobre.html");
            n.enlaces.Add("http://www.heraldo.es.otro.html");
            aux.nodos.Add(n);




            Assert.AreEqual(2, aux.buscar("heraldo sobre")[0].buscarNodosContienenTexto("heraldo sobre").Count);
            Assert.AreEqual(1, aux.buscar("palabraimposible sobre")[0].buscarNodosContienenTexto("palabraimposible sobre").Count);




        }

        [TestMethod]

        public void PruebaGrabarLeer()
        {
            NodoCentral aux = new NodoCentral();
            Assert.AreNotEqual(null, aux);


            Nodo n = new Nodo();
            n.codigo = "Seg fotos";
            n.descripción = "Relacionado con fotos";
            n.enlace = "";
            n.carpeta = "d:\\seg fotos\\";

            n.subcarpetas.AddRange(Utiles.RecorrerDirectorios(n.carpeta));

            aux.nodos.Add(n);


            Assert.AreEqual(0, aux.buscar("google").Count);
            Assert.AreEqual(1, aux.buscar("palabraimposible bilbao").Count);
            Assert.AreEqual(1, aux.buscar("andorra").Count);


            aux.grabar("c:\\pu\\nodos.xml");

            aux = new NodoCentral();


            aux=aux.leer("c:\\pu\\nodos.xml");

            Assert.AreNotEqual(null, aux);
            Assert.AreEqual(0, aux.buscar("google").Count);
            Assert.AreEqual(1, aux.buscar("palabraimposible bilbao").Count);
            Assert.AreEqual(1, aux.buscar("andorra").Count);



        }

        [TestMethod]
        public void pruebaBusqueda()
        {
            NodoCentral aux = new NodoCentral();
            aux = aux.leer("c:\\pu\\nodos.xml");
           
            Assert.AreEqual(4, aux.buscarResultados("andorra",true).Count);
            

            

        }


    }
}
