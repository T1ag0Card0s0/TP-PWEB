using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Models;
using Microsoft.AspNetCore.Identity;

namespace HabitAqui.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        public DbSet<Habitacao> Habitacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Arrendamento> Arrendamentos { get; set; }
        public DbSet<AvaliacaoHabitacao> AvaliacoesHabitacao { get; set; }
        public DbSet<AvaliacaoLocador> AvaliacoesLocador { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Dano> Danos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Locador> Locadores { get; set; }
    }
}