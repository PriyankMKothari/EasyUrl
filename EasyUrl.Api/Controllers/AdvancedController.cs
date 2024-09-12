using Microsoft.AspNetCore.Mvc;

namespace EasyUrl.Api.Controllers;

/// <summary>
/// Feature - Advanced Links
/// </summary>
[ApiController]
[Route("advanced")]
public class AdvancedController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}