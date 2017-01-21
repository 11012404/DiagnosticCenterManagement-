using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Management_System.BLL
{
    public class TestReportManager
    {
        TestReportGateway aTestReportGateway = new TestReportGateway();
        public List<TestReportModel> ViewTestReport(TestReportModel aTestReportModel)
        {
            return aTestReportGateway.GetTestReport(aTestReportModel);
        }
    }
}