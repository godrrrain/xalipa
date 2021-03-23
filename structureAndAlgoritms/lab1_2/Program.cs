using System;

namespace lab1_2
{
    class Program
    {
static void Main(string[] args)
{
    //получаю исходные данные
    Console.WriteLine("Введи строку");
    string inputLine = Console.ReadLine();

    //решаю задачу
    string newLine = "";
    bool repeat;
    foreach (char x in inputLine)
    {
        if (x == ' ') 
        {
            continue;
        }

        repeat = false;

        foreach (char y in newLine)
        {
            if (y == x) 
            {
                repeat = true;
                break;
            }
        }
        
        if (repeat == false)
        {
            newLine += x;
        }
    }
    Console.WriteLine(newLine);
}
    }
}
