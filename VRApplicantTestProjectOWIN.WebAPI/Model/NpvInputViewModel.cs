using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRApplicantTestProjectOWIN.WebAPI.Model
{
    public class NpvInputViewModel
    {
        public double InterestRate { get; set; }
        public double InvestmentAmount { get; set; }
        public List<double> CashFlow { get; set; }
    }
}
