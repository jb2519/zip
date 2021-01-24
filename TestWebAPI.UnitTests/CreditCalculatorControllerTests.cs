using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TestWebAPI.Controllers;
using TestWebAPI.Interfaces;
using TestWebAPI.Models;
using TestWebAPI.Services;

namespace TestWebAPI.UnitTests
{
    public class CreditCalculatorControllerTests
    {
        private CreditCalculatorController _creditCalculatorController;
        private Mock<ICreditCalculator> _creditCalculatorServiceMock = new Mock<ICreditCalculator>();
        private Mock<ILogger<CreditCalculatorController>> _LoggingMock = new Mock<ILogger<CreditCalculatorController>>();

        [SetUp]
        public void Setup()
        {
            _creditCalculatorController = new CreditCalculatorController(_creditCalculatorServiceMock.Object, _LoggingMock.Object);
        }

        [Test]
        public async Task ControllerTest_Ok()
        {
            _creditCalculatorServiceMock.Setup(x => x.CalculateCredit(It.IsAny<Customer>())).Returns(100);
            var response = await _creditCalculatorController.GetCreditScore(It.IsAny<Customer>()).ConfigureAwait(false);
            _creditCalculatorServiceMock.Verify(x => x.CalculateCredit(It.IsAny<Customer>()), Times.Once);
        }
    }
}