using OA.Data.Model;
using OA.Repo.UoW;
using OA.Service.Interfaces;

namespace OA.Service.Services
{
    public class OrderSrvc : IOrderSrvc
    {
        private readonly IGenericUoW _UoW2;
        public OrderSrvc(IGenericUoW UoW2)
        {
            _UoW2 = UoW2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public void InsertOrder(Order order)
        {
            _UoW2.GenericRepository<Order>().Insert(order);
        }
    }
}
