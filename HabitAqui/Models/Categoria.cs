using System.Text.Json.Serialization;

namespace HabitAqui.Models
{
	public class Categoria
	{
		public int CategoriaId { get; set; }
		public string Nome { get; set; }
		public bool Ativo { get; set; }
        
        public ICollection<Habitacao> Habitacao { get; set; }

    }
}
