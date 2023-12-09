using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Path { get; set; }

        [ForeignKey("Arrendamento")]
        public int ArrendamentoId { get; set; }
        public Arrendamento? Arrendamento { get; set; }
    }

}
