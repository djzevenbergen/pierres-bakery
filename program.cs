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
      string receiptHead;
      receiptHead = (
$@"              

                       ____________________________________________________________
                      |        ################
                      |        ###Items List###
                      |        ################
                      |    ");
      Console.WriteLine(receiptHead);
      // int breadTypeCount = 0;
      // decimal breadTotal = 0m;
      // int pastryTypeCount = 0;
      // decimal pastryTotal = 0m;
      //int pastryTypeCount = 0;

      decimal breadDiscount = Bread.CalculateBreadDiscount();
      decimal breadPrice = Bread.TotalBreadPrice();
      decimal newBreadTotal = breadPrice - breadDiscount;
      List<string> breadReceipt = Bread.GenerateBreadReceipt();
      decimal pastryDiscount = Pastry.CalculatePastryDiscount();
      decimal pastryPrice = Pastry.TotalPastryPrice();
      decimal newPastryPrice = pastryPrice - pastryDiscount;
      List<string> pastryReceipt = Pastry.GeneratePastryReceipt();
      List<string> receipt = new List<string> { };
      receipt.Add(receiptHead);


      decimal totalPricetag = newPastryPrice + newBreadTotal;

      foreach (string b in breadReceipt)
      {
        Console.WriteLine(b);
        receipt.Add(b);

      }

      foreach (string p in pastryReceipt)
      {
        Console.WriteLine(p);
        receipt.Add(p);
      }
      string priceString = (
$@"                      |                                                                                                                                
                      |  ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++   
                      |                                                                                                                            
                      |   Your total bread price before discounts is: ${breadPrice}          
                      |   Your total bread price after discounts is: ${newBreadTotal}           
                      |   Your total pastry price before discounts is: ${pastryPrice}          
                      |   Your total pastry price after discount is: ${newPastryPrice}            
                      |   --                                                          
                      |   Your total price is: ${totalPricetag}                                
                      |   --                                                          
                      |   You saved ${breadDiscount} on bread!                                   
                      |   You saved ${pastryDiscount} on pastries!                                 
                       ---------------------------------------------------------------");
      Console.WriteLine(priceString);

      receipt.Add(priceString);

      Console.WriteLine($"Would you like to save this receipt? [y/n]");
      if (Console.ReadLine().ToLower() == "y")
      {
        PrintReceipt(receipt);
      }
      else
      {
        Console.ReadLine();
        Console.ResetColor();
      }

    }

    static void RedBackground(string value)
    {
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write(value);
    }

    public static void PrintReceipt(List<string> rec)
    {
      string startupPath = Environment.CurrentDirectory;
      System.IO.File.WriteAllLines(startupPath + "/PierresBakeryReceipt.txt", rec);
    }


  }
}
