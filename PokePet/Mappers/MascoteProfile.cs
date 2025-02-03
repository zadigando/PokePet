using AutoMapper;
using PokeTamaLibrary.Models;
using System.Linq;

namespace PokeTamaLibrary.Mappers
{
    public class MascoteProfile : Profile
    {
        public MascoteProfile()
        {
            CreateMap<Mascote, MascoteTamagotchi>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height / 10.0))  // Convertendo para metros
                .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight / 10.0))  // Convertendo para kg
                .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities.Select(a => a.Ability.Name).ToList()));
        }
    }
}
