
using HabitAqui.Controllers;

namespace HabitAqui.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public ICollection<Arrendamento>? Arrendamentos { get; set; }
        public ICollection<Habitacao>? Favoritos { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}