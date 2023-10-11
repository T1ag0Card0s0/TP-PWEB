namespace HabitAqui.Models
{
	public class Locador
	{
		public int LocadorId { get; set; }
		public string Nome { get; set; }
		public string Contacto { get; set; }

		// Lista das habitacoes do Locador
		public ICollection<Habitacao> Habitacoes { get; set; }

	}
}
