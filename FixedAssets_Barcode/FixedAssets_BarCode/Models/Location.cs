using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssets_BarCode.Models.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string BinLoc { get; set; }
        public string Site { get; set; }
        
        public Location()
        {
        }

        public Location(int id,string binLoc , string site)
        {
            this.Id = id;
            this.Site = site;
            this.BinLoc = binLoc;
        }

        public Location(Location value)
        {
            this.Id = value.Id;
            this.Site = value.Site;
            this.BinLoc = value.BinLoc;
        }
    }
}
