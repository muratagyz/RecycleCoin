using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Core.Data;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;

namespace RecycleCoin.UI.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RecycleCoinDbContext context) : base(context)
        {
        }

        public async Task UserCoinAddAsync(string identity, decimal recycleCoinAccount)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Identity == identity);
            getUser.RecycleCoinAccount += recycleCoinAccount;
            _context.Users.Update(getUser);
            await _context.SaveChangesAsync();
        }

        public async Task<string> UserCoinSenderAsync(string identity1, string identity2, decimal recycleCoinAccount)
        {
            if (recycleCoinAccount < 0)
                return "Gireceğniz değer 0 dan büyük olmalı";

            if (identity1 == identity2)
                return "Kendinize Coin Gönderemezsiniz";

            var user1 = await _context.Users.FirstOrDefaultAsync(x => x.Identity == identity1);
            var user2 = await _context.Users.FirstOrDefaultAsync(x => x.Identity == identity2);

            var user1Result = user1.RecycleCoinAccount - recycleCoinAccount;

            if (user1Result < 0)
                return "Bakiyeniz yetersiz";

            user1.RecycleCoinAccount = user1Result;
            user2.RecycleCoinAccount += recycleCoinAccount;


            _context.Users.Update(user1);
            _context.Users.Update(user2);
            await _context.SaveChangesAsync();

            return "İşlem Başarılı";

        }
    }
}