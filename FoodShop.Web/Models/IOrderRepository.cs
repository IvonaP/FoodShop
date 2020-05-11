using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Web.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
