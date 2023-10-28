﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Application
{
    public class EleccionArtista
    {
        public class Cancion
        {
            public string Autor { get; set; }
            public string Genero { get; set; }
            public string Album { get; set; }
            public string EmocionAsociada { get; set; }
            public string UrlVideo { get; set; }
            public string UrlImagenArtista { get; set; }
            public string UrlImagenAlbum { get; set; }
        }

        public List<Cancion> ObtenerCancionesPorEmocion(string emocionSeleccionada)
        {
            List<Cancion> canciones = new List<Cancion>();

            string[] lineas = File.ReadAllLines($"{emocionSeleccionada}.txt");
            Cancion cancionActual = null;

            foreach (string linea in lineas)
            {
                if (linea.StartsWith("Autor:"))
                {
                    cancionActual = new Cancion();
                    canciones.Add(cancionActual);
                    cancionActual.Autor = linea.Substring("Autor:".Length).Trim();
                }
                else if (cancionActual != null)
                {
                    if (linea.StartsWith("Genero:"))
                    {
                        cancionActual.Genero = linea.Substring("Genero:".Length).Trim();
                    }
                    else if (linea.StartsWith("Álbum:"))
                    {
                        cancionActual.Album = linea.Substring("Álbum:".Length).Trim();
                    }
                    else if (linea.StartsWith("Emoción Asociada:"))
                    {
                        cancionActual.EmocionAsociada = linea.Substring("Emoción Asociada:".Length).Trim();
                    }
                    else if (linea.StartsWith("URL del Video:"))
                    {
                        cancionActual.UrlVideo = linea.Substring("URL del Video:".Length).Trim();
                    }
                    else if (linea.StartsWith("URL de la Imagen del Artista:"))
                    {
                        cancionActual.UrlImagenArtista = linea.Substring("URL de la Imagen del Artista:".Length).Trim();
                    }
                    else if (linea.StartsWith("URL de la Imagen del Álbum:"))
                    {
                        cancionActual.UrlImagenAlbum = linea.Substring("URL de la Imagen del Álbum:".Length).Trim();
                    }
                }
            }

            return canciones;
        }

        public void MostrarArtistas(List<Cancion> canciones)
        {
            Console.WriteLine("Lista de artistas relacionados con la emoción seleccionada:");
            int contador = 1;

            foreach (Cancion cancion in canciones)
            {
                Console.WriteLine($"{contador}. {cancion.Autor}");
                contador++;
            }
        }

        public void MostrarInformacionCancion(Cancion cancion)
        {
            Console.WriteLine($"Información de la canción:");
            Console.WriteLine($"Autor: {cancion.Autor}");
            Console.WriteLine($"Género: {cancion.Genero}");
            Console.WriteLine($"Álbum: {cancion.Album}");
            Console.WriteLine($"Emoción Asociada: {cancion.EmocionAsociada}");
            Console.WriteLine($"URL del Video: {cancion.UrlVideo}");
            Console.WriteLine($"URL de la Imagen del Artista: {cancion.UrlImagenArtista}");
            Console.WriteLine($"URL de la Imagen del Álbum: {cancion.UrlImagenAlbum}");
        }
    }
}
