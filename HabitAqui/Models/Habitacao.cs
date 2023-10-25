using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Habitacao
    {
        public int Id { get; set; }
        public int PeriodoMinimoArrendamento { get; set; }
        public int PeriodoMaximoArrendamento { get; set; }
        public double Custo { get; set; }
        public double? MediaAvaliacao { get; set; }
        public bool Ativo { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public int? Andar { get; set; }
        public string? NumeroPorta { get; set; }
        public Categoria? Categoria { get; set; }
        [ForeignKey("CategoriaId")]
        public int? CategoriaId { get; set; }
        public Locador? Locador { get; set; }
        [ForeignKey("LocadorId")]
        public int? LocadorId { get; set; }
        public ICollection<AvaliacaoHabitacao>? Avaliacoes { get; set; }
        public ICollection<Arrendamento>? Arrendamentos { get; set; }
    }
}
