using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VRApplicantTestProjectOWIN.WebAPI.Model;
using VRApplicantTestProject_Services;
using VRApplicantTestProject_Services.Interfaces;

namespace VRApplicationTestProjectMVC.WebAPI.Controllers
{
    public class AccountingController : ApiController
    {
        private readonly IAccountingService _accountingService;

        public AccountingController(IAccountingService service)
        {
            _accountingService = service;
        }

        [HttpPost]
        [Route("api/CalculateNPV")]
        public double Calculate([FromBody]NpvInputViewModel model)
        {
            double investment = model.InvestmentAmount * -1;
            model.CashFlow.Insert(0, investment);

            return _accountingService.CalculateNPV(model.CashFlow, model.InterestRate);
        }
    }
}
