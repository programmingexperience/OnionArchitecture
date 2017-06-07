using System;
using System.Collections.Generic;
using OA.Data.Model;

namespace OA.Service.Interfaces
{
    public interface IUserSrvc
    {
        User ValidateUser(string Username, string PasswordHash);
        IEnumerable<User> Get();
        Int64 InsertUserOrder(User user, Order order);
    }
}
