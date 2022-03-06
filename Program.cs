using System;

namespace _20220304_Cinema
{
    class Seat
    {
        private static int[,] seat;

        public Seat()
        {
            seat = new int[4, 5];

            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    seat[i, j] = 0;
                }
            }
        }

        public void PrintSeat()
        {
            Console.WriteLine("\n*********좌석 현황*********");

            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    if (seat[i, j] == 0)
                        Console.Write($"[{i + 1}-{j + 1}]");
                    else
                        Console.Write("[예매]");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------");
        }

        public static bool IsBooked(int row, int col)
        {
            // 삼항연산자로 표현해보기

            if (seat[row, col] == 0)
                return false;
            else
                return true;
        }

        public static void Book(int row, int col, int num)
        {
            seat[row, col] = num;
        }

        public static void Show(int num)
        {
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    if (seat[i, j] == num)
                        Console.WriteLine($"\n고객님이 예매하신 좌석은 {i + 1}-{j + 1} 입니다.\n");
                }
            }
        }

        public static void Cancel(int num)
        {
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    if (seat[i, j] == num) seat[i, j] = 0;
                }
            }
        }
    }

    class Customer
    {
        Random rand = new Random();
        int num;

        public void Book()
        {
            int row, col;

            Console.WriteLine("이미 예매된 좌석은 \"예매\"라고 표시됩니다.\n");

            Console.Write("좌석의 행을 선택해주세요. ");
            row = int.Parse(Console.ReadLine()) - 1;
            Console.Write("좌석의 열을 선택해주세요. ");
            col = int.Parse(Console.ReadLine()) - 1;

            // 다른 입력값 들어왔을 때 예외처리 필요
            // 예매할건지 물어보기 > 네, 아니오 필요

            if (!Seat.IsBooked(row, col))
            {
                num = rand.Next();   // 중복값 검사 필요

                Seat.Book(row, col, num);
                Console.WriteLine("\n예매가 완료되었습니다.");
                Console.WriteLine($"예매한 좌석번호: [{row + 1}-{col + 1}] / 예매번호: [{num}]");
                Console.WriteLine("감사합니다.\n");
            }
            else
                Console.WriteLine("\n이미 예약된 좌석입니다.\n");
        }

        public void Show()
        {
            Console.WriteLine("예매번호를 입력해주세요.");
            int num = int.Parse(Console.ReadLine());
            Seat.Show(num);
        }

        public void Cancel()
        {
            Console.WriteLine("예매번호를 입력해주세요.");
            int num = int.Parse(Console.ReadLine());
            Seat.Show(num);

            // 예매를 취소할 것인지 물어보기

            Seat.Cancel(num);
            Console.WriteLine("\n예매가 취소되었습니다. 감사합니다.\n");
        }
    }

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
