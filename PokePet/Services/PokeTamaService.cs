using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PokeTamaLibrary.Models;

namespace PokeTamaLibrary.Services
{
    public class PokeTamaService
    {
        public static async Task<Mascote> BuscarPokemonAsync(string pokemonName)
        {
            if (string.IsNullOrEmpty(pokemonName))
            {
                Console.WriteLine("❌ Nome inválido! Tente novamente.");
                return null;
            }

            string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("⚠️ A API do Pokémon está indisponível no momento. Tente novamente mais tarde.");
                        return null;
                    }

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Mascote>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("❌ Erro ao conectar com a PokeAPI. Verifique sua conexão.");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erro inesperado: {ex.Message}");
                    return null;
                }
            }
        }

    }
}
