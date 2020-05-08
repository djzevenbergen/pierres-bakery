using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Bread
  {

    public decimal Price { get; set; }

    public string Type { get; set; }

    private static List<Bread> _instances = new List<Bread> { };

    public Bread(string type, int quantity)
    {
      Type = type;
      Price = FindPrice(type);

      for (int i = 1; i <= quantity; i++)
      {
        _instances.Add(this);
      }

    }

    public static List<Bread> GetBreads()
    {
      return _instances;
    }

    public decimal FindPrice(string type)
    {
      decimal precio = 0m;
      if (type == "r")
      {
        precio = 6.00m;
      }
      else if (type == "w")
      {
        precio = 5.00m;
      }
      else if (type == "h")
      {
        precio = 6.50m;
      }
      else
      {
        precio = 5.00m;
      }
      return precio;
    }

    public static decimal TotalBreadPrice()
    {
      decimal total = 0.00m;
      foreach (Bread b in GetBreads())
      {
        total += b.Price;
      }
      return total;
    }

  }
}