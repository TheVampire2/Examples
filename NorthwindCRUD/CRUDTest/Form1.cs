using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUDTest
{
    public partial class Form1 : Form
    {
        NorthwindCRUDService.BasicCRUDserviceClient serviceClient;
        public Form1()
        {
            InitializeComponent();
            serviceClient = new NorthwindCRUDService.BasicCRUDserviceClient();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
          
          //  DataSet ds = DatabaseAccess.listCustomers();
           
           
             
            DataSet ds = serviceClient.ListCustomers();
            DataTable dt = new DataTable();
            dt = ds.Tables["Customers"];
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtName.Text = (listBox1.SelectedItem as DataRowView)["name"].ToString();
            txtCountry.Text = (listBox1.SelectedItem as DataRowView)["country"].ToString();
            txtCompany.Text = (listBox1.SelectedItem as DataRowView)["phone"].ToString();
            txtCity.Text = (listBox1.SelectedItem as DataRowView)["city"].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = (listBox1.SelectedItem as DataRowView)["id"].ToString();
            serviceClient.DeleteCustomer(id);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                txtCity.ReadOnly = false;
                txtCountry.ReadOnly = false;
                txtName.ReadOnly = false;
                txtCompany.ReadOnly = false;
                btnEdit.Text = "Save";
            }
            else
            {
                string id = (listBox1.SelectedItem as DataRowView)["id"].ToString();
                serviceClient.SaveCustomer(txtCompany.Text, txtName.Text, txtCity.Text, txtCountry.Text, id);
                txtCity.ReadOnly = true;
                txtCountry.ReadOnly = true;
                txtName.ReadOnly = true;
                txtCompany.ReadOnly = true;
                btnEdit.Text = "Edit";
            }
            
            
                

        }
    }
}
