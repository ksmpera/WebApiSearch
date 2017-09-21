using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserService;
using ServiceClient;

namespace WebApplicationWEBAPI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IAddUserService adduser = ServiceFactoryCreator.CreateServicesFactory().CreateUserClient();
            User user = new User();
            user.UserName = TextBox1.Text;
            user.Name = TextBox2.Text;
            user.SurName = TextBox3.Text;
            user.UserPassword = TextBox5.Text;
            user.E_Mail = TextBox4.Text;

            string hash = Hashhelper.GetProperty(user);
            user.HashCode = Hashhelper.GetMD5(hash);
            adduser.AddUser(user);
            Response.Write("User is added!");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                IAddUserService sus = ServiceFactoryCreator.CreateServicesFactory().CreateUserClient();
                Test test = new Test();
                test.Letter = TextBox1.Text;
                string hash = Hashhelper.GetProperty(test);
                test.HashCode = Hashhelper.GetMD5(hash);
                //test.HashCode = "";
                GridView1.DataSource = sus.Search(test);
                GridView1.DataBind();
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}