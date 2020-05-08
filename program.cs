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
@"                          Welcome to Pierre's Bakery
                          We sell bread and pastries
                          Would you like some: 
                                [B]read
                                [P]astries
                                ");

      string resp = Console.ReadLine().ToLower();

      while (resp == "b")
      {
        resp = BreadMenu();

      }

      while (resp == "p")
      {
        resp = PastryMenu();
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
                                [R]ye
                                [W]hite
                                W[H]ole Wheat
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
      string optionMenu = "t";
      return optionMenu;
    }

    public static void BreadPrice(string type)
    {
      if (type == "r")
      {
        Console.WriteLine(
@"                         Rye is $6.00 a loaf");
      }
      else if (type == "w")
      {
        Console.WriteLine(
@"                        White bread is $5.00 a loaf (deals will be applied upon checkout)");
      }
      else if (type == "h")
      {
        Console.WriteLine(
@"                        Whole wheat is $6.50 a loaf");
      }
      else
      {
        Console.WriteLine("Ok, bakers choice is $5.00 a loaf");
      }
    }

    public static void TotalPrice()
    {
      int breadTypeCount = 0;
      decimal total = 0m;
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
        total += br.Price;
      }

      int breadDiscount = breadTypeCount / 3;
      decimal newTotal = total - (breadDiscount * 5.00m);

      Console.WriteLine(
$@"                        Your total price before discounts is:{total}
                         Your total after discounts is: {newTotal}
                         You got {breadDiscount} loaves for free!");

      Console.ReadLine();


    }


  }
}