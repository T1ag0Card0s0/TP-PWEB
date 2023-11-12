using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Existencia { get; set; }
        public string DescricaoEstado { get; set; }
    }
}
