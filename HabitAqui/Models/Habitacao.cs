
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HabitAqui.Models
{
    public class Habitacao
    {
        public int Id { get; set; }

        [DataType("number")]
        public double? MediaAvaliacao { get; set; }

        [Required(ErrorMessage = "O custo é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O custo não pode ser menor que zero.")]
        [DataType("number")]
        public int Custo { get; set; }

        [Required]
        [DataType("number")]
        public int PeriodoMinimoArrendamento { get; set; }

        [Required]
        [DataType("number")]
        public int PeriodoMaximoArrendamento{ get; set; }

        public bool Ativo { get; set; }

        [Required]
        [DataType("text")]
        public string Localizacao { get; set; }

        [Required]
        [DataType("number")]
        public Categoria Categoria { get; set; }
        [ForeignKey("CategoriaId")]
        public int? CategoriaId { get; set; }

        public Locador? Locador { get; set; }
        [ForeignKey("LocadorId")]
        public int? LocadorId { get; set; }

        public ICollection<AvaliacaoHabitacao>? Avaliacoes { get; set; }
        public ICollection<Arrendamento>? Arrendamentos { get; set; }
    }
}
