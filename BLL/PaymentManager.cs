using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Management_System.BLL
{
    public class PaymentManager
    {
        PaymentGateway aPaymentGateway = new PaymentGateway();
        public List<PaymentModel> Amount(PaymentModel aPaymentModel)
        {
            List<PaymentModel> bill = aPaymentGateway.Amount(aPaymentModel);
            return bill;
        }

        public string Message(PaymentModel aPaymentModel)
        {
            int i = aPaymentGateway.AddAmount(aPaymentModel);
            if (i > 0)
            {
                return "Save Successfully";
            }
            else
            {
                return "Cannot Save";
            }
        }
    }
}