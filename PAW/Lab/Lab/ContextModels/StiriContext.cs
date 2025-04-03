using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.ContextModels
{
    public class StiriContext : DbContext
    {
        public StiriContext(DbContextOptions<StiriContext> options) :
            base(options)
        {

        }

        public DbSet<Stire> Stiri { get; set; }
        public DbSet<Categorie> Categorii { get; set; }
    }
}
