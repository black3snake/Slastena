using Microsoft.EntityFrameworkCore;

namespace Slastena.Models
{
    public class SlastenaPieShopDbContext : DbContext
    {
        public SlastenaPieShopDbContext(DbContextOptions<SlastenaPieShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }


    }
}
