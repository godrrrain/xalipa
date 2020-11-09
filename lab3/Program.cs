using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

/*
Задание.
На основе одной из готовых обобщенных (шаблонных) объектных коллекций .NET создать класс
«Организация», включающий сотрудников. Классы сотрудников должны образовывать иерархию
с базовым классом. Сотрудники бывают двух типов: с фиксированной оплатой и почасовики.
Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы. Для
почасовиков формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 *
почасовую ставку», для сотрудников с фиксированной оплатой «среднемесячная заработная плата
= фиксированной месячной оплате», также к зарплате прибавляется фиксированная премия,
размер которой зависит от должности сотрудника. В виде меню программы реализовать
нижеприведенный функционал.
1. Упорядочить всю последовательность сотрудников по убыванию среднемесячного заработка.
При совпадении зарплаты – упорядочивать данные по алфавиту по ФИО. Вывести идентификатор
работника, ФИО, день рождения и среднемесячный заработок для всех элементов списка.
2. Вывести первые 5 имен работников из полученного в пункте 1 списка.
3. Вывести последние 3 идентификатора работников из полученного в пункте 1 списка.
4. В реальном времени (в процессе заполнения списка сотрудников) рассчитывать и
поддерживать в актуальном состоянии среднемесячную заработную плату по организации,
сохранить значение как поле класса «Организация».
5. Организовать запись и чтение всех данных в/из файла. Реализовать поддержку формата файлов
XML.
6. Организовать обработку некорректного формата входного файла.
*/

/*
__От студента, который это писал__
Отличная задача.

Структура программы и суть решения.
Описал абстактный класс, 2 класса, которые наследуют этот абстрактный класс. А также большой класс, поле
которого является список из абстрактных классов(по задаче нам необходим список, содержащий элементы двух
классов, наследуемых от абстрактного класса, тут может показаться, что возникает вопрос
"как определить один список, хранящий два типа?", однако, благодаря тому, что все необходимые значения
мы получаем либо через поля наследуемого абстрактного класса, либо через переопределенный метод,
то мы можем себе позволить просто объявить список типа наследуемого абстрактного класса).
Также стоит отметить, что, так как мы сериализуем абстрактный класс, то нам необходимо явно указать
типы, которые наследуют этот абстрактный класс
*/


namespace lab3
{
    //компаратор
    class EmployeeCamparer : IComparer<Employee>
    {
        public int Compare(Employee p1, Employee p2)
        {
            if (p1.GetMonthlySalary() > p2.GetMonthlySalary())
            {
                return -1;
            }
            else if (p1.GetMonthlySalary() < p2.GetMonthlySalary())
            {
                return 1;
            }
            else
            {
                string[] names = {p1.Name, p2.Name};
                Array.Sort(names);
                if (p1.Name == names[0])
                {
                    return -1;
                }
                else return 1;
            }
        }
    }

    [XmlInclude(typeof(EmployeeWithMonthlyPayment))]
    [XmlInclude(typeof(EmployeeWithHourlyPayment))]
    [Serializable]
    public abstract class Employee {
        public int Id;
        public string Name;
        public string DateOfBirth;
        public int Rank;

        public abstract double GetMonthlySalary();

        public Employee(int id, string name, string dateOfBirth, int rank)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Rank = rank;
        }
    }
    [Serializable]
    public class EmployeeWithMonthlyPayment : Employee
    {
        public double fixedSalary;

        public EmployeeWithMonthlyPayment(int id, string name, string dateOfBirth, int rank, double _fixedSalary)
        : base(id, name, dateOfBirth, rank)
        {
            fixedSalary = _fixedSalary;
        }
        public EmployeeWithMonthlyPayment() : base(0, "", "", 0) {}

        public override double GetMonthlySalary()
        {
            return fixedSalary + Rank * 10000;
        }

    }
    [Serializable]
    public class EmployeeWithHourlyPayment : Employee
    {
        public double hourlyRate;

        public EmployeeWithHourlyPayment(int id, string name, string dateOfBirth, int rank, double _hourlyRate)
        : base(id, name, dateOfBirth, rank)
        {
            hourlyRate = _hourlyRate;
        }
        public EmployeeWithHourlyPayment() : base(0, "", "", 0) {}

        public override double GetMonthlySalary()
        {
            return hourlyRate * 20.8 * 8 + Rank * 10000;
        }

    }
    [Serializable]
    public class Organization
    {
        private double AverageTotalMonthlySalary;
        public List<Employee> employees = new List<Employee>();

        public Organization() {}

        public void CalculateAverageTotalMounthlySalary()
        {
            AverageTotalMonthlySalary = 0;
            foreach (Employee one in employees)
                AverageTotalMonthlySalary += one.GetMonthlySalary();
            AverageTotalMonthlySalary /= employees.Count;
        }
        public double GetAverageTotalMounthSalary()
        {
            return AverageTotalMonthlySalary;
        }
        public void SortEmployee()
        {
            employees.Sort(new EmployeeCamparer());
        }
        public void PrintEmployees()
        {
            foreach (Employee one in employees)
                Console.WriteLine($"{one.Id}  {one.Name}  {one.DateOfBirth}  {one.GetMonthlySalary()}");
        }
        public void PrintFirstFiveNameEmployees()
        {
            for (int x = 0; x < 5; x++)
            {
                Console.WriteLine(employees[x].Name);
            }
        }
        public void PrintLastThreeIdEmployees()
        {
            for (int y = 1; y <= 3; y++)
            {
                Console.WriteLine(employees[employees.Count - y].Id);
            }
        }
    }
    class Program
    {
        static Organization ReadOrganizationXml(string _name)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Organization), new Type[]{typeof(Organization)});
            
            using (FileStream fs = new FileStream(_name, FileMode.OpenOrCreate))
            {
                
                Organization organization = (Organization)formatter.Deserialize(fs);
                return organization;
            }
        }
        static void WriteOrganizationXml(string _name, Organization organization)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Organization), new Type[]{typeof(Organization)});
            using (FileStream fs = new FileStream(_name, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, organization);
            }
        }
        static void Main(string[] args)
        {

            Organization perCab = new Organization();

            Console.WriteLine("Привет! :D");
            while(true)
            {
                Console.WriteLine("\nНапиши цифру того, что хочешь использовать:");
                Console.WriteLine("1 - Прочитать данные из xml файла\n2 - Упорядочить сотрудников и вывести" +
                " информацию о них\n3 - Вывести первые 5 имен работников\n4 - Вывести последние 3" +
                " идентификатора работников\n5 - Вывести среднемесячную заработную плату по организации" +
                "\n6 - Записать данные в xml файл\n0 - Завершить программу");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.WriteLine("Введи название xml файла(Пример: organization.xml):");
                    string name = Console.ReadLine();
                    if (String.Compare(name.Substring(name.Length - 4), ".xml") != 0)
                    {
                        Console.WriteLine("Неверно указан формат файла");
                        continue;
                    }
                    if (!File.Exists(name))
                    {
                        Console.WriteLine("Файл не найден");
                        continue;
                    }
                    perCab = ReadOrganizationXml(name);
                    perCab.CalculateAverageTotalMounthlySalary();
                    Console.WriteLine("Данные успешно прочитаны");
                }
                if (choose == "2")
                {
                    perCab.SortEmployee();
                    perCab.PrintEmployees();
                }
                if (choose == "3")
                {
                    perCab.PrintFirstFiveNameEmployees();
                }
                if (choose == "4")
                {
                    perCab.PrintLastThreeIdEmployees();
                }
                if (choose == "5")
                {
                    Console.WriteLine(perCab.GetAverageTotalMounthSalary());
                }
                if (choose == "6")
                {
                    Console.WriteLine("Введи имя файла, куда необходимо сохранить данные(Пример: new_organization.xml):");
                    string name = Console.ReadLine();
                    WriteOrganizationXml(name, perCab);
                    Console.WriteLine("Запись успешно завершена");
                }
                if (choose == "0")
                {
                    break;
                }
            }
        }
    }
}
