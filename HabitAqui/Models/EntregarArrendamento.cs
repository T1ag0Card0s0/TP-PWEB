using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace HabitAqui.Models
{
    public class EntregarArrendamento
    {
        public int Id { get; set; }
        public DateTime DataEntrega {  get; set; }
        public Funcionario FuncionarioEntrega { get; set; }
        [ForeignKey("FuncionarioEntregaId")]
        public int FuncionarioEntregaId { get; set; }

        public List<Equipamento>? Equipamentos { get; set; }
        public string? Danos { get; set; }

        public string? Observacoes { get; set; }
    }
}
