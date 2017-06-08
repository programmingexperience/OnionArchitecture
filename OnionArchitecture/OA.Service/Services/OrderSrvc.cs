using OA.Data.Model;
using OA.Repo.UoW;
using OA.Service.Interfaces;

namespace OA.Service.Services
{
    public class OrderSrvc : IOrderSrvc
    {
        private readonly IGenericUoW _UoW;
        public OrderSrvc(IGenericUoW UoW)
        {
            _UoW = UoW;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public void InsertOrder(Order order)
        {
            _UoW.GenericRepository<Order>().Insert(order);
        }
    }
}
