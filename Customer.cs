using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220304_Cinema
{
    class Customer
    {
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
                            Random rand = new Random();
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
}
