using System;

/*
Задание.
Составить описание класса для представления комплексных чисел. Обеспечить выполнение
операций сложения, вычитания и умножения комплексного числа на вещественное число.
Предусмотреть поддержку числа в алгебраической форме. Все операции реализовать в виде
перегрузки операторов. Программа должна содержать меню, позволяющее осуществлять
проверку всех методов.
*/

/*
__От студента, который это писал__
Достаточно легкое задание. Просто перегружаем операторы в классе.
*/

namespace lab2
{
    class ComplexNum
    {
        public double RealNumber;
        public double ImaginaryUnit;

        public ComplexNum(double real, double imagine)
        {
            RealNumber = real;
            ImaginaryUnit = imagine;
        }

        //перегружаю операторы
        public static ComplexNum operator +(ComplexNum first, double second)
        {
            return new ComplexNum(first.RealNumber + second, first.ImaginaryUnit);
        }
        public static ComplexNum operator -(ComplexNum first, double second)
        {
            return new ComplexNum(first.RealNumber - second, first.ImaginaryUnit);
        }
        public static ComplexNum operator *(ComplexNum first, double second)
        {
            return new ComplexNum(first.RealNumber * second, first.ImaginaryUnit * second);
        }

        public string ShowComplexPlane()
        {
            return $"{RealNumber} + {ImaginaryUnit}i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Введи комплексное число в формате 'a + bi'(Например 2 + 4i). Либо введи 0, чтобы закрыть программу");
                string choose = Console.ReadLine();
                if (choose == "0")
                {
                    break;
                }
                if (!choose.Contains("i") || (!choose.Contains("+") && !choose.Contains("-")))
                {
                    Console.WriteLine("Введи, пожалуйста, комплексное число(если что, оно пишется с буквой i)");
                    continue;
                }
                string[] arrayOfChoose = choose.Split("+");
                arrayOfChoose[1] = arrayOfChoose[1].Replace("i", "");

                ComplexNum one = new ComplexNum(Convert.ToDouble(arrayOfChoose[0]), Convert.ToDouble(arrayOfChoose[1]));

                while(true)
                {
                    Console.WriteLine("Выбери операцию, которую хочешь выполнить:\n1 - Сложение\n2 - Вычитание\n3 - Умножение");
                    Console.WriteLine("0 - Выбрать другое комплексное число");
                    string chose = Console.ReadLine();
                    if (chose == "1")
                    {
                        Console.WriteLine("Введи действительное число:");
                        double num = Convert.ToDouble(Console.ReadLine());
                        one = one + num;
                        Console.WriteLine($"Результат = {one.ShowComplexPlane()}");
                    }
                    if (chose == "2")
                    {
                        Console.WriteLine("Введи действительное число:");
                        double num = Convert.ToDouble(Console.ReadLine());
                        one = one - num;
                        Console.WriteLine($"Результат = {one.ShowComplexPlane()}");
                    }
                    if (chose == "3")
                    {
                        Console.WriteLine("Введи действительное число:");
                        double num = Convert.ToDouble(Console.ReadLine());
                        one = one * num;
                        Console.WriteLine($"Результат = {one.ShowComplexPlane()}");
                    }
                    if (chose == "0")
                    {
                        break;
                    }
                }
            }
        }
    }
}
