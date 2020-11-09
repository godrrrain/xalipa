using System;

/*
Задание.
Построить систему классов для описания плоских геометрических фигур: круга, квадрата,
прямоугольника. Предусмотреть методы для создания объектов, перемещения на плоскости на
заданный вектор, изменения размеров относительно геометрического центра фигуры, вращения
на заданный угол и определение факта пересечения (наложения) двух выбранных фигур.
Программа должна содержать меню, позволяющее осуществлять проверку всех методов.
*/

/*
__От студента, который это писал__
Решение получилось относительно большим. Присутствует довольно много математики в задаче.

Структура программы и суть решения.
Описал классы фигур: круга, квадрата, прямоугольника. В классе каждой фигуры написал необходимые
методы, которые затрагивают одну фигуру(сами себя). И создал отдельный класс, хранящий перегруженный
метод, который затрагивает несколько фигур - определение факта пересечения.
*/

namespace lab1
{
    struct Coordinate
    {
        public double x;
        public double y;
    }

    class Circle
    {
        public Coordinate centre;
        public double radius;

        public void _init_(double x1, double y1, double r)
        {
            centre.x = x1;
            centre.y = y1;
            radius = r;
        }

        public void MoveByVector(double xVector, double yVector)
        {
            centre.x += xVector;
            centre.y += yVector;
        }

        public void ChangeOfSize(double multiplier)
        {
            radius *= multiplier;
        }
    }

    class Square
    {
        public Coordinate centre;
        public double length;

        public Coordinate A;
        public Coordinate B;
        public Coordinate C;
        public Coordinate D;

        public void _init_(double x1, double y1, double length1)
        {
            centre.x = x1;
            centre.y = y1;
            length = length1;
            
            A.x = centre.x - (length / 2);
            A.y = centre.y + (length / 2);

            B.x = centre.x + (length / 2);
            B.y = centre.y + (length / 2);

            C.x = centre.x + (length / 2);
            C.y = centre.y - (length / 2);

            D.x = centre.x - (length / 2);
            D.y = centre.y - (length / 2);
        }
        
        public void MoveByVector(double xVector, double yVector)
        {
            centre.x += xVector;
            centre.y += yVector;

            A.x += xVector;
            A.y += yVector;
            B.x += xVector;
            B.y += yVector;
            C.x += xVector;
            C.y += yVector;
            D.x += xVector;
            D.y += yVector;
        }

        public void ChangeOfSize(double multiplier)
        {
            length *= multiplier;

            A.x = (A.x - centre.x) * multiplier + centre.x;
            A.y = (A.y - centre.y) * multiplier + centre.y;

            B.x = (B.x - centre.x) * multiplier + centre.x;
            B.y = (B.y - centre.y) * multiplier + centre.y;

            C.x = (C.x - centre.x) * multiplier + centre.x;
            C.y = (C.y - centre.y) * multiplier + centre.y;

            D.x = (D.x - centre.x) * multiplier + centre.x;
            D.y = (D.y - centre.y) * multiplier + centre.y;
        }

        public void Rotate(double angle)
        {
            double angleRadian = angle * Math.PI / 180;

            A.x = (A.x - centre.x) * Math.Cos(angleRadian) - (A.y - centre.y) * Math.Sin(angleRadian) + A.x;
            A.y = (A.x - centre.x) * Math.Sin(angleRadian) + (A.y - centre.y) * Math.Cos(angleRadian) + A.y;
            
            B.x = (B.x - centre.x) * Math.Cos(angleRadian) - (B.y - centre.y) * Math.Sin(angleRadian) + B.x;
            B.y = (B.x - centre.x) * Math.Sin(angleRadian) + (B.y - centre.y) * Math.Cos(angleRadian) + B.y;

            C.x = (C.x - centre.x) * Math.Cos(angleRadian) - (C.y - centre.y) * Math.Sin(angleRadian) + C.x;
            C.y = (C.x - centre.x) * Math.Sin(angleRadian) + (C.y - centre.y) * Math.Cos(angleRadian) + C.y;

            D.x = (D.x - centre.x) * Math.Cos(angleRadian) - (D.y - centre.y) * Math.Sin(angleRadian) + D.x;
            D.y = (D.x - centre.x) * Math.Sin(angleRadian) + (D.y - centre.y) * Math.Cos(angleRadian) + D.y;
        }

    }

    class Rectangle
    {
        public Coordinate centre;
        public double length;
        public double width;

        public Coordinate A;
        public Coordinate B;
        public Coordinate C;
        public Coordinate D;

        public void _init_(double x1, double y1, double length1, double width1)
        {
            centre.x = x1;
            centre.y = y1;
            length = length1;
            width = width1;

            A.x = centre.x - (width / 2);
            A.y = centre.y + (length / 2);

            B.x = centre.x + (width / 2);
            B.y = centre.y + (length / 2);

            C.x = centre.x + (width / 2);
            C.y = centre.y - (length / 2);

            D.x = centre.x - (width / 2);
            D.y = centre.y - (length / 2);
        }

        public void MoveByVector(double xVector, double yVector)
        {
            centre.x += xVector;
            centre.y += yVector;

            A.x += xVector;
            A.y += yVector;
            B.x += xVector;
            B.y += yVector;
            C.x += xVector;
            C.y += yVector;
            D.x += xVector;
            D.y += yVector;
        }

        public void ChangeOfSize(double multiplier)
        {
            length *= multiplier;
            width *= multiplier;

            A.x = (A.x - centre.x) * multiplier + centre.x;
            A.y = (A.y - centre.y) * multiplier + centre.y;

            B.x = (B.x - centre.x) * multiplier + centre.x;
            B.y = (B.y - centre.y) * multiplier + centre.y;

            C.x = (C.x - centre.x) * multiplier + centre.x;
            C.y = (C.y - centre.y) * multiplier + centre.y;

            D.x = (D.x - centre.x) * multiplier + centre.x;
            D.y = (D.y - centre.y) * multiplier + centre.y;
        }

        public void Rotate(double angle)
        {
            double angleRadian = angle * Math.PI / 180;

            A.x = (A.x - centre.x) * Math.Cos(angleRadian) - (A.y - centre.y) * Math.Sin(angleRadian) + A.x;
            A.y = (A.x - centre.x) * Math.Sin(angleRadian) + (A.y - centre.y) * Math.Cos(angleRadian) + A.y;
            
            B.x = (B.x - centre.x) * Math.Cos(angleRadian) - (B.y - centre.y) * Math.Sin(angleRadian) + B.x;
            B.y = (B.x - centre.x) * Math.Sin(angleRadian) + (B.y - centre.y) * Math.Cos(angleRadian) + B.y;

            C.x = (C.x - centre.x) * Math.Cos(angleRadian) - (C.y - centre.y) * Math.Sin(angleRadian) + C.x;
            C.y = (C.x - centre.x) * Math.Sin(angleRadian) + (C.y - centre.y) * Math.Cos(angleRadian) + C.y;

            D.x = (D.x - centre.x) * Math.Cos(angleRadian) - (D.y - centre.y) * Math.Sin(angleRadian) + D.x;
            D.y = (D.x - centre.x) * Math.Sin(angleRadian) + (D.y - centre.y) * Math.Cos(angleRadian) + D.y;
        }
    }

    class ActionsWithFigures
    {
        private static bool LineToCircleIntersection(double x1, double y1, double x2, double y2, double xC, double yC, double radius)
        {
            //пересечение отрезка с окружностью
            x1 -= xC;
            y1 -= yC;
            x2 -= xC;
            y2 -= yC;

            double dx = x2 - x1;
            double dy = y2 - y1;

            double a = dx * dx + dy * dy;
            double b = 2 * (x1 * dx + y1 * dy);
            double c = (x1 * x1) + (y1 * y1) - (radius * radius);

            if (-b < 0)
            {
                return (c < 0);
            }
            if (-b < (2 * a))
            {
                return ((4 * a * c - b * b) < 0);
            }
            return (a + b + c < 0);
        }
        private static bool PointToCircleIntersection(double x1, double y1, double xC, double yC, double radius)
        {
            if (Math.Pow(x1 - xC, 2) + Math.Pow(y1 - yC, 2) <= Math.Pow(radius, 2))
            {
                return true;
            }
            return false;
        }
        private static double PositionPointToLine(double x1, double y1, double x2, double y2, double x0, double y0)
        {
            //нахожу положение точки относительно прямой
            return (x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1);
        }
        private static bool IsOneSideOfPointsAndLine(double x1, double y1, double x2, double y2, double x0, double y0, double _x0, double _y0)
        {
            //проверяю, лежат ли точки с одной стороны от прямой
            return PositionPointToLine(x1, y1, x2, y2, x0, y0) * PositionPointToLine(x1, y1, x2, y2, _x0, _y0) >= 0;
        }
        private static bool LineToLineIntersection(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            //проверяю случай, когда отрезки накладываются друг на друга
            if (((x2 >= x1) && (x3 <= x1) && (x4 >= x1)) || ((y2 >= y1) && (y3 <= y1) && (y4 >= y1)))
            {
                return true;
            }
            if (((x1 <= x2) && (x3 <= x2) && (x4 >= x2)) || ((y1 <= y2) && (y3 <= y2) && (y4 >= y2)))
            {
                return true;
            }
            //проверяю парралельность отрезков
            if ((x2 - x1) / (y2 - y1) == (x4 - x3) / (y4 - y3))
            {
                return false;
            }
            //проверяю пересечение отрезков
            double x = ((x1 * y2 - x2 * y1) * (x4 - x3) - (x3 * y4 - x4 * y3) * (x2 - x1)) /
            ((y1 - y2) * (x4 - x3) - (y3 - y4) * (x2 - x1));
            double y = ((y3 - y4) * x - (x3 * y4 - x4 * y3)) / (x4 - x3);
            if (((x1 <= x) && (x2 >= x) && (x3 <= x) && (x4 >= x)) || (y1 <= y) && ((y2 >= y) && (y3 <= y) && (y4 >= y)))
            {
                return true;
            }
            return false;
        }

        public static bool Intersection(Circle circle, Square square)
        {
            //проверяю пересечение отрезков с окружностью
            if (LineToCircleIntersection(square.A.x, square.A.y, square.B.x, square.B.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (LineToCircleIntersection(square.B.x, square.B.y, square.C.x, square.C.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (LineToCircleIntersection(square.C.x, square.C.y, square.D.x, square.D.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (LineToCircleIntersection(square.D.x, square.D.y, square.A.x, square.A.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }

            //проверяю случай, когда сторона квадрата касается окружность
            if (circle.radius + (square.length / 2) == Math.Sqrt(Math.Pow(circle.centre.x - 
            square.centre.x, 2) + Math.Pow(circle.centre.y - square.centre.y, 2)))
            {
                return true;
            }

            //проверяю случай, когда окружность касается вершин квадрата, или когда квадрат находится
            //внутри окружности
            if (PointToCircleIntersection(square.A.x, square.A.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(square.B.x, square.B.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(square.C.x, square.C.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(square.D.x, square.D.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(square.centre.x, square.centre.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }

            //проверяю случай, когда окружность находится внутри квадрата
            if (IsOneSideOfPointsAndLine(square.A.x, square.A.y, square.B.x, square.B.y, circle.centre.x, circle.centre.y, square.C.x, square.C.y) 
            && IsOneSideOfPointsAndLine(square.B.x, square.B.y, square.C.x, square.C.y, circle.centre.x, circle.centre.y, square.D.x, square.D.y)
            && IsOneSideOfPointsAndLine(square.C.x, square.C.y, square.D.x, square.D.y, circle.centre.x, circle.centre.y, square.A.x, square.A.y)
            && IsOneSideOfPointsAndLine(square.D.x, square.D.y, square.A.x, square.A.y, circle.centre.x, circle.centre.y, square.B.x, square.B.y))
            {
                return true;
            }
            return false;
        }

        public static bool Intersection(Circle circle, Rectangle rectangle)
        {
            //проверяю пересечение отрезков с окружностью
            if (LineToCircleIntersection(rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (LineToCircleIntersection(rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (LineToCircleIntersection(rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (LineToCircleIntersection(rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }

            //проверяю случай, когда сторона прямоугольника касается окружность
            if (circle.radius + (rectangle.length / 2) == Math.Sqrt(Math.Pow(circle.centre.x - 
            rectangle.centre.x, 2) + Math.Pow(circle.centre.y - rectangle.centre.y, 2)))
            {
                return true;
            }
            if (circle.radius + (rectangle.width / 2) == Math.Sqrt(Math.Pow(circle.centre.x - 
            rectangle.centre.x, 2) + Math.Pow(circle.centre.y - rectangle.centre.y, 2)))
            {
                return true;
            }

            //проверяю случай, когда окружность касается вершин прямоугольника, или когда прямоугольник
            //находится внутри окружности
            if (PointToCircleIntersection(rectangle.A.x, rectangle.A.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(rectangle.B.x, rectangle.B.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(rectangle.C.x, rectangle.C.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(rectangle.D.x, rectangle.D.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }
            if (PointToCircleIntersection(rectangle.centre.x, rectangle.centre.y, circle.centre.x, circle.centre.y, circle.radius))
            {
                return true;
            }

            //проверяю случай, когда окружность находится внутри прямоугольника
            if (IsOneSideOfPointsAndLine(rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y, circle.centre.x, circle.centre.y, rectangle.C.x, rectangle.C.y) 
            && IsOneSideOfPointsAndLine(rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y, circle.centre.x, circle.centre.y, rectangle.D.x, rectangle.D.y)
            && IsOneSideOfPointsAndLine(rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y, circle.centre.x, circle.centre.y, rectangle.A.x, rectangle.A.y)
            && IsOneSideOfPointsAndLine(rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y, circle.centre.x, circle.centre.y, rectangle.B.x, rectangle.B.y))
            {
                return true;
            }
            return false;
        }

        public static bool Intersection(Square square, Rectangle rectangle)
        {
            //проверяю пересечение сторон квадрата со сторонами прямоугольника
            if (LineToLineIntersection(square.A.x, square.A.y, square.B.x, square.B.y, rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y)
            || LineToLineIntersection(square.A.x, square.A.y, square.B.x, square.B.y, rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y)
            || LineToLineIntersection(square.A.x, square.A.y, square.B.x, square.B.y, rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y)
            || LineToLineIntersection(square.A.x, square.A.y, square.B.x, square.B.y, rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y))
            {
                return true;
            }
            if (LineToLineIntersection(square.B.x, square.B.y, square.C.x, square.C.y, rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y)
            || LineToLineIntersection(square.B.x, square.B.y, square.C.x, square.C.y, rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y)
            || LineToLineIntersection(square.B.x, square.B.y, square.C.x, square.C.y, rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y)
            || LineToLineIntersection(square.B.x, square.B.y, square.C.x, square.C.y, rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y))
            {
                return true;
            }
            if (LineToLineIntersection(square.C.x, square.C.y, square.D.x, square.D.y, rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y)
            || LineToLineIntersection(square.C.x, square.C.y, square.D.x, square.D.y, rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y)
            || LineToLineIntersection(square.C.x, square.C.y, square.D.x, square.D.y, rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y)
            || LineToLineIntersection(square.C.x, square.C.y, square.D.x, square.D.y, rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y))
            {
                return true;
            }
            if (LineToLineIntersection(square.D.x, square.D.y, square.A.x, square.A.y, rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y)
            || LineToLineIntersection(square.D.x, square.D.y, square.A.x, square.A.y, rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y)
            || LineToLineIntersection(square.D.x, square.D.y, square.A.x, square.A.y, rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y)
            || LineToLineIntersection(square.D.x, square.D.y, square.A.x, square.A.y, rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y))
            {
                return true;
            }
            //проверяю случай, когда квадрат находится внутри прямоугольника
            if (IsOneSideOfPointsAndLine(rectangle.A.x, rectangle.A.y, rectangle.B.x, rectangle.B.y, square.centre.x, square.centre.y, rectangle.C.x, rectangle.C.y) 
            && IsOneSideOfPointsAndLine(rectangle.B.x, rectangle.B.y, rectangle.C.x, rectangle.C.y, square.centre.x, square.centre.y, rectangle.D.x, rectangle.D.y)
            && IsOneSideOfPointsAndLine(rectangle.C.x, rectangle.C.y, rectangle.D.x, rectangle.D.y, square.centre.x, square.centre.y, rectangle.A.x, rectangle.A.y)
            && IsOneSideOfPointsAndLine(rectangle.D.x, rectangle.D.y, rectangle.A.x, rectangle.A.y, square.centre.x, square.centre.y, rectangle.B.x, rectangle.B.y))
            {
                return true;
            }
            //проверяю случай, когда прямоугольник находится внутри квадрата
            if (IsOneSideOfPointsAndLine(square.A.x, square.A.y, square.B.x, square.B.y, rectangle.centre.x, rectangle.centre.y, square.C.x, square.C.y) 
            && IsOneSideOfPointsAndLine(square.B.x, square.B.y, square.C.x, square.C.y, rectangle.centre.x, rectangle.centre.y, square.D.x, square.D.y)
            && IsOneSideOfPointsAndLine(square.C.x, square.C.y, square.D.x, square.D.y, rectangle.centre.x, rectangle.centre.y, square.A.x, square.A.y)
            && IsOneSideOfPointsAndLine(square.D.x, square.D.y, square.A.x, square.A.y, rectangle.centre.x, rectangle.centre.y, square.B.x, square.B.y))
            {
                return true;
            }
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            Square square = new Square();
            Rectangle rectangle = new Rectangle();
            while (true)
            {
                Console.WriteLine("Напиши номер фигуры, с которой хочешь работать:");
                Console.WriteLine("1 - Круг\n2 - Квадрат\n3 - Прямоугольник\n4 - Хочу проверить, пересекаются ли фигуры\n0 - Закрыть программу ;(");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.WriteLine("Для начала, давай создадим круг");
                    Console.WriteLine("Введи какие-нибудь координаты центра круга(Два числа через пробел):");
                    string[] koord = Console.ReadLine().Split(" ");
                    Console.WriteLine("Напиши радиус круга:");
                    double rad = Convert.ToDouble(Console.ReadLine());
                    circle._init_(Convert.ToDouble(koord[0]), Convert.ToDouble(koord[1]), rad);
                    Console.WriteLine("Отлично, ты создал круг\nТеперь ты можешь:");
                    while (true)
                    {
                        Console.WriteLine("1 - Переместить его на вектор\n2 - Изменить размер\n3 - Повернуть на угол\n0 - Вернуться назад к выбору фигуры либо к проверке пересечения фигур");
                        string _choose = Console.ReadLine();
                        if (_choose == "1")
                        {
                            Console.WriteLine("Опиши вектор(2 числа через пробел):");
                            string[] vect = Console.ReadLine().Split(" ");
                            circle.MoveByVector(Convert.ToDouble(vect[0]), Convert.ToDouble(vect[1]));
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "2")
                        {
                            Console.WriteLine("Введи множитель, на который надо изменить размер круга:");
                            double mult = Convert.ToDouble(Console.ReadLine());
                            circle.ChangeOfSize(mult);
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "3")
                        {
                            Console.WriteLine("Если повернуть круг на какой-либо угол, ничего не поменяется :D");
                        }
                        if (_choose == "0")
                        {
                            break;
                        }
                    }
                }
                if (choose == "2")
                {
                    Console.WriteLine("Для начала, давай создадим квадрат");
                    Console.WriteLine("Введи какие-нибудь координаты центра квадрта(Два числа через пробел):");
                    string[] koord = Console.ReadLine().Split(" ");
                    Console.WriteLine("Напиши длину стороны квадрата:");
                    double len = Convert.ToDouble(Console.ReadLine());
                    square._init_(Convert.ToDouble(koord[0]), Convert.ToDouble(koord[1]), len);
                    Console.WriteLine("Отлично, ты создал квадрат\nТеперь ты можешь:");
                    while (true)
                    {
                        Console.WriteLine("1 - Переместить на вектор\n2 - Изменить размер\n3 - Повернуть на угол\n0 - Вернуться назад к выбору фигуры либо к проверке пересечения фигур");
                        string _choose = Console.ReadLine();
                        if (_choose == "1")
                        {
                            Console.WriteLine("Опиши вектор(2 числа через пробел):");
                            string[] vect = Console.ReadLine().Split(" ");
                            square.MoveByVector(Convert.ToDouble(vect[0]), Convert.ToDouble(vect[1]));
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "2")
                        {
                            Console.WriteLine("Введи множитель, на который надо изменить размер квадрата:");
                            double mult = Convert.ToDouble(Console.ReadLine());
                            square.ChangeOfSize(mult);
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "3")
                        {
                            Console.WriteLine("Укажи угол, на который необходимо повернуть квадрат(в градусах):");
                            double anlg = Convert.ToDouble(Console.ReadLine());
                            square.Rotate(anlg);
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "0")
                        {
                            break;
                        }
                    }
                }
                if (choose == "3")
                {
                    Console.WriteLine("Для начала, давай создадим прямоугольник");
                    Console.WriteLine("Введи какие-нибудь координаты центра прямоугольника(Два числа через пробел):");
                    string[] koord = Console.ReadLine().Split(" ");
                    Console.WriteLine("Напиши длину прямоугольника:");
                    double len = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Напиши ширину прямоугольника:");
                    double widt = Convert.ToDouble(Console.ReadLine());
                    rectangle._init_(Convert.ToDouble(koord[0]), Convert.ToDouble(koord[1]), len, widt);
                    Console.WriteLine("Отлично, ты создал прямоугольник\nТеперь ты можешь:");
                    while (true)
                    {
                        Console.WriteLine("1 - Переместить на вектор\n2 - Изменить размер\n3 - Повернуть на угол\n0 - Вернуться назад к выбору фигуры либо к проверке пересечения фигур");
                        string _choose = Console.ReadLine();
                        if (_choose == "1")
                        {
                            Console.WriteLine("Опиши вектор(2 числа через пробел):");
                            string[] vect = Console.ReadLine().Split(" ");
                            rectangle.MoveByVector(Convert.ToDouble(vect[0]), Convert.ToDouble(vect[1]));
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "2")
                        {
                            Console.WriteLine("Введи множитель, на который надо изменить размер прямоугольника:");
                            double mult = Convert.ToDouble(Console.ReadLine());
                            rectangle.ChangeOfSize(mult);
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "3")
                        {
                            Console.WriteLine("Укажи угол, на который необходимо повернуть прямоугольник(в градусах):");
                            double anlg = Convert.ToDouble(Console.ReadLine());
                            rectangle.Rotate(anlg);
                            Console.WriteLine("Сделано!");
                        }
                        if (_choose == "0")
                        {
                            break;
                        }
                    }
                }
                if (choose == "4")
                {
                    while (true)
                    {
                        Console.WriteLine("Выбери, какие две фигуры проверить на пересечение:\n1 - Круг и квадрат\n2 - Круг и прямоугольник\n3 - Квадрат и прямоугльник\n0 - Вернуться к выбору фигур");
                        string _choose = Console.ReadLine();
                        if (_choose == "1")
                        {
                            if (ActionsWithFigures.Intersection(circle, square))
                            {
                                Console.WriteLine("Они пересекаются!");
                            } else {
                                Console.WriteLine("Они не пересекаются"); 
                                }
                        }
                        if (_choose == "2")
                        {
                            if (ActionsWithFigures.Intersection(circle, rectangle))
                            {
                                Console.WriteLine("Они пересекаются!");
                            } else
                            {
                               Console.WriteLine("Они не пересекаются"); 
                            }
                        }
                        if (_choose == "3")
                        {
                            if (ActionsWithFigures.Intersection(square, rectangle))
                            {
                                Console.WriteLine("Они пересекаются!");
                            } else
                            {
                               Console.WriteLine("Они не пересекаются"); 
                            }
                        }
                        if (_choose == "0")
                        {
                            break;
                        }
                    }
                }
                if (choose == "0")
                {
                    break;
                }
            }
        }
    }
}
