using System;

namespace lab1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //беру входные данные
            Console.WriteLine("Введи целочисленные элементы(через пробел)");
            string inputLine = Console.ReadLine();
            string[] arrayOfInput = inputLine.Split(" ");
            int[] arrayOfIntInput = new int[arrayOfInput.Length];
            for (int x = 0; x < arrayOfInput.Length; x++) 
            {
                arrayOfIntInput[x] = Convert.ToInt32(arrayOfInput[x]);
            }

            //решаю задачу
            int sum = 0;
            foreach (int y in arrayOfIntInput)
            {
                if (y > 0)
                {
                    break;
                }
                sum += y;
            }
            Console.WriteLine(sum);
        }
    }
}
