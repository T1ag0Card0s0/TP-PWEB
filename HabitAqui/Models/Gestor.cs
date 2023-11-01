namespace HabitAqui.Models
{
    public class Gestor
    {
        public int GestorId { get; set; }
        public ICollection<Locador>? Locadores { get; set; }
        public ICollection<Estado>? Estados { get; set; }
        public Utilizador Utilizador { get; set; }
        public int UtilizadorId { get; set; }
    }
}