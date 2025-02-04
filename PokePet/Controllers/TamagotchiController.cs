using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PokeTamaLibrary.Models;
using PokeTamaLibrary.Services;
using PokeTamaLibrary.Views;

namespace PokeTamaLibrary.Controllers
{
    public class TamagotchiController
    {
        private readonly IMapper _mapper;
        private List<MascoteTamagotchi> mascotesAdotados; 
        private MenuView menuView;

        public TamagotchiController(IMapper mapper)
        {
            _mapper = mapper;
            menuView = new MenuView();
            mascotesAdotados = new List<MascoteTamagotchi>();
        }

        public async Task JogarAsync()
        {
            string nomeJogador = menuView.SolicitarNomeJogador();

            bool jogando = true;
            while (jogando)
            {
                string escolha;
                do
                {
                    escolha = menuView.ExibirMenu();
                    if (escolha != "1" && escolha != "2" && escolha != "3")
                    {
                        menuView.ExibirMensagem("❌ Opção inválida! Digite 1, 2 ou 3.");
                    }
                } while (escolha != "1" && escolha != "2" && escolha != "3");

                try
                {
                    switch (escolha)
                    {
                        case "1":
                            await AdotarMascoteAsync();
                            break;
                        case "2":
                            menuView.MostrarMascotesAdotados(mascotesAdotados);
                            break;
                        case "3":
                            menuView.ExibirMensagem("Obrigado por jogar! 👋");
                            jogando = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    menuView.ExibirMensagem($"❌ Erro inesperado: {ex.Message}");
                }
            }
        }


        private async Task AdotarMascoteAsync()
        {
            string nomePokemon = menuView.PedirNomePokemon();

            Mascote mascote = await PokeTamaService.BuscarPokemonAsync(nomePokemon);

            if (mascote != null)
            {
                menuView.MostrarDetalhesMascote(mascote);

                if (menuView.ConfirmarAdocao())
                {
                    // 🔹 Usando AutoMapper para converter Mascote em MascoteTamagotchi
                    MascoteTamagotchi novoMascote = _mapper.Map<MascoteTamagotchi>(mascote);

                    mascotesAdotados.Add(novoMascote);
                    menuView.ExibirMensagem($"\n🎉 Parabéns! Você adotou {novoMascote.Nome}! 🎉");
                }
                else
                {
                    menuView.ExibirMensagem("\nTudo bem, escolha outro mascote se desejar!");
                }
            }
            else
            {
                menuView.ExibirMensagem("\nNão foi possível encontrar esse Pokémon. Tente novamente.");
            }
        }
    }
}
