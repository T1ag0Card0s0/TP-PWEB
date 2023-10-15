namespace HabitAqui.Models
{
	public class Funcionario
	{
		public int FuncionarioId { get; set; }

		public Utilizador Utilizador { get; set; }

		public Locador Locador { get; set; }
		public int LocadorId { get; set; }

		// Lista de habitações geridas pelo funcionário
		public ICollection<Habitacao> Habitacoes { get; set; }
	}
}
