using ShubhKarya2.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web;
using System.Web.Security;

namespace ShubhKarya2.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string SrNo { get; set; }
        public string OnBehalf { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Height { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
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
        public string BloodGroup { get; set; }
        public string SkinComp { get; set; }
        public string TOB { get; set; }
        public string POB { get; set; }
        public string Rashi { get; set; }
        public string Nakshatra { get; set; }
        public string SubCaste { get; set; }
        public string Gotra { get; set; }
        public string Manglik { get; set; }
        public string College { get; set; }
        public string Organization { get; set; }
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherOccupation { get; set; }
        public string TotalFamilyMember { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }

        public string saveMember(HttpPostedFileBase fb, MemberModel model)
        {
            string Message = "Data save sucessfully";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            string filepath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {
                filepath = HttpContext.Current.Server.MapPath("../Content/Img");
                DirectoryInfo di = new DirectoryInfo(filepath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filepath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("/Content/Img") + "/" + sysFileName;
                }
            }

            if (model.Id == 0)
            {
                var check = db.tblRegs.Where(p => p.Mobile == model.Mobile || p.Email == model.Email).FirstOrDefault();
                if (check == null)
                {
                    var data = new tblReg()
                    {
                        Id = model.Id,
                        SrNo = model.SrNo,
                        OnBehalf = model.OnBehalf,
                        FullName = model.FullName,
                        Gender = model.Gender,
                        DOB = Convert.ToDateTime(model.DOB),
                        Mobile = model.Mobile,
                        Email = model.Email,
                        Height = model.Height,
                        Religion = model.Religion,
                        Caste = model.Caste,
                        MotherTongue = model.MotherTongue,
                        Country = model.Country,
                        City = model.City,
                        State = model.State,
                        Address = model.Address,
                        Landmark = model.Landmark,
                        PinCode = model.PinCode,
                        Education = model.Education,
                        Profession = model.Profession,
                        Income = model.Income,
                        Img = sysFileName,
                        MaritalStatus = model.MaritalStatus,
                        Password = model.Password,
                        ConfirmPassword = model.ConfirmPassword,
                        BloodGroup = model.BloodGroup,
                        SkinComp = model.SkinComp,
                        TOB = model.TOB,
                        POB = model.POB,
                        Rashi = model.Rashi,
                        Nakshatra = model.Nakshatra,
                        SubCaste = model.SubCaste,
                        Gotra = model.Gotra,
                        Manglik = model.Manglik,
                        College = model.College,
                        Organization = model.Organization,
                        FatherName = model.FatherName,
                        FatherOccupation = model.FatherOccupation,
                        MotherName = model.MotherName,
                        MotherOccupation = model.MotherOccupation,
                        TotalFamilyMember = model.TotalFamilyMember,
                        IsActive = true,
                    };
                    db.tblRegs.Add(data);
                    db.SaveChanges();

                }
                else
                {
                    Message = "This record already exist.";
                }
            }
            else
            {
                var data = db.tblRegs.Where(p => p.Id == model.Id && p.Mobile == model.Mobile).FirstOrDefault();
                if (data != null)
                {
                    data.Id = model.Id;
                    data.SrNo = model.SrNo;
                    data.OnBehalf = model.OnBehalf;
                    data.FullName = model.FullName;
                    data.Gender = model.Gender;
                    data.DOB = Convert.ToDateTime(model.DOB);
                    data.Mobile = model.Mobile;
                    data.Email = model.Email;
                    data.Height = model.Height;
                    data.Religion = model.Religion;
                    data.Caste = model.Caste;
                    data.MotherTongue = model.MotherTongue;
                    data.Country = model.Country;
                    data.City = model.City;
                    data.State = model.State;
                    data.Address = model.Address;
                    data.Landmark = model.Landmark;
                    data.PinCode = model.PinCode;
                    data.Education = model.Education;
                    data.Profession = model.Profession;
                    data.Income = model.Income;
                    data.Img = sysFileName;
                    data.MaritalStatus = model.MaritalStatus;
                    data.Password = model.Password;
                    data.ConfirmPassword = model.ConfirmPassword;
                    data.BloodGroup = model.BloodGroup;
                    data.SkinComp = model.SkinComp;
                    data.TOB = model.TOB;
                    data.POB = model.POB;
                    data.Rashi = model.Rashi;
                    data.Nakshatra = model.Nakshatra;
                    data.SubCaste = model.SubCaste;
                    data.Gotra = model.Gotra;
                    data.Manglik = model.Manglik;
                    data.College = model.College;
                    data.Organization = model.Organization;
                    data.FatherName = model.FatherName;
                    data.FatherOccupation = model.FatherOccupation;
                    data.MotherName = model.MotherName;
                    data.MotherOccupation = model.MotherOccupation;
                    data.TotalFamilyMember = model.TotalFamilyMember;
                    data.IsActive = model.IsActive;
                };
                db.SaveChanges();
                Message = "Updated Successfully";
            }
            return Message;
        }
        public List<MemberModel> GetMemberList()
        {
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            List<MemberModel> lstMember = new List<MemberModel>();

            var MemberList = db.tblRegs.ToList();
            if (MemberList != null)
            {
                foreach (var obj in MemberList)
                {
                    lstMember.Add(new MemberModel()
                    {
                        Id = obj.Id,
                        SrNo = obj.SrNo,
                        OnBehalf = obj.OnBehalf,
                        FullName = obj.FullName,
                        Gender = obj.Gender,
                        DOB = Convert.ToDateTime(obj.DOB).ToShortDateString(),
                        Mobile = obj.Mobile,
                        Email = obj.Email,
                        Height = obj.Height,
                        Religion = obj.Religion,
                        Caste = obj.Caste,
                        MotherTongue = obj.MotherTongue,
                        Country = obj.Country,
                        City = obj.City,
                        State = obj.State,
                        Address = obj.Address,
                        Landmark = obj.Landmark,
                        PinCode = obj.PinCode,
                        Education = obj.Education,
                        Profession = obj.Profession,
                        Income = obj.Income,
                        Img = obj.Img,
                        MaritalStatus = obj.MaritalStatus,
                        Password = obj.Password,
                        ConfirmPassword = obj.ConfirmPassword,
                        BloodGroup = obj.BloodGroup,
                        SkinComp = obj.SkinComp,
                        TOB = obj.TOB,
                        POB = obj.POB,
                        Rashi = obj.Rashi,
                        Nakshatra = obj.Nakshatra,
                        SubCaste = obj.SubCaste,
                        Gotra = obj.Gotra,
                        Manglik = obj.Manglik,
                        College = obj.College,
                        Organization = obj.Organization,
                        FatherName = obj.FatherName,
                        FatherOccupation = obj.FatherOccupation,
                        MotherName = obj.MotherName,
                        MotherOccupation = obj.MotherOccupation,
                        TotalFamilyMember = obj.TotalFamilyMember,
                        IsActive = obj.IsActive,
                    });
                }

            }
            return lstMember;

        }
        public List<MemberModel> GetSubscriptionMemberId(int Id)
        {
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            List<MemberModel> lstMember = new List<MemberModel>();
            var MemberList = (from m in db.tblMemberships
                              join r in db.tblRegs on m.MemberId equals r.Id
                              join p in db.tblPackages on m.SubscriptionId equals p.Id
                              select new
                              {
                                  m.MemberId,
                                  m.SubscriptionId,
                                  m.StartDate,
                                  m.DueDate,
                                  m.Amount,
                                  m.Discount,
                                  m.TotalAmount,
                                  m.IsActive,
                                  r.FullName,
                                  r.Id,
                                  r.Gender,
                                  r.Mobile,
                                  r.Email,
                                  r.Caste,
                                  r.Img,
                                  r.Password,
                                  r.ConfirmPassword,
                                  r.DOB,
                                  p.Title,
                              }).Where(o => o.SubscriptionId == Id && o.IsActive == true).ToList();
            if (MemberList != null)
            {
                foreach (var obj in MemberList)
                {
                    lstMember.Add(new MemberModel()
                    {
                        Id = obj.Id,
                        FullName = obj.FullName,
                        Gender = obj.Gender,
                        DOB = Convert.ToDateTime(obj.DOB).ToShortDateString(),
                        Mobile = obj.Mobile,
                        Email = obj.Email,
                        Img = obj.Img,
                    });
                }

            }
            return lstMember;

        }
        public string DeleteMember(int Id)
        {
            string Message = "Practice Data delete successfully.";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            var MemberData = db.tblRegs.Where(p => p.Id == Id).FirstOrDefault();
            if (MemberData != null)
            {
                db.tblRegs.Remove(MemberData);
                db.SaveChanges();
            }
            return Message;
        }
        public MemberModel EditMember(int Id)
        {
            MemberModel model = new MemberModel();
            ShubhkaryaEntities db = new ShubhkaryaEntities();

            var getData = db.tblRegs.Where(p => p.Id == Id).FirstOrDefault();
            if (getData != null)
            {

                model.Id = getData.Id;
                model.SrNo = getData.SrNo;
                model.OnBehalf = getData.OnBehalf;
                model.FullName = getData.FullName;
                model.Gender = getData.Gender;
                model.DOB = Convert.ToDateTime(getData.DOB).ToLongDateString();
                model.Mobile = getData.Mobile;
                model.Email = getData.Email;
                model.Height = getData.Height;
                model.Religion = getData.Religion;
                model.Caste = getData.Caste;
                model.MotherTongue = getData.MotherTongue;
                model.Country = getData.Country;
                model.City = getData.City;
                model.State = getData.State;
                model.Address = getData.Address;
                model.Landmark = getData.Landmark;
                model.PinCode = getData.PinCode;
                model.Education = getData.Education;
                model.Profession = getData.Profession;
                model.Income = getData.Income;
                model.Img = getData.Img;
                model.MaritalStatus = getData.MaritalStatus;
                model.Password = getData.Password;
                model.ConfirmPassword = getData.ConfirmPassword;
                model.BloodGroup = getData.BloodGroup;
                model.SkinComp = getData.SkinComp;
                model.TOB = getData.TOB;
                model.POB = getData.POB;
                model.Rashi = getData.Rashi;
                model.Nakshatra = getData.Nakshatra;
                model.SubCaste = getData.SubCaste;
                model.Gotra = getData.Gotra;
                model.Manglik = getData.Manglik;
                model.College = getData.College;
                model.Organization = getData.Organization;
                model.FatherName = getData.FatherName;
                model.FatherOccupation = getData.FatherOccupation;
                model.MotherName = getData.MotherName;
                model.MotherOccupation = getData.MotherOccupation;
                model.TotalFamilyMember = getData.TotalFamilyMember;
                model.IsActive = getData.IsActive;
            };
            return model;
        }

        public List<MemberModel> GetallActiveMember()

        {

            ShubhkaryaEntities db = new ShubhkaryaEntities();

            List<MemberModel> lstMember = new List<MemberModel>();

            var MemberList = (from m in db.tblMemberships

                              join r in db.tblRegs on m.MemberId equals r.Id

                              join p in db.tblPackages on m.SubscriptionId equals p.Id

                              select new

                              {

                                  m.MemberId,

                                  m.SubscriptionId,

                                  m.StartDate,

                                  m.DueDate,

                                  m.Amount,

                                  m.Discount,

                                  m.TotalAmount,

                                  m.IsActive,

                                  r.FullName,

                                  r.Id,

                                  r.Gender,

                                  r.Mobile,

                                  r.Email,

                                  r.Caste,

                                  r.Img,

                                  r.Password,

                                  r.ConfirmPassword,

                                  r.DOB,

                                  p.Title,

                              }).Where(o => o.IsActive == true).ToList();

            if (MemberList != null)

            {

                foreach (var obj in MemberList)

                {

                    lstMember.Add(new MemberModel()

                    {

                        Id = obj.Id,

                        FullName = obj.FullName,

                        Gender = obj.Gender,

                        DOB = Convert.ToDateTime(obj.DOB).ToLongDateString(),

                        Mobile = obj.Mobile,

                        Email = obj.Email,

                        Img = obj.Img,

                    });

                }

            }

            return lstMember;

        }
        public List<MemberModel> GetBridelst()
        {
            string Gender = "Female";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            List<MemberModel> lstMember = new List<MemberModel>();
            var MemberList = (from m in db.tblMemberships
                              join r in db.tblRegs on m.MemberId equals r.Id
                              join p in db.tblPackages on m.SubscriptionId equals p.Id
                              select new
                              {
                                  m.MemberId,
                                  m.SubscriptionId,
                                  m.StartDate,
                                  m.DueDate,
                                  m.Amount,
                                  m.Discount,
                                  m.TotalAmount,
                                  m.IsActive,
                                  r.FullName,
                                  r.Id,
                                  r.Gender,
                                  r.Mobile,
                                  r.Email,
                                  r.Caste,
                                  r.Img,
                                  r.Password,
                                  r.ConfirmPassword,
                                  r.DOB,
                                  p.Title,
                              }).Where(o => o.IsActive == true && o.Gender == Gender).ToList();
            if (MemberList != null)
            {
                foreach (var obj in MemberList)
                {
                    lstMember.Add(new MemberModel()
                    {
                        Id = obj.Id,
                        FullName = obj.FullName,
                        Gender = obj.Gender,
                        DOB = Convert.ToDateTime(obj.DOB).ToShortDateString(),
                        Mobile = obj.Mobile,
                        Email = obj.Email,
                        Img = obj.Img,
                    });
                }

            }
            return lstMember;

        }
        public List<MemberModel> GetGroomlst()
        {
            string Gender = "Male";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            List<MemberModel> lstMember = new List<MemberModel>();
            var MemberList = (from m in db.tblMemberships
                              join r in db.tblRegs on m.MemberId equals r.Id
                              join p in db.tblPackages on m.SubscriptionId equals p.Id
                              select new
                              {
                                  m.MemberId,
                                  m.SubscriptionId,
                                  m.StartDate,
                                  m.DueDate,
                                  m.Amount,
                                  m.Discount,
                                  m.TotalAmount,
                                  m.IsActive,
                                  r.FullName,
                                  r.Id,
                                  r.Gender,
                                  r.Mobile,
                                  r.Email,
                                  r.Caste,
                                  r.Img,
                                  r.Password,
                                  r.ConfirmPassword,
                                  r.DOB,
                                  p.Title,
                              }).Where(o => o.IsActive == true && o.Gender == Gender).ToList();
            if (MemberList != null)
            {
                foreach (var obj in MemberList)
                {
                    lstMember.Add(new MemberModel()
                    {
                        Id = obj.Id,
                        FullName = obj.FullName,
                        Gender = obj.Gender,
                        DOB = Convert.ToDateTime(obj.DOB).ToShortDateString(),
                        Mobile = obj.Mobile,
                        Email = obj.Email,
                        Img = obj.Img,
                    });
                }

            }
            return lstMember;

        }

    }
}