using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UserService;
using System.Net.Http;
using log4net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Reflection;

namespace ServiceClient
{       

    public class WebAPIUserClient : IAddUserService
    {
        private static readonly string WEB_API_BASE_URL = ConfigurationManager.AppSettings["WebAPIBaseURL"];

       
        private static readonly ILog log = LogManager.GetLogger(typeof(WebAPIUserClient));       

        public IEnumerable<spSearch_Result> Search(Test test)
        {           
                using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_API_BASE_URL);
              

                var responseTask = client.PostAsJsonAsync<Test>("Search", test);
                responseTask.Wait();

                var result = responseTask.Result;

                log.DebugFormat("User count: {0}", result);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<spSearch_Result>>();
                    readTask.Wait();                    

                    var ret = readTask.Result;
                    log.DebugFormat("The letter is: {0}", test);    

                    return ret;
                }
                return null;
            }
        }
        public bool AddUser(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_API_BASE_URL);
                //HTTP POST
                var responseTask = client.PostAsJsonAsync<User>("AddUser", user);
                responseTask.Wait();               
                
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();
                    readTask.Wait();

                    var ret = readTask.Result;

                    return ret;
                }
                return false;
            }
        }
        public bool AddAccount(UserAccount useraccount)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_API_BASE_URL);
                //HTTP POST
                var responseTask = client.PostAsJsonAsync<UserAccount>("AddAccount", useraccount);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<bool>();
                    readTask.Wait();

                    var ret = readTask.Result;

                    return ret;
                }
                return false;
            }
        }       
    }
}
