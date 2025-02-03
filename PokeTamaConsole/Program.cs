using System;
using System.Threading.Tasks;
using AutoMapper;
using PokeTamaLibrary.Controllers;
using PokeTamaLibrary.Mappers;

class Program
{
    static async Task Main()
    {
        // Configuração do AutoMapper
        var config = new MapperConfiguration(cfg => cfg.AddProfile(new MascoteProfile()));
        var mapper = config.CreateMapper();

        // Iniciar jogo com AutoMapper
        TamagotchiController jogo = new TamagotchiController(mapper);
        await jogo.JogarAsync();
    }
}
