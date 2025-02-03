using System.Collections.Generic;

namespace PokeTamaLibrary.Models
{
    public class Mascote
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<AbilitiesClass> Abilities { get; set; }
    }
}
