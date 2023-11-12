using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome {  get; set; }

        public Locador Locador { get; set; }
        [ForeignKey("LocadorId")]
        public int LocadorId { get; set; }

        public Gestor Gestor { get; set; }
        [ForeignKey("GestorId")]
        public int? GestorId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}