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
                    if (seat[i, j] == 0) Console.Write($"[{i + 1}-{j + 1}]");
                    else Console.Write("[예매]");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------");
        }

        public static bool IsBooked(int row, int col)
        {
            return seat[row, col] == 0 ? false : true;
        }

        public static bool IsExist(int num)
        {
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    if (seat[i, j] == num) return true;
                }
            }
            return false;
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
                    Console.Write("1. 예매하기\n\n2. 예매조회\n\n3. 예매취소\n\n");

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
    }

    class Customer
    {
        Random rand = new Random();
        int num;

        public void Book()
        {
            int row, col;
            int ans;

            Console.WriteLine("이미 예매된 좌석은 \"예매\"라고 표시됩니다.\n");

            do
            {
                try
                {
                    Console.Write("좌석의 행을 선택해주세요. ");
                    row = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("좌석의 열을 선택해주세요. ");
                    col = int.Parse(Console.ReadLine()) - 1;

                    if (row >= 0 && row < 4 && col >= 0 && col < 5) break;
                    else throw new Exception("존재하지 않는 좌석번호입니다.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);

            do
            {
                try
                {
                    if (!Seat.IsBooked(row, col))
                    {
                        Console.WriteLine("예매 가능합니다. 예매하시겠습니까?");
                        Console.WriteLine("네(1), 아니오(2) 중 하나를 입력해주세요.");
                        ans = int.Parse(Console.ReadLine());

                        if (ans == 1)
                        {
                            num = rand.Next();   // 중복값 검사 필요

                            Seat.Book(row, col, num);
                            Console.WriteLine("\n예매가 완료되었습니다.");
                            Console.WriteLine($"예매한 좌석번호: [{row + 1}-{col + 1}] / 예매번호: [{num}]");
                            Console.WriteLine("감사합니다.\n");

                            break;
                        }
                        else if (ans == 2) break;
                        else throw new Exception("올바른 값이 아닙니다.\n");
                    }
                    else
                    {
                        Console.WriteLine("\n이미 예약된 좌석입니다.\n"); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        public void Show()
        {
            Console.WriteLine("예매번호를 입력해주세요.");
            int num = int.Parse(Console.ReadLine());

            do
            {
                try
                {
                    if (Seat.IsExist(num))
                    {
                        Seat.Show(num); break;
                    }
                    else
                    {
                        Console.WriteLine("\n존재하지 않는 예매번호입니다.\n"); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        public void Cancel()
        {
            int ans;

            Console.WriteLine("예매번호를 입력해주세요.");
            int num = int.Parse(Console.ReadLine());

            do
            {
                try
                {
                    if (Seat.IsExist(num))
                    {
                        Seat.Show(num);

                        Console.WriteLine("예매를 취소하시겠습니까?");
                        Console.WriteLine("네(1), 아니오(2) 중 하나를 입력해주세요.");
                        ans = int.Parse(Console.ReadLine());

                        if (ans == 1)
                        {
                            Seat.Cancel(num);
                            Console.WriteLine("\n예매가 취소되었습니다. 감사합니다.\n");

                            break;
                        }
                        else if (ans == 2) break;
                        else throw new Exception("올바른 값이 아닙니다.\n");
                    }
                    else
                    {
                        Console.WriteLine("\n존재하지 않는 예매번호입니다.\n");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
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
