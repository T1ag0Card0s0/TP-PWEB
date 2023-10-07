using System.Data;

namespace HabitAqui.Models
{
	public class Arrendamento
	{
		public int Id { get; set; }

		public Cliente Cliente { get; set; }
		public Habitacao Habitacao { get; set; }
		public int Periodo_min { get; set; }
		public int Periodo_max { get; set; }
		public DateOnly Data_inicio { get; set; }
		public DateOnly Data_fim { get; set; }
	}
}
