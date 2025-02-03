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
                Console.WriteLine("Nome inválido!");
                return null;
            }

            string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Mascote>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
