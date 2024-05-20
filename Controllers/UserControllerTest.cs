using Xunit;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;

namespace CRUD_application_2.Tests
{
    public class UserControllerTest
    {
        [Fact]
        public void TestIndex()
        {
            var controller = new UserController();
            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDetails()
        {
            var controller = new UserController();
            controller.Create(new User { Id = 1, Name = "Test", Email = "test@test.com" });
            var result = controller.Details(1) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreate()
        {
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
            var result = controller.Create(user) as RedirectToRouteResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void TestEdit()
        {
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
            controller.Create(user);
            var editUser = new User { Id = 1, Name = "Test Edit", Email = "testedit@test.com" };
            var result = controller.Edit(1, editUser) as RedirectToRouteResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void TestDelete()
        {
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
            controller.Create(user);
            var result = controller.Delete(1) as RedirectToRouteResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }
    }
}
