namespace HabitAqui.Models
{
	public class Avaliacao
	{
		public int Id { get; set; }
		public int Classificacao { get; set; }
		public string Descricao { get; set; }

		public Cliente Cliente { get; set; }
	}
}
