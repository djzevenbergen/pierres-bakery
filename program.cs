using System;
using System.Collections.Generic;
using Bakery.Models;

namespace Bakery
{
  public class Program
  {


    public static void Main()
    {

      Console.WriteLine(
@"                      

  _____ _____ ______ _____  _____  ______ _       ____          _  ________ _______     __
 |  __ \_   _|  ____|  __ \|  __ \|  ____( )     |  _ \   /\   | |/ /  ____|  __ \ \   / /
 | |__) || | | |__  | |__) | |__) | |__  |/ ___  | |_) | /  \  | ' /| |__  | |__) \ \_/ / 
 |  ___/ | | |  __| |  _  /|  _  /|  __|   / __| |  _ < / /\ \ |  < |  __| |  _  / \   /  
 | |    _| |_| |____| | \ \| | \ \| |____  \__ \ | |_) / ____ \| . \| |____| | \ \  | |   
 |_|   |_____|______|_|  \_\_|  \_\______| |___/ |____/_/    \_\_|\_\______|_|  \_\ |_|   

                                   
                                                                            
                          We sell bread and pastries
                          Would you like some: 
                                [B]read
                                [P]astries
                                ");

      string resp = Console.ReadLine().ToLower();

      while (resp != "t")
      {

        if (resp == "b")
        {
          resp = BreadMenu();

        }

        else
        {
          resp = PastryMenu();
        }

      }

      if (resp == "t")
      {
        TotalPrice();
      }

    }

    public static string BreadMenu()
    {

      string breadType;
      string menuOption = "b";
      Console.WriteLine(
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

      BreadPrice(breadType);

      Console.Write(
@"                         Please enter quantity:

                                
                                ");
      int amount = int.Parse(Console.ReadLine());

      Bread tempBread = new Bread(breadType, amount);


      Console.WriteLine(
$@"                      {amount} loaves of {breadType} added to your cart.");
      Console.WriteLine(
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

    public static string PastryMenu()
    {

      string pastryType;
      string menuOption = "p";
      Console.WriteLine(
@"                        Select kind of pastry you'd like:
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

      PastryPrice(pastryType);

      Console.Write(
@"                         Please enter quantity:

                                
                                ");
      int amount = int.Parse(Console.ReadLine());

      Pastry tempBread = new Pastry(pastryType, amount);


      Console.WriteLine(
$@"                      {amount} loaves of {pastryType} added to your cart.");
      Console.WriteLine(
@"                        If you'd like to see our bread menu, press [B].
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

    public static void BreadPrice(string type)
    {
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

    public static void PastryPrice(string type)
    {
      if (type == "c")
      {
        Console.WriteLine(
@"                           Croissants are $2.00 
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

    public static void TotalPrice()
    {
      int breadTypeCount = 0;
      decimal breadTotal = 0m;
      int pastryTypeCount = 0;
      decimal pastryTotal = 0m;
      //int pastryTypeCount = 0;

      foreach (Bread br in Bread.GetBreads())
      {
        string name = "";
        if (br.Type == "w")
        {
          name = "White bread";
          breadTypeCount += 1;
        }
        else if (br.Type == "h")
        {
          name = "Whole Wheat";
        }
        else if (br.Type == "r")
        {
          name = "Rye";
        }
        else
        {
          name = "Baker's Choice";
        }
        Console.WriteLine($"{name} for ${br.Price}");
        breadTotal += br.Price;
      }


      foreach (Pastry pas in Pastry.GetPastries())
      {
        string name = "";
        if (pas.Type == "c")
        {
          name = "Croissant";
          pastryTypeCount += 1;
        }
        else if (pas.Type == "m")
        {
          name = "Muffin";
        }
        else if (pas.Type == "o")
        {
          name = "Cookie";
        }
        else
        {
          name = "Baker's Choice";
        }
        Console.WriteLine($"{name} for ${pas.Price}");
        pastryTotal += pas.Price;
      }

      int pastryDiscount = pastryTypeCount / 3;
      decimal newPastryPrice = pastryTotal - (pastryDiscount * 1.00m);

      int breadDiscount = breadTypeCount / 3;
      decimal newBreadTotal = breadTotal - (breadDiscount * 5.00m);

      decimal totalPricetag = newPastryPrice + newBreadTotal;

      WriteFullLine(
$@"                         Your total bread price before discounts is: ${breadTotal}
                         Your total bread price after discounts is: ${newBreadTotal}
                         Your total pastry price before discounts is: ${pastryTotal}
                         Your total pastry price after discount is: ${newPastryPrice}
                         --
                         Your total price is: ${totalPricetag}
                         --
                         You got {breadDiscount} loaves for free!
                         You saved ${pastryDiscount * 1.00m} on pastries!
                         bread.totalbreadprice: {Bread.TotalBreadPrice()}
                         pastry.totalpastryprice: {Pastry.TotalPastryPrice()}");


      Console.ReadLine();
    }

    static void WriteFullLine(string value)
    {
      //
      // This method writes an entire line to the console with the string.
      //
      Console.BackgroundColor = ConsoleColor.DarkGreen;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
                                                                  //
                                                                  // Reset the color.
                                                                  //
      Console.ResetColor();
    }


  }
}