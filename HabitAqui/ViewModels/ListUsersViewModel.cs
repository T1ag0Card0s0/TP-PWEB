using HabitAqui.Models;

namespace HabitAqui.ViewModels
{
    public class ListUsersViewModel
    {
        public List<Funcionario> Funcionarios { get; set; }
        public List<Gestor> Gestores { get; set; }
        public List<Locador> Locadores { get; set; }
        public List<Cliente> Clientes { get; set;}
    }
}
