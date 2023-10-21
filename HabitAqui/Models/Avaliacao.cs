namespace HabitAqui.Models
{
	public class Avaliacao
	{
		public int AvaliacaoId { get; set; }

		// uma avaliacao pertence a uma habitacao
        public int HabitacaoId {  get; set; }
		public Habitacao Habitacao { get; set; }

        public int Classificacao { get; set; }
		public string Descricao { get; set; }

		// uma avaliacao é dada por um utilizador
		public Cliente Cliente { get; set; }
		public int ClienteId {  get; set; }
	}
}
