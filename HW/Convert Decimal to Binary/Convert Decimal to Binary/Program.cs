using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> pinaryDigit = new Stack<int>();

            Console.Write("Enter Nuber To convert: ");
            if(int.TryParse(Console.ReadLine(),out int x))
            {
                int tempint = x;

                while (tempint != 0)
                {
                    pinaryDigit.Push(tempint % 2);

                    tempint /= 2;

                }
            }

            while(pinaryDigit.Count != 0)
            {
                Console.Write($"{pinaryDigit.Peek()}");
                pinaryDigit.Pop();
          
            }

           
        }
    }
}