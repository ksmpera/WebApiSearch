using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserService;
using ServiceClient;
using System.Security.Cryptography;
using System.Reflection;
using WebApiSearch.Controller;

namespace SearchUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IAddUserService sus = ServiceFactoryCreator.CreateServicesFactory().CreateUserClient();               
                Test test = new Test();
                test.Letter = textBox1.Text;
                string hash = Hashhelper.GetProperty(test);
                test.HashCode = Hashhelper.GetMD5(hash);
                //test.HashCode = "";
                dataGridView1.DataSource = sus.Search(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            IAddUserService adduser = ServiceFactoryCreator.CreateServicesFactory().CreateUserClient();
            User user = new User();
            user.UserName = textBox1.Text;
            user.Name = textBox2.Text;
            user.SurName = textBox3.Text;
            user.UserPassword = textBox5.Text;
            user.E_Mail = textBox4.Text;
           
            string hash = Hashhelper.GetProperty(user);
            user.HashCode = Hashhelper.GetMD5(hash);
            adduser.AddUser(user);
        }
    }
}


