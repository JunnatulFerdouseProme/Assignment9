using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Assignment9.BLL;
using Assignment9.Model;
using System.Windows.Forms;

namespace Assignment9
{
    public partial class CustomerUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        int indexRow;
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            //Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(itemComboBox.Text))
            {
                MessageBox.Show("Please select a District!!");
                return;
            }
            customer.code = codeTextBox.Text;
            customer.name = nameTextBox.Text;
            customer.address = addressTextBox.Text;
            customer.contact = contactTextBox.Text;
            customer.districtid = Convert.ToInt32(itemComboBox.SelectedValue);


            //Unique
            if (_customerManager.IsCodeExist(customer))
            {
                MessageBox.Show(nameTextBox.Text + " Code Already Exist!!");
                return;
            }
            if (_customerManager.IsContactExist(customer))
            {
                MessageBox.Show(nameTextBox.Text + "Contact Already Exist!!");
                return;
            }

            //Validity
            if(codeTextBox.Text.Length !=4)
            {
                MessageBox.Show("Code must be within 4 characters");
            }
            if (contactTextBox.Text.Length != 11)
            {
                MessageBox.Show("Code must be within 11 characters");
            }


            //Add/Insert
            if (_customerManager.Add(customer))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _customerManager.Display();
            //update
          
            //else
            //{
            //    saveButton.Text = "Save";
            //}


        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Search(codeTextBox.Text);
        }

        private void CustomerUi_Load(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _customerManager.DistrictCombo();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = showDataGridView.Rows[indexRow];
            codeTextBox.Text = row.Cells[1].Value.ToString();
            nameTextBox.Text = row.Cells[2].Value.ToString();
            addressTextBox.Text = row.Cells[3].Value.ToString();
            contactTextBox.Text = row.Cells[4].Value.ToString();
            itemComboBox.Text = row.Cells[5].Value.ToString();
            saveButton.Text = "Update";
            if (saveButton.Text == "Update")
            {
                updateButton_Click();

            }


        }
        private void updateButton_Click( )
        {
            Customer customer = new Customer();
           // Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(itemComboBox.Text))
            {
                MessageBox.Show("Please select a District!!");
                return;
            }
            customer.code = codeTextBox.Text;
            customer.name = nameTextBox.Text;
            customer.address = addressTextBox.Text;
            customer.contact = contactTextBox.Text;
            customer.districtid = Convert.ToInt32(itemComboBox.SelectedValue);


           // Unique

            if (_customerManager.IsContactExist(customer))
            {
                MessageBox.Show(contactTextBox.Text + "Contact Already Exist!!");
                return;
            }

           // Validity
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be within 4 characters");
            }
            if (contactTextBox.Text.Length != 11)
            {
                MessageBox.Show("Code must be within 11 characters");
            }




            if (_customerManager.Update(customer))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
