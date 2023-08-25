using SQLite;

using System.Collections.Generic;

namespace FixedAssets_BarCode.Models.Models
{
    public class InventoryItem
    {
        public string AssetNo { get; set; }
        public string BinLoc { get; set; }
        public string Site { get; set; }
        public string Item_ { get; set; }
        public string Description { get; set; }
        public InventoryItem()
        {
        }
        public InventoryItem(string assetNo, string binLoc, string site, string item_,string Description)
        {
            this.AssetNo = assetNo;
            this.BinLoc = binLoc;
            this.Site = site;
            this.Item_ = item_;
            this.Description = Description;
        }

        public InventoryItem(InventoryItem value)
        {
            this.AssetNo = value.AssetNo;
            this.Item_ = value.Item_;
            this.Description = value.Description;
            this.BinLoc = value.BinLoc;
            this.Site = value.Site;
        }
    }
}
