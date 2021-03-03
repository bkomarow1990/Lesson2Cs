using System;
using System.IO;
namespace CS_massive_Lesson2
{
    class Program
    {
        static void Swap<T>(ref T one,ref T two)
        {
            T tmp = one;
            one = two;
            two = tmp;
        }
        static bool Equation(double a,double b, double c, out double x1, out double x2)
        {
            double D = Math.Pow(b, 2) - 4 * a * c;
            if (D<0)
            {
                x1 = x2 = double.MinValue;
                return false;
            }
            x1 = (-b + Math.Sqrt(D)) / (2 * a);
            x2 = (-b - Math.Sqrt(D)) / (2 * a);
            return true;
        }
        static void Main(string[] args)
        {
            String first = "1";
            String second = "2";
            Swap(ref first, ref second);
            Console.WriteLine($"One : {first}, Second : {second}");
            Console.WriteLine($"Equation : ");
            double a=1, b=20, c=1, x1, x2;
            if (Equation(a, b, c, out x1, out x2))
            {
                Console.WriteLine($"X1 : {x1:F2}, X2 {x2:F2}");
            }
            else {
                Console.WriteLine("No roots");
            }
            Console.WriteLine("Hello World!");
        }
    }
}
