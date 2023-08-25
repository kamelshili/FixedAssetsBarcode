using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssets_BarCode.Models.Models
{
    public class Upload
    {
        [PrimaryKey, AutoIncrement]
        public int TransID { get; set; }
        public string TransType { get; set; }
        public string UserID { get; set; }
        public string Item_ { get; set; }
        public string Description { get; set; }
        public string FromSite { get; set; }
        public string FromLocation { get; set; }
        public string ToSite { get; set; }
        public string ToBinLoc { get; set; }
        public string TranDateTime { get; set; }
        public string AssetNo { get; set; }
        public string Status { get; set; }
        public string SerialNumber { get; set; }
        public Upload(string TransType, string UserID, string Item_, string Description, string FromSite, string FromLocation, string ToSite, string ToBinLoc, string TranDateTime, string AssetNo, string Status, string SerialNumber)
        {
            this.TransType = TransType;
            this.UserID = UserID;
            this.Item_ = Item_;
            this.Description = Description;
            this. FromSite= FromSite;
            this.FromLocation = FromLocation; 
            this.ToSite = ToSite;
            this.ToBinLoc = ToBinLoc;
            this.TranDateTime = TranDateTime;
            this.AssetNo = AssetNo;
            this.Status = Status;
            this.SerialNumber = SerialNumber;
        }
         public Upload()
         { 
         }       
    }
}
