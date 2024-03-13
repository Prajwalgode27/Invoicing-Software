using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShubhKarya2.Data;
using System.Data;
using System.IO;


namespace ShubhKarya2.Models
{
    public class RegModel
    {
        public int Id { get; set; }
        public Nullable<int> SrNo { get; set; }
        public string OnBehalf { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Religion { get; set; }
        public string Cast { get; set; }
        public string MotherTongue { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string PinCode { get; set; }
        public string Education { get; set; }
        public string Profession { get; set; }
        public string Income { get; set; }
        public string Img { get; set; }
        public string MaritalStatus { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string BloodGroup { get; set; }
        public string SkinComp { get; set; }


        public string SaveReg(HttpPostedFileBase fb, RegModel model)
        {
            string Message = "Registration Successfully";
            ShubhkaryaEntities db = new ShubhkaryaEntities();

            string filePath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("../Content/Img");
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
                    string varfileName = HttpContext.Current.Server.MapPath("../Content/Img") + "/" + sysFileName;
                }
            }

            var Reg = new tblReg()
            {
                FullName = model.FullName,
                Gender = model.Gender,
                DOB = model.DOB,
                Mobile = model.Mobile,
                Email = model.Email,
                Img = sysFileName,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword

            };
            db.tblRegs.Add(Reg);
            db.SaveChanges();
            return Message;

        }
    }
}