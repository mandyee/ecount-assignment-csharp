using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220304_Cinema
{
    class Cinema
    {
        private Seat seat;
        private Customer customer;

        public Cinema(int row, int col)
        {
            seat = new Seat(row, col);
            customer = new Customer(row, col);
        }

        public void Start()
        {
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
                        return;
                }
            }
        }
    }
}
