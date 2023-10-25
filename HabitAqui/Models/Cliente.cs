namespace HabitAqui.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<AvaliacaoHabitacao>? AvaliacoesHabitacao { get; set; }
        public ICollection<AvaliacaoLocador>? AvaliacoesLocador { get; set; }
        public ICollection<Arrendamento>? Arrendamentos { get; set; }
    }
}
