namespace HabitAqui.Models
{
	public class Habitacao
	{
		public int HabitacaoId { get; set; }
        public string Descricao { get; set; }
        public int Custo { get; set; }
		public string Localizacao {  get; set; }
		public DateTime Data_inicio { get; set; }
		public DateTime Data_fim {  get; set; }
		public int PeriodoMinimo {  get; set; }

		public Categoria Categoria { get; set; }
		public int CategoriaId { get; set; }

        // uma habitacao tem um locador
        public Locador Locador { get; set; }
		public int LocadorId {  get; set; }

		// uma habitacao tem varias avaliacoes
		public ICollection<Avaliacao> Avaliacoes { get; set; }
	}

}
