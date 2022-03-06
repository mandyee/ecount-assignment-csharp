using System;

namespace _20220304_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Seat seat = new Seat();
            Customer customer = new Customer();

            Boolean auto = true;

            while (auto)
            {
                Console.WriteLine("**************************");
                Console.WriteLine("*****영화 예매 시스템*****");
                Console.WriteLine("**************************");
                Console.Write("1. 예매하기\n\n2. 예매조회\n\n3. 예매취소\n\n");

                int input = int.Parse(Console.ReadLine());

                switch (input)
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
                        auto = false;
                        continue;
                    default:
                        Console.WriteLine("올바른 메뉴를 선택하세요\n");
                        continue;
                }
            }
        }
    }
}
