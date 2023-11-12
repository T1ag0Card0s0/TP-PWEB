namespace HabitAqui.Models
{
    public class Administrador
    {
        public int AdministradorId { get; set; }
        public string Name { get; set; }
      
        public ICollection<Locador>Locadores { get; set; }
       
        public ICollection<Categoria>Categorias { get; set; }
 
        public ApplicationUser ApplicationUser { get; set; }
    }
}