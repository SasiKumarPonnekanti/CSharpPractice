using System;

namespace NullCoalescingCharacter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int? ticketsonsale = null;

            int ticketsavailable;
            if (ticketsonsale == null)
            {
                ticketsavailable = 0;
            }
            else
            {
                ticketsavailable = (int)ticketsonsale;
            }
            Console.WriteLine(ticketsonsale);

           // the above code can be written as

            int ? ticketsonsal = null;
            int ticketsavailabl = ticketsonsal ?? 0;
            Console.WriteLine(ticketsavailabl);
        }
    }
}
