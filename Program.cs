using System;

namespace LabWork
{
    public interface IGeometricShape
    {
        void SetCoefficients();
        void DisplayCoefficients();
        bool IsPointInside();
    }

    public abstract class BaseShape : IGeometricShape
    {
        public abstract void SetCoefficients();
        public abstract void DisplayCoefficients();
        public abstract bool IsPointInside();

        protected BaseShape()
        {
            Console.WriteLine("System: BaseShape initialized");
        }

        ~BaseShape()
        {
            Console.WriteLine("System: BaseShape finalized");
        }
    }

    class Rectangle : BaseShape
    {
        private double _b1, _a1, _b2, _a2;

        public Rectangle()
        {
            Console.WriteLine("System: Rectangle object created");
        }

        public override void SetCoefficients()
        {
            Console.WriteLine("--- Налаштування Прямокутника ---");
            Console.Write("b1: ");
            _b1 = double.Parse(Console.ReadLine());
            Console.Write("a1: ");
            _a1 = double.Parse(Console.ReadLine());
            Console.Write("b2: ");
            _b2 = double.Parse(Console.ReadLine());
            Console.Write("a2: ");
            _a2 = double.Parse(Console.ReadLine());
        }

        public override void DisplayCoefficients()
        {
            Console.WriteLine($"Прямокутник: {_b1} <= x1 <= {_a1}, {_b2} <= x2 <= {_a2}");
        }

        public override bool IsPointInside()
        {
            Console.WriteLine("Перевірка точки для прямокутника:");
            Console.Write("x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("x2: ");
            double x2 = double.Parse(Console.ReadLine());
            return (x1 >= _b1 && x1 <= _a1) && (x2 >= _b2 && x2 <= _a2);
        }

        ~Rectangle()
        {
            Console.WriteLine("System: Rectangle object destroyed");
        }
    }

    class Parallelepiped : Rectangle
    {
        private double _b3, _a3;

        public Parallelepiped()
        {
            Console.WriteLine("System: Parallelepiped object created");
        }

        public override void SetCoefficients()
        {
            base.SetCoefficients();
            Console.Write("b3: ");
            _b3 = double.Parse(Console.ReadLine());
            Console.Write("a3: ");
            _a3 = double.Parse(Console.ReadLine());
        }

        public override void DisplayCoefficients()
        {
            base.DisplayCoefficients();
            Console.WriteLine($"Z-вісь: {_b3} <= x3 <= {_a3}");
        }

        public override bool IsPointInside()
        {
            bool baseResult = base.IsPointInside();
            Console.Write("x3: ");
            double x3 = double.Parse(Console.ReadLine());
            return baseResult && (x3 >= _b3 && x3 <= _a3);
        }

        ~Parallelepiped()
        {
            Console.WriteLine("System: Parallelepiped object destroyed");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n1 - Прямокутник, 2 - Паралелепіпед, 0 - Вихід");
                string choice = Console.ReadLine();
                if (choice == "0") break;

                IGeometricShape figure = null;

                if (choice == "1")
                {
                    figure = new Rectangle();
                }
                else if (choice == "2")
                {
                    figure = new Parallelepiped();
                }

                if (figure != null)
                {
                    figure.SetCoefficients();
                    figure.DisplayCoefficients();
                    bool result = figure.IsPointInside();
                    Console.WriteLine(result ? "Результат: Точка всередині" : "Результат: Точка зовні");
                }

                figure = null;
            }
        }
    }
}