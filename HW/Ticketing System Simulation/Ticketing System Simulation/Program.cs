using System.Net.Sockets;

namespace Ticketing_System_Simulation
{
  
    internal class Program
    {
        static void _newTicket(ref Queue<int> ticket)
        {
         
            int x = ticket.Last();
            x++;
            ticket.Enqueue(x);
            Console.WriteLine($"Ticket {ticket.Last()} issued.");

     

        }
        static void Main(string[] args)
        {
            Queue<int> tickets = new Queue<int>();

            tickets.Enqueue(100);
            if (tickets.Count > 0) {
                _newTicket(ref tickets);
                _newTicket(ref tickets);
                _newTicket(ref tickets);
                _newTicket(ref tickets);
                _newTicket(ref tickets);
            }
            Console.WriteLine("Ticketing System Simulation Started...\r\n\r\n");
            while(tickets.Count > 0)
            {
                Thread.Sleep(500);
                var ticket = tickets.Dequeue();
                Console.WriteLine($"Processing Ticket: {ticket}");
                //Remaining Tickets: 102, 103, 104, 105


                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(500);
                    Console.Write("*");
                    if(i == 4)
                    {
                        Console.WriteLine();
                    }
           
                }
                Console.WriteLine($"Remaining Tickets: {string.Join(",",tickets)}");
                Console.WriteLine("-----");


            }
            Console.WriteLine("No more tickets in the queue.\r\n\r\nTicketing System Simulation Ended.");
            Console.ReadLine();



        }
    }
}
