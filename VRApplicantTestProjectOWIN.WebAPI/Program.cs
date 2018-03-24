using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace OwinSelfhostSample
{
    public class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine(@"Self Hosted WEBAPI : To test use http://localhost:9000/api/Accounting using POST method");
                Console.WriteLine(@"Expected PARAMS : CashFlow(array of numeric),  InterestRate(numeric) and InvestmentAmount(numeric) ");
                Console.ReadLine();
            }
        }
    }
}