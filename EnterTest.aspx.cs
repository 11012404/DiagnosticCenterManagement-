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
    public partial class EnterTest : System.Web.UI.Page
    {
        DiagnosticManager aDiagnosticManager = new DiagnosticManager();
        DiagnosticModel aDiagnosticModel = new DiagnosticModel();
        TestSetupManager aTestSetupManager = new TestSetupManager();

        protected void Page_Load(object sender, EventArgs e)
        {
           GetTestType();
           GetTestSetUp();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            aDiagnosticModel.Name = txt_name.Text;
            aDiagnosticModel.Fee = Convert.ToInt32(txt_fee.Text);
            aDiagnosticModel.Type = DropList.Text;

            string p = aTestSetupManager.Save(aDiagnosticModel);
            
            txt_name.Text = null;
            txt_fee.Text = null;

            List<DiagnosticModel> testlist = aTestSetupManager.TestSetUp();

            bookListGridView.DataSource = testlist;
            bookListGridView.DataBind();
        }

        private void GetTestType()
        {
            List<DiagnosticModel> testlist = aDiagnosticManager.TestTypes();

            if (testlist.Count > 0)
            {
                DropList.DataSource = testlist;
                    foreach (var item in testlist)
                    {
                        DropList.Items.Add(item.Name);
                    }
            }
        }
        private void GetTestSetUp()
        {
            List<DiagnosticModel> testlist = aTestSetupManager.TestSetUp();

            bookListGridView.DataSource = testlist;
            bookListGridView.DataBind();

        }
    }
}