using System.Collections.Generic;

namespace PierresOrderTracker.Models
{
  public class Order
  {
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Description { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string name, string description, int cost)
    {
      Description = description;
      Name = name;
      Cost = cost;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId -1 ];
    }
    
    public static void DestroyOrder(int id)
    {
      _instances.RemoveAt(id - 1);
    }
  }
}