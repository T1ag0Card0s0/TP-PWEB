using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Locador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool EstadoDeSubscricao { get; set; }
        public double? MediaAvaliacao { get; set; }
        public ICollection<Habitacao>? Habitacoes { get; set;}
        public ICollection<AvaliacaoLocador>? Avaliacoes { get; set; }
        public Funcionario? Funcionario { get; set; }
        [ForeignKey("FuncionarioId")]
        public int? FuncionarioId { get; set; }
    }
}
