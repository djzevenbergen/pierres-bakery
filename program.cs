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





    }

    public static string PastryMenu()
    {

    }

    public static void BreadPrice(string type)
    {
      if (type = "r")
      {
        Console.WriteLine("Rye is $6.00 a loaf (deals will be applied upon checkout)");
      }
      else if (type = "w")
      {
        Console.WriteLine("White bread is $5.00 a loaf (deals will be applied upon checkout)");
      }
      else if (type = "h")
      {
        Console.WriteLine("Whole wheat is $6.50 a loaf (deals will be applied upon checkout)");
      }
      else
      {
        Console.WriteLine("Ok, bakers choice is $5.00 a loaf (deals will be applied upon checkout) ");
      }
    }
  }
}