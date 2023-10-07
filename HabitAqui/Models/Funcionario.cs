namespace HabitAqui.Models
{
	public class Funcionario
	{
		public int Id { get; set; }

		public Utilizador utilizador { get; set; }

		// Locador ao qual esta associado
		public Locador Locador { get; set; }

		// Lista de habitações geridas pelo funcionário
		public List<Habitacao> Habituacoes { get; set; }
	}
}
