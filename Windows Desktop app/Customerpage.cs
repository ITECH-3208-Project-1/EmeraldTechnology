using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp.Config;
using Windows_Desktop_app.Models;

namespace Windows_Desktop_app
{
    public partial class Customerpage : Form
    {

        Customer customer = new Customer();
        
        public Customerpage()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customerpage_Load(object sender, EventArgs e)
        {

        }

        private void labelCustomerID_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            //Get the data from the text field.
            customer.user_address = address.Text;
            customer.user_email = email.Text;
            customer.user_firstname = first_name.Text;
            customer.user_lastname = last_name.Text;
            customer.user_contact = contact_number.Text;
            Console.WriteLine(address.Text);
            bool isDataInserted = customer.CreateCustomer(customer);
            if(isDataInserted == true)
            {
                MessageBox.Show("Customer added");
            }
            else
            {
                MessageBox.Show("Sorry! Customer couldn't be added");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            myForm.Show();
            this.Hide();
        }
    }
}