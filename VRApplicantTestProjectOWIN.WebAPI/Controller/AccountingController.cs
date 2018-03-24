using System.Collections.Generic;
using System.Web.Http;
using VRApplicantTestProjectOWIN.WebAPI.Model;
using VRApplicantTestProject_Services;
using VRApplicantTestProject_Services.Interfaces;

namespace OwinSelfhostSample
{
    public class AccountingController : ApiController
    {
        private readonly IAccountingService _accountingService;

        public AccountingController(IAccountingService _service)
        {
            _accountingService = _service;
        }

        [HttpPost]
        public double Calculate([FromBody]NpvInputViewModel model)
        {
            double investment = model.InvestmentAmount * -1;
            model.CashFlow.Insert(0, investment);

            return _accountingService.CalculateNPV(model.CashFlow, model.InterestRate);
        }
    }
}