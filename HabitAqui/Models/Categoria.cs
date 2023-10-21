namespace HabitAqui.Models
{
	public class Categoria
	{
		public int CategoriaId { get; set; }
		public string Nome { get; set; } // EX. T1, T2, T3

		// uma categoria tem varias habitacoes
		public ICollection<Habitacao> Habitacao { get; set; }
	}
}

/*
 * 2	T1
 * 3	T2
 * 4	T3
 * 5	Moradias
 * 6	Terrenos
 */