using Diagnostic_Management_System.BLL;
using Diagnostic_Management_System.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Management_System
{
    public partial class UnpaidBill : System.Web.UI.Page
    {
        UnpaidManager aUnpaidManager = new UnpaidManager();
        UnpaidModel aUnpaidModel = new UnpaidModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            aUnpaidModel.FromDate = txt_from.Text;
            aUnpaidModel.ToDate = txt_to.Text;
            List<UnpaidModel> viewtest = aUnpaidManager.Unpaid(aUnpaidModel);
            bookListGridView.DataSource = viewtest;
            bookListGridView.DataBind();
        }
        private decimal Total = (decimal)0.0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            else if (e.Row.RowType == DataControlRowType.Footer)
                e.Row.Cells[4].Text = string.Format("{0}", Total);
        }
    }
}