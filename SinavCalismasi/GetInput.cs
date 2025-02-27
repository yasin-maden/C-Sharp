using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavCalismasi
{
    internal class GetInput
    {
        public static int GetInt(string message)
        {
            Console.Write(message);
            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                Console.Write(message);
            }
            return input;
        }
        public static int GetPositiveInt(string message)
        {
            int input;
            do
            {
                input = GetInt(message);
            }
            while (input < 0);
            return input;
        }
        public static int GetChoice(string message, int min, int max)
        {
            int choice;
            do
            {
                choice = GetInt(message);
            }
            while (choice < min || choice > max);
            return choice;
        }

        public static string GetString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
