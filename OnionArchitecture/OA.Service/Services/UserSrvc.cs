using OA.Data.Model;
using OA.Repo.UoW;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OA.Service.Services
{
    public class UserSrvc : IUserSrvc
    {
        private readonly IGenericUoW _UoW2;
        public UserSrvc(IGenericUoW UoW2)
        {
            _UoW2 = UoW2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="PasswordHash"></param>
        /// <returns></returns>
        public User ValidateUser(string Username, string PasswordHash)
        {
            return _UoW2.GenericRepository<User>().GetFirstOrDefault(x => x.Email == Username && x.PasswordHash == PasswordHash);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> Get()
        {
            return _UoW2.GenericRepository<User>().Get().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Int64 InsertUserOrder(User user, Order order)
        {
            Int64 uid = 0;
            using (var _dbtransaction = _UoW2.BeginTransaction())
            {
                try
                {
                    _UoW2.GenericRepository<User>().Insert(user);
                    _UoW2.SaveChanges();
                    uid = user.Id;
                    order.UserId = uid;

                    _UoW2.GenericRepository<Order>().Insert(order);
                    _UoW2.SaveChanges();
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
