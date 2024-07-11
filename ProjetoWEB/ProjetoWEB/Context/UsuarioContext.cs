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
    }
}
