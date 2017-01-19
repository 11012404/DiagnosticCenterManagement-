using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diagnostic_Management_System.BLL;
using Diagnostic_Management_System.DAL.Model;

namespace Diagnostic_Management_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        TestSetupManager aTestSetupManager = new TestSetupManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetTestName();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            List<Testlist> testlist = new  List<Testlist>();
        }

        private void GetTestName()
        {
            List<DiagnosticModel> testlist = aTestSetupManager.TestSetUp();

            if (testlist.Count > 0)
            {
                DropDownList.DataSource = testlist;
                foreach (var item in testlist)
                {
                    DropDownList.Items.Add(item.Name);
                }
            }
        }
    }
}