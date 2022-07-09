using AuthenticateMicroservice.Controllers;
using AuthenticateMicroservice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using AuthenticateMicroservice.Models;
using AuthenticateMicroservice.Repository;
using AuthenticateMicroservice.DB;

namespace AuthenticateMicroserviceUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        AuthDbContext context;

        [Test]
        public void IsTokenNotNullIsTokenNotNull_When_ValidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            var TokenObj = new AuthRepository(config.Object,context);
            var Result = TokenObj.AuthenticateUser(new UserCredentails { UserName = "Manager", Password = "1234", Roles = "Employee" });
            Assert.IsNotNull(Result);
        }

        [Test]
        public void IsTokenNull_When_InvalidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            var TokenObj = new AuthRepository(config.Object, context);
            var Result = TokenObj.AuthenticateUser(new UserCredentails() { UserName = "JhonSmith", Password = "0000",Roles="Employee" });
            Assert.IsNull(Result);
        }
    }
}