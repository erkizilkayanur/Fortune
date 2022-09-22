using Fortune.Context;
using Fortune.Context.Model;

namespace Fortune.Repository
{

    public interface IUserRepository : IBaseRepository<AppUser>
    {

    }

    public class UserRepository : BaseRepository<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
