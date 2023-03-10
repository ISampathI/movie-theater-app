using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheaterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            this.ActiveControl = label3;
        }
        //checking the username and password then navigate to next form.
        private void customButton1_Click(object sender, EventArgs e)
        {
            String userName = tbUserName.Text.Trim();
            String password = tbPassword.Text;
            if (userName == "user" && password == "123")
            {
                Form4 form4 = new Form4(userName);
                form4.Show();
                this.Hide();
            }
            else
            {
                label5.Visible = true;
                Timer timer = new Timer(); //Timer is used to show error message for 4 seconds.
                timer.Interval = 4000;
                timer.Tick += (object sender, EventArgs e) =>
                {
                    label5.Visible = false;
                    timer.Stop();
                }; timer.Start();
            }
        }
    }
}
