using Diagnostic_Management_System.DAL.Gateway;
using Diagnostic_Management_System.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Management_System.BLL
{
    public class UnpaidManager
    {
        UnpaidGateway aUnpaidGateway = new UnpaidGateway();
        public List<UnpaidModel> Unpaid(UnpaidModel aUnapidModel)
        {
            return aUnpaidGateway.UnpaidBill(aUnapidModel);
        }
    }
}