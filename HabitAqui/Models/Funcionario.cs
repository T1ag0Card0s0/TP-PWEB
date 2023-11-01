using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public ICollection<Locador>? Locadores { get; set; }
        public ICollection<Estado>? Estados { get; set; }
        public Utilizador Utilizador { get; set; }
        public int UtilizadorId { get; set; }
    }
}