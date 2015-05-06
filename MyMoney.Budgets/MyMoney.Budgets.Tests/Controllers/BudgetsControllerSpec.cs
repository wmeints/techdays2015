using Moq;
using MyMoney.Budgets.Controllers;
using MyMoney.Budgets.Domain;
using MyMoney.Budgets.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Xunit;

namespace MyMoney.Budgets.Tests.Controllers
{
    public class BudgetsControllerSpec
    {
        Mock<IBudgetRepository> budgetRepositoryMock;
        BudgetsController controller;

        public BudgetsControllerSpec()
        {
            budgetRepositoryMock = new Mock<IBudgetRepository>();
            controller = new BudgetsController();

            controller.ControllerContext = new Mock<HttpControllerContext>().Object;
            controller.Configuration = new HttpConfiguration();

            budgetRepositoryMock.Setup(mock => mock.FindById(1)).Returns(new Budget()
            {
                Id = 1,
                Description = "Sample budget",
                MaxAmountAvailable = 100.0
            });

            budgetRepositoryMock
                .Setup(mock => mock.Update(It.IsAny<Budget>()))
                .Returns(new Budget());

            budgetRepositoryMock.Setup(mock => mock.Remove(It.IsAny<Budget>()));
        }

        [Fact(DisplayName = "The budgets controller returns an existing budget")]
        public void GetReturnsDataWhenAskedForAnExistingBudget()
        {
            controller.Request = new HttpRequestMessage(HttpMethod.Get, "/api/budgets/1");
            controller.Get(1);

            budgetRepositoryMock.Verify(mock => mock.FindById(1));
        }

        [InlineData(1, HttpStatusCode.OK)]
        [InlineData(2, HttpStatusCode.NotFound)]
        [Theory(DisplayName = "The budgets controller returns the correct status code for the GET request")]
        public void GetReturnsTheCorrectStatusCode(int id, HttpStatusCode statusCode)
        {
            controller.Request = new HttpRequestMessage(
                HttpMethod.Get, new Uri("/api/budgets/create", UriKind.RelativeOrAbsolute));

            var actualResult = controller.Get(id);
            Assert.Equal(statusCode, actualResult.StatusCode);
        }

        [Fact(DisplayName = "The budgets controller updates an existing budget succesfully.")]
        public void PutUpdatesAnExistingBudget()
        {
            controller.Request = new HttpRequestMessage(HttpMethod.Put, "/api/budgets/1");

            controller.Put(1, new UpdateBudgetRequest()
            {
                Description = "Sample budget - with updated text",
                MaxAmountAvailable = 120.0
            });

            budgetRepositoryMock.Verify(mock => mock.FindById(1));
            budgetRepositoryMock.Verify(mock => mock.Update(It.IsAny<Budget>()));
        }

        [InlineData(1, HttpStatusCode.OK)]
        [InlineData(2, HttpStatusCode.NotFound)]
        [Theory(DisplayName = "The budgets controller returns the correct status code for the PUT method")]
        public void PutReturnsTheCorrectStatusCode(int id, HttpStatusCode expectedResult)
        {
            controller.Request = new HttpRequestMessage(HttpMethod.Put, "/api/budgets/1");

            var actualResult = controller.Put(id, new UpdateBudgetRequest()
            {
                Description = "Sample budget - with updated text",
                MaxAmountAvailable = 120.0
            });

            Assert.Equal(actualResult.StatusCode, expectedResult);
        }

        [Fact(DisplayName = "The budgets controller removes an existing budget")]
        public void DeleteRemovesAnExistingBudget()
        {
            controller.Request = new HttpRequestMessage(HttpMethod.Delete, "/api/budgets/1");

            var actualResult = controller.Delete(1);

            budgetRepositoryMock.Verify(mock => mock.FindById(1));
            budgetRepositoryMock.Verify(mock => mock.Remove(It.IsAny<Budget>()));
        }

        [Theory(DisplayName = "The budgets controller returns the correct status code for DELETE")]
        [InlineData(1, HttpStatusCode.NoContent)]
        [InlineData(2, HttpStatusCode.NotFound)]
        public void DeleteReturnsTheCorrectStatusCode(int id, HttpStatusCode expectedResult)
        {
            controller.Request = new HttpRequestMessage(HttpMethod.Delete, "/api/budgets/1");

            var actualResult = controller.Delete(id);

            Assert.Equal(expectedResult, actualResult.StatusCode);
        }
    }
}
