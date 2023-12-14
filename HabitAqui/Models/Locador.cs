using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Locador
    {
        public int LocadorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool EstadoDeSubscricao { get; set; }
        public double? MediaAvaliacao { get; set; }
        public ICollection<Habitacao>? Habitacoes { get; set; }
        public ICollection<AvaliacaoLocador>? Avaliacoes { get; set; }
        public ICollection<Funcionario>? Funcionarios { get; set; }
        public ICollection<Gestor>? Gestores { get; set; }

        public ICollection<Arrendamento>? Arrendamentos { get; set; }
  
    }
}