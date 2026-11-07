
using System;
using System.Collections.Generic;
using DeliveryService.Models;
using DeliveryService.Interfaces;

namespace DeliveryService.Services
{
    public class DeliveryService
    {
        private List<Transport> transports;
        private List<Order> orders;
        private List<Order> history;

        private Dictionary<Order, Transport> assignedTransports;

        public DeliveryService()
        {
            transports = new List<Transport>();
            orders = new List<Order>();
            history = new List<Order>();
            assignedTransports = new Dictionary<Order, Transport>();
        }

        public void AddTransport(Transport transport)
        {
            transports.Add(transport);
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);

        }

        public bool AssignTransport(Order order, Transport transport)
        {
            if (!transport.FreeTransport)
            {
                return false;
            }

            if (!transport.CanTake(order))
            {
                return false;
            }

            if (assignedTransports.ContainsKey(order))
            {
                return false;
            }

            assignedTransports.Add(order, transport);

            transport.Busy();

            return true;
        }

        public bool CompleteDelivery(Order order, IPayment payment)
        {
            if (!assignedTransports.ContainsKey(order))
                return false;

            Transport transport = assignedTransports[order];
            double cost = transport.CalculateCost(order);

            if (!payment.Pay(cost))
            {
                return false;
            }

            transport.Release();
            orders.Remove(order);
            history.Add(order);
            assignedTransports.Remove(order);

            return true;
        }
        public void ShowOrders()
        {
            Console.WriteLine("Активні замовлення:");

            foreach (Order order in orders)
            {
                Console.WriteLine($"Номер: {order.Number}, Опис: {order.Description}");
            }
        }
        public void ShowHistory()
        {
            Console.WriteLine("Історія доставок:");

            foreach (Order order in history)
            {
                Console.WriteLine($"Номер: {order.Number}, Опис: {order.Description}");
            }
        }
        public void ShowDeliveryCosts(Order order)
        {
            Console.WriteLine($"Вартість доставки замовлення {order.Number}:");

            foreach (Transport transport in transports)
            {
                if (transport.CanTake(order))
                {
                    double cost = transport.CalculateCost(order);

                    Console.WriteLine($"{transport.Name}: {cost} грн");
                }
            }
        }
    }
}
