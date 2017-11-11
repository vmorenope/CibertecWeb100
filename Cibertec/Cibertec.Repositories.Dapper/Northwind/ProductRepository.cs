﻿using System.Collections.Generic;
using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System.Data.SqlClient;
using Dapper;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }

        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(Id) FROM dbo.Product");
            }
        }

        public IEnumerable<Product> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<Product>();
            using (var connection = new
           SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);
                return
               connection.Query<Product>("dbo.ProductPagedList",
                parameters,
               commandType:
               System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
