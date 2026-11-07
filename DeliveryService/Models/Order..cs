using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class Order
    {
        public int Number { get; private set; }

        public string Description { get; private set; }

        public double Weight { get; private set; }

        public double Distance { get; private set; }

        public Order(int number, string description, double weight, double distance)
        {
            Number = number;
            Description = description;
            Weight = weight;
            Distance = distance;
        }
    }
}