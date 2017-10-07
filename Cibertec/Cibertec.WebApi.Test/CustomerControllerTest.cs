using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using CIbertec.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cibertec.WebApi.Test
{
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerController;
        public CustomerControllerTest()
        {
            _customerController = new CustomerController(
                new NorthwindUnitOfWork(ConfigSettings.NorthwindConnectionString)
                );
        }

        [Fact]
        public void Test_Get_All()
        {
            var result = _customerController.GetList() as OkObjectResult;
            //assert.true(result != null);
            //assert.true(result.value != null);

            //var model = result.value as list<customer>;
            //assert.true(model.count > 0);

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Customer>;
            model.Count.Should().BeGreaterThan(0);
        }
    }
}
