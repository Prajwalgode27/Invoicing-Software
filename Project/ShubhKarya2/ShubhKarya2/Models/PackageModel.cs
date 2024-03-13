using ShubhKarya2.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShubhKarya2.Models
{
    public class PackageModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }

        public string SavePackage(HttpPostedFileBase fb, PackageModel model)
        {
            string Message = "";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";

            if (fb != null && fb.ContentLength > 0)
            {

                filePath = HttpContext.Current.Server.MapPath("../Content/Img/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);

                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("../Content/Img/") + "/" + sysFileName;
                }
            }
            if (model.Id == 0)
            {
                var check = db.tblPackages.Where(p => p.Title == model.Title).FirstOrDefault();
                if (check == null)
                {
                    var savePackage = new tblPackage()
                    {
                        Photo = sysFileName,
                        Title = model.Title,
                        Description = model.Description,
                        Duration = model.Duration,
                        Amount = model.Amount,
                        IsActive=model.IsActive,

                    };
                    db.tblPackages.Add(savePackage);
                    db.SaveChanges();
                    Message = "Data Save Successfully.";
                }
                else
                {
                    Message = "This Package already include.";
                }
            }
            else
            {
                var savePackage = db.tblPackages.Where(p => p.Id == model.Id).FirstOrDefault();
                if (savePackage != null)
                {
                    savePackage.Id = model.Id;
                    savePackage.Title = model.Title;
                    savePackage.Description = model.Description;
                    savePackage.Photo = sysFileName;
                    savePackage.Duration = model.Duration;
                    savePackage.Amount = model.Amount;
                    savePackage.IsActive = model.IsActive;
                }
                db.SaveChanges();
                Message = "Update Package Data Successfully.";
            }
            return Message;

        }

        public List<PackageModel> GetPackageList()
        {
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            List<PackageModel> lstPackage = new List<PackageModel>();
            var PackageList = db.tblPackages.ToList();
            //var PackageList = db.tblPackages.Where(p => p.Title.Contains(Search) || p.Duration.Contains(Search)).ToList();
            if (PackageList != null)
            {
                foreach (var tbl_ in PackageList)
                {
                    lstPackage.Add(new PackageModel()
                    {
                        Id = tbl_.Id,
                        Title = tbl_.Title,
                        Photo = tbl_.Photo,
                        Description = tbl_.Description,
                        Duration = tbl_.Duration,
                        Amount = tbl_.Amount,
                    });
                }

            }
            return lstPackage;
        }
        public string DeletePackage(int Id)
        {
            string Message = "Practice Data delete successfully.";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            var PackageData = db.tblPackages.Where(p => p.Id == Id).FirstOrDefault();
            if (PackageData != null)
            {
                db.tblPackages.Remove(PackageData);
                db.SaveChanges();
            }
            return Message;
        }

        public PackageModel EditPackage(int Id)
        {
            PackageModel model = new PackageModel();
            ShubhkaryaEntities db = new ShubhkaryaEntities();

            var editData = db.tblPackages.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.Title = editData.Title;
                model.Photo = editData.Photo;
                model.Description = editData.Description;
                model.Duration = editData.Duration;
                model.Amount = editData.Amount;

            };
            return model;
        }
    }
}