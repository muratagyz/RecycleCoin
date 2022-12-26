using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;
using RecycleCoin.UI.Repository.Abstract;
using RecycleCoin.UI.UnitOfWorks;

namespace RecycleCoin.UI.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly RecycleCoinDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUserRepository userRepository, RecycleCoinDbContext context, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string? message)
        {
            ViewBag.Message = message;
            return View();
        }

        public async Task<IActionResult> UserCoinAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCoinAdd(UserAddCoinViewModel data)
        {
            var userCheck = await _userRepository.AnyAsync(u => u.Identity == data.Identity);

            if (!userCheck)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            await _userRepository.UserCoinAddAsync(data.Identity, data.RecycleCoinAccount);

            return RedirectToAction("Index", new { message = "İşlem Başarılı" });
        }

        public async Task<IActionResult> UserCoinGet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCoinGet(UserGetViewModel model)
        {
            var userCheck = await _userRepository.AnyAsync(u => u.Identity == model.Identity);

            if (!userCheck)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            var user = _userRepository.Where(u => u.Identity == model.Identity).FirstOrDefault();

            return RedirectToAction("UserGetList", user);
        }

        public async Task<IActionResult> UserGetList(User model)
        {
            return View(model);
        }

        public async Task<IActionResult> CarbonAdd(string? message)
        {
            CarbonAddViewModel data = new CarbonAddViewModel()
            {
                Aluminums = await _context.Aluminums.ToListAsync(),
                Irons = await _context.Irons.ToListAsync(),
                Plastics = await _context.Plastics.ToListAsync(),
                Papers = await _context.Papers.ToListAsync(),
                Pines = await _context.Pines.ToListAsync(),
            };
            ViewBag.Message = message;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> CarbonAluminumAdd(CarbonAddViewModel data)
        {
            var user = await _userRepository.Where(x => x.Identity == data.Identity).FirstOrDefaultAsync();

            if (user == null)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            var total = Convert.ToDecimal(data.AluminsNumber) * data.AluminsValue;
            user.RecycleCoinAccount +=
                RecycleCoin.UI.Utilities.CoinConvert.Convert.CarbonToRecycleCoin(total);

            _userRepository.Update(user);
             await _unitOfWork.CommitAsync();

            return RedirectToAction("Index", new { message = "İşlem Başarılı" });
        }

        [HttpPost]
        public async Task<IActionResult> CarbonIronsAdd(CarbonAddViewModel data)
        {
            var user = await _userRepository.Where(x => x.Identity == data.Identity).FirstOrDefaultAsync();

            if (user == null)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            var total = Convert.ToDecimal(data.IronsNumber) * data.IronsValue;
            user.RecycleCoinAccount +=
                RecycleCoin.UI.Utilities.CoinConvert.Convert.CarbonToRecycleCoin(total);

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index", new { message = "İşlem Başarılı" });
        }

        [HttpPost]
        public async Task<IActionResult> CarbonPapersAdd(CarbonAddViewModel data)
        {
            var user = await _userRepository.Where(x => x.Identity == data.Identity).FirstOrDefaultAsync();

            if (user == null)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            var total = Convert.ToDecimal(data.PapersNumber) * data.PapersValue;
            user.RecycleCoinAccount +=
                RecycleCoin.UI.Utilities.CoinConvert.Convert.CarbonToRecycleCoin(total);

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("CarbonAdd", new { message = "İşlem Başarılı" });
        }

        [HttpPost]
        public async Task<IActionResult> CarbonPinesAdd(CarbonAddViewModel data)
        {
            var user = await _userRepository.Where(x => x.Identity == data.Identity).FirstOrDefaultAsync();

            if (user == null)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            var total = Convert.ToDecimal(data.PinesNumber) * data.PinesValue;
            user.RecycleCoinAccount +=
                RecycleCoin.UI.Utilities.CoinConvert.Convert.CarbonToRecycleCoin(total);

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("CarbonAdd", new { message = "İşlem Başarılı" });
        }

        [HttpPost]
        public async Task<IActionResult> CarbonPlasticsAdd(CarbonAddViewModel data)
        {
            var user = await _userRepository.Where(x => x.Identity == data.Identity).FirstOrDefaultAsync();

            if (user == null)
                return RedirectToAction("Index", new { message = "Böyle Bir Kullanıcı Bulunamadı." });

            var total = Convert.ToDecimal(data.PlasticsNumber) * data.PlasticsValue;
            user.RecycleCoinAccount +=
                RecycleCoin.UI.Utilities.CoinConvert.Convert.CarbonToRecycleCoin(total);

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("CarbonAdd", new { message = "İşlem Başarılı" });
        }

    }
}
