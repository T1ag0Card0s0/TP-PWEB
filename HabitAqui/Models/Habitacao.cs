namespace HabitAqui.Models
{
	public enum TipoHabitacao
	{
		Casa, 
		Quarto, 
		Apartamento
	}
	public class Habitacao
	{
		public int Id { get; set; }
		public Locador Locador { get; set; }
		public TipoHabitacao Tipo {  get; set; }

		public string Descricao { get; set; }

		public int Custo { get; set; }

		public Avaliacao Avaliacao { get; set; }
	}
}
