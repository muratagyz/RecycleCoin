using RecycleCoin.UI.Context;
using RecycleCoin.UI.Core.Data;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;

namespace RecycleCoin.UI.Repository.Concrete
{
    public class AluminumRepository : GenericRepository<Aluminum>, IAluminumRepository
    {
        public AluminumRepository(RecycleCoinDbContext context) : base(context)
        {
        }
    }
}