using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Observacoes { get; set; }
        public Funcionario? Funcionario { get; set; }
        [ForeignKey("FuncionarioId")]
        public int? FuncionarioId { get; set; }
        public ICollection<Equipamento>? Equipamentos { get; set; }
        public ICollection<Dano>? Danos { get; set; }
        public Arrendamento? Arrendamento { get; set; }
        [ForeignKey("ArrendamentoId")]
        public int? ArrendamentoId { get; set; }
    }
}
