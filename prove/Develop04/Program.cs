using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select a choice from the menu:");

            string choiceStr = Console.ReadLine();
            int.TryParse(choiceStr, out choice);

            if(choice == 1)
            {
                BreathingActivity breathe = new BreathingActivity(1.5f, 2.5f, "Welcome to the breathing activity!", 3, "Here, we will try to calm our breathing for a bit.", 1);
                breathe.DoActivity();
            }
            else if(choice == 2)
            {
                ReflectingActivity reflect = new ReflectingActivity(1, "Welcome to the reflecting activity!", 3, "Here, we will ponder about a previous experience.");
                reflect.DoActivity();
            }
            else if (choice == 3)
            {
                ListingActivity list = new ListingActivity(1, "Welcome to the listing activity!", 3, "Here, we will make a list of items relating to a prompt.");
                list.DoActivity();   
            }
            else if (choice == 4)
            {
                //they quit, ignore.
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again.");
                Thread.Sleep(150);
            }
        }
    }
}