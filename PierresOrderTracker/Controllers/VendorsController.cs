using Microsoft.AspNetCore.Mvc;
using PierresOrderTracker.Models;
using System.Collections.Generic;

namespace PierresOrderTracker.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
        return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
        Vendor newVendor = new Vendor(vendorName, vendorDescription);
        return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{vendorId}")]
    public ActionResult Show(int vendorId)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor selectedVendor = Vendor.Find(vendorId);
        List<Order> vendorOrders = selectedVendor.Orders;
        model.Add("vendor", selectedVendor);
        model.Add("orders", vendorOrders);
        return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderName, string orderDescription, int orderCost, string orderDate)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderName, orderDescription, orderCost, orderDate);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
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