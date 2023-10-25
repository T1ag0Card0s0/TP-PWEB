using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class AvaliacaoHabitacao
    {
        public int Id { get; set; }
        public int Classificacao { get; set; }
        public string? Descricao { get; set; }
        public Habitacao? Habitacao { get; set; }
        [ForeignKey("HabitacaoId")]
        public int? HabitacaoId { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey("ClienteId")]
        public int? ClienteId { get; set; }
    }
}
