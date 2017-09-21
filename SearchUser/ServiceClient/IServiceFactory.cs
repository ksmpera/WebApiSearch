using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Http;
using System.Net.Http;
using UserService;
using log4net;

namespace ServiceClient
{
    public interface IServiceFactory
    {
        IAddUserService CreateUserClient();
    }

    public class InProcessServiceFactory : IServiceFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(InProcessServiceFactory));  

        public IAddUserService CreateUserClient()
        {
            log.DebugFormat("AddUserService is active!");
            return new AddUserService();
        }
    }
    public class WebAPIServiceFactory : IServiceFactory
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebAPIServiceFactory));  

        public IAddUserService CreateUserClient()
        {
            log.DebugFormat("WebAPIUserClient is active!");
            return new WebAPIUserClient();
        }
    }
    public class ServiceFactoryCreator
    {
        private static readonly bool _skipWebApi;

        private static readonly ILog log = LogManager.GetLogger(typeof(InProcessServiceFactory));  

        static ServiceFactoryCreator()
        {
            string skip = ConfigurationManager.AppSettings["SkipWebAPI"];

            log.DebugFormat("SkipWebAPI is {0}!", skip);

            if (!bool.TryParse(skip, out _skipWebApi))
            {
                _skipWebApi = false;
            }
        }
        public static IServiceFactory CreateServicesFactory()
        {
            return _skipWebApi ? (IServiceFactory)new InProcessServiceFactory() : (IServiceFactory)new WebAPIServiceFactory();
        }
    }
}
