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

        public ICollection<Equipamento>?EquipamentosOpcionais { get; set; }
        public ICollection<Dano>? Danos { get; set; }

        public String Observacoes { get; set; }

        public Funcionario FuncionarioEntrega { get; set; }
        public int FuncionarioEntregaId { get; set; }

        public Locador Locador { get; set; }
        [ForeignKey("LocadorId")]
        public int LocadorId { get; set; }

        public DateTime DataEntrega { get; set; }

        public bool Ativo { get; set; } // confirmado ou rejeitado
    }
}
