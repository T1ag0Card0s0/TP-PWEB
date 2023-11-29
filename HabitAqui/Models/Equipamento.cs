using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public List<Arrendamento>? Arrendamentos { get; set;}
        public EquipamentoEstado EquipamentoEstado { get; set; }
        public bool? Existencia { get; set; }
    }
}
