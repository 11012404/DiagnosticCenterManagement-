using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diagnostic_Management_System.BLL;
using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;

namespace Diagnostic_Management_System
{
    public partial class DiagnosticTestType : System.Web.UI.Page
    {
        DiagnosticModel aDiagnosticModel = new DiagnosticModel();
        DiagnosticManager aDiagnosticManager = new DiagnosticManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTestType();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            aDiagnosticModel.Name = txt_test_typy.Text;

            txt_test_typy.Text = null;
            string p = aDiagnosticManager.Save(aDiagnosticModel);
            //lbl_message.Text = p;

            List<DiagnosticModel> testlist = aDiagnosticManager.TestTypes();

            bookListGridView.DataSource = testlist;
            bookListGridView.DataBind();
        }
        private void GetTestType()
        {
            List<DiagnosticModel> testlist = aDiagnosticManager.TestTypes();

            bookListGridView.DataSource = testlist;
            bookListGridView.DataBind();

        }
    }
}