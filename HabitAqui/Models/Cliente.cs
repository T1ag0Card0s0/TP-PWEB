
namespace HabitAqui.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }
        public ICollection<AvaliacaoHabitacao>? AvaliacoesHabitacao { get; set; }
        public ICollection<Arrendamento>? Arrendamentos { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}