namespace HabitAqui.Models
{
    public class Administrador
    {
        public int AdministradorId { get; set; }
        public string Name { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
