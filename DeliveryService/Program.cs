using DeliveryService.Interfaces;
using DeliveryService.Models;
using DeliveryService.Payments;
using DeliveryService.Services;
using System;

namespace DeliveryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryService.Services.DeliveryService service =
            new DeliveryService.Services.DeliveryService();
            Car car = new Car();
            service.AddTransport(car);
            Truck truck = new Truck();
            service.AddTransport(truck);
            Bike bike = new Bike();
            service.AddTransport(bike);

            Order order1 = new Order(1, "Одяг", 2, 5);
            service.AddOrder(order1);
            Order order2 = new Order(2, "Меблі", 30, 15);
            service.AddOrder(order2);
            Order order3 = new Order(3, "Книги", 3, 4);
            service.AddOrder(order3);

            Console.WriteLine("Вартість Доставки: ");

            service.ShowDeliveryCosts(order1);
            service.ShowDeliveryCosts(order2);
            service.ShowDeliveryCosts(order3);


            Console.WriteLine("\nПризначення Транспорту: ");

            bool result1 = service.AssignTransport(order1, car);

            if (result1)
                Console.WriteLine("Для замовлення 1 призначено: Автомобіль ");
            else
                Console.WriteLine("Не вдалося призначити Автомобіль");

            bool result2 = service.AssignTransport(order2, truck);

            if (result2)
                Console.WriteLine("Для замовлення 2 призначено:Вантажівку  ");
            else
                Console.WriteLine("Не вдалося призначити Вантажівку");

            bool result3 = service.AssignTransport(order3, bike);

            if (result3)
                Console.WriteLine("Для замовлення 3 призначено: Велосипед ");
            else
                Console.WriteLine("Не вдалося призначити Велосипед");

            Console.WriteLine("\nЗавершення Доставки: ");


            CardPayment card = new CardPayment();
            CashPayment cash = new CashPayment();

            bool delivery1 = service.CompleteDelivery(order1, card);

            if (delivery1)
                Console.WriteLine("Замовлення 1 доставлено!");
            else
                Console.WriteLine("Не вдалося завершити замовлення 1");

            bool delivery2 = service.CompleteDelivery(order2, cash);

            if (delivery2)
                Console.WriteLine("Замовлення 2 доставлено!");
            else
                Console.WriteLine("Не вдалося завершити замовлення 2");

            //bool delivery3 = service.CompleteDelivery(order3, cash);

            //if (delivery3)
            //    Console.WriteLine("Замовлення 3 доставлено!");
            //else
            //    Console.WriteLine("Не вдалося завершити замовлення 3");

            service.ShowOrders( );
            service.ShowHistory();

        }




    }
}