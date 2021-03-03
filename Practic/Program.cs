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

            int [] result1 = new int[0];
            int [] result2 = new int[0];
            
            result1 = Array.FindAll(arr, e => e<0);
            result2= Array.FindAll(arr, e => e>=0);
            result1.CopyTo(toArr,0);
            result2.CopyTo(toArr,result1.Length);
            //printArr(toArr);
            //Array.Copy(result2, toArr, result1.Length-1);

        }
        static int task2(ref int [] arr, int num) {
            Random rnd = new Random(); //srand(base)
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }

            return arr.Count(e => num == e);
        }
        static int task3(ref int [] arr) {
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
        static void printArr(int[] arr) {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int [] arr = {3,5,-3,44,-233,332,-555};
            int[] toArr = new int[arr.Length];
            task1(ref arr, ref toArr);
            printArr(toArr);
            Console.WriteLine("Hello World!");
        }
    }
}
