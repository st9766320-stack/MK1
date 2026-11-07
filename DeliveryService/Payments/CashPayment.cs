using System;
using System.Collections.Generic;
using System.Text;
using DeliveryService.Interfaces;

namespace DeliveryService.Payments
{
    public class CashPayment : IPayment
    {
        public bool Pay(double amount)
        {
            if (amount <= 0)
                return false;

            Console.WriteLine($"Оплата готівкою: {amount} грн"); //$ дозволяє вставляти значення змінної через {}
            return true;
        }
    }
}