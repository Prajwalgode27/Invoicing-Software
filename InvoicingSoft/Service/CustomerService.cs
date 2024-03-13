using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Reflection;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Web.Helpers;
using System.Data.Entity.Infrastructure;

namespace InvoicingSoft.Service
{
    public class CustomerService
    {

        InvoicingSoftEntities db = new InvoicingSoftEntities();
        public string SaveCustomer(CustomerModel model)
        {
            string msg = "";
            var CustomerId = db.tblCustomers.Max(p => (long?)p.Id) + 1;
            var checkdata = db.tblCustomers.Where(p => p.Mobile == model.Mobile).FirstOrDefault();
            if (model.Id == 0)
            {
                if (checkdata == null)
                {
                    var customerdata = new tblCustomer()
                    {

                        MasterId = 1,
                        CustomerName = model.CustomerName,
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
                        isActive = model.isActive,
                    };
                    db.tblCustomers.Add(customerdata);
                    db.SaveChanges();
                    msg = "Customer Data Saved";
                }
                else
                {
                    msg = "Customer Data Is Already Exist";
                }
            }
            else
            {
                var getcustomerdata = db.tblCustomers.Where(p => p.Id == model.Id).FirstOrDefault();

                if (getcustomerdata != null)
                {
                    getcustomerdata.MasterId = model.MasterId;
                    getcustomerdata.CustomerName = model.CustomerName;
                    getcustomerdata.Mobile = model.Mobile;
                    getcustomerdata.Email = model.Email;
                    getcustomerdata.GSTNo = model.GSTNo;
                    getcustomerdata.Address = model.Address;
                    getcustomerdata.City = model.City;
                    getcustomerdata.State = model.State;
                    getcustomerdata.ZipCode = model.ZipCode;
                    getcustomerdata.UpdateDate = Convert.ToDateTime(DateTime.Now);
                    getcustomerdata.UpdateBy = 1;
                    getcustomerdata.isActive = model.isActive;
                };
                db.SaveChanges();
                msg = "Updated Customer Data Successfully";
            }

            var custaccountdata = new tblCustomerAccount()
            {

                MasterId = 1,
                CustomerId = (int)CustomerId,
                PaidBalance =0,
                PreveusBalance =0,
                BalanceAmount = 0,
                PaymentMode = "cash",
                TransactionNo = "0000",
                NewInvoiceAmount = 0,
                CrateDate = Convert.ToDateTime(DateTime.Now),
                CreateBy = 1,
                UpdateDate = Convert.ToDateTime(DateTime.Now),
                UpdateBy = 1,
                isActive = model.isActive,
            };
            db.tblCustomerAccounts.Add(custaccountdata);
            db.SaveChanges();
            return msg;
        }
        public List<CustomerModel> ddlCustomerSearch(string Prefix)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<CustomerModel> lstcustomer = new List<CustomerModel>();
            var Customer = db.tblCustomers.Where(p => p.MasterId == 1 && p.CustomerName.Contains(Prefix)).ToList();
            if (Customer != null)
            {
                foreach (var customer in Customer)
                {
                    lstcustomer.Add(new CustomerModel()
                    {
                        Id= customer.Id,
                        CustomerName = customer.CustomerName,
                        Mobile = customer.Mobile,
                        Email = customer.Email,
                        GSTNo = customer.GSTNo,
                        Address = customer.Address,
                        City = customer.City,
                        State = customer.State,
                        ZipCode = customer.ZipCode,
                        CrateDate = customer.CrateDate,
                       
                    });
                }
            }
            return lstcustomer;
        }

        public List<CustomerModel> GetCustomerList(int MasterId )
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<CustomerModel> lstcustomer = new List<CustomerModel>();
            var Customer = db.tblCustomers.Where(p => p.MasterId == MasterId).ToList();
            if (Customer != null)
            {
                foreach (var customer in Customer)
                {
                    lstcustomer.Add(new CustomerModel()
                    {
                        Id = customer.Id,
                        CustomerName = customer.CustomerName,
                        Mobile = customer.Mobile,
                        Email = customer.Email,
                        GSTNo = customer.GSTNo,
                        Address = customer.Address,
                        City = customer.City,
                        State = customer.State,
                        ZipCode = customer.ZipCode,
                        CrateDate = customer.CrateDate,

                    });
                }
            }
            return lstcustomer;
        }
        public string DeleteCustomer(int Id)
        {
            string msg = "";
            try
            {
                var getcustomer = db.tblCustomers.Where(p => p.Id == Id).FirstOrDefault();
                if (getcustomer != null)
                {
                    db.tblCustomers.Remove(getcustomer);
                };
                db.SaveChanges();
                msg = "Customer Delete";

            }
            catch (Exception)
            {
                msg = "Data not Match";
            }

            return msg;
        }
        public CustomerModel GetCustomerDetailbyId(int Id)
        {
            CustomerModel model = new CustomerModel();
            try
            {
                var customerData = db.tblCustomers.Where(p => p.Id == Id).FirstOrDefault();
                if (customerData != null)
                {
                    model.Id = customerData.Id;
                    model.MasterId = customerData.MasterId;
                    model.CustomerName = customerData.CustomerName;
                    model.Mobile = customerData.Mobile;
                    model.Email = customerData.Email;
                    model.GSTNo = customerData.GSTNo;
                    model.Address = customerData.Address;
                    model.City = customerData.City;
                    model.State = customerData.State;
                    model.ZipCode = customerData.ZipCode;
                    model.isActive = customerData.isActive;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}