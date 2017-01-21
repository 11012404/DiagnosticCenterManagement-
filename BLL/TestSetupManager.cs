using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;

namespace Diagnostic_Management_System.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway aTestSetupGateway = new TestSetupGateway();
        public string Save(DiagnosticModel aDiagnosticModel)
        {
            int rowAffected = aTestSetupGateway.Save(aDiagnosticModel);

            if (rowAffected > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save failed";
            }
        }

        public List<DiagnosticModel> TestSetUp()
        {
            return aTestSetupGateway.TestSetUp();
        }
    }
}