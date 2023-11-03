namespace HabitAqui.Models
{
    public class Gestor
    {
        public int GestorId { get; set; }
        public string Nome { get; set; }
        public ICollection<Locador>? Locadores { get; set; }
        public ICollection<Estado>? Estados { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
    
}