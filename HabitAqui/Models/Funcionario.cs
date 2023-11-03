using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome {  get; set; }
        public ICollection<Locador>? Locadores { get; set; }
        public ICollection<Estado>? Estados { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}