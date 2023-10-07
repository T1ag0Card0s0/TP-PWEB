namespace HabitAqui.Models
{
	public enum TipoUtilizador
	{
		Cliente, 
		Gestor, 
		Administrador,
		Funcionario, 
		Anonimo
	}
	public class Utilizador
	{
		public string Id { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }
		public string UserName { get; set; }
		public string Password {  get; set; }
		public string Email {  get; set; }
		public TipoUtilizador Tipo {  get; set; }
	}
}
