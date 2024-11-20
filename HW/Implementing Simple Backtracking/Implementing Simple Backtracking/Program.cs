using System.IO;

namespace Implementing_Simple_Backtracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> Backtracking = new Stack<string>();
            //Start -> Go to Gaz Station -> Go to Super Market -> Go To Work -> Go to Cafe -> Go Home.

           // Backtracking...
            Backtracking.Push("Start");

            Backtracking.Push("Gaz Station");

            Backtracking.Push("Super Market");
           
            Backtracking.Push("Work");
  
            Backtracking.Push("Cafe");
     
            Backtracking.Push("Home");
            Console.WriteLine("Start -> Go to Gaz Station -> Go to Super Market -> Go To Work -> Go to Cafe -> Go Home.");

            while (Backtracking.Count > 0) {

                Console.WriteLine($"Back to: {Backtracking.Pop()}");
            }
            Console.ReadKey();

        }
    }
}
