using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
