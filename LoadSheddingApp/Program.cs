using System;

namespace LoadSheddingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int action = 0;
            DisplayInfo info = new DisplayInfo();

            try
            {
                Console.Write("Enter 1 if you want to check loadshedding schedule or -1 if you want to exit: ");
                action = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("You have entered invalid key. Please enter a valid key!");
            }

            while (action == 1)
            {
                try
                {
                    Console.Write("\nEnter a number of your surburb: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    info.LoadSheddingDuration(number);
                    info.Result();

                    Console.Write("\nEnter 1 if you want to check loadshedding schedule or -1 if you want to exit: ");
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You have entered invalid key. Please enter a valid key!");
                }
            }

            Console.WriteLine("\nHave a nice day!");

        }
    }
}
