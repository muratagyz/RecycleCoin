using RecycleCoin.UI.Context;
using RecycleCoin.UI.Core.Data;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;

namespace RecycleCoin.UI.Repository.Concrete
{
    public class IronRepository : GenericRepository<Iron>, IIronRepository
    {
        public IronRepository(RecycleCoinDbContext context) : base(context)
        {
        }
    }
}