using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace HabitAqui.Models
{
    public class ReceberArrendamento
    {
        public int Id { get; set; }
        public Funcionario FuncionarioRecebeu{ get; set; }
        [ForeignKey("FuncionarioRecebeuId")]
        public int FuncionarioRecebeuId { get; set; }

        public List<Equipamento>? Equipamentos { get; set; }
        public string? Danos { get; set; }

        public string? Observacoes { get; set; }
    }
}
