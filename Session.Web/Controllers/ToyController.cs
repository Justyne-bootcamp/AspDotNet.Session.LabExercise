using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session.Data.Repositories;
using Session.Web.Services;

namespace Session.Web.Controllers
{
    public class ToyController : Controller
    {
        private IToyService _toyService;
        public ToyController(IToyService toyService)
        {
            _toyService = toyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_toyService.GetPagedResult(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPage)
        {
            return View(_toyService.GetPagedResult(currentPage));
        }
        public IActionResult Details(string id)
        {
            ViewData["Toy"] = _toyService.FindByPrimaryKey(id);
            return View();
        }
    }
}
