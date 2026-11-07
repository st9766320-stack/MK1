using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public abstract class Transport
    {
        public string Name { get; private set; }

        public bool FreeTransport { get; private set; }

        public Transport(string name)
        {
            Name = name;
            FreeTransport = true;
        }

        // Абстрактний метод розрахунку вартості
        public abstract double CalculateCost(Order order);

        // Перевірка можливості прийняти замовлення
        public virtual bool CanTake(Order order)
        {
            if (order == null)
                return false;

            if (!FreeTransport)
                return false;

            if (order.Weight <= 0 || order.Distance <= 0)
                return false;

            return true;
        }

        // Зайняти транспорт
        public void Busy()
        {
            FreeTransport = false;
        }

        // Звільнити транспорт
        public void Release()
        {
            FreeTransport = true;
        }
    }
}