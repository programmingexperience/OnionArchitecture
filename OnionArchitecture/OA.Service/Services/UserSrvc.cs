using OA.Data.Model;
using OA.Repo.UoW;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Service.Services
{
    public class UserSrvc : IUserSrvc
    {
        private readonly IGenericUoW _UoW;
        public UserSrvc(IGenericUoW UoW)
        {
            _UoW = UoW;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="PasswordHash"></param>
        /// <returns></returns>
        public User ValidateUser(string Username, string PasswordHash)
        {
            return _UoW.GenericRepository<User>().GetFirstOrDefault(x => x.Email == Username && x.PasswordHash == PasswordHash);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> Get()
        {
            return _UoW.GenericRepository<User>().Get().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Int64 InsertUserOrder(User user, Order order)
        {
            Int64 uid = 0;
            using (var _dbtransaction = _UoW.BeginTransaction())
            {
                try
                {
                    _UoW.GenericRepository<User>().Insert(user);
                    _UoW.SaveChanges();
                    uid = user.Id;
                    order.UserId = uid;

                    _UoW.GenericRepository<Order>().Insert(order);
                    _UoW.SaveChanges();
                    _dbtransaction.Commit();
                }
                catch (Exception)
                {
                    _dbtransaction.Rollback();
                }
                return uid;
            }
        }
    }
}
