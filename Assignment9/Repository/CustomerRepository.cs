using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Assignment9.Model;

namespace Assignment9.Repository
{
   public  class CustomerRepository
    {
        public bool Add(Customer customer)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"INSERT INTO Customer (Code,Name, Address, Contact,DistrictId) Values ('" + customer.code + "','" + customer.name + "','" + customer.address + "', '" + customer.contact + "','" + customer.districtid + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {

            }

            return isAdded;

        }

        public bool IsCodeExist(Customer customer)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"SELECT * FROM Customer WHERE Code='" + customer.code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {

            }
            return isExist;
        }
        public bool IsContactExist(Customer customer)
        {
            bool isExist = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"SELECT * FROM Customer WHERE Contact='" + customer.contact + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {

            }
            return isExist;
        }

        public bool Update(Customer customer)
        {
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"UPDATE Customer SET Code='"+customer.code+"',Name= '" + customer.name + "' , Address = '" + customer.address + "', Contact = '" + customer.contact + "',DistrictId='"+customer.districtid+"' WHERE SerialNumber = " + customer.serialnumber + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
            }
            return false;
        }

        public DataTable Display()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            string commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;

        }


        public DataTable DistrictCombo()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            string commandString = @"SELECT Id,Name FROM District ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Insert the Default Item to DataTable.
            DataRow row = dataTable.NewRow();
            row[0] = 0;
            row[1] = "--Select--";
            dataTable.Rows.InsertAt(row, 0);

            //Close
            sqlConnection.Close();

            return dataTable;

        }

        public DataTable Search(string code)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                string commandString = @"SELECT * FROM Customer WHERE Code='" + code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {

            }

            return dataTable;
        }
    }
}
