using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
