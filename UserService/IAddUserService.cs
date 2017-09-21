using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public interface IAddUserService
    {
        //IEnumerable<spSearch_Result> Search(string letter);

        IEnumerable<spSearch_Result> Search(Test test);

        bool AddUser(User user);
     

        bool AddAccount(UserAccount useraccount);
    }
}
