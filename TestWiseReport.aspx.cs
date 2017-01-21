using Diagnostic_Management_System.BLL;
using Diagnostic_Management_System.DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Diagnostic_Management_System
{
    public partial class TestWiseReport : System.Web.UI.Page
    {
        TestReportModel aTestReportModel = new TestReportModel();
        TestReportManager aTestReportManager = new TestReportManager(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            aTestReportModel.FromDate = txt_from.Text;
            aTestReportModel.ToDate = txt_to.Text;
            bindgrid();
           
        }

        public void bindgrid()
        {
            aTestReportModel.FromDate = txt_from.Text;
            aTestReportModel.ToDate = txt_to.Text;
            List<TestReportModel> viewtest = aTestReportManager.ViewTestReport(aTestReportModel);
            bookListGridView.DataSource = viewtest;
            bookListGridView.DataBind();
        }
        private decimal Total = (decimal)0.0;

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fee"));
            else if (e.Row.RowType == DataControlRowType.Footer)
                e.Row.Cells[2].Text = string.Format("{0}", Total);
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bookListGridView.PageIndex = e.NewPageIndex;
            this.bindgrid();
        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    bookListGridView.AllowPaging = false;
                    this.bindgrid();

                    bookListGridView.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}