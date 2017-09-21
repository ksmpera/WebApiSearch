using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using System.Net.Http;
using UserService;
using log4net;
using ServiceClient;
using System.Security.Cryptography;
using System.Reflection;
using System.Text;


namespace WebApiSearch.Controller
{  

    public class AddUserServiceController : ApiController, IAddUserService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AddUserServiceController));
        

        [HttpPost]
        [Route("api/AddUser")]
        public bool AddUser(User user)
        {            
            string hash = user.HashCode;

            string input = Hashhelper.GetProperty(user);

            if (Hashhelper.VerifyMd5Hash(input, hash))
            {
                AddUserService us = new AddUserService();
                bool state = us.AddUser(user);
                return state;
            }
            return false;
        }

        [HttpPost]
        [Route("api/AddAccount")]
        public bool AddAccount(UserAccount useraccount)
        {
            AddUserService us = new AddUserService();
            bool state = us.AddAccount(useraccount);
            return state;
        }

        [HttpPost]
        [Route("api/Search")]        
        public IEnumerable<spSearch_Result> Search([FromBody]Test test)
        {          
            string hash = test.HashCode;
            string input = Hashhelper.GetProperty(test);

            if (Hashhelper.VerifyMd5Hash(input, hash))
            {
                AddUserService us = new AddUserService();
                var state = us.Search(test);
                log.DebugFormat("WebApi got letter {0}.", test.Letter);
                return state;
            }
            else
            {
                return null;
            }
        }        
    }   
}