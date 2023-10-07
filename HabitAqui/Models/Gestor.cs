namespace HabitAqui.Models
{
	public class Gestor
	{
		public int Id { get; set; }

		public Utilizador Utilizador { get; set; }

		// Locador ao qual esta associado
		public Locador Locador { get; set; }

		// Lista de funcionários associados ao locador gerido pelo gestor
		public List<Funcionario> Funcionarios { get; set; }

		// Lista de arrendamentos geridos pelo gestor
		public List<Arrendamento> Arrendamentos { get; set; }

		// Lista de habitações geridas pelo gestor
		public List<Habitacao> Habituacoes { get; set; }
	}
}
