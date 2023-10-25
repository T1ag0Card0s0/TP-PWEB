namespace HabitAqui.Models
{
	public class Categoria
	{
		public int CategoriaId { get; set; }
		public string Nome { get; set; } 
		public ICollection<Habitacao>? Habitacao { get; set; }
	}
}
