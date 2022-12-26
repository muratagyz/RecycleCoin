using RecycleCoin.UI.Core.Entity;
using RecycleCoin.UI.Enums;

namespace RecycleCoin.UI.Models
{
    public class User : BaseEntity
    {
        public string Identity { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal RecycleCoinAccount { get; set; } = 0;
        public Roles Roles { get; set; }
    }
}