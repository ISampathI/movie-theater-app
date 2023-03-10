using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieTheaterApp
{
    public partial class Form3 : Form
    {
        //Here just showing ticket in a form.
        public Form3(int orderedTickets, int reservedSeatsFC, int reservedSeatsODC, int reservedSeatsBOX, float totalPrice, float cash, string movieName, string time, string category, string[] seatArr)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            string seats = "";

            for (int i = 0; i < orderedTickets; i++)
            {
                seats += seatArr[i] + "  ";
            }

            lblDateTime.Text = now.ToString();
            lblTickets.Text = orderedTickets.ToString() + (orderedTickets == 1?" Ticket" : " Tickets");
            lblFC.Text = reservedSeatsFC.ToString();
            lblODC.Text = reservedSeatsODC.ToString();
            lblBox.Text = reservedSeatsBOX.ToString();
            lblTotalAmount.Text = "Rs." + totalPrice.ToString();
            lblCash.Text = "Rs." + cash.ToString();
            lblChange.Text = "Rs." + (cash - totalPrice).ToString();
            lblSeats.Text = seats;
            lblMovieDetails.Text = movieName + "  -  " + category + "  -  " + time;

            if (category == "3D")
            {
                label3.Visible = true;
            }

        }
    }
}
