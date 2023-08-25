using SQLite;
using System.Collections.Generic;

namespace FixedAssets_BarCode.Models.Models
{
    public class Inventory
    {
        [PrimaryKey]
        public string AssetNo { get; set; }
        public string BinLoc { get; set; }
        public string Site { get; set; }
        public string Item_ { get; set; }
        public byte CreatedOnHH { get; set; }
        public string SerialNumber { get; set; }
        public Inventory()
        {
        }

        public Inventory(string assetNo, string binLoc, string site, string item_,byte createdOnHH,string serialNumber)
        {
            this.AssetNo = assetNo;
            this.BinLoc = binLoc;
            this.Site = site;
            this.Item_ = item_;
            this.CreatedOnHH = createdOnHH;
            this.SerialNumber = serialNumber;
        }
        public Inventory(Inventory value)
        {
            this.AssetNo = value.AssetNo;
            this.BinLoc = value.BinLoc;
            this.Site = value.Site;
            this.Item_ = value.Item_;
        }
    }
}
