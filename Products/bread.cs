using System;
using System.Collections.Generic;

namespace Bakery.Products
{
  public class Bread
  {

    public decimal Price { get; set; }

    public string Type { get; set; }

    private static List<Bread> _instance = new List<Bread> { };

    public Bread(decimal price, string type)
    {
      Price = price;
      Type = type;
      _instances.Add(this);
    }

    public static List<Bread> GetBreads()
    {
      return _instances;
    }

  }
}