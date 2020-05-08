using System;
using System.Collections.Generic;
using Bakery.Models;

namespace Bakery
{
  public class Program
  {


    public static void Main()
    {

      RedBackground(
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
          resp = Bread.BreadMenu();

        }

        else
        {
          resp = Pastry.PastryMenu();
        }

      }

      if (resp == "t")
      {
        TotalPrice();
      }

    }
    public static void TotalPrice()
    {

      Console.WriteLine(
$@"                        ################
                        ###Items List###
                        ################");
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
        Console.WriteLine(
$@"                         Item: {name} ........... Price: ${br.Price}");
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
        Console.WriteLine(
$@"                         Item: {name} ........... Price: ${pas.Price}");
        pastryTotal += pas.Price;
      }

      int pastryDiscount = pastryTypeCount / 3;
      decimal newPastryPrice = pastryTotal - (pastryDiscount * 1.00m);

      int breadDiscount = breadTypeCount / 3;
      decimal newBreadTotal = breadTotal - (breadDiscount * 5.00m);

      decimal totalPricetag = newPastryPrice + newBreadTotal;

      RedBackground(
$@"                        ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                         Your total bread price before discounts is: ${breadTotal}
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

    static void RedBackground(string value)
    {
      //
      // This method writes an entire line to the console with the string.
      //
      Console.BackgroundColor = ConsoleColor.DarkRed;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine(value);

      //Console.ResetColor();
    }


  }
}