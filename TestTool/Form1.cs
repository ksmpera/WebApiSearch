using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceClient;

namespace TestTool
{
    public partial class Form1 : Form
    {
        private static readonly string unum = ConfigurationManager.AppSettings["usersnumber"];
        private static readonly string cnum = ConfigurationManager.AppSettings["callsnumber"];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usersnumber = Convert.ToInt32(unum);
            var callsnumber = Convert.ToInt32(cnum);
            AppTest apptest = new AppTest();
            apptest.Start(usersnumber, callsnumber);
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            AppTest apptest = new AppTest();
            apptest.Stop();
        }
    }
}
