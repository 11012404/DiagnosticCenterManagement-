using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;

namespace Diagnostic_Management_System.BLL
{
    public class TestEntryManager
    {
        TestEntryGateway aTestEntryGateway = new TestEntryGateway();

        public int Fee(DiagnosticModel aDiagnosticModel)
        {
            int fee = aTestEntryGateway.TestFee(aDiagnosticModel);
            return fee;
        }
        public int TestEntry(TestEntryModel aTestEntryModel)
        {
            int i = aTestEntryGateway.TestEntry(aTestEntryModel);
            return i;
        }

        public List<TestEntryModel> ViewTestEntry(TestEntryModel aTestEntryModel)
        {
            return aTestEntryGateway.GetTestEntry(aTestEntryModel);
        }
    }
}