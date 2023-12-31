﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdonetDemo
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
        public List<Product> GetAll()

        {

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            SqlCommand command = new SqlCommand("select * from products", _connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())

            {
                Product product = new Product

                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),

                };

                products.Add(product);

            }

            reader.Close();
            _connection.Close();
            return products;

        }

        public DataTable GetAll2()

        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("select * from products", connection);

            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            connection.Close();
            return dataTable;

        }

        public void Add(Product product)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            SqlCommand command = new SqlCommand
                ("insert into Products values(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);

            command.ExecuteNonQuery();
            _connection.Close();


        }


    }




}
