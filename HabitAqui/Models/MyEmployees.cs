namespace HabitAqui.Models
{
    public class MyEmployees
    {
        public ICollection<Gestor>? Gestores { get; set; }
        public ICollection<Funcionario>? Funcionarios { get; set; }
        public ICollection<Cliente>? Clientes { get; set; }

    }
}
