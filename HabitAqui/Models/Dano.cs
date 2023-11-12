using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Dano
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public byte[]? Image { get; set; }
        public string? Fomat { get; set; }
    }
}
