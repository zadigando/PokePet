using System;
using System.Collections.Generic;
using PokeTamaLibrary.Models;

namespace PokeTamaLibrary.Views
{
    public class MenuView
    {
        public string SolicitarNomeJogador()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Bem-vindo ao PokeTama - Seu Pokémon Virtual!");
            Console.WriteLine("==========================================\n");

            Console.Write("Qual é o seu nome? ");
            return Console.ReadLine();
        }

        public string ExibirMenu()
        {
            Console.WriteLine("\nMENU PRINCIPAL");
            Console.WriteLine("1 - Adoção de mascotes");
            Console.WriteLine("2 - Ver mascotes adotados");
            Console.WriteLine("3 - Sair do jogo");
            Console.Write("Escolha uma opção: ");
            return Console.ReadLine();
        }

        public string PedirNomePokemon()
        {
            Console.Write("\nDigite o nome do Pokémon que deseja visualizar antes de adotá-lo: ");
            return Console.ReadLine()?.ToLower();
        }

        public void MostrarDetalhesMascote(Mascote mascote)
        {
            Console.WriteLine("\n===== INFORMAÇÕES DO POKÉMON =====");
            Console.WriteLine($"Nome: {mascote.Name}");
            Console.WriteLine($"Altura: {mascote.Height / 10.0} m");
            Console.WriteLine($"Peso: {mascote.Weight / 10.0} kg");
            Console.WriteLine("\nHabilidades:");
            foreach (var ability in mascote.Abilities)
            {
                Console.WriteLine($"- {ability.Ability.Name}");
            }
        }

        public bool ConfirmarAdocao()
        {
            Console.Write("\nDeseja adotar esse Pokémon? (s/n): ");
            string resposta = Console.ReadLine()?.ToLower();
            return resposta == "s";

        }

        public void MostrarMascotesAdotados(List<MascoteTamagotchi> mascotesAdotados)
        {
            if (mascotesAdotados.Count == 0)
            {
                Console.WriteLine("\nVocê ainda não adotou nenhum mascote.");
            }

            else
            {
                Console.WriteLine("\nSeus Mascotes Adotados");
                foreach (var mascote in mascotesAdotados)
                {
                    Console.WriteLine($"- {mascote.Nome}");
                }
            }
        }

        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
