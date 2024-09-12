using Microsoft.AspNetCore.Mvc;

namespace EasyUrl.Api.Controllers;

/// <summary>
/// Feature - Pro Links
/// Generate and store code in the database, return it.
/// </summary>
[ApiController]
[Route("professional")]
public class ProfessionalController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}