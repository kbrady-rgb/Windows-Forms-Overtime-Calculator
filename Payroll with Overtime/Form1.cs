using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/***************************************************************
* Name        : Payroll with Overtime Tutorial
* Author      : Kabrina Brady
* Created     : 9/15/2019
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work
* Description : Calculates an employee's pay and adds overtime pay if employee worked overtime
*               Input:  Hours worked, hourly pay rate
*               Output: Gross pay
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or unmodified. I have not given other fellow student(s) access to my program.         
***************************************************************/

namespace Payroll_with_Overtime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //named constants
                const decimal BASE_HOURS = 40m;
                const decimal OT_MULTIPLIER = 1.5m;

                //local variables
                decimal hoursWorked;
                decimal hourlyPayRate;
                decimal basePay;
                decimal overtimeHours;
                decimal overtimePay;
                decimal grossPay;

                //get hours worked and hourly pay rate
                hoursWorked = decimal.Parse(hoursWorkedTextBox.Text);
                hourlyPayRate = decimal.Parse(hourlyPayRateTextBox.Text);

                //determine gross pay
                if (hoursWorked > BASE_HOURS)
                {
                    //calculate base pay without overtime
                    basePay = hourlyPayRate * BASE_HOURS;

                    //calculate number overtime hours
                    overtimeHours = hoursWorked - BASE_HOURS;

                    //calculate overtime pay
                    overtimePay = overtimeHours * hourlyPayRate * OT_MULTIPLIER;

                    //calculate gross pay
                    grossPay = basePay + overtimePay;
                }
                else
                {
                    //calculate gross pay
                    grossPay = hoursWorked * hourlyPayRate;
                }

                //display gross pay
                grossPayLabel.Text = grossPay.ToString("c");
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //clear TextBoxes and gross pay label
            hoursWorkedTextBox.Text = "";
            hourlyPayRateTextBox.Text = "";
            grossPayLabel.Text = "";

            //reset focus
            hoursWorkedTextBox.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //terminates program
            this.Close();
        }
    }
}
