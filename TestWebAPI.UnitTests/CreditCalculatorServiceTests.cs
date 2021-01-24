using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Models;
using TestWebAPI.Services;

namespace TestWebAPI.UnitTests
{

    class CreditCalculatorServiceTests
    {
        private CreditCalculatorService _creditCalculatorService;

        [SetUp]
        public void Setup()
        {
            _creditCalculatorService = new CreditCalculatorService();
        }

        [Test]
        [TestCase(0, 0, 0, 15, ExpectedResult = 0)]
        [TestCase(450, 0, 0, 35, ExpectedResult = 0)]
        [TestCase(450, 0, 3, 35, ExpectedResult = 0)]
        [TestCase(700, 1, 1, 25, ExpectedResult = 200)]
        [TestCase(1000, 2, 0, 15, ExpectedResult = 0)]
        [TestCase(1000, 2, 0, 45, ExpectedResult = 0)]
        [TestCase(1000, 1, 2, 45, ExpectedResult = 500)]
        public decimal CreditServiceTest_Ok(int bureauScore, int missedPaymentCount, int completedPaymentCount, int ageInYears)
        {
            Customer customer = new Customer(bureauScore, missedPaymentCount, completedPaymentCount, ageInYears);
            return _creditCalculatorService.CalculateCredit(customer);
        }
    }
}
