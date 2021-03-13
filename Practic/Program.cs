using System;
using System.IO;
using System.Linq;
namespace Practic
{
    //    -------------Одновимірні масиви C #---------------------------------------------
    //7. Перерозташувати елементи у масиві(відємні, потім невідємні) у порядку їх слідування.
    //Для масиву : 2  1 -4  -55  -7 100 10
    //Повинні отримати змінений масив: -4  -55  -7  2 1 100 10
    //Використати FindAll(), CopyTo().

    //8. Вводиться число. Масив заповнити випадковими числами. Знайти кількість входжень у масив введеного числа.
    //Скористатися Count() з System.Linq

    //9. Визначити суму елементів, розміщених між максимальним та мінімальним елементом масиву.
    //Користуватися методами (Max, Min, IndexOf)

    //10. Створити 2 паралельних масиви: назви та ціни тoварів. Впорядкувати масиви по зростанню ціни(Sort(keys, values)). 
    class Program
    {
        static void task1(ref int[] arr, ref int[] toArr)
        {

            int[] result1 = new int[0];
            int[] result2 = new int[0];

            result1 = Array.FindAll(arr, e => e < 0);
            result2 = Array.FindAll(arr, e => e >= 0);
            result1.CopyTo(toArr, 0);
            result2.CopyTo(toArr, result1.Length);
            //printArr(toArr);
            //Array.Copy(result2, toArr, result1.Length-1);

        }
        static void task2(ref int[] arr, int num)
        {
            Random rnd = new Random(); //srand(base)
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }

            Console.WriteLine($"Arr randomed, count nums: {arr.Count(e => num == e)}"); 
        }
        static int task3(ref int[] arr)
        {
            int[] arr2 = arr;
            int summ = 0;
            Array.Sort(arr2);
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] >= arr.Min() && arr2[i] <= arr.Max())
                {
                    summ += arr2[i];
                }
            }
            return summ;

        }
        static void task4(int[] arr)
        {
            int sum = 0;
            foreach (var item in arr)
            {
                if (item % 2 ==0 )
                {
                    sum += item;
                }
            }
            Console.WriteLine($"Summ of Even numbers of array: {sum}");
            Console.WriteLine($"Count Single digit numbers of array : {arr.Count(elem => elem/10 < 1 && 0 < elem)}");
        }
        static void printArr<T>(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        static void reInitArray<T>(ref T[]arr,params T [] arr2) {
            arr = new T[arr2.Length];
            arr = arr2;
        }
        static void task5<T1, T2>(T1 [] key, T2 [] arr) {
            Array.Sort(key, arr);
        }
        static void Main(string[] args)
        {
            int[] arr = { 3, 5, -3, 44, -233, 332, -555 };
            int[] toArr = new int[arr.Length];
            task1(ref arr, ref toArr);

            printArr(toArr);
            Console.WriteLine("Task 2");
            task2(ref arr, 14);
            printArr(arr);
            Console.WriteLine("Task 3");
            Console.WriteLine(task3(ref arr));
            reInitArray<int>(ref arr, 1,2,3,4,5,55,33,22);
            Console.WriteLine("Task 4");
            task4(arr);
            Console.WriteLine("Task 5");
            string[] names = new string[5] { "Apple","Peach","Melon","Bread","Cherry"};
            int[] prices = new int[5] { 23,42,48,12,8};
            Console.WriteLine("Before:");
            printArr(names);
            printArr(prices);
            Console.WriteLine("After:");
            task5(prices, names);
            printArr(names);
            printArr(prices);

        }
    }
}
