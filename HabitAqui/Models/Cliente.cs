namespace HabitAqui.Models
{
	public class Cliente
	{
		public int Id { get; set; }

		public Utilizador Utilizador { get; set; }

		// Lista de arrendamentos efetuados pelo cliente
		public List<Arrendamento> Arrendamentos { get; set; }
	}
}
