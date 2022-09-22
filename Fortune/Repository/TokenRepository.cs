using Fortune.Context;
using Fortune.Context.Model;

namespace Fortune.Repository
{

    public interface ITokenRepository : IBaseRepository<TokenIdentitiy>
    {

    }

    public class TokenRepository : BaseRepository<TokenIdentitiy>, ITokenRepository
    {

        public TokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
