using RecycleCoin.UI.Context;

namespace RecycleCoin.UI.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecycleCoinDbContext _context;

        public UnitOfWork(RecycleCoinDbContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            var result = _context.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<bool> CommitAsync()
        {
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
    }
}