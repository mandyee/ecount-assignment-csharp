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

        public int DisplayMenu()
        {
            int input;

            do
            {
                try
                {
                    Console.WriteLine("**************************");
                    Console.WriteLine("*****영화 예매 시스템*****");
                    Console.WriteLine("**************************");
                    Console.Write("1. 예매하기\n\n2. 예매조회\n\n3. 예매취소\n\n4. 종료\n\n");

                    input = int.Parse(Console.ReadLine());

                    if (input >= 1 && input <= 4) break;
                    else throw new Exception("올바른 메뉴를 선택하세요.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);

            return input;
        }

        public void Start()
        {
            while (true)
            {
                switch (DisplayMenu())
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
