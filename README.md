# _Pierre's Baker_

#### _Simulates an ordering system for a bakery, 5/8/2020_

#### By _**DJ Zevenbergen**_

## Description

_This C# console application uses custom classes, namespaces, looping, lists, and autogenerated propertiese to allow the user to interact with a bakery.  _

## Setup/Installation Requirements

* Clone repository from GitHub in terminal or console
* ensure that C#/.netcore2.2 is installed on your computer
* dotnet run


## Specs

* - Allows the user to enter whether they want to purchase bread or pastries.
    * enters b for bread
    * returns
        *  - [R]ye - $6.00
        *  - [W]hite - $5.00
        *  - W[H]ole Wheat - $6.50
    * enter p for pastries
    * returns
        *  - [C]roissant - $2.00
        *  - [M]uffin - $2.50
        *  - C[O]okie - $1.50

* - Allows the user to enter the type of bread/pastry they want to purchase.
    * enter c for Croissant
    * returns "Croissants are $2.00, how many would you like?"


* - Allows the user to return to continue to buy bread or pastries or switch menus
    * enter 'b' to view bread menu
    * returns bread menu

* - Allows the user to view their total and checkout
    * enter 't' for total after purchasing any amount of product
    * return 
      *  Your total bread price before discounts is: ${breadTotal}
      *  Your total bread price after discounts is: ${newBreadTotal}
      *  Your total pastry price before discounts is: ${pastryTotal}
      *  Your total pastry price after discount is: ${newPastryPrice}
      *  --
      *  Your total price is: ${totalPricetag}
      *  --
      *  You got {breadDiscount} loaves for free!
      *  You saved ${pastryDiscount * 1.00m} on pastries!



    

## Known Bugs
* No Known Bugs

## License

Copyright © 2020

**_DJ Zevenbergen_**
