using RecycleCoin.UI.Context;
using RecycleCoin.UI.Core.Data;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;

namespace RecycleCoin.UI.Repository.Concrete
{
    public class PaperRepository : GenericRepository<Paper>, IPaperRepository
    {
        public PaperRepository(RecycleCoinDbContext context) : base(context)
        {
        }
    }
}