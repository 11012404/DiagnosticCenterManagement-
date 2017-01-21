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
            int i = 0;
            aDiagnosticModel.Name = txt_test_typy.Text;
            List<DiagnosticModel> testlist = aDiagnosticManager.TestTypes();

            foreach (var item in testlist)
            {
                if (item.Name.Equals(txt_test_typy.Text))
                {
                    i = 1;
                }
            }
            if (i == 0)
            {
                string p = aDiagnosticManager.Save(aDiagnosticModel);
                lbl_msg.Visible = false;
                testlist = aDiagnosticManager.TestTypes();
                bookListGridView.DataSource = testlist;
                bookListGridView.DataBind();
            }
            if (i == 1)
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Test Type Already Exit";
            }
            txt_test_typy.Text = null;
            
        }
        private void GetTestType()
        {
            List<DiagnosticModel> testlist = aDiagnosticManager.TestTypes();

            bookListGridView.DataSource = testlist;
            bookListGridView.DataBind();

        }
    }
}