using EntityFrameworkCoreExample.Managers;
using EntityFrameworkCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreExample.Controllers
{
    public class HomeController : Controller
    {
	    public IActionResult Index()
        {
	        return View();
        }
    }
}
