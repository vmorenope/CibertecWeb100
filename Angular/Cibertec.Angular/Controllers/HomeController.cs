using Microsoft.AspNetCore.Mvc;
using Cibertec.Angular.Code;
using Microsoft.Extensions.Options;

namespace Cibertec.Angular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConfigurationFile _config;
        public HomeController(IOptions<ConfigurationFile> config)
        {
            _config = config.Value;
        }
        public IActionResult Index()
        {
            ViewBag.WebApiUrl = _config.WebApiUrl; return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
    // 1ra parte
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //}
}
