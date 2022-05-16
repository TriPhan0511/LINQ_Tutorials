using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
                This code reverses a message, counts the number of times
                a particular character appears, then prints the results
                to the console window.
            */
            string originalMessage = "The quick brown fox jumps over the lazy dog.";

            char[] message = originalMessage.ToCharArray();
            Array.Reverse(message);

            int letterCount = 0;

            foreach (char letter in message)
            {
                if (letter == 'o')
                {
                    letterCount++;
                }
            }

            string newMessage = new string(message);

            Console.WriteLine(newMessage);
            Console.WriteLine($"'o' appears {letterCount} times.");
        }

        //static void Main(string[] args)
        //{
        //    //Random random = new Random();
        //    //Console.WriteLine(random.Next(10));
        //    //Console.WriteLine(random.Next(10));
        //    //Console.WriteLine(random.Next(10));

        //    /*
        //        The following code creates five random OrderIDs
        //        to test the fraud detection process.
        //        OrderIDs consist of a letter from A to E, 
        //        and three digit number. Ex. A123
        //     */
        //    Random random = new Random();
        //    string[] orderIDs = new string[5];

        //    for (int i = 0; i < orderIDs.Length; i++)
        //    {
        //        int prefixValue = random.Next(65, 70);
        //        string prefix = Convert.ToChar(prefixValue).ToString();
        //        string suffix = random.Next(1, 1000).ToString("000");
        //        orderIDs[i] = prefix + suffix;
        //    }

        //    foreach (string id in orderIDs)
        //    {
        //        Console.WriteLine(id);
        //    }
        //}




        //static void Main(string[] args)
        //{
        //    Random random = new Random();
        //    int daysUntilExpiration = random.Next(12);
        //    int discountPercentage = 0;

        //    if (daysUntilExpiration == 0)
        //    {
        //        Console.WriteLine("Your subscription has expired.");
        //    }
        //    else if (daysUntilExpiration == 1)
        //    {
        //        Console.WriteLine("Your subscription expires within a day!");
        //        discountPercentage = 20;
        //    }
        //    else if (daysUntilExpiration <= 5)
        //    {
        //        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
        //        discountPercentage = 10;
        //    }
        //    else if (daysUntilExpiration <= 10)
        //    {
        //        Console.WriteLine("Your subscription will expire soon. Renew now!");
        //    }

        //    if (discountPercentage > 0)
        //    {
        //        Console.WriteLine($"Renew now and save {discountPercentage}%!");
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    Random dice = new Random();

        //    int roll1 = dice.Next(1, 7);
        //    int roll2 = dice.Next(1, 7);
        //    int roll3 = dice.Next(1, 7);

        //    //int roll1 = 3;
        //    //int roll2 = 3;
        //    //int roll3 = 3;

        //    //int roll1 = 3;
        //    //int roll2 = 4;
        //    //int roll3 = 3;

        //    int total = roll1 + roll2 + roll3;
        //    Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

        //    //if ((roll1 == roll2) && (roll2 == roll3))
        //    //{
        //    //    Console.WriteLine("You rolled triples! +6 bonus to total");
        //    //    total += 6;
        //    //}
        //    //else if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
        //    //{
        //    //    Console.WriteLine("You rolled doubles! +2 bonus to total!");
        //    //    total += 2;
        //    //}

        //    if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
        //    {
        //        if ((roll1 == roll2) && (roll2 == roll3))
        //        {
        //            Console.WriteLine("You rolled triples! +6 bonus to total!");
        //            total += 6;
        //        }
        //        else
        //        {
        //            Console.WriteLine("You rolled doubles! +2 bonus to total!");
        //            total += 2;
        //        }
        //    }

        //    if (total >= 16)
        //    {
        //        Console.WriteLine("You win a new car!");
        //    }
        //    else if (total >= 10)
        //    {
        //        Console.WriteLine("You win a new laptop");
        //    }
        //    else if (total == 7)
        //    {
        //        Console.WriteLine("You win a strip");
        //    }
        //    else
        //    {
        //        Console.WriteLine("You win a kitten");
        //    }
        //}

    }
}
