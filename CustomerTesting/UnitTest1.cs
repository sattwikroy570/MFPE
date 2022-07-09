
using CustomerMicroservice.Controllers;
using CustomerMicroservice.Models;
using CustomerMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CustomerTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void getcustomers_ValidInputPassed_OkRequest()
        {
            
            var mock = new Mock<CustomerRepository>();
            CustomerController obj = new CustomerController(mock.Object);
            var data = obj.getCustomerDetails("JhonSmith");
            var res = data as ObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }

        [Test]
        public void GetCustomer_InvalidInputPassed_ReturnsNotFound()
        {

            var mock = new Mock<CustomerRepository>();
            CustomerController obj = new CustomerController(mock.Object);
            var data = obj.getCustomerDetails("Arnold");
            var res = data as NotFoundResult;
            Assert.AreEqual(404, res.StatusCode);
        }

        [Test]
        public void Getcustomers_ReturnsNotnullList()
        {

            var mock = new Mock<CustomerRepository>();
            CustomerController obj = new CustomerController(mock.Object);
            var data = obj.getCustomerDetails("JhonSmith");
            var res = data as ObjectResult;
            Assert.IsNotNull(data);
        }

        
        [Test]
        public void Createcustomers_InvalidInputPassed_ReturnsBadRequest()
        {
            var mock = new Mock<CustomerRepository>();           
            CustomerController obj = new CustomerController(mock.Object);
            CustomerDetails cz = new CustomerDetails();
            var data = obj.createCustomer(cz);
            var res = data as BadRequestResult;
            Assert.AreEqual(400, res.StatusCode);


        }
    }
}