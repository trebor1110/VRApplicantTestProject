using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VRApplicantTestProject_Services;

namespace VRApplicantTestProject.Tests
{
    [TestClass]
    public class AccountingToolTest
    {
        [TestMethod]
        public void TestGetNPV()
        {
            // arrange
            double investmentAmount = -500;
            double interestRate = 10;
            List<double> cashFlow = new List<double> { 570, 585, 599};
            var cashFlowArray = cashFlow.ToArray();
            cashFlow.Insert(0, investmentAmount);
            AccountingService svc = new AccountingService();

            // act
            var method1Result = svc.CalculateNPV(cashFlow, interestRate);
            var builtInMethod = Financial.NPV(interestRate / 100, ref cashFlowArray) + investmentAmount;

            //assert
            Assert.AreEqual(builtInMethod, method1Result);

        }
    }
}
