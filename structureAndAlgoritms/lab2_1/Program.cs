using System;
using System.Collections.Generic;


namespace lab2_1
{
    struct Date
    {
        public int day;
        public int month;
        public int year;
    }
    struct Time
    {
        public int hour;
        public int minute;
    }

    struct PaymentForCall
    {
        public string fullName;
        public string phoneNumber;
        public Date dateOfCall;
        public int oneMinuteRate;
        public Time timeOfBeginning;
        public Time timeOfEnding;

        public string GetDataString()
        {
            return $"{dateOfCall.day}.{dateOfCall.month}.{dateOfCall.year}";
        }

    }

    //компаратор сравнения по фио
    class PaymentFullNameCamparer : IComparer<PaymentForCall>
    {
        public int Compare(PaymentForCall p1, PaymentForCall p2)
        {
            string[] names = {p1.fullName, p2.fullName};
            Array.Sort(names);
            if (p1.fullName == names[0])
            {
                return -1;
            }
            else return 1;
        }
    }
    //компаратор сравнения по дате
    class PaymentDataCamparer : IComparer<PaymentForCall>
    {
        public int Compare(PaymentForCall p1, PaymentForCall p2)
        {
            if (p1.dateOfCall.year > p2.dateOfCall.year)
            {
                return -1;
            } else if (p1.dateOfCall.year < p2.dateOfCall.year)
            {
                return 1;
            }
            else {
                if (p1.dateOfCall.month > p2.dateOfCall.month)
                {
                    return -1;
                } else if (p1.dateOfCall.month < p2.dateOfCall.month)
                {
                    return 1;
                }
                else {
                    if (p1.dateOfCall.day > p2.dateOfCall.day)
                    {
                        return -1;
                    } 
                    else
                    {
                        return 1;
                    }
                }
            }
        }
    }

    class CallPayments
    {
        public List<PaymentForCall> callPayments = new List<PaymentForCall>();

        public void SearchWithFullName(string fullName_)
        {
            List<PaymentForCall> allCallWithFullName = new List<PaymentForCall>();

            foreach (PaymentForCall call in callPayments)
            {
                if (fullName_ == call.fullName)
                {
                    allCallWithFullName.Add(call);
                }
            }
            PrintCallPayment(allCallWithFullName);
        }
        public void SearchWithDateOfCall(string dataOfCall_)
        {
            List<PaymentForCall> allCallWithDate = new List<PaymentForCall>();

            foreach (PaymentForCall call in callPayments)
            {
                if (call.GetDataString() == dataOfCall_)
                {
                    allCallWithDate.Add(call);
                }
            }
            PrintCallPayment(allCallWithDate);
        }
        
        public void SortWithFullName()
        {
            callPayments.Sort(new PaymentFullNameCamparer());
        }
        public void SortWithDate()
        {
            callPayments.Sort(new PaymentDataCamparer());
        }
        public void PrintCallPayments()
        {
            foreach (PaymentForCall call in callPayments)
            {
                Console.WriteLine("Информация по платежу: ");
                Console.WriteLine($"ФИО: {call.fullName}");
                Console.WriteLine($"Телефон: {call.phoneNumber}");
                Console.WriteLine($"Дата: {call.GetDataString()}");
                Console.WriteLine($"Тариф: {call.oneMinuteRate} руб");
                Console.WriteLine($"Время начала звонка: {call.timeOfBeginning.hour}:{call.timeOfBeginning.minute}");
                Console.WriteLine($"Время окончания звонка: {call.timeOfEnding.hour}:{call.timeOfEnding.minute}");
                Console.WriteLine("\n");
            }
        }
        public void PrintCallPayment(List<PaymentForCall> calls)
        {
            foreach (PaymentForCall call in calls)
            {
                Console.WriteLine("Информация по платежу: ");
                Console.WriteLine($"ФИО: {call.fullName}");
                Console.WriteLine($"Телефон: {call.phoneNumber}");
                Console.WriteLine($"Дата: {call.GetDataString()}");
                Console.WriteLine($"Тариф: {call.oneMinuteRate} руб");
                Console.WriteLine($"Время начала звонка: {call.timeOfBeginning.hour}:{call.timeOfBeginning.minute}");
                Console.WriteLine($"Время окончания звонка: {call.timeOfEnding.hour}:{call.timeOfEnding.minute}");
                Console.WriteLine("\n");
            }
        }
        public void FindCallWithMoreTime(PaymentForCall somecall)
        {
            foreach (PaymentForCall call in callPayments)
            {
                if ((call.timeOfEnding.hour - call.timeOfBeginning.hour) * 60 +
                call.timeOfEnding.minute - call.timeOfBeginning.minute >
                (somecall.timeOfEnding.hour - somecall.timeOfBeginning.hour) * 60 +
                somecall.timeOfEnding.minute - somecall.timeOfBeginning.minute)
                {
                    Console.WriteLine($"Платеж, длительностью {call.timeOfEnding.hour - call.timeOfBeginning.hour}:{call.timeOfEnding.minute - call.timeOfBeginning.minute}");
                }
            }
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            CallPayments newCallPayments = new CallPayments();
            
            //вношу данные о платежах
            PaymentForCall first = new PaymentForCall();
            first.fullName = "Владимир Дегтярев Андреевич";
            first.phoneNumber = "+795156756780";
            first.dateOfCall.year = 2021;
            first.dateOfCall.month = 10;
            first.dateOfCall.day = 20;
            first.oneMinuteRate = 5;
            first.timeOfBeginning.hour = 16;
            first.timeOfBeginning.minute = 30;
            first.timeOfEnding.hour = 17;
            first.timeOfEnding.minute = 10;
            newCallPayments.callPayments.Add(first);

            PaymentForCall two = new PaymentForCall();
            two.fullName = "Богатырева Вероника Олеговна";
            two.phoneNumber = "+79555375775";
            two.dateOfCall.year = 2020;
            two.dateOfCall.month = 10;
            two.dateOfCall.day = 24;
            two.oneMinuteRate = 5;
            two.timeOfBeginning.hour = 17;
            two.timeOfBeginning.minute = 40;
            two.timeOfEnding.hour = 18;
            two.timeOfEnding.minute = 10;
            newCallPayments.callPayments.Add(two);

            PaymentForCall third = new PaymentForCall();
            third.fullName = "Иванов Иван Иванович";
            third.phoneNumber = "+795456686570";
            third.dateOfCall.year = 2021;
            third.dateOfCall.month = 12;
            third.dateOfCall.day = 29;
            third.oneMinuteRate = 15;
            third.timeOfBeginning.hour = 14;
            third.timeOfBeginning.minute = 30;
            third.timeOfEnding.hour = 16;
            third.timeOfEnding.minute = 40;
            newCallPayments.callPayments.Add(third);
            
            //тестирую программу
            Console.WriteLine("Вывод всех платежей");
            newCallPayments.PrintCallPayments();

            Console.WriteLine("Поиск по ФИО: ");
            string name = Console.ReadLine();
            newCallPayments.SearchWithFullName(name);

            Console.WriteLine("Поиск по Дате(xx.xx.xxxx): ");
            string data = Console.ReadLine();
            newCallPayments.SearchWithDateOfCall(data);

            Console.WriteLine("Сортировка по фамилии");
            newCallPayments.SortWithFullName();
            newCallPayments.PrintCallPayments();

            Console.WriteLine("Сортировка по дате");
            newCallPayments.SortWithDate();
            newCallPayments.PrintCallPayments();

            Console.WriteLine("Поиск разговоров со временем разговора больше, чем у Владимира Дегтярева:");
            newCallPayments.FindCallWithMoreTime(first);
        }
    }
}
