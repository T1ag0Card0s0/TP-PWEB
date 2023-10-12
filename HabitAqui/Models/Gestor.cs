namespace HabitAqui.Models
{
	public class Gestor
	{
		public int GestorId { get; set; }

		public Utilizador Utilizador { get; set; }

		// Lista de funcionários associados ao locador gerido pelo gestor
		public ICollection<Funcionario> Funcionarios { get; set; }

		// Lista de habitações geridas pelo gestor
		public ICollection<Habitacao> Habitacoes { get; set; }
	}
}
