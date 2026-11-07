using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class Truck : Transport
    {
        public Truck() : base("Вантажівка")
        {
        }

        public override double CalculateCost(Order order)
        {
            return 200 + 15 * order.Distance + 0.5 * order.Weight;
        }
    }
}
