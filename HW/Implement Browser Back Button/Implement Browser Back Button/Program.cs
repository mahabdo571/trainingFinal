using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WebPage page = new WebPage();

            while (true)
            {
                Console.Write("Enter url : ");
                page.Url = Console.ReadLine();
                page.currntPage();
                page.openNewPage();

                Console.Write("1 - back \n 2- close \n 3 - clos :");
                if (int.TryParse(Console.ReadLine(), out int x))
                {

                    if (x == 1)
                    {

                        page.Back();
                        page.currntPage();

                    }

                }
                else if(x == 2)
                {
                    break;
                }

            }

        }
    }
}