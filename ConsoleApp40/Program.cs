using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
{
    interface Transport
    {
        void Price();
        void Distance();
        void Patrol();
        void Deliver();
    }
    public class Ship : Transport
    {
        public Ship() { }
        public void Price() => Console.WriteLine("Заказ корабля = 10000$ + (500$ = 1км)");
        public void Distance() => Console.WriteLine("Максимальная дистанция = 3000км");
        public void Patrol() => Console.WriteLine("6000 литров/час");
        public void Deliver()
        {
            Console.WriteLine("Введите дистанию");
            int distance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ваш заказ корабля стоит = {distance * 500 + 10000}$");
        }
    }
    public class Truck : Transport
    {
        public Truck() { }
        public void Price() => Console.WriteLine("Заказ грузовика = 1000$ + (10$ = 1км)");
        public void Distance() => Console.WriteLine("Максимальная дистанция = 2000км");
        public void Patrol() => Console.WriteLine("25 литров/км");
        public void Deliver()
        {
            Console.WriteLine("Введите дистанию");
            int distance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ваш заказ грузовика стоит = {distance * 10 + 1000}$");
        }
    }
    public class Plane : Transport
    {
        public Plane() { }
        public void Price() => Console.WriteLine("Заказ самолета = 100000$ + (1000$ = 1км)");
        public void Distance() => Console.WriteLine("Максимальная дистанция = 4000км");
        public void Patrol() => Console.WriteLine("15000 литров/час");
        public void Deliver()
        {
            Console.WriteLine("Введите дистанию");
            int distance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ваш заказ грузовика стоит = {distance * 1000 + 100000}$");
        }
    }


    abstract class LogisticApp
    {
        virtual public Transport Create() { return null; }
    }
    class AirLogistic : LogisticApp
    {
        public AirLogistic() { }
        public override Transport Create() { return new Plane(); }
    }
    class TruckLogistic : LogisticApp
    {
        public TruckLogistic() { }
        public override Transport Create() { return new Truck(); }
    }
    class ShipLogistic : LogisticApp
    {
        public ShipLogistic() { }
        public override Transport Create() { return new Ship(); }
    }

    internal class Program
    {
        static Transport App(LogisticApp app)
        {
            return app.Create();
        }

        static void Main(string[] args)
        {
            LogisticApp app = new AirLogistic();
            Transport transport = App(app);
            transport.Distance();
        }
    }
}