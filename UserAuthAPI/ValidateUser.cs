using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAuthAPI.Models;

namespace UserAuthAPI
{
    public class ValidateUser
    {
        public static bool VaidateUser(string username, string password)
        {

            using (UserCredentialsEntities db = new UserCredentialsEntities())
            {
                var user = db.Users.Where(x => x.userName == username && x.Password == password).ToList();
                if (user.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
             
        }
    }
}