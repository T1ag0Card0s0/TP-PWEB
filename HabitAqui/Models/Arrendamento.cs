using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HabitAqui.Models
{
    public class Arrendamento
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }

        public decimal Custo { get; set; }

        public Cliente Cliente { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        
        public int HabitacaoId { get; set; }
        public Habitacao Habitacao { get; set; }

        public Locador Locador { get; set; }
        [ForeignKey("LocadorId")]
        public int LocadorId { get; set; }

        // estado atual
        public Estados Estado { get; set; }

        // guarda o estado de receção
        public ReceberArrendamento? ReceberArrendamento {  get; set; }
        public int? ReceberArrendamentoId { get; set; }
        
        // guarda o estado de entrega
        public EntregarArrendamento? EntregarArrendamento {  get; set; }
        public int? EntregarArrendamentoId { get; set; }

        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
    }
}
