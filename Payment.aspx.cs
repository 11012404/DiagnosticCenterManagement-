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
    public partial class Payment : System.Web.UI.Page
    {
        PaymentModel aPaymentModel = new PaymentModel();
        PaymentManager aPaymentManager = new PaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btn_search_Click(object sender, EventArgs e)
        {
            aPaymentModel.Bil = txt_bill.Text;
            aPaymentModel.Mobile = txt_mobile.Text;
            if (txt_bill.Text.Length > 0)
            {
                aPaymentModel.Number = 1;
            }
            if (txt_mobile.Text.Length > 0)
            {
                aPaymentModel.Number = 2;
            }
            List<PaymentModel> total = aPaymentManager.Amount(aPaymentModel);
            foreach (var item in total)
            {
                txt_amount.Text = item.Number.ToString();
                txt_bill.Text = item.Bil;
            }
            btn_pay.Visible = true;
            txt_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        protected void btn_pay_Click(object sender, EventArgs e)
        {
            
            aPaymentModel.Number = Convert.ToInt32(txt_bill.Text);
            aPaymentModel.Bil = txt_amount.Text;
            aPaymentModel.Mobile = txt_date.Text;
            string message = aPaymentManager.Message(aPaymentModel);
            lbl_msg.Visible = true;
            txt_bill.Text = null;
            txt_mobile.Text = null;
            txt_amount.Text = null;
            txt_date.Text = null;
            lbl_msg.Text = message;
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lbl_msg.ClientID + "').style.display='none'\",2000)</script>");

        }
    }
}