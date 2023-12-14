using System.ComponentModel.DataAnnotations.Schema;

namespace HabitAqui.Models
{
    public class Gestor
    {
        public int GestorId { get; set; }
        public String Nome { get; set; }
        
        public int LocadorId { get; set; }
        public Locador Locador { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
    
}