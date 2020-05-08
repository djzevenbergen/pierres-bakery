using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Pastry
  {

    public decimal Price { get; set; }

    public string Type { get; set; }

    private static List<Pastry> _instances = new List<Pastry> { };

    public Pastry(string type, int quantity)
    {
      Type = type;
      Price = FindPrice(type);

      for (int i = 1; i <= quantity; i++)
      {
        _instances.Add(this);
      }

    }

    public static List<Pastry> GetPastries()
    {
      return _instances;
    }

    public decimal FindPrice(string type)
    {
      decimal precio = 0m;
      if (type == "c")
      {
        precio = 2.00m;
      }
      else if (type == "m")
      {
        precio = 2.50m;
      }
      else if (type == "c")
      {
        precio = 1.50m;
      }
      else
      {
        precio = 2.00m;
      }
      return precio;
    }

  }
}