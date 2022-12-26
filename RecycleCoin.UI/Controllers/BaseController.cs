using Microsoft.AspNetCore.Mvc;
using RecycleCoin.UI.Models;
using System.Diagnostics;

namespace RecycleCoin.UI.Controllers;

public class BaseController: Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}