using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieTheaterApp
{
    public partial class Form2 : Form
    {
        int totalReservedSeats;
        int totalReservedSeatsFC;
        int totalReservedSeatsODC;
        int totalReservedSeatsBOX;
        String userName;
        string movieName = "";
        string time = "";
        string category = "";


        int orderedTickets = 0;
        int orderedTicketsCounter = -1;
        int reservedSeatsFC = 0;
        int reservedSeatsODC = 0;
        int reservedSeatsBOX = 0;
        float totalPrice = 0;
        List<Button> reservedSeatsBtn = new List<Button>();

        public Form2(string userName, string movieName, string time, string category)
        {
            InitializeComponent();
            this.userName = userName;
            this.movieName = movieName;
            this.time = time;
            this.category = category;
            lblUserName.Text = userName;
            lblMovieDetails.Text = movieName + "  -  " + category + "  -  " + time;
        }

        //selecting and unselecting seats. there are 250 seats.
        //changing seat information
        private void seat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool isInArray = false;
            String seatNo = btn.Text;

            if (orderedTickets == 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (reservedSeatsBtn.Contains(btn))
            {
                this.label41.Text = seatNo;
                if (seatNo[0] >= 'L')
                {
                    label42.Text = "FIRST CLASS";
                    label43.Text = "Rs.250.00";
                    totalPrice -= 250;
                    reservedSeatsFC--;
                    label27.Text = (totalReservedSeatsFC + reservedSeatsFC).ToString() + "/40";
                    btn.BackColor = Color.FromArgb(128, 128, 255);
                }
                else if (seatNo[0] >= 'B')
                {
                    label42.Text = "ODC";
                    label43.Text = "Rs.350.00";
                    totalPrice -= 350;
                    reservedSeatsODC--;
                    label28.Text = (totalReservedSeatsODC + reservedSeatsODC).ToString() + "/200";
                    btn.BackColor = Color.FromArgb(150, 16, 255);
                }
                else if (seatNo[0] == 'A')
                {
                    label42.Text = "BOX";
                    label43.Text = "Rs.800.00";
                    totalPrice -= 800;
                    reservedSeatsBOX--;
                    label29.Text = (totalReservedSeatsBOX + reservedSeatsBOX).ToString() + "/10";
                    btn.BackColor = Color.FromArgb(192, 0, 192);
                }

                label32.Text = "Rs." + totalPrice.ToString("0.00");
                label22.Text = (totalReservedSeats + (reservedSeatsFC + reservedSeatsODC + reservedSeatsBOX)).ToString() + "/250";
                orderedTicketsCounter--;
                isInArray = true;
                reservedSeatsBtn.Remove(btn);

            }
            if (orderedTicketsCounter < orderedTickets && !isInArray)
            {
                this.label41.Text = seatNo;
                btn.BackColor = Color.DarkOrange;

                if (seatNo[0] >= 'L')
                {
                    label42.Text = "FIRST CLASS";
                    label43.Text = "Rs.250.00";
                    totalPrice += 250;
                    reservedSeatsFC++;
                    label27.Text = (totalReservedSeatsFC + reservedSeatsFC).ToString() + "/40";
                }
                else if (seatNo[0] >= 'B')
                {
                    label42.Text = "ODC";
                    label43.Text = "Rs.350.00";
                    totalPrice += 350;
                    reservedSeatsODC++;
                    label28.Text = (totalReservedSeatsODC + reservedSeatsODC).ToString() + "/200";
                }
                else if (seatNo[0] == 'A')
                {
                    label42.Text = "BOX";
                    label43.Text = "Rs.800.00";
                    totalPrice += 800;
                    reservedSeatsBOX++;
                    label29.Text = (totalReservedSeatsBOX + reservedSeatsBOX).ToString() + "/10";
                }
                label32.Text = "Rs." + totalPrice.ToString("0.00");
                label22.Text = (totalReservedSeats + (reservedSeatsFC + reservedSeatsODC + reservedSeatsBOX)).ToString() + "/250";
                reservedSeatsBtn.Add(btn);
                orderedTicketsCounter++;

            }
        }

        //Changing needed seats quantity according to combobox
        //If more seats are selected than required, the last selected seats will unselect.
        //changing seat informations
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                orderedTickets = (Convert.ToInt32(comboBox1.Items[comboBox1.SelectedIndex].ToString())) - 1;
                if (orderedTickets < orderedTicketsCounter)
                {
                    while (orderedTickets < orderedTicketsCounter)
                    {
                        Button btn = (Button)reservedSeatsBtn[orderedTicketsCounter];
                        string seatNo = btn.Text;
                        if (seatNo[0] >= 'L')
                        {
                            totalPrice -= 250;
                            reservedSeatsFC--;
                            label27.Text = (totalReservedSeatsFC + reservedSeatsFC).ToString() + "/40";
                            btn.BackColor = Color.FromArgb(128, 128, 255);
                        }
                        else if (seatNo[0] >= 'B')
                        {
                            totalPrice -= 350;
                            reservedSeatsODC--;
                            label28.Text = (totalReservedSeatsODC + reservedSeatsODC).ToString() + "/200";
                            btn.BackColor = Color.FromArgb(150, 16, 255);
                        }
                        else if (seatNo[0] == 'A')
                        {
                            totalPrice -= 800;
                            reservedSeatsBOX--;
                            label29.Text = (totalReservedSeatsBOX + reservedSeatsBOX).ToString() + "/10";
                            btn.BackColor = Color.FromArgb(192, 0, 192);
                        }
                        reservedSeatsBtn.RemoveAt(orderedTicketsCounter);
                        orderedTicketsCounter--;
                    }
                    label41.Text = "_ _ _";
                    label42.Text = "_ _ _";
                    label43.Text = "_ _ _";
                    label32.Text = "Rs." + totalPrice.ToString("0.00");
                    label22.Text = (totalReservedSeats + (reservedSeatsFC + reservedSeatsODC + reservedSeatsBOX)).ToString() + "/250";
                }
            }
        }

        //Navigating to ticket form and resetting the seats fields.
        //In this system i am not using printing codes just showing the ticket in  a form.
        //changing seat informations
        private void printButton_Click(object sender, EventArgs e)
        {
            float cash;
            string[] tempSeatArr = new string[20];
            int i = 0;

            try
            {
                cash = float.Parse(textBoxCash.Text.ToString().Trim());
            }
            catch (Exception)
            {
                cash = 0;
            }

            if (orderedTickets == orderedTicketsCounter)
            {
                if (cash >= totalPrice)
                {
                    foreach (Button btn in reservedSeatsBtn)
                    {
                        tempSeatArr[i] = btn.Text;
                        btn.Enabled = false;
                        i++;
                    }
                    Form3 form = new Form3(orderedTickets + 1, reservedSeatsFC, reservedSeatsODC, reservedSeatsBOX, totalPrice, cash, movieName, time, category, tempSeatArr);

                    totalReservedSeats += orderedTickets + 1;
                    totalReservedSeatsFC += reservedSeatsFC;
                    totalReservedSeatsODC += reservedSeatsODC;
                    totalReservedSeatsBOX += reservedSeatsBOX;
                    label22.Text = totalReservedSeats.ToString() + "/250";
                    label27.Text = totalReservedSeatsFC.ToString() + "/40";
                    label28.Text = totalReservedSeatsODC.ToString() + "/200";
                    label29.Text = totalReservedSeatsBOX.ToString() + "/10";
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "No. Of Full Tickets";

                    orderedTickets = 0;
                    orderedTicketsCounter = -1;
                    reservedSeatsFC = 0;
                    reservedSeatsODC = 0;
                    reservedSeatsBOX = 0;
                    totalPrice = 0;

                    label41.Text = "_ _ _";
                    label42.Text = "_ _ _";
                    label43.Text = "_ _ _";
                    label32.Text = "_ _ _";
                    textBoxCash.Clear();

                    reservedSeatsBtn.Clear();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("The money is not enough! Please check again.");
                }
            }
            else
            {
                MessageBox.Show("Please select " + (orderedTickets - orderedTicketsCounter).ToString() + " more seat!");
            }
        }
    }
}