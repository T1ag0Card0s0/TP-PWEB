namespace HabitAqui.Models
{
	public class Cliente
	{
		public int ClienteId { get; set; }

		public Utilizador Utilizador { get; set; }

		// Lista de arrendamentos efetuados pelo cliente
		public ICollection<Arrendamento> Arrendamentos { get; set; }

		// Lista de avaliacoes
		public ICollection<Avaliacao>Avaliacoes { get; set; }
	}
}
