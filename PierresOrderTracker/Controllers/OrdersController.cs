using Microsoft.AspNetCore.Mvc;
using PierresOrderTracker.Models;
using System.Collections.Generic;

namespace PierresOrderTracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
        Order order = Order.Find(orderId);
        Vendor vendor = Vendor.Find(vendorId);
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("orders", order);
        model.Add("vendor", vendor);
        return View(model);
    }

    // [HttpPatch("/vendors/{vendorId}/orders/{orderId}/edit")]
    // public ActionResult Update(int orderId)
    // {
    //   Order order = Order.Find(orderId);
    //   order.Paid = "Paid";
    //   return RedirectToAction("Show");
    // }
  }
}
