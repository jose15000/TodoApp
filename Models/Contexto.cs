using Microsoft.EntityFrameworkCore;

namespace TodoApp.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
