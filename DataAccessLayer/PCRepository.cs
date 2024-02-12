using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PCRepository
    {
        public List<PC> GetAllPC()
        {
            List<PC> results = new List<PC>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM pc";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    PC p = new PC();
                    p.Id = sqlDataReader.GetInt32(0);
                    p.GPU = sqlDataReader.GetString(1);
                    p.CPU = sqlDataReader.GetString(2);
                    p.RAM = sqlDataReader.GetString(3);
                    p.Motherboard = sqlDataReader.GetString(4);
                    p.Storage = sqlDataReader.GetString(5);
                    p.Case = sqlDataReader.GetString(6);
                    p.PSU = sqlDataReader.GetString(7);
                    p.Description = sqlDataReader.GetString(8);

                    results.Add(p);
                }
            }

            return results;
        }

        public int InsertPC(PC p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO PC VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                    p.GPU, p.CPU, p.RAM, p.Motherboard, p.Storage, p.Case, p.PSU, p.Description);

                return sqlCommand.ExecuteNonQuery();
            }
        }


        public int UpdatePC(PC p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE PC SET GPU='{0}', CPU='{1}', RAM='{2}', Motherboard='{3}', Storage='{4}', [Case]='{5}', PSU='{6}', Description='{7}' WHERE Id='{8}'",
                    p.GPU, p.CPU, p.RAM, p.Motherboard, p.Storage, p.Case, p.PSU, p.Description, p.Id);

                return sqlCommand.ExecuteNonQuery();
            }
        }


        public int DeletePC(PC p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "DELETE FROM PC WHERE Id = " + p.Id;
               
                return command.ExecuteNonQuery();
            }
        }

    }
}
