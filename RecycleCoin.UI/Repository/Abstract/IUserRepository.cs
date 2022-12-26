using RecycleCoin.UI.Core.Data;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UI.Repository.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UserCoinAddAsync(string identity, decimal recycleCoinAccount);
        Task<string> UserCoinSenderAsync(string identity1, string identity2, decimal recycleCoinAccount);
    }
}