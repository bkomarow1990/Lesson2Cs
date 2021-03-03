using System;

namespace Massive
{
    class Program
    {
        static void FillRand(int[] arr, int left = 0 , int right = 100)
        {
            Random rnd = new Random();// in c++ srand(base)
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(left, right + 1);
            }
        }
        static void PrintArray(int[]arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item.ToString() + "\t");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter array size : ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Wrong size! Try again");
            }

            int[] arr = new int[size];
            FillRand(arr, 1, 100);
            PrintArray(arr);
            int[] arr2 = new int[arr.Length * 2];
            arr.CopyTo(arr2, 2);
            Console.WriteLine();
            PrintArray(arr2);
            int index = Array.FindIndex(arr,(int e) => { return e > 0; });
            Console.WriteLine($"Index of first positive number in arr: {index}");
            index = Array.FindIndex(arr, e => e % 2 == 0);
            Console.WriteLine($"First number with div on 5 : { index }");
            Array.Resize(ref arr, arr.Length + 1);
            
        }
    }
}
