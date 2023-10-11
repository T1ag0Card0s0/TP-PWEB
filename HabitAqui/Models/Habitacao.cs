namespace HabitAqui.Models
{
	public class Habitacao
	{
		public int HabitacaoId { get; set; }
        public string Descricao { get; set; }
        public int Custo { get; set; }

        // uma habitacao tem um locador
        public Locador Locador { get; set; }
		public int LocadorId {  get; set; }

		// uma habitacao tem varias avaliacoes
		public ICollection<Avaliacao> Avaliacoes { get; set; }
	}

}
