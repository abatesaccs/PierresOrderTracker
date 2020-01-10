using Microsoft.AspNetCore.Mvc;
using PierresOrderTracker.Models;

namespace PierresOrderTracker.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}