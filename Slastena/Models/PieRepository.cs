
using Microsoft.EntityFrameworkCore;

namespace Slastena.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly SlastenaPieShopDbContext _slastenaPieShopDbContext;

        public PieRepository(SlastenaPieShopDbContext slastenaPieShopDbContext)
        {
            _slastenaPieShopDbContext = slastenaPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _slastenaPieShopDbContext.Pies.Include(c => c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _slastenaPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _slastenaPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _slastenaPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
