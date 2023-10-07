namespace HabitAqui.Models
{
	public class Locador
	{
		public int Id { get; set; }
		public string Nome { get; set; }

		public string Contacto { get; set; }

		// Lista das habitacoes do Locador
		public List<Habitacao> Habitacoes { get; set; }

	}
}
