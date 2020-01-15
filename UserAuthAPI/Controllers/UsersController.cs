using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using UserAuthAPI.Models;

namespace UserAuthAPI.Controllers
{
   
    public class UsersController : ApiController
    {
        private UserCredentialsEntities db = new UserCredentialsEntities();

        [AcceptVerbs("GET")]
        [HttpGet]
        [BasicAuthentication]
        public HttpResponseMessage GetUserDetail(string username, string password)
        {
            int id = db.Users.Where(x => x.userName == username && x.Password == password).FirstOrDefault().Id;

            var userdetail = db.f_getUserDetail(id).ToList();
            if (userdetail.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, userdetail, Configuration.Formatters.JsonFormatter);
        }

        //public IEnumerable<User> GetUser()
        //{
        //    return db.Users.ToList();
        //}
    }
}