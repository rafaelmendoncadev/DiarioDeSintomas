using Microsoft.EntityFrameworkCore;

namespace DiarioDeSintomas.Models
{
    public class DiarioContext : DbContext
    {
        public DiarioContext(DbContextOptions<DiarioContext> options) : base(options) { }

        public DbSet<DiarioSintoma> DiarioSintomas { get; set; }
    }
}
