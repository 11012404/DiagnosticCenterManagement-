using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;

namespace Diagnostic_Management_System.BLL
{
    public class DiagnosticManager 
    {
       TestTypeGateway aTestTypeGateway = new TestTypeGateway();
       
        public string Save(DiagnosticModel aDiagnosticModel)
        {
            int rowAffected = aTestTypeGateway.Save(aDiagnosticModel);

            if (rowAffected > 0)
            {
                return "Save Successfull";
            }
            else
            {
                return "Save failed";
            }
        }
        public List<DiagnosticModel> TestTypes()
        {
            return aTestTypeGateway.TestTypes();
        }
    }
}