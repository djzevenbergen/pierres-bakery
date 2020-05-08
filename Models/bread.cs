using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Bread
  {

    public decimal Price { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }

    private static List<Bread> _instances = new List<Bread> { };

    public Bread(string type, int quantity)
    {
      Type = type;
      Price = FindPrice(type);
      Name = BreadName(type);

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

    public static decimal CalculateBreadDiscount()
    {
      int breadTypeCount = 0;
      foreach (Bread br in GetBreads())
      {
        if (br.Type == "w")
        {
          breadTypeCount += 1;
        }
      }
      decimal totalDiscount = (breadTypeCount / 3) * 5.00m;
      return totalDiscount;
    }

    public static List<string> GenerateBreadReceipt()
    {
      List<string> receipt = new List<string> { };
      foreach (Bread br in Bread.GetBreads())
      {
        receipt.Add(
$@"                      |  Item: {br.Name} ........... Price: ${br.Price}");
      }
      return receipt;

    }
    public static void BreadPrice(string type)
    {
      Console.WriteLine(@"");
      if (type == "r")
      {
        Console.WriteLine(
@"                          Rye is $6.00 a loaf");
      }
      else if (type == "w")
      {
        Console.WriteLine(
@"                          White bread is $5.00 a loaf 
                    (deals will be applied upon checkout)");
      }
      else if (type == "h")
      {
        Console.WriteLine(
@"                          Whole wheat is $6.50 a loaf");
      }
      else
      {
        Console.WriteLine(
@"                      Ok, bakers choice is $5.00 a loaf");
      }
    }

    public static string BreadMenu()
    {

      string breadType;
      string menuOption = "b";
      Console.Write(
@"                        Select kind of bread you'd like:
                       ------------------------------------                       
                                [R]ye - $6.00
                                [W]hite - $5.00
                                W[H]ole Wheat - $6.50
                       ------------------------------------         
                        (*White bread is buy 2, get one free!
                          Must add 3 to your cart to get the deal
                          All deals are applied on checkout)
                                
                                       ");


      breadType = Console.ReadLine().ToLower();

      Bread.BreadPrice(breadType);

      Console.Write(
@"                         Please enter quantity:

                                
                                    ");
      int amount = int.Parse(Console.ReadLine());

      Bread tempBread = new Bread(breadType, amount);

      string tempName = tempBread.BreadName(breadType);


      Console.WriteLine(
$@"                        
                        {amount} loaves of {tempName} added to your cart.
                                            ");
      Console.Write(
@"                        If you'd like to see our pastry menu, press [P].
                        If you'd like to checkout, press [T]otal.
                        If you'd like to buy more bread, press enter.

                                          ");
      string selection = Console.ReadLine().ToLower();

      if (selection == "p")
      {
        menuOption = selection;
      }
      else if (selection == "t")
      {
        menuOption = selection;
      }
      return menuOption;
    }

    public string BreadName(string type)
    {
      string name = "";
      if (type == "w")
      {
        name = "white bread";
      }
      else if (type == "r")
      {
        name = "rye";
      }
      else if (type == "h")
      {
        name = "whole wheat";
      }
      else
      {
        name = "baker's choice";
      }
      return name;
    }


  }
}