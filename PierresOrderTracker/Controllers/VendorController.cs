using Microsoft.AspNetCore.Mvc;
using PierresOrderTracker.Models;

namespace PierresOrderTracker.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}