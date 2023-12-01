using System.Text.Json.Serialization;

namespace HabitAqui.Models
{
	public class Categoria
	{
		public int CategoriaId { get; set; }
		public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<Habitacao> Habitacao { get; set; }

        // Adicione uma propriedade Count para armazenar a contagem
        public int Count => Habitacao?.Count ?? 0;
    }
}
