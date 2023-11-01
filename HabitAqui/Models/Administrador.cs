namespace HabitAqui.Models
{
    public class Administrador
    {
        public int AdministradorId { get; set; }
        public string Name { get; set; }
        public Utilizador Utilizador { get; set; }
        public int UtilizadorId { get; set; }
    }
}