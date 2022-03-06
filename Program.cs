using System;

namespace _20220304_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Seat seat = new Seat();
            Customer customer = new Customer();

            while (true)
            {
                switch (seat.DisplayMenu())
                {
                    case 1:
                        seat.PrintSeat();
                        customer.Book();
                        break;
                    case 2:
                        customer.Show();
                        break;
                    case 3:
                        customer.Cancel();
                        break;
                    case 4:
                        Console.WriteLine("종료되었습니다.");
                        break;
                }
            }
        }
    }
}
