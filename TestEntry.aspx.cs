using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diagnostic_Management_System.BLL;
using Diagnostic_Management_System.DAL.Model;
using Diagnostic_Management_System.DAL.Gateway;
using System.Data;

namespace Diagnostic_Management_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int i;
        TestSetupManager aTestSetupManager = new TestSetupManager();
        DiagnosticModel aDiagnosticModel = new DiagnosticModel();
        TestEntryManager aTestEntryManager = new TestEntryManager();
        TestEntryModel aTestEntryModel = new TestEntryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDefaultFirstRecord();
            }
            GetTestName();
            aDiagnosticModel.Name = DropDownList.SelectedValue;

            int fee = aTestEntryManager.Fee(aDiagnosticModel);

            txt_fee.Text = Convert.ToString(fee);
        }
        private void AddDefaultFirstRecord()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "AuthorBooks";
            dt.Columns.Add(new DataColumn("Test Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Fee", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            ViewState["AuthorBooks"] = dt;
            bookListGridView.DataSource = dt;
            bookListGridView.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            i = 1;
            AddNewRecordRowToGrid();
            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("Test Name", typeof(string)));
            //dt.Columns.Add(new DataColumn("Fee", typeof(int)));

            //DataRow dr = dt.NewRow();
            //dr["Test Name"] = DropDownList.Text;
            //dr["Fee"] = Convert.ToInt32(txt_fee.Text);
            //dt.Rows.Add(dr);


            //bookListGridView.DataSource = dt;
            //bookListGridView.DataBind();
            btn_save.Visible = true;

        }
        private decimal Total = (decimal)0.0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (i == 1)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                    Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
                else if (e.Row.RowType == DataControlRowType.Footer)
                    e.Row.Cells[2].Text = string.Format("{0}", Total);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            aTestEntryModel.Name = txt_name.Text;
            aTestEntryModel.Date = txt_birth.Text;
            aTestEntryModel.No = txt_no.Text;
            aTestEntryModel.Test = DropDownList.Text;
            aTestEntryModel.Fee = Convert.ToInt32(txt_fee.Text);

            int fee = aTestEntryManager.TestEntry(aTestEntryModel);

        }
        private void GetTestName()
        {
            List<DiagnosticModel> testlist = aTestSetupManager.TestSetUp();
            DiagnosticModel aDiagnosticModel = new DiagnosticModel();

            if (testlist.Count > 0)
            {
                DropDownList.DataSource = testlist;
                foreach (var item in testlist)
                {
                    if (!DropDownList.Items.Contains(new ListItem(item.Name)))
                        DropDownList.Items.Add(item.Name);
                }
            }
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            aDiagnosticModel.Name = DropDownList.SelectedValue;

            int fee = aTestEntryManager.Fee(aDiagnosticModel);

            txt_fee.Text = Convert.ToString(fee);

        }
        private void AddNewRecordRowToGrid()
        {
            
            if (ViewState["AuthorBooks"] != null)
            {
                   
                DataTable dtCurrentTable = (DataTable)ViewState["AuthorBooks"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {   
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Test Name"] = DropDownList.Text;
                        drCurrentRow["Fee"] = txt_fee.Text;
                    }
                    
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    
                    dtCurrentTable.Rows.Add(drCurrentRow);
                     
                    ViewState["AuthorBooks"] = dtCurrentTable;
                    
                    bookListGridView.DataSource = dtCurrentTable;
                    bookListGridView.DataBind();
                }
            }
        }
    }
}