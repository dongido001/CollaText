
using Microsoft.EntityFrameworkCore;

namespace CollaText.Models
{
    public class CollaTextPenContext : DbContext
    {
        public CollaTextPenContext (DbContextOptions<CollaTextPenContext> options)
            : base(options)
        {
        }
        public DbSet<Pen> Pens { get; set; }
    }
}