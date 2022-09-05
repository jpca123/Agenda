using Microsoft.EntityFrameworkCore;
using Agenda.Dominio;

namespace Agenda.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("Server=PCJP; Database=Agenda; Integrated Security=True;");
            }
        }

    }
}