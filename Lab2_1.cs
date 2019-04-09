using System;
using System.Text;

namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введіть ціле значення першого множника (A): ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть ціле значення другого множника (B): ");
            int b = int.Parse(Console.ReadLine());
            Multiply(a, b);
            Console.ReadKey();
        }
        static void Multiply(int a, int b)
        {
            Int64 A = (Int64)a << 17,
                S = (Int64)(-a) << 17,
                P = (b << 1) & 0b0000_0000_0000_0000_1111_1111_1111_1111_0;
            string A_bits = IntToBinaryString(A),
                S_bits = IntToBinaryString(S);
            Console.WriteLine("Регістр (Q):\t{0}\nБінарне A:\t{1}\nБінарне -A:\t{2}\n", IntToBinaryString(P), IntToBinaryString(A), IntToBinaryString(S));
            for (int i = 1; i < 17; ++i)
            {
                Console.Write(i + ") ");
                switch (P & 0b11)
                {
                    case 0b01:
                        P += A;
                        Console.WriteLine("  Q + A:\t{0}", IntToBinaryString(P));
                        break;
                    case 0b10:
                        P += S;
                        Console.WriteLine("  Q - A:\t{0}", IntToBinaryString(P));
                        break;
                }
                P >>= 1;
                Console.WriteLine("\t>>:\t" + IntToBinaryString(P));
            }
            P >>= 1;
            Console.WriteLine("\nВідповідь: {0} = {1}", IntToBinaryString(P, true), P);
        }
        static string IntToBinaryString(Int64 number, bool is_end_result = false)
        {
            const int mask = 1;
            var binary = string.Empty;
            for (int i = (is_end_result ? 1 : 0); i < 33; ++i)
            {
                binary = (i % 4 == 0 ? " " : "") + (number & mask) + binary;
                number >>= 1;
            }
            return binary;
        }
    }
}