using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HabitAqui.Models;

namespace HabitAqui.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HabitAqui.Models.Utilizador>? Utilizador { get; set; }
        public DbSet<HabitAqui.Models.Habitacao>? Habitacao { get; set; }
        public DbSet<HabitAqui.Models.Locador>? Locador { get; set; }
        public DbSet<HabitAqui.Models.Arrendamento>? Arrendamento { get; set; }
        public DbSet<HabitAqui.Models.Gestor>? Gestor { get; set; }
        public DbSet<HabitAqui.Models.Cliente>? Cliente { get; set; }
        public DbSet<HabitAqui.Models.Avaliacao>? Avaliacao { get; set; }
        public DbSet<HabitAqui.Models.Funcionario>? Funcionario { get; set; }
        public DbSet<HabitAqui.Models.Administrador>? Administrador { get; set; }
        public DbSet<HabitAqui.Models.Categoria>? Categoria { get; set; }

	}
}