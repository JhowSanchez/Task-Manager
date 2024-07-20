
using Microsoft.EntityFrameworkCore;
using ProjetoWEB.Models;

namespace ProjetoWEB.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Tarefas
            modelBuilder.Entity<Tarefas>()
                .Property(t => t.Prioridadade)
                .HasConversion(
                    v => v.ToString(), // Converte enum para string ao armazenar
                    v => Enum.Parse<PrioridadeTarefa>(v)); // Converte string de volta para enum ao recuperar

            // Outras configurações podem ser adicionadas aqui
            modelBuilder.Entity<Tarefas>()
                     .HasOne(t => t.Usuario)
                     .WithMany(u => u.Tarefas)
                     .HasForeignKey(t => t.ID_Usuario);

            base.OnModelCreating(modelBuilder);
        }
    }
}
