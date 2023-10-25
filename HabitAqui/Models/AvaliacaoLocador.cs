using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class AvaliacaoLocador
    {
        public int Id { get; set; }
        public int Classificacao { get; set; }
        public string? Descricao { get; set; }
        public Locador? Locador { get; set; }
        [ForeignKey("LocadorId")]
        public int? LocadorId { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey("ClienteId")]
        public int? ClienteId { get; set; }
    }
}
