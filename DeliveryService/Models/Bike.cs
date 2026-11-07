using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.Models
{
    public class Bike : Transport
    {
        public Bike() : base("Велосипед")
        {
        }

        public override double CalculateCost(Order order)
        {
            return 20 + 5 * order.Distance;
        }

        public override bool CanTake(Order order)
        {
            if (!base.CanTake(order))
                return false;

            if (order.Weight > 10)
                return false;

            if (order.Distance > 10)
                return false;

            return true;
        }
    }
} 