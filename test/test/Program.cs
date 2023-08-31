using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class CustomerData
    {
        public int custId { get; set; }
        public string custName { get; set; }
        public string custPhone { get; set; }

        public int? billId { get; set; }
    }

    interface ICustomerDb
    {
        void AddCustomer(string custName, string custPhone, int billId);
        void UpdateCustomer(int v1, CustomerData data);

        void DeleteCustomer(int custId);

        CustomerData FindCustomer(int custId);
    }

    class CustomerTable : ICustomerDb
    {
        public object CustomerId { get; private set; }
        public string STRCONNECTION { get; internal set; }
        public CustomerData CustomerData { get; private set; }

        public void AddCustomer(string custName, string custPhone, int billId)
        {
            string query = $"Insert into CustomerTable values('{custName}','{custPhone}','{billId}')";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Customer Inserted Successfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteCustomer(int custId)
        {
            string query = $"Delete from CustomerTable where custId = {custId}";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Customer Deleted Successfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public CustomerData FindCustomer(int custId)
        {
            string query = $"SELECT * From CustomerTable where custId = {custId}";

            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CustomerData = new CustomerData
                    {
                        custId = Convert.ToInt32(reader["custId"]),
                        custName = reader["custName"].ToString(),
                        custPhone = reader["custPhone"].ToString(),
                        billId = reader["billId"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["billId"])
                    };
                }
                else
                {
                    Console.WriteLine("Customer Not found");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return CustomerData;
        }


        public void UpdateCustomer(int v1, CustomerData data)
        {
            string query = $"Update CustomerTable Set custName = '{data.custName}', custPhone = '{data.custPhone}', billId = '{data.billId}' where custId = {data.custId}";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Customer Updated Successfully");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        CustomerData ICustomerDb.FindCustomer(int custId)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        const string fileName = @"C:\Users\cajmera\source\repos\test\test\Menu.txt";

        const string STRSELECT = "SELECT * FROM CustomerTable";
        const string STRCONNECTION = "Data Source = W-674PY03-2; Initial Catalog = Chhavi_db; User ID = SA; Password = Password@123456-=";

        static CustomerTable CustomerTable = new CustomerTable() { STRCONNECTION = STRCONNECTION };
        static void Main(string[] args)
        {
            string content = File.ReadAllText(fileName);
            var processing = true;
            do
            {
                string choice = Utilities.GetString(content).ToUpper();
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "N":
                    return addingHelper();
                case "U":
                    return updatingHelper();
                case "F":
                    return findingHelper();
                case "D":
                    return deleteHelper();
                default:
                    return true; ;
            }
        }


        private static bool addingHelper()
        {
            string custName = Utilities.GetString("Enter the Customer Name: ");
            string custPhone = Utilities.GetString("Enter the Phone No: ");
            int billId = Utilities.GetInteger("Enter the Bill Id: ");

            CustomerTable.AddCustomer(custName, custPhone, billId);
            return true;
        }

        private static bool updatingHelper()
        {
            int custId = Utilities.GetInteger("Enter the Customer ID to update: ");

            string custName = Utilities.GetString("Enter the updated Name of Customer: ");
            string custPhone = Utilities.GetString("Enter the updated Phone no Customer: ");

            int billId = Utilities.GetInteger("Enter the updated Bill Id: ");

            CustomerData updatedData = new CustomerData
            {
                custId = custId,
                custName = custName,
                custPhone = custPhone,

                billId = billId
            };
            CustomerTable.UpdateCustomer(custId, updatedData);
            Console.WriteLine("Customer updated successfully");
            return true;
        }


        private static bool deleteHelper()
        {
            int custId = Utilities.GetInteger("Enter the Customer ID to delete: ");
            CustomerTable.DeleteCustomer(custId);
            Console.WriteLine("Customer Deleted Successfully");
            return true;
        }

        private static bool findingHelper()
        {
            int custId = Utilities.GetInteger("Enter the Customer ID to find: ");
            CustomerData CustomerData = CustomerTable.FindCustomer(custId);
            CustomerTable.FindCustomer(custId);

            if (CustomerData != null)
            {
                Console.WriteLine($"Customer Name: {CustomerData.custName}");
                Console.WriteLine($"Phone Number: {CustomerData.custPhone}");
                Console.WriteLine($"Bill Id: {CustomerData.billId}");
            }
            else
            {
                Console.WriteLine("Customer Not Found");
            }
            return true;
        }
    }
}
