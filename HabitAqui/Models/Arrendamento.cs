using System;
namespace HabitAqui.Models
{
	public class Arrendamento
	{
		public int ArrendamentoId { get; set; }

		// um arrendamento é feito por um cliente
		public Cliente Cliente { get; set; }
		public int ClienteId {  get; set; }

		// um arrendamento tem uma habitacao 
		public Habitacao Habitacao { get; set; }
		public int HabitacaoId {  get; set; }

		public int Periodo_min { get; set; }
		public int Periodo_max { get; set; }
		public DateTime Data_inicio { get; set; }
		public DateTime Data_fim { get; set; }
	}

}
