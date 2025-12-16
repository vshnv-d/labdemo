
using Microsoft.Data.SqlClient;
namespace DemoProject.Models
{
    public class InventoryViewModel
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Inventory;Integrated Security=True;";
        
        public List<Inventory> GetInventory()
        {
            List<Inventory> inventory = new List<Inventory>();

           SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
           SqlCommand command = new SqlCommand("select * from Inventory", connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Inventory inventory1 = new Inventory();
                inventory1.No = Convert.ToInt32(reader["No"]);
                inventory1.Name = reader["Name"].ToString();
                inventory1.Description = reader["Description"].ToString();
                inventory1.Quantity = Convert.ToInt32(reader["Quantity"]);
                inventory1.Price = Convert.ToInt32(reader["Price"]);
                inventory.Add(inventory1);
            }
            return inventory;
        }

        public Inventory GetInventory(int No)
        {
            List<Inventory> inventory = GetInventory();
            Inventory filteredInventory = (from inventory1 in inventory
                                           where inventory1.No==No select inventory1)
                                           .First();
            return filteredInventory;
        }

        public int AddInventory(Inventory inventory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryFormat = "insert into Inventory (Name,Description,Quantity,Price) values ('{0}','{1}',{2},{3})";
            string query = string.Format(queryFormat,
                inventory.Name,
                inventory.Description,
                inventory.Quantity,
                inventory.Price);
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;                  
        }

        public int UpdateInventory(Inventory inventory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryFormat = "update Inventory set Name='{0}', Description='{1}',Quantity={2},Price={3} where No = {4}";
            string query = string.Format(queryFormat,
                inventory.Name,
                inventory.Description,
                inventory.Quantity,
                inventory.Price,
                inventory.No);
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public int RemoveInventory(int No)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryFormat = "delete from Inventory where No = {0}";

            string query = string.Format(queryFormat, No);
               
            SqlCommand command = new SqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}
