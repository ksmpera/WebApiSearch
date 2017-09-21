using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public class AddUserService : IAddUserService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AddUserService));


        //public IEnumerable<spSearch_Result> Search(string letter)
        public IEnumerable<spSearch_Result> Search(Test test)
        {
            log.DebugFormat("AddUserService is active!");
            try
            {
                using (var dbc = new UserSearchEntities())
                {
                    string letter = test.Letter;
                    var allUser = dbc.spSearch(letter).ToList();
                    log.DebugFormat("Search(), user count: {0}", allUser.Count);

                    return allUser;
                }
            }
            catch (Exception ex)
            {                
                log.ErrorFormat("Search(): {0}", ex.Message);
                throw ex;                
            }
            finally { }
        }

        public bool AddUser(User user)
        {
            try
            {
                using (var dbc = new UserSearchEntities())
                {
                    dbc.Users.Add(user);
                    dbc.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public bool AddAccount(UserAccount useraccount)
        {
            try
            {
                using (var dbc = new UserSearchEntities())
                {
                    dbc.UserAccounts.Add(useraccount);
                    dbc.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }       
    }
}
    

