using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieTheaterApp
{
    public partial class Form4 : Form
    {
        string userName;
        string movieName = "";
        string time = "";
        string category = "";

        public Form4(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            comboBox1.SelectedIndex = 0;
        }

        //Checking radio buttons and navigating to next form
        private void btnNext_Click(object sender, EventArgs e)
        {
            movieName = comboBox1.Text;

            if (radioButtonTime1.Checked)
            {
                time = "10:00 am";
            }
            else if (radioButtonTime2.Checked)
            {
                time = "01:15 pm";
            }
            else if (radioButtonTime3.Checked)
            {
                time = "04:15 pm";
            }
            else if (radioButtonTime4.Checked)
            {
                time = "07:15 pm";
            }


            if (radioButtonCat1.Checked)
            {
                category = "Normal";
            }
            else if (radioButtonCat2.Checked)
            {
                category = "3D";
            }


            if (movieName != "" && time != "" && category != "")
            {
                label1.Text = movieName + " " + time + " " + category;
                Form2 form2 = new Form2(userName, movieName, time, category);
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Please check the movie name!");
            }
        }
    }
}
