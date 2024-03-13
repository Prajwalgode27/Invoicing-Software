using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Service
{
    public class ProductService
    {
        public string SaveProduct(ProductModel model)
        {
            string msg = "";
            InvoicingSoftEntities db = new InvoicingSoftEntities();
         
            var checkdata = db.tblProducts.Where(p => p.HSN == model.HSN).FirstOrDefault();

            if (model.Id == 0)
            {
                if (checkdata == null)
                {
                    var productdata = new tblProduct()
                    {

                        MasterId = 1,
                        Particular = model.Particular,
                        HSN = model.HSN,
                        UOM = model.UOM,
                        GST = model.GST,
                        MRP = model.MRP,
                        Rate = model.Rate,
                        CrateDate = Convert.ToDateTime(DateTime.Now),
                        CreateBy = 1,
                      UpdateDate = Convert.ToDateTime(DateTime.Now),
                    UpdateBy = 1,
                    isActive = model.isActive,
                    };
                    db.tblProducts.Add(productdata);
                    db.SaveChanges();
                    msg = "Add Product";
                }
                else
                {
                    msg = "Product Is Already Exist";
                }

            }
            else
            {
                var getproductdata = db.tblProducts.Where(p => p.Id == model.Id).FirstOrDefault();

                if (getproductdata != null)
                {
                    getproductdata.MasterId = model.MasterId;
                    getproductdata.Particular = model.Particular;
                    getproductdata.HSN = model.HSN;
                    getproductdata.UOM = model.UOM;
                    getproductdata.GST = model.GST;
                    getproductdata.MRP = model.MRP;
                    getproductdata.Rate = model.Rate;
                    getproductdata.UpdateDate = Convert.ToDateTime(DateTime.Now);
                    getproductdata.UpdateBy = 1;
                    getproductdata.isActive = model.isActive;
                };
                db.SaveChanges();
                msg = "Updated Product Successfully";
            }
            return msg;

        }
        public List<ProductModel> GetProductList(int MasterId)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<ProductModel> lstproduct = new List<ProductModel>();
            var Product = db.tblProducts.Where(p => p.Id == MasterId).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new ProductModel()
                    {
                      Id= product.Id,
                      Particular= product.Particular,
                      UOM= product.UOM,
                      HSN= product.HSN,
                      GST= product.GST,
                      MRP=decimal.Round(product.MRP,2 ,MidpointRounding.AwayFromZero),
                      Rate= (decimal)product.Rate,
                      CrateDate=Convert.ToDateTime( product.CrateDate).ToString("dd/MM/yyyy"),
                    });
                }
            }
            return lstproduct;
        }
        public string DeleteProduct(int Id)
        {

            string msg = "";
            InvoicingSoftEntities Db = new InvoicingSoftEntities();
            try
            {
                var getproduct = Db.tblProducts.Where(p => p.Id == Id).FirstOrDefault();
                if (getproduct != null)
                {
                    Db.tblProducts.Remove(getproduct);
                };
                Db.SaveChanges();
                msg = "Product Delete";
              
            }
            catch (Exception)
            {
                msg = "Data not Match";
            }

            return msg;
        }
        public ProductModel GetProductbyId(int Id)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            ProductModel model = new ProductModel();
            try
            {
                var productData = db.tblProducts.Where(p => p.Id == Id).FirstOrDefault();
                if (productData != null)
                {
                    model.MasterId = (int)productData.MasterId;
                    model.Id= productData.Id;
                    model.Particular = productData.Particular;
                    model.HSN = productData.HSN;
                    model.UOM = productData.UOM;
                    model.GST = productData.GST;
                    model.MRP = productData.MRP;
                    model.Rate = (decimal)productData.Rate;
                    model.isActive = (bool)productData.isActive;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model; 
        }
        public List<ProductModel> pruductSearch(string Prefix)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<ProductModel> lstproduct = new List<ProductModel>();
            var Product = db.tblProducts.Where(p => p.MasterId == 1 && p.Particular.Contains(Prefix)).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new ProductModel()
                    {
                        Id = product.Id,
                        Particular = product.Particular,
                        UOM = product.UOM,
                        HSN = product.HSN,
                        GST = product.GST,
                        MRP = decimal.Round(product.MRP, 2, MidpointRounding.AwayFromZero),
                        Rate = (decimal)product.Rate,
                        CrateDate = Convert.ToDateTime(product.CrateDate).ToString("dd/MM/yyyy"),
                    });
                }
            }
            return lstproduct;
        }
        public string DeletePurchesProducts(List<int> productIds)
        {
            string msg = "";
            InvoicingSoftEntities Db = new InvoicingSoftEntities();
            try
            {
                foreach (int productId in productIds)
                {
                    var productToDelete = Db.tblStocks.FirstOrDefault(p => p.Id == productId);
                    if (productToDelete != null)
                    {
                        Db.tblStocks.Remove(productToDelete);
                    }
                    else
                    {
                        msg += "Product with ID " + productId + " not found in tblStocks. ";
                    }

                    var stockOrderToDelete = Db.tblPurchesStockOrders.FirstOrDefault(p => p.Id == productId);
                    if (stockOrderToDelete != null)
                    {
                        Db.tblPurchesStockOrders.Remove(stockOrderToDelete);
                    }
                    else
                    {
                        msg += "Product with ID " + productId + " not found in tblPurchesStockOrders. ";
                    }
                }

                if (Db.ChangeTracker.HasChanges())
                {
                    Db.SaveChanges();
                    msg = "Products Deleted";
                }
                else
                {
                    msg = "No matching products found";
                }
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message;
            }

            return msg;
        }

    }
}