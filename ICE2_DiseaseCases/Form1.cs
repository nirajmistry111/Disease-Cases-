// Name: - Niraj Mistry.
// Student no: -100855211    
//Date: - 02/06/2022.
// Disease Cases average calculator.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE2_DiseaseCases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region variables
        // Global Variables
        Label[] weekDays;
        TextBox[] infections;
        double totalcases = 0;
        
        // TODO: Add an event (ValueChanged) to the DateTimePicker control such that the weekday names are updated to match the chosen date. Note: the custom method to enter the names is already created, just call it.

        private void Form1_Load(object sender, EventArgs e)
        {
            // initialize the weekdays label array and populate with the appropriate labels
            weekDays = new Label[] { lblDay1, lblDay2, lblDay3, lblDay4, lblDay5, lblDay6, lblDay7 };


            // TODO: initialize the infections textbox array and populate with the appropriate textboxes
            infections = new TextBox[] { txtDay1, txtDay2, txtDay3, txtDay4, txtDay5, txtDay6, txtDay7 };
           
            
            // populate the week day name labels with the actual names.
            SetDayNames();
        }


        private void SetDayNames()
        {
            for (int day = 1; day <= 7; day++)
            {
                //TODO: review the below line to see if you can figure out how it works!
                weekDays[day - 1].Text = (dtpStartingDate.Value.AddDays(day - 1)).DayOfWeek.ToString();
            }
        }
        #endregion
        #region method
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double averagecases = 0;
            int validateInfections = 0;

            // this will check each and every element of the array. 
            foreach (TextBox textBoxToCheck in infections)
            {
                // If the textbox is valid, count it. If not, just don't.
                if (ValidateInfections(textBoxToCheck))
                {
                    validateInfections++;
                }
            }

            if (validateInfections == infections.Length)
            {
                //formula to calculate the average .
                averagecases = Math.Round(totalcases / infections.Length, 2);

                // this will print the average in the lable of the output.
                lblDailyAverage.Text = averagecases.ToString();

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // this is the code to exit the application.
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // this will reset the form to the initial stage.
            txtDay1.Clear();
            txtDay2.Clear();
            txtDay3.Clear();
            txtDay4.Clear();
            txtDay5.Clear();
            txtDay6.Clear();
            txtDay7.Clear();
            lblDailyAverage.ResetText();
            totalcases = 0;
        }
        #endregion
        #region functions

        private bool ValidateInfections(TextBox textBoxInput)
        {

            // declaring thre variables.
            double inputcases;
            bool isValid = false;

            //TODO: complete this function such that if any of the infection textboxes are not numeric then validation fails.  It is expected to do this in a modular way (i.e. looping, rather than using the textbox names.)
            if (double.TryParse(textBoxInput.Text, out inputcases))
            {
                
                isValid = true;
                totalcases += inputcases;
            }
            else
            {
                

                lblDailyAverage.Text += "The entered value of '" + textBoxInput.Text + "' is not valid. Please enter a numeric temperature.\r\n";

            }
            return isValid;
        }
        #endregion 
    }
}
