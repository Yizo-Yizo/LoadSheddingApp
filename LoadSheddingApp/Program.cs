using System;

namespace LoadSheddingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DisplayInfo info = new DisplayInfo();

            Console.Write("Enter 1 if you want to check loadshedding schedule or -1 if you want to exit: ");
            int action = Convert.ToInt32(Console.ReadLine());

            while (action == 1)
            {
                Console.Write("\nEnter a number of your surburb: ");
                int number = Convert.ToInt32(Console.ReadLine());

                info.LoadSheddingDuration(number);
                info.Result();

                Console.Write("\nEnter 1 if you want to check loadshedding schedule or -1 if you want to exit: ");
                action = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nHave a nice day!");
            
        }
    }
}
