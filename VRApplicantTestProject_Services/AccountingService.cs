using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using VRApplicantTestProject_Services.Interfaces;

namespace VRApplicantTestProject_Services
{
    // NOTE : Though I think that making this a static class and making the CalculateNPV a static and.or extension method is a better option
    // because it is more like a utility class. I opted to make it a service to be able to ues Dependency Injection since the requirement is limited to this one service.
    public class AccountingService : IAccountingService
    {   
        public double CalculateNPV(List<double> cashFlow, double interestRate)
        {
            double intRate = interestRate / 100;
            return cashFlow.Select((x, y) => x / Math.Pow(1 + intRate, y)).Sum();
        }
    }

    // If this is a real requirement and not a test project I am convinced that this is better to become an extension method.
   
    //public static class AccountingTool
    //{
    //    public static double CalculateNPV(this List<double> cashFlow, double interestRate)
    //    {
    //        double intRate = interestRate / 100;
    //        return cashFlow.Select((x, y) => x / Math.Pow(1 + intRate, y)).Sum();
    //    }
    //}
}
