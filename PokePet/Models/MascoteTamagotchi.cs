using System;
using System.Collections.Generic;

namespace PokeTamaLibrary.Models
{
    public class MascoteTamagotchi
    {
        public string Nome { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<string> Habilidades { get; set; }
        public DateTime DataDeAdocao { get; set; }

        public MascoteTamagotchi()
        {
            DataDeAdocao = DateTime.Now;
        }
    }
}
