using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Pastry
  {

    public decimal Price { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }

    private static List<Pastry> _instances = new List<Pastry> { };

    public Pastry(string type, int quantity)
    {
      Type = type;
      Price = FindPrice(type);
      Name = PastryName(type);

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

    public static decimal TotalPastryPrice()
    {
      decimal total = 0.00m;
      foreach (Pastry p in GetPastries())
      {
        total += p.Price;
      }
      return total;
    }

    public static decimal CalculatePastryDiscount()
    {
      int pastryTypeCount = 0;
      foreach (Pastry br in GetPastries())
      {
        if (br.Type == "c")
        {
          pastryTypeCount += 1;
        }
      }
      decimal totalDiscount = (pastryTypeCount / 3) * 1.00m;
      return totalDiscount;
    }

    public static List<string> GeneratePastryReceipt()
    {
      List<string> receipt = new List<string> { };
      foreach (Pastry br in GetPastries())
      {

        receipt.Add(
$@"                      |  Item: {br.Name} ........... Price: ${br.Price}");
      }

      return receipt;

    }


    public static void PastryPrice(string type)
    {
      Console.WriteLine(@"");
      if (type == "c")
      {
        Console.WriteLine(
@"                                 Croissants are $2.00 
                      (All deals will be applied at checkout)");
      }
      else if (type == "m")
      {
        Console.WriteLine(
@"                           Muffins are $2.50 each");
      }
      else if (type == "o")
      {
        Console.WriteLine(
@"                           Cookies are $1.50 each!");
      }
      else
      {
        Console.WriteLine(
@"                         Ok, bakers choice is $2.00 per pastry");
      }
    }

    public static string PastryMenu()
    {

      string pastryType;
      string menuOption = "p";
      Console.Write(
@"                  
                  
                        Select kind of pastry you'd like:
                       ------------------------------------                       
                                [C]roissant - $2.00
                                [M]uffin - $2.50
                                C[O]okie - $1.50
                       ------------------------------------         
                        (*Croissants are 1 for $2, 3 for $5
                          Must add 3 to your cart to get the deal
                          All deals are applied on checkout)
                                
                                        ");




      pastryType = Console.ReadLine().ToLower();

      Pastry.PastryPrice(pastryType);

      Console.Write(
@"                            Please enter quantity:

                                
                                ");
      int amount = int.Parse(Console.ReadLine());

      Pastry tempBread = new Pastry(pastryType, amount);
      string tempName = tempBread.PastryName(pastryType);

      Console.WriteLine(
$@"                         
                          {amount} {tempName}s added to your cart.");
      Console.Write(
@"                         
                          If you'd like to see our bread menu, press [B].
                          If you'd like to checkout, press [T]otal.
                          If you'd like to buy more pastries, press enter.


                                ");
      string selection = Console.ReadLine().ToLower();

      if (selection == "b")
      {
        menuOption = selection;
      }
      else if (selection == "t")
      {
        menuOption = selection;
      }

      return menuOption;
    }

    public string PastryName(string type)
    {
      string name = "";
      if (type == "c")
      {
        name = "croissant";
      }
      else if (type == "m")
      {
        name = "muffin";
      }
      else if (type == "o")
      {
        name = "cookie";
      }
      else
      {
        name = "baker's choice";
      }
      return name;
    }


  }

}