using Cibertec.Models;
using Cibertec.Repositories.EntityFramework.Northwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.EntityFrameworkTests
{
    public class CustomerRepositoryTest
    {
        private readonly DbContext _context;
        private readonly CustomerRepository repo;

        public CustomerRepositoryTest()
        {
            _context = new NorthwindDbContext();
            repo = new CustomerRepository(_context);
        }

        [Fact(DisplayName ="[CustomerRepository]Get All")]
        public void Customer_Reposiroty_GetAll()
        {
            var result = repo.GetList();
            Assert.True(result.Count() > 0);
        }

        [Fact(DisplayName = "[CustomerRepository]Get By Id")]
        public void Customer_Reposiroty_Get_By_Id()
        {
            var customer = repo.GetById(10);
            Assert.True(customer != null);
        }

        [Fact(DisplayName = "[CustomerRepository]Insert")]
        public void Customer_Repository_Insert()
        {
            var customer = GetNewCustomer();
            var result = repo.Insert(customer);
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "[CustomerRepository]Delete")]
        public void Customer_Repository_Delete()
        {
            var customer = GetNewCustomer();
            var result = repo.Insert(customer);
            Assert.True(repo.Delete(customer));
        }

        [Fact(DisplayName = "[CustomerRepository]Update")]
        public void Customer_Repository_Update()
        {
            var customer = repo.GetById(10);
            Assert.True(customer != null);
            customer.FirstName = $"Today {DateTime.Now.ToShortDateString()}";
            Assert.True(repo.Update(customer));
        }

        private Customer GetNewCustomer()
        {
            return new Customer
            {
                City = "Lima",
                Country = "Peru",
                FirstName = "Julio",
                LastName = "Velarde",
                Phone = "555-555-555"
            };
        }


    }
}