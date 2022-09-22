using Fortune.Context;
using Fortune.Context.Model;

namespace Fortune.Repository
{

    public interface ICardRepository : IBaseRepository<Card>
    {

    }

    public class CardRepository : BaseRepository<Card>, ICardRepository
    {

        public CardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
