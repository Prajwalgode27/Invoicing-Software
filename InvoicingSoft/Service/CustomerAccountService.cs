using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace InvoicingSoft.Service
{
    public class CustomerAccountService
    {
        InvoicingSoftEntities db = new InvoicingSoftEntities();

        public string SaveCustomerAccount(CustomerAccountModel model)
        {
            string msg = "Paid Sucessfully";
            if (model.Id == 0)
            {
                    var customeraccountdata = new tblCustomerAccount()
                    {

                        MasterId = 1,
                        CustomerId = model.CustomerId,
                        PreveusBalance = model.PreveusBalance,
                        PaidBalance = model.PaidBalance,
                        BalanceAmount = model.BalanceAmount,
                        PaymentMode = model.PaymentMode,
                        TransactionNo = model.TransactionNo,
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                        UpdateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = 1,
                        isActive = model.isActive,
                    };
                    db.tblCustomerAccounts.Add(customeraccountdata);
                    db.SaveChanges();
                    msg = model.CustomerId.ToString();
                
                     
            }
            else
            {
                var getproductdata = db.tblCustomerAccounts.Where(p => p.Id == model.Id).FirstOrDefault();

                if (getproductdata != null)
                {
                    getproductdata.MasterId = 1;
                    getproductdata.CustomerId = model.CustomerId;
                    getproductdata.PreveusBalance = model.PreveusBalance;
                    getproductdata.PaidBalance = model.PaidBalance;
                    getproductdata.BalanceAmount = model.BalanceAmount;
                    getproductdata.PaymentMode = model.PaymentMode;
                    getproductdata.TransactionNo = model.TransactionNo;
                    getproductdata.UpdateDate = Convert.ToDateTime(DateTime.Now);
                    getproductdata.UpdateBy = 1;
                    getproductdata.isActive = model.isActive;
                };
                db.SaveChanges();
                msg = model.CustomerId.ToString();
                msg = "Updated  Successfully";
            }
       
            msg = model.CustomerId.ToString();
            return msg;

        }
        public List<CustomerAccountModel> GetCustomerAccountList(int CustomerId)
        {
            List<CustomerAccountModel> lstcustomeraccount = new List<CustomerAccountModel>();
            var Data = db.tblCustomerAccounts.Where(p => p.CustomerId == CustomerId).ToList();
            if (Data.Any())
            {
                foreach (var data in Data)
                {
                    lstcustomeraccount.Add(new CustomerAccountModel()
                    {
                        Id = data.Id,
                        CustomerId = data.CustomerId,
                        PreveusBalance = data.PreveusBalance ?? 0m,
                        PaidBalance = data.PaidBalance??0m,   //    BalanceAmount = data.BalanceAmount??0m,
                        PaymentMode = data.PaymentMode??null,
                        TransactionNo = data.TransactionNo??null,
                        NewInvoiceAmount = data.NewInvoiceAmount ?? 0m,
                        BalanceAmount = data.BalanceAmount,
                        CrateDate = data.CrateDate != null ? Convert.ToDateTime(data.CrateDate).ToShortDateString() : null,
                    });
                }
            }
            return lstcustomeraccount;
        }
    }
}