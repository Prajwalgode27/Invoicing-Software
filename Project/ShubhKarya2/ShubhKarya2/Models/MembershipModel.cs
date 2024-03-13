using ShubhKarya2.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShubhKarya2.Models
{
    public class MembershipModel
    {
        public int Id { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> SubscriptionId { get; set; }
        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public object FullName { get; set; }
        public string Title { get; set; }

        public string SaveMemberShip(MembershipModel model)
        {
            string Message = "";
            ShubhkaryaEntities db = new ShubhkaryaEntities();

            if (model.Id == 0)
            {
                var check = db.tblMemberships.Where(p => p.MemberId == model.MemberId).FirstOrDefault();
                if (check == null)
                {
                    var membership = new tblMembership()
                    {
                        Id = Id,
                        MemberId = model.MemberId,
                        SubscriptionId = model.SubscriptionId,
                        StartDate =Convert.ToDateTime( model.StartDate),
                        DueDate = Convert.ToDateTime(model.DueDate),
                        Amount = model.Amount,
                        Discount = model.Discount,
                        TotalAmount = model.TotalAmount,
                        IsActive = true,



                    };
                    db.tblMemberships.Add(membership);
                    db.SaveChanges();
                    Message = "Data Save Successfully.";
                }
                else
                {
                    Message = "This Subcription already include.";
                }
            }
            else
            {
                var update = db.tblMemberships.Where(p => p.Id == model.Id).FirstOrDefault();
                if (update != null)
                {
                    update.Id =model.Id;
                    update.MemberId = model.MemberId;
                    update.SubscriptionId = model.SubscriptionId;
                    update.StartDate = Convert.ToDateTime(model.StartDate);
                    update.DueDate = Convert.ToDateTime(model.StartDate);
                    update.Amount = model.Amount;
                    update.Discount = model.Discount;
                    update.TotalAmount = model.TotalAmount;
                    update.IsActive = true;
                }
                db.SaveChanges();
                Message = "Update  Data Successfully.";
            }
            return Message;

        }
        public List<MembershipModel> GetMembershipList()
        {
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            List<MembershipModel> lstMembership = new List<MembershipModel>();
           // var Membership = db.tblMemberships.ToList();

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
                                  m.IsActive
                              }).ToList();
            if (MemberList != null)
            {
                foreach (var tbl_ in MemberList)
                {
                    lstMembership.Add(new MembershipModel()
                    {
                        Id = tbl_.Id,
                        FullName = tbl_.FullName,
                        Title  = tbl_.Title,
                        StartDate = Convert.ToDateTime(tbl_.StartDate).ToShortDateString(),
                        DueDate = Convert.ToDateTime(tbl_.DueDate).ToShortDateString(),
                        Amount = tbl_.Amount,
                        Discount = tbl_.Discount,
                        TotalAmount = tbl_.TotalAmount,
                        IsActive =  tbl_.IsActive,
                    });
                }

            }
            return lstMembership;
        }
        public string DeleteMembership(int Id)
        {
            string Message = "Membership Data delete successfully.";
            ShubhkaryaEntities db = new ShubhkaryaEntities();
            var MembershipData = db.tblMemberships.Where(p => p.Id == Id).FirstOrDefault();
            if (MembershipData != null)
            {
                db.tblMemberships.Remove(MembershipData);
                db.SaveChanges();
            }
            return Message;
        }
        public MembershipModel EditMembership(int Id)
        {
            MembershipModel model = new MembershipModel();
            ShubhkaryaEntities db = new ShubhkaryaEntities();

            var editData = db.tblMemberships.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.MemberId = editData.MemberId;
                model.SubscriptionId = editData.SubscriptionId;
                model.StartDate = Convert.ToDateTime(editData.StartDate).ToShortDateString();
                model.DueDate = Convert.ToDateTime(editData.DueDate).ToShortDateString();
                model.Amount = editData.Amount;
                model.Discount = editData.Discount;
                model.TotalAmount = editData.TotalAmount;
            };
            return model;
        }
       
       
    }
}