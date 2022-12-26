using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UnitTest;

[TestFixture]
public class IronControllerUnitTest
{
    [Test]
    public void GetList()
    {
        // Arrange
        var context = new RecycleCoinDbContext();

        // Action
        var result = context.Irons.ToList();

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void Detail()
    {
        // Arrange
        var userIdTest = new Guid("6784cd47-bccc-4ddd-a38d-75401374b9f5");
        var context = new RecycleCoinDbContext();

        // Action
        var result = context.Irons.Where(x => x.Id == userIdTest).FirstOrDefault();

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void Create()
    {
        // Arrange
        var iron = new Iron()
        {
            Id = new Guid(),
            CarbonValue = 500,
            Object = "Tencere"
        };

        var context = new RecycleCoinDbContext();

        // Action
        context.Irons.Add(iron);
        var result = context.SaveChangesAsync();

        // Assert
        Assert.AreEqual(1, result.Result);
    }

    [Test]
    public void Edit()
    {
        // Arrange
        var iron = new Iron()
        {
            Id = new Guid("e4bf7cd9-9386-4745-1a81-08dae6bc1bca"),
            CarbonValue = 600,
            Object = "Tava"
        };

        var context = new RecycleCoinDbContext();

        // Action
        context.Irons.Update(iron);
        var result = context.SaveChangesAsync();

        // Assert
        Assert.AreEqual(1, result.Result);
    }

    [Test]
    public void Delete()
    {
        // Arrange
        var iron = new Iron()
        {
            Id = new Guid("e4bf7cd9-9386-4745-1a81-08dae6bc1bca"),
            CarbonValue = 600,
            Object = "Tava"
        };

        var context = new RecycleCoinDbContext();

        // Action
        context.Irons.Remove(iron);
        var result = context.SaveChangesAsync();

        // Assert
        Assert.AreEqual(1, result.Result);
    }
}