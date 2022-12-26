using RecycleCoin.UI.Core.Entity;

namespace RecycleCoin.Core.Entity
{
    public class BaseObjectEntity : BaseEntity
    {
        public string Object { get; set; }
        public decimal CarbonValue { get; set; }
    }
}