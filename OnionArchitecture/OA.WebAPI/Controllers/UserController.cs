using OA.Data.Model;
using OA.Service.Helpers;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OA.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserSrvc userService;
        private readonly IOrderSrvc orderService;
        //
        // GET: /Product/
        public UserController(IUserSrvc userServiceParam, IOrderSrvc orderServiceParam)
        {
            userService = userServiceParam;
            orderService = orderServiceParam;
        }
        [Route("api/GetAllUser")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = userService.Get().ToList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route("api/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser()
        {
            #region Models
            bool flag = false;
            Int64 i = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User()
            {
                Title = "Mr.",
                FirstName = "Zulia",
                LastName = "Robert",
                Role = "Customer",
                Mobile = "919742957601",
                Email = "zulia.robert@gmail.com",
                PasswordHash = "xyz12345678$",
                SecurityStamp = Guid.NewGuid().ToString(),
                IPAddress = Helpers.GetIpAddress(),
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
                IsForgotPSWD = false,
                IsDeleted = false
            };
            var order = new Order()
            {
                UserId = 0,
                ProductId = 1
            };
            #endregion

            i = userService.InsertUserOrder(user, order);
            if (i > 0)
                flag = true;

            if (flag == null)
            {
                return NotFound();
            }
            return Ok(flag);
        }
    }
}
