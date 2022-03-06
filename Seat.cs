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

        public Seat(int r, int c)
        {
            seat = new int[r, c];

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
    }
}
