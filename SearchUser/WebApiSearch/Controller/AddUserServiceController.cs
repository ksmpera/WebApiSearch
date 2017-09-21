using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using System.Net.Http;

namespace WebApiSearch.Controller
{
    public class AddUserServiceController
    {
        [HttpPost]
        [Route("api/AddUser")]
        public bool AddUser(User user)
        {
            AddUserService us = new AddUserService();
            bool state = us.AddUser(user);
            return state;
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
        public IEnumerable<spSearch_Result> Search([FromBody]string letter)
        {
            AddUserService us = new AddUserService();
            var state = us.Search(letter);
            return state;
        }


    }
}
