using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Internal;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Enums;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;
using RecycleCoin.UI.Repository.Concrete;
using RecycleCoin.UI.UnitOfWorks;
using RecycleCoin.UI.Utilities.Hashing;

namespace RecycleCoin.UnitTest;

[TestFixture]
public class UserServiceUnitTest
{
    private IUserRepository _userRepository;
    protected IUnitOfWork _unitOfWork;

    [Test]
    public void GetById()
    {
        // Arrange
        var userTestId = new Guid("863d63ab-f63f-4baa-bb52-458cb82d4f2a");
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();

        // Action
        var result = _userRepository.GetByIdAsync(userTestId).Result;

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void GetAll()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();

        // Action
        var result = _userRepository.GetAll();

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void GetFirstOrDefault()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();

        // Action
        var result = _userRepository.GetFirstOrDefault().Result;

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void Where()
    {
        // Arrange
        var userTestId = new Guid("863d63ab-f63f-4baa-bb52-458cb82d4f2a");
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();

        // Action
        var result = _userRepository.Where(x => x.Id == userTestId).FirstOrDefaultAsync().Result;

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void Any()
    {
        // Arrange
        var userTestId = new Guid("863d63ab-f63f-4baa-bb52-458cb82d4f25");
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();

        // Action
        var result = _userRepository.AnyAsync(x => x.Id == userTestId).Result;

        // Assert
        Assert.AreEqual(true, result);
    }

    [Test]
    public void AddAsync()
    {
        // Arrange
        var user = new User()
        {
            Id = new Guid(),
            FullName = "Unit Test",
            Identity = HashingHelper.SHA256Hash(),
            RecycleCoinAccount = 0,
            Password = "test",
            Roles = Roles.User,
            UserName = "UnitTest"
        };
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();

        // Action
        _userRepository.AddAsync(user);
        var result = _unitOfWork.CommitAsync();

        // Assert
        Assert.AreEqual(true, result.Result);
    }

    [Test]
    public void AddRangeAsync()
    {
        // Arrange
        var users = new List<User>()
        {
            new User() {
                Id = new Guid(),
                FullName = "Unit Test",
                Identity = HashingHelper.SHA256Hash(),
                RecycleCoinAccount = 0,
                Password = "test",
                Roles = Roles.User,
                UserName = "UnitTest"
            },
            new User() {
                Id = new Guid(),
                FullName = "Unit Test2",
                Identity = HashingHelper.SHA256Hash(),
                RecycleCoinAccount = 0,
                Password = "test2",
                Roles = Roles.User,
                UserName = "UnitTest2"
            },
        };
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();

        // Action
        _userRepository.AddRangeAsync(users);
        var result = _unitOfWork.CommitAsync();

        // Assert
        Assert.AreEqual(true, result.Result);
    }

    [Test]
    public void Update()
    {
        // Arrange
        var user = new User()
        {
            Id = new Guid("073f9a5d-f579-4660-2e94-08dae6997243"),
            FullName = "Unit Test Update",
            Identity = HashingHelper.SHA256Hash(),
            RecycleCoinAccount = 0,
            Password = "test Update",
            Roles = Roles.User,
            UserName = "UnitTest Update"
        };
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();

        // Action
        _userRepository.Update(user);
        var result = _unitOfWork.CommitAsync();

        // Assert
        Assert.AreEqual(true, result.Result);
    }

    [Test]
    public void Remove()
    {
        // Arrange
        var user = new User()
        {
            Id = new Guid("20aef6e6-cb8d-41ee-e55a-08dae69be11e"),
            FullName = "Unit Test2",
            Identity = "94E5850F2CABBE331A8CF8EFD23BE8E51FCF7BDDFA80BFE2A88374724CFC9FF1",
            RecycleCoinAccount = 0,
            Password = "test2",
            Roles = Roles.User,
            UserName = "UnitTest2"
        };
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();

        // Action
        _userRepository.Remove(user);
        var result = _unitOfWork.CommitAsync();

        // Assert
        Assert.AreEqual(true, result.Result);
    }

    [Test]
    public void RemoveRangeAsync()
    {
        // Arrange
        var users = new List<User>()
        {
            new User() {
                Id = new Guid("073f9a5d-f579-4660-2e94-08dae6997243"),
                FullName = "Unit Test Update",
                Identity = "C9010BDB560F73DE48B2BDFEAF3E75F56A7754016894B21937A3A5AAD4360B0A",
                RecycleCoinAccount = 0,
                Password = "test Update",
                Roles = Roles.User,
                UserName = "UnitTest Update"
            },
            new User() {
                Id = new Guid("fa9ebf5a-8cd7-4169-e559-08dae69be11e"),
                FullName = "Unit Test",
                Identity = "7D2D1356A5442B72AEEDD9A74B19CC23B210F1FF587D107DF5B516C0E2982A21",
                RecycleCoinAccount = 0,
                Password = "test",
                Roles = Roles.User,
                UserName = "UnitTest"
            },
        };
        var services = new ServiceCollection();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<RecycleCoinDbContext>();
        var serviceProvider = services.BuildServiceProvider();
        _userRepository = serviceProvider.GetService<IUserRepository>();
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();

        // Action
        _userRepository.RemoveRange(users);
        var result = _unitOfWork.CommitAsync();

        // Assert
        Assert.AreEqual(true, result.Result);
    }
}