using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using ServiceClient;
using UserService;
using log4net;
using System.Windows.Forms;

namespace TestTool
{
    public class AppTest
    {
        static Semaphore s = new Semaphore(1, 1);

        private static readonly ILog log = LogManager.GetLogger(typeof(AppTest));


        public void Start(int usersnumber, int callsnumber)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 1; i < usersnumber + 1; i++)
            {                
                Thread thread = new Thread(() => EnterMethod(callsnumber));
                thread.Name = "Thread_" + i;

                threads.Add(thread);

                thread.Start();
                log.DebugFormat("Number of threads is: {0}", usersnumber);  
            }
        }

        public static void EnterMethod(int callsnumber)
        {           
  
            for (int i = 0; i < callsnumber; i++)
            {
                int num = int.Parse(Thread.CurrentThread.Name.Substring(7));

                if (num % 2 == 0)
                {
                    try
                    {
                        IAddUserService sus = ServiceFactoryCreator.CreateServicesFactory().CreateUserClient();                      
                        Test test = new Test();
                        test.Letter = "";
                        string hash = Hashhelper.GetProperty(test);
                        test.HashCode = Hashhelper.GetMD5(hash);
                        sus.Search(test);
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("Search(): {0}", ex.Message);
                        throw ex;
                    }
                }
                else
                {
                    try
                    {                        
                        IAddUserService addu = ServiceFactoryCreator.CreateServicesFactory().CreateUserClient();
                        User user = new User();
                        user.UserName = RandomString(8);
                        user.Name = RandomString(6);
                        user.SurName = RandomString(8);
                        user.UserPassword = RandomString(9);
                        user.E_Mail = RandomString(4)+"@"+RandomString(8);
                        string hash = Hashhelper.GetProperty(user);
                        user.HashCode = Hashhelper.GetMD5(hash);
                        addu.AddUser(user);
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("Search(): {0}", ex.Message);
                        throw ex;
                    }
                }               
            }
            s.WaitOne();
            MessageBox.Show("End of test tool!");            
            log.DebugFormat("Number of calls was: {0}", callsnumber);
            Environment.Exit(Environment.ExitCode);
            s.Release();           
        }
        public void Stop()
        {
            Environment.Exit(Environment.ExitCode);
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

