using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Service
{
    public class InvoiceService
    {
        InvoicingSoftEntities db = new InvoicingSoftEntities();
        public string GetInvoiceId()
        {
            // var getMaaxId = db.tblInvoices.Max(p => p.InvoiceNo);

            int getMaaxId = 0;
              getMaaxId =Convert.ToInt32( db.tblInvoices.Max(p => (int?)p.Id)??0);
            var f = Convert.ToInt32(getMaaxId);
            var g = f++;
            var InvoiceId =  DateTime.Now.ToString("yyyy") + g;

            //var r = f.ToString().PadLeft(5, '0');
            return InvoiceId;
        }

        public string SaveCustomerInvoice(InvoiceModel model)
        {
            string msg = "";
            var CustomerId = db.tblCustomers.Max(p => (long?)p.Id) + 1;
            var custbalance = db.tblCustomerAccounts
                                .Where(p => p.CustomerId == model.CustomerId)
                                .OrderByDescending(p => p.Id)
                                .FirstOrDefault(); 
           
            if (model.Id == 0)
            {

                var invoicedata = new tblInvoice()
                {
                    Id = model.Id,
                    MasterId = 1,
                    InvoiceNo = model.InvoiceNo,
                    CustomerId = (int?)(((int)model.CustomerId==0)?CustomerId:model.CustomerId),
                    Quantity = model.Quantity,
                    TaxAmount = (decimal)model.TaxAmount,
                    Discount = (decimal)model.Discount,
                    CGST = (decimal)model.CGST,
                    OtherCharge = (decimal)model.OtherCharge,
                    SGST = (decimal)model.SGST,
                    CESS = (decimal)model.CESS,
                    TotalAmount = (decimal)model.TotalAmount,
                    CrateDate = (DateTime)DateTime.Now,
                    CreateBy = 1,
                    UpdateDate = (DateTime)DateTime.Now,
                    UpdateBy = 1,
                    isActive =true,
                };
                db.tblInvoices.Add(invoicedata);
                db.SaveChanges();
               // msg = "GentrateInvoice";
                msg=model.InvoiceNo.ToString();
                if (model.CustomerId == 0)
                {
                   
                    var customerdata = new tblCustomer()
                    {

                        Id = (long)CustomerId,
                        MasterId=1, 
                        CustomerName = (string)model.CustomerName,
                        Mobile = model.Mobile,
                        Email = model.Email,
                        GSTNo = model.GSTNo,
                        Address = model.Address,
                        City = model.City,
                        State = model.State,
                        ZipCode = model.ZipCode,
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                        UpdateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = 1,
                        isActive = true,
                    };
                    db.tblCustomers.Add(customerdata);
                    db.SaveChanges();
                }
                if (model.CustomerId == 0)
                {

                    var customeraccountdata = new tblCustomerAccount()
                    {

                        MasterId = 1,
                        CustomerId = (int)CustomerId,
                        PaidBalance = 0,
                        NewInvoiceAmount = model.TotalAmount,
                        PreveusBalance = (custbalance.PreveusBalance ?? 0m) + (model.TotalAmount),
                        BalanceAmount = (custbalance.PreveusBalance ?? 0m) + (model.TotalAmount),
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                        UpdateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = 1,
                        isActive = model.isActive,
                    };
                    db.tblCustomerAccounts.Add(customeraccountdata);
                    db.SaveChanges();
                }
            
                if (custbalance != null)
                {
                    var customeraccountdata = new tblCustomerAccount()
                    {

                        MasterId = 1,
                        CustomerId = model.CustomerId,
                        PaidBalance = 0,
                        NewInvoiceAmount = model.TotalAmount,
                        PreveusBalance = (custbalance.PreveusBalance ?? 0m) + (model.TotalAmount),
                        BalanceAmount = (custbalance.PreveusBalance ?? 0m) + (model.TotalAmount),
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                        UpdateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = 1,
                        isActive = model.isActive,
                    };
                    db.tblCustomerAccounts.Add(customeraccountdata);
                    db.SaveChanges();
                }
                else
                {
                    var custaccountdata = new tblCustomerAccount()
                    {

                        MasterId = 1,
                        CustomerId = model.CustomerId,
                        PaidBalance = 0,
                        NewInvoiceAmount = model.TotalAmount,
                        PreveusBalance = 0 + model.TotalAmount,
                        BalanceAmount = 0 + model.TotalAmount,
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                        UpdateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = 1,
                        isActive = model.isActive,
                    };
                    db.tblCustomerAccounts.Add(custaccountdata);
                    db.SaveChanges();
                }
               
            }
           return msg;
        }
        public List<InvoiceModel> GetInvoiceList(int MasterId)
        {
            InvoicingSoftEntities db= new InvoicingSoftEntities();  
            List<InvoiceModel> lstInvoice = new List<InvoiceModel>();
        
              //var Data= db.tblInvoices.Where(p=>p.MasterId == MasterId).ToList();

            var Data = (from coi in db.tblInvoices
                        join p in db.tblCustomers on coi.CustomerId equals (int) p.Id
                                 select new
                                 {
                                     coi.MasterId,
                                     coi.CustomerId,
                                     coi.Quantity,
                                     coi.TaxAmount,
                                     coi.Discount,
                                     coi.OtherCharge,
                                     coi.SGST,
                                     coi.CGST, 
                                     coi.CESS,
                                     coi.TotalAmount,
                                     coi.CrateDate,
                                     p.Id,
                                     coi.InvoiceNo,
                                     p.CustomerName


                                 }).Where(p=>p.MasterId==MasterId).ToList();

            if (Data != null)
            {
                foreach (var data in Data)
                {
                    lstInvoice.Add(new InvoiceModel()
                    {
                        Id = data.Id,
                        InvoiceNo = data.InvoiceNo,
                        CustomerId = (int)data.CustomerId,
                        CustomerName= data.CustomerName,
                        Quantity = data.Quantity,
                        TaxAmount = data.TaxAmount,
                        Discount = data.Discount,
                        CGST = data.CGST,
                        OtherCharge = data.OtherCharge,
                        SGST = data.SGST,
                        CESS = data.CESS,
                        TotalAmount = data.TotalAmount,
                        CrateDate =Convert.ToDateTime( data.CrateDate).ToShortDateString(),
                    });
                }
               
            }
            return lstInvoice;
        }

        public List<InvoiceModel> CustomerInvoiceList(int CustomerId)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<InvoiceModel> lstInvoice = new List<InvoiceModel>();

            //var Data= db.tblInvoices.Where(p=>p.MasterId == MasterId).ToList();

            var Data = (from coi in db.tblInvoices
                        join p in db.tblCustomers on coi.CustomerId equals(int) p.Id
                        select new
                        {
                            coi.MasterId,
                            coi.CustomerId,
                            coi.Quantity,
                            coi.TaxAmount,
                            coi.Discount,
                            coi.OtherCharge,
                            coi.SGST,
                            coi.CGST,
                            coi.CESS,
                            coi.TotalAmount,
                            coi.CrateDate,
                            p.Id,
                            coi.InvoiceNo,
                            p.CustomerName


                        }).Where(p => p.CustomerId == CustomerId).ToList();

            if (Data != null)
            {
                foreach (var data in Data)
                {
                    lstInvoice.Add(new InvoiceModel()
                    {
                        Id = data.Id,
                        InvoiceNo = data.InvoiceNo,
                        CustomerId = (int)data.CustomerId,
                        CustomerName = data.CustomerName,
                        Quantity = data.Quantity,
                        TaxAmount = data.TaxAmount,
                        Discount = data.Discount,
                        CGST = data.CGST,
                        OtherCharge = data.OtherCharge,
                        SGST = data.SGST,
                        CESS = data.CESS,
                        TotalAmount = data.TotalAmount,
                        CrateDate =Convert.ToDateTime( data.CrateDate).ToShortDateString(),
                    });
                }

            }
            return lstInvoice;
        }
        public InvoiceModel InvoiceDetails(string InvoiceNo)
        {
            InvoiceModel model = new InvoiceModel();
         
            try
            {
                var Data = (from coi in db.tblInvoices
                            join p in db.tblCustomers on coi.CustomerId equals(int) p.Id
                            select new
                            {
                                coi.MasterId,
                                coi.CustomerId,
                                p.Address,
                                p.City,
                                p.State,
                                p.ZipCode,
                                p.GSTNo,
                                p.Mobile,
                                coi.Quantity,
                                coi.TaxAmount,
                                coi.Discount,
                                coi.OtherCharge,
                                coi.SGST,
                                coi.CGST,
                                coi.CESS,
                                coi.TotalAmount,
                                coi.CrateDate,
                                p.Id,
                                coi.InvoiceNo,
                                p.CustomerName


                            }).Where(p => p.InvoiceNo == InvoiceNo).FirstOrDefault();
                if(Data !=null )
                {
                    model.Id= Data.Id;

                    model.MasterId= (int)Data.MasterId;
                    model.InvoiceNo = Data.InvoiceNo;
                    model.CustomerName= Data.CustomerName;
                    model.CustomerId = (int)Data.CustomerId;
                    model.Address = Data.Address+" " + "," + Data.City +"" + "," + Data.State+ ""+"," +Data.ZipCode;
                    model.City = Data.City;
                    model.State = Data.State;
                    model.ZipCode = Data.ZipCode;
                    model.GSTNo = Data.GSTNo;
                    model.Mobile = Data.Mobile;
                    model.Quantity= Data.Quantity;
                    model.TaxAmount= Data.TaxAmount;
                    model.Discount= Data.Discount;
                    model.OtherCharge= Data.OtherCharge;
                    model.SGST= Data.SGST;
                    model.CGST= Data.CGST;
                    model.CESS= Data.CESS;
                    model.TotalAmount= Data.TotalAmount;
                    model.TotalAmount= Data.TotalAmount;
                    model.CrateDate =Convert.ToDateTime( Data.CrateDate).ToShortDateString();

                }
                return model;
            }
            catch(Exception)
            { throw; }

          

        }
    }
}

