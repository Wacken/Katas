using System;
using Calculatro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDevelopmentFirst
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AnnualSalyryTest()
        {
            SalaryCalculator sc = new SalaryCalculator();

            decimal annualSalary = sc.GetAnnualSalary(50);

            Assert.AreEqual(104000, annualSalary);
        }
    }
}
