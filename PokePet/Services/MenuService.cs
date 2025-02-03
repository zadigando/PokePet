using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokeTamaLibrary.Services;
using PokeTamaLibrary.Models;

namespace PokeTamaLibrary.Services
{
    public class MenuService
    {
        private List<Mascote> mascotesAdotados = new List<Mascote>();

        public async Task ExibirMenuAsync()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Bem-vindo ao PokeTama - Seu Pokémon Virtual!");
            Console.WriteLine("==========================================\n");

            Console.Write("Qual é o seu nome? ");
            string nomeJogador = Console.ReadLine();
            Console.WriteLine($"\nOlá {nomeJogador}, escolha uma opção abaixo:\n");

            bool rodando = true;
            while (rodando)
            {
                Console.WriteLine("\n MENU PRINCIPAL ");
                Console.WriteLine("1 - Adoção de mascotes");
                Console.WriteLine("2 - Ver mascotes adotados");
                Console.WriteLine("3 - Sair do jogo");
                Console.Write("Escolha uma opção: ");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        await AdotarMascoteAsync();
                        break;
                    case "2":
                        MostrarMascotesAdotados();
                        break;
                    case "3":
                        Console.WriteLine("Obrigado por jogar!");
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        private async Task AdotarMascoteAsync()
        {
            Console.Write("\nDigite o nome do Pokémon que deseja visualizar antes de adotá-lo: ");
            string nomePokemon = Console.ReadLine()?.ToLower();

            Mascote mascote = await PokeTamaService.BuscarPokemonAsync(nomePokemon);

            if (mascote != null)
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

                Console.Write("\nDeseja adotar esse Pokémon? (s/n): ");
                string resposta = Console.ReadLine()?.ToLower();

                if (resposta == "s")
                {
                    mascotesAdotados.Add(mascote);
                    Console.WriteLine($"\nParabéns! Você adotou {mascote.Name}!");
                }
                else
                {
                    Console.WriteLine("\nTudo bem, escolha outro mascote se desejar!");
                }
            }
            else
            {
                Console.WriteLine("\nNão foi possível encontrar esse Pokémon. Tente novamente.");
            }
        }

        private void MostrarMascotesAdotados()
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
                    Console.WriteLine($"- {mascote.Name}");
                }
            }
        }
    }
}
