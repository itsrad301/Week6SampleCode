using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Week6SampleCode2026.Models;

namespace Week6SampleCode2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signinManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _signinManager = signInManager;
        }

        public IActionResult Index()
        {
            var claims = _signinManager.Context.User
            .Claims.Where(r => r.Type == ClaimTypes.Role)
            .Select(v => v.Value).Distinct().ToList();
            ViewData["claims"] = claims;
            ViewData["UserName"] = User.Identity.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
