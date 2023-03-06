using AmbitionedTask.Models;
using AmbitionedTask.Services;
using AmbitionedTask.ViewModels;

using NUnit.Framework;

namespace AmbitionedTaskTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfPriorityForAdditionMultiplicationDivisionAndBracketWorks()
        {
            var service = new CalculatorService();
            var model = new ExpressionViewModel
            {
                Expression = "(1 + 2) * 4 / 6"
            };

            service.Calculate(model);
            var result = service.GetResult();

            var expectedResult = Number.Create("2");

            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void TestIfPriorityForMultiplicationAdditionDivisionAndBracketsWorks()
        {
            var service = new CalculatorService();
            var model = new ExpressionViewModel
            {
                Expression = "3 * (3 + 5) / 2"
            };

            service.Calculate(model);
            var result = service.GetResult();

            var expectedResult = Number.Create("12");

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestIfPriorityForAdditionMultiplicationAndBracketsWorks()
        {
            var service = new CalculatorService();
            var model = new ExpressionViewModel
            {
                Expression = "2 + 3 +(4 + 5) * 6"
            };

            service.Calculate(model);
            var result = service.GetResult();

            var expectedResult = Number.Create("59");

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestIfDecimalsCalculationWorks()
        {
            var service = new CalculatorService();
            var model = new ExpressionViewModel
            {
                Expression = "2.02 + 2"
            };

            service.Calculate(model);
            var result = service.GetResult();

            var expectedResult = Number.Create("4.02");

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestIfCustomValidationAttributeForWrongInputWorks()
        {
            var attribute = new CustomValidationAttribute();

            var result = attribute.IsValid("2+a");

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestIfWrongInputThrowsArgumentNullExceptionAtService()
        {
            var model = new ExpressionViewModel
            {
                Expression = "2+a"
            };

            var service = new CalculatorService();

            Assert.That(() =>
            {
                service.Calculate(model);

            }, Throws.ArgumentNullException);
        }
    }
}