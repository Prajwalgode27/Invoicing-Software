using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace InvoicingSoft.Service
{
    public class CustomerOrderInvoiceService
    {
        InvoicingSoftEntities db = new InvoicingSoftEntities();
        public string SaveCustomerOrder(CustomerOrderInvoice model)
        {
            string msg = "";
            //var InvoiceId = db.tblInvoices.Max(p => p.Id );
           // var CustomerId = db.tblCustomers.Max(p => p.Id )+1;
            var invoiceid =Convert.ToInt32( + 1);

            if (model.Id == 0)
            {
                    var orderdata = new tblCustomerOrder()
                    {
                        Id= model.Id,
                        MasterId = 1,
                        InvoiceId= invoiceid,
                        InvoiceNo=model.InvoiceNo,
                        CustomerId = model.CustomerId,
                        ProductId = model.ProductId,
                        Particular=model.Particular,
                        HSN = model.HSN,
                        UOM = model.UOM,
                        GST = model.GST,
                        MRP = model.MRP,
                        Rate = model.Rate,
                        Amount =  model.Amount,
                        Discount = model.Discount,
                        Quantity = model.Quantity,
                        CGST = model.CGST,
                        SGST = model.SGST,
                        CESS = model.CESS,
                        TotalAmount = model.TotalAmount,
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                        UpdateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = 1,
                        isActive = model.isActive,
                    };
                    db.tblCustomerOrders.Add(orderdata);
                    db.SaveChanges();
                    msg = "Add order";
                var stock = db.tblStocks.FirstOrDefault(p => p.Id == model.ProductId);
                if (stock != null)
                {
                    int quantityToSubtract = Convert.ToInt32(model.Quantity);
                    stock.Quantity -= quantityToSubtract;

                    // Update the amount based on the remaining quantity and purchase rate
                    stock.Amount = stock.Quantity * stock.PurchesRate;

                    // Update CGST and SGST based on the updated amount and GST rate
                    stock.CGST = stock.Amount * Convert.ToInt32(stock.GST) / 200;
                    stock.SGST = stock.Amount * Convert.ToInt32(stock.GST) / 200;

                    // Calculate the total amount after considering CGST and SGST
                    stock.Total = stock.Amount + stock.CGST + stock.SGST;

                    db.SaveChanges();
                }
                //var customerdata = new tblCustomer()
                //{

                //    Id = CustomerId,
                //    CustomerName = model.CustomerName,
                //    Mobile = model.Mobile,
                //    Email = model.Email,
                //    GSTNo = model.GSTNo,
                //    Address = model.Address,
                //    City = model.City,
                //    State = model.State,
                //    ZipCode = model.ZipCode,
                //    CrateDate = Convert.ToDateTime(DateTime.Now),
                //    CreateBy = 1,
                //    UpdateDate = Convert.ToDateTime(DateTime.Now),
                //    UpdateBy = 1,
                //    isActive = model.isActive,
                //};
                //db.tblCustomers.Add(customerdata);
                //db.SaveChanges();
            }
           
            else
            {
                var getorderdata = db.tblCustomerOrders.Where(p => p.Id == model.Id).FirstOrDefault();

                if (getorderdata != null)
                {
                    getorderdata.Id = model.Id;
                    getorderdata.MasterId = 1;
                    getorderdata.InvoiceId = invoiceid;
                    getorderdata.InvoiceNo = model.InvoiceNo;
                    getorderdata.CustomerId = model.CustomerId;
                    getorderdata.ProductId = model.ProductId;
                    getorderdata.Amount = model.Amount;
                    getorderdata.Discount = model.Discount;
                    getorderdata.CGST = model.CGST;
                    getorderdata.SGST = model.SGST;
                    getorderdata.CESS = model.CESS;
                    getorderdata.TotalAmount = model.TotalAmount;
                    getorderdata.UpdateDate = Convert.ToDateTime(DateTime.Now);
                    getorderdata.UpdateBy = 1;
                    getorderdata.isActive = model.isActive;
                };
                db.SaveChanges();
                msg = "Updated  Successfully";
            }
            return msg;
        }
        public List<CustomerOrderInvoice> GetcustomerordertList(string InvoiceNo)
        {
            List<CustomerOrderInvoice> lstcustorder = new List<CustomerOrderInvoice>();
            var CustomerOrder = db.tblCustomerOrders.Where(p => p.InvoiceNo == InvoiceNo).ToList();
            if (CustomerOrder != null)
            {
                foreach (var customerOrder in CustomerOrder)
                {
                    lstcustorder.Add(new CustomerOrderInvoice()
                    {
                        Id = customerOrder.Id,
                        InvoiceNo = customerOrder.InvoiceNo,
                        CustomerId = customerOrder.CustomerId,
                        ProductId = customerOrder.ProductId,
                        Particular=customerOrder.Particular,
                        UOM = customerOrder.UOM,
                        HSN = customerOrder.HSN,
                        GST = customerOrder.GST,
                        MRP = (decimal)customerOrder.MRP,
                        Rate = (decimal)customerOrder.Rate,
                        Amount = customerOrder.Amount,
                        Discount =Convert.ToDecimal( customerOrder.Discount),
                        Quantity = customerOrder.Quantity,
                        CGST = customerOrder.CGST,
                        SGST = customerOrder.SGST,
                        CESS = Convert.ToDecimal(customerOrder.CESS),
                        TotalAmount = customerOrder.TotalAmount,
                      
                    });
                }
            }
            return lstcustorder;
        }

        public CustomerOrderInvoice TotalCustomerOrderDetails(string InvoiceNo)
        {
            CustomerOrderInvoice model = new CustomerOrderInvoice();
            try
            {
                model.TotalQuantity = (from emp in db.tblCustomerOrders.Where(p=>p.InvoiceNo== InvoiceNo).ToList()
                                     select emp).Sum(e => Convert.ToDecimal(e.Quantity));
                model.TaxableAmount = (from amt in db.tblCustomerOrders.Where(p => p.InvoiceNo == InvoiceNo).ToList()
                                       select amt).Sum(e => Convert.ToDecimal(e.Amount));
                model.TotalDiscount = (from amt in db.tblCustomerOrders.Where(p => p.InvoiceNo == InvoiceNo).ToList()
                                       select amt).Sum(e => Convert.ToDecimal(e.Discount));
                model.TotalCGST = (from amt in db.tblCustomerOrders.Where(p => p.InvoiceNo == InvoiceNo).ToList()
                                       select amt).Sum(e => Convert.ToDecimal(e.CGST));
                model.TotalSGST = (from amt in db.tblCustomerOrders.Where(p => p.InvoiceNo == InvoiceNo).ToList()
                                   select amt).Sum(e => Convert.ToDecimal(e.SGST));
                model.TotalCESS = (from amt in db.tblCustomerOrders.Where(p => p.InvoiceNo == InvoiceNo).ToList()
                                   select amt).Sum(e => Convert.ToDecimal(e.CESS));

                model.TotalAmount = (model.TaxableAmount-model.TotalDiscount+model.TotalCGST+model.TotalSGST+model.TotalCESS);
                
                List<GSTDetails> gstPerceList = db.tblCustomerOrders.Where(a => a.InvoiceNo == InvoiceNo).GroupBy(b => b.GST)
                .Select(x => new Models.GSTDetails
                {
                   GST=x.FirstOrDefault().GST,
                   Amount=x.Sum(s => s.Amount).Value,
                     SGST = x.Sum(s => s.SGST),
                    CGST = x.Sum(s => s.CGST)

                }).ToList();
                model.GSTDetails = gstPerceList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}