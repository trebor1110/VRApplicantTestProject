using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VRApplicantTestProject_Services;

namespace VRApplicantTestProject.Controllers
{
    public class AccountingController : ApiController
    {
        public double Get()
        {
            List<double> test = new List<double> {500, 570};

            return test.CalculateNPV(10);
        }
    }
}
