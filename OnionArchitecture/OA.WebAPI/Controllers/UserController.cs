using OA.Data.Model;
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
                FirstName = "Sagar",
                LastName = "Parida",
                Role = "Admin",
                Mobile = "918742957601",
                Email = "sagar.chini@gmail.com",
                PasswordHash = "password123$",
                SecurityStamp = Guid.NewGuid().ToString(),
                IPAddress = "172.20.20.177",
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
                ProductId = 1001
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
