using System;

namespace Task8
{
    public class TCircle
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                    Console.WriteLine("Радіус не може бути від'ємним!");
            }
        }

        public TCircle()
        {
            radius = 0;
        }

        public TCircle(double r)
        {
            Radius = r;
        }

        public TCircle(TCircle other)
        {
            this.radius = other.radius;
        }

        public void Input()
        {
            Console.Write("Введіть радіус кола: ");
            if (double.TryParse(Console.ReadLine(), out double r))
            {
                Radius = r;
            }
            else
            {
                Console.WriteLine("Некоректне значення! Встановлено 0.");
                radius = 0;
            }
        }

        public void Print()
        {
            Console.WriteLine($"Коло з радіусом: {radius}");
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetSectorArea(double angleInDegrees)
        {
            return (Math.PI * radius * radius * angleInDegrees) / 360.0;
        }

        public double GetLength()
        {
            return 2 * Math.PI * radius;
        }


        public bool Equals(TCircle other)
        {
            if (other == null) return false;
            return this.radius == other.radius;
        }

        public static TCircle operator +(TCircle c1, TCircle c2)
        {
            return new TCircle(c1.radius + c2.radius);
        }

        public static TCircle operator -(TCircle c1, TCircle c2)
        {
            double newRadius = c1.radius - c2.radius;
            if (newRadius < 0) newRadius = 0; 
            return new TCircle(newRadius);
        }

        public static TCircle operator *(TCircle c, double number)
        {
            return new TCircle(c.radius * number);
        }

        public static TCircle operator *(double number, TCircle c)
        {
            return new TCircle(c.radius * number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            Console.WriteLine("=== ТЕСТУВАННЯ КЛАСУ TCircle ===\n");

            TCircle c1 = new TCircle(5.0);
            Console.Write("Коло 1: ");
            c1.Print();

            Console.WriteLine($"Площа круга c1: {c1.GetArea():F2}");
            Console.WriteLine($"Довжина кола c1: {c1.GetLength():F2}");
            Console.WriteLine($"Площа сектора (90 градусів) c1: {c1.GetSectorArea(90):F2}");
            Console.WriteLine();

            TCircle c2 = new TCircle();
            Console.WriteLine("Введення c2:");
            c2.Input();
            Console.Write("Коло 2: ");
            c2.Print();
            Console.WriteLine();

            TCircle c3 = new TCircle(c1);
            Console.Write("Коло 3 (копія c1): ");
            c3.Print();
            Console.WriteLine();

            Console.WriteLine($"Чи однакові c1 і c3? {c1.Equals(c3)}");
            Console.WriteLine($"Чи однакові c1 і c2? {c1.Equals(c2)}");
            Console.WriteLine();

            Console.WriteLine("=== ТЕСТУВАННЯ ОПЕРАТОРІВ ===");

            TCircle cSum = c1 + c2;
            Console.Write("c1 + c2 = ");
            cSum.Print();

            TCircle cDiff = c1 - c2;
            Console.Write("c1 - c2 = ");
            cDiff.Print();

            TCircle cMult = c1 * 3;
            Console.Write("c1 * 3 = ");
            cMult.Print();

            Console.WriteLine("\nНатисніть кнопочку Enter, щоб завершити...");
            Console.ReadLine();
        }
    }
}