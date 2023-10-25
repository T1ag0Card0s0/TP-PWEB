using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Arrendamento
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Confirmacao { get; set; } // "Em espera" "Confirmado" "Rejeitado"
        public Cliente? Cliente { get; set; }
        [ForeignKey("ClienteId")]
        public int? ClienteId { get; set; }
        public Habitacao? Habitacao { get; set; }
        [ForeignKey("HabitacoesId")]
        public int? HabitacoesId { get; set; }
        public ICollection<Estado>? Estados { get; set; }//Max 2 ESTADOS
    }
}
