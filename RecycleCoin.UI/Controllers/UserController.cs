using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;

namespace RecycleCoin.UI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(string? message)
        {
            var identity = HttpContext.Session.GetString("userIdentity");
            var user = await _userRepository.Where(x => x.Identity == identity).FirstOrDefaultAsync();
            ViewBag.Message = message;
            return View(user);
        }

        public async Task<IActionResult> UserCoinSend()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCoinSend(UserSendCoinViewModel model)
        {
            var userCheck = await _userRepository.AnyAsync(u => u.Identity == model.Identity);

            if (!userCheck)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });


            var identity = HttpContext.Session.GetString("userIdentity");

            var result = await _userRepository.UserCoinSenderAsync(identity, model.Identity, model.RecycleCoinAccount);

            return RedirectToAction("Index", new { message = result });
        }
    }
}
