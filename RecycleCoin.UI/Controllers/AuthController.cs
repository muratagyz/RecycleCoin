using Microsoft.AspNetCore.Mvc;
using RecycleCoin.UI.Dtos;
using RecycleCoin.UI.Enums;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;
using RecycleCoin.UI.UnitOfWorks;
using RecycleCoin.UI.Utilities.Hashing;

namespace RecycleCoin.UI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userCheck = await _userRepository.AnyAsync(x =>
                x.UserName == userLoginDto.UserName && x.Password == userLoginDto.Password);

            if (userCheck != true)
            {
                // viewbag ile kullanıcı adı veya şifre yanlış mesajı döndürülmesi lazım
                return RedirectToAction("Login");
            }

            var user = _userRepository.Where(x => x.UserName == userLoginDto.UserName).FirstOrDefault();

            HttpContext.Session.SetString("userIdentity", user.Identity);

            if (user.Roles == Roles.User)
                return RedirectToAction("Index", "User");

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserAddDto userDto)
        {
            var userAdd = new User()
            {
                Id = Guid.NewGuid(),
                FullName = userDto.FullName,
                UserName = userDto.UserName,
                Password = userDto.Password,
                RecycleCoinAccount = 0,
                Identity = HashingHelper.SHA256Hash(),
                Roles = Roles.User
            };

            await _userRepository.AddAsync(userAdd);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
