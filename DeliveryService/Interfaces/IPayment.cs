using System;
using System.Collections.Generic;
using System.Text;


namespace DeliveryService.Interfaces
{
    public interface IPayment
    {
        bool Pay(double amount);
    }
}
