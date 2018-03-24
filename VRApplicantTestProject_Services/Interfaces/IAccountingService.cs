using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRApplicantTestProject_Services.Interfaces
{
    public interface IAccountingService
    {
        double CalculateNPV(List<double> cashFlow, double interestRate);
    }
}
