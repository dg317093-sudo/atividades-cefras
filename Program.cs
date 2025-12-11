using System;
using System.ComponentModel.Design;

namespace atividade3
{
    class program
    {
        public class Node
        {
            public string NomeMusica;
            public Node proximo;
            public Node anterior;

            public Node(string nome)
            {
                NomeMusica = nome;
                proximo = null;
                anterior = null;
            }
        }

        public class Playlist
        {
            private Node inicio;
            private Node fim;

            public void adicionarmuscia(string nome)
            {
                Node novaMusica = new Node(nome);
                if (inicio == null) 
                {
                    inicio = novaMusica;
                    fim = novaMusica;
                }
                else
                {
                    fim.proximo = novaMusica;
                    novaMusica.anterior = fim;
                    fim = novaMusica;
                }
                Console.WriteLine($"musica '{nome}' adicionada!");
            }
            public void tocarplaylist()
            {
                if(inicio == null)
                {
                    Console.WriteLine("a playlist esta vazia");
                    return;
                }
                Node atual = inicio;
                Console.WriteLine("\n--- tocando playlist ---");
                while ( atual != null)
                {
                    Console.WriteLine($"tocando: {atual.NomeMusica}");
                    atual = atual.proximo;
                }
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Playlist playlist = new Playlist();

                playlist.adicionarmuscia("hotel claifornia");
                playlist.adicionarmuscia("vicio");
                playlist.adicionarmuscia("ego");

                playlist.tocarplaylist();
            }
        }

       
    }
}