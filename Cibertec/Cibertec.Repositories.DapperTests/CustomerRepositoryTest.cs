using System;
using Xunit;
using Cibertec.Repositories.Dapper.Northwind;
using System.Linq;
using Cibertec.Models;

namespace Cibertec.Repositories.DapperTests
{
    public class CustomerRepositoryTest
    {
        private CustomerRepository repo;

        public CustomerRepositoryTest()
        {
            repo = new CustomerRepository("Server=.;Database=Northwind_Lite; Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        [Fact(DisplayName = "[CustomerRepository]Get All")]
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

        [Fact(DisplayName = "[CustomerRepository]Search By Name")]
        public void Customer_Reposiroty_Search_By_Name()
        {
            var customer = repo.SearchByNames("Maria","Anders");
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
