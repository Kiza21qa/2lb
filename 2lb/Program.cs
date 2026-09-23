using System;

namespace LabWork_Inheritance
{
    class Program
    {
        static void Main()
        {
            // 1. Создаем массив базового типа для хранения разных объектов
            Автомобиль[] garage = new Автомобиль[2];

            // 2. Создаем объекты и сохраняем их в массив
            garage[0] = new Легковой("Toyota", "А123АА 67", 5);
            garage[1] = new Грузовой("KAMAZ", "В456ВВ 67", 10.5);

            // 3. Вызываем переопределенные методы в цикле
            Console.WriteLine("--- Автопарк ---");
            foreach (Автомобиль auto in garage)
            {
                auto.Показать();
            }

            Console.ReadKey();
        }
    }

    // Базовый класс
    class Автомобиль
    {
        private string mark;
        private string number;

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public Автомобиль(string m, string n)
        {
            mark = m;
            number = n;
        }

        // virtual позволяет переопределить этот метод в наследниках
        public virtual void Показать()
        {
            Console.WriteLine($"Автомобиль: марка - {Mark}, номер – {Number}");
        }
    }

    // Производный класс 1
    class Легковой : Автомобиль
    {
        private int seats;

        public int Seats
        {
            get { return seats; }
            set { if (value > 0) seats = value; }
        }

        // Вызов конструктора базового класса через base
        public Легковой(string m, string n, int s) : base(m, n)
        {
            Seats = s;
        }

        // Переопределение метода для вывода специфичных данных
        public override void Показать()
        {
            Console.WriteLine($"Легковой автомобиль: марка - {Mark}, номер – {Number}, число пассажирских мест – {Seats}");
        }
    }

    // Производный класс 2
    class Грузовой : Автомобиль
    {
        private double capacity;

        public double Capacity
        {
            get { return capacity; }
            set { if (value > 0) capacity = value; }
        }

        public Грузовой(string m, string n, double c) : base(m, n)
        {
            Capacity = c;
        }

        public override void Показать()
        {
            Console.WriteLine($"Грузовой автомобиль: марка - {Mark}, номер – {Number}, грузоподъемность – {Capacity}");
        }
    }
}