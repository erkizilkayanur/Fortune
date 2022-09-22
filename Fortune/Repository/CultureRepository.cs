using Fortune.Context;
using Fortune.Context.Model;

namespace Fortune.Repository
{

    public interface ICultureRepository : IBaseRepository<Culture>
    {

    }

    public class CultureRepository : BaseRepository<Culture>, ICultureRepository
    {

        public CultureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
