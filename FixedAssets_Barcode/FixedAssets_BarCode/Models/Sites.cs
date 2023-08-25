using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssets_BarCode.Models.Models
{
    public class Sites
    {
        [PrimaryKey]
        public string Site { get; set; }
        public Sites()
        {
        }

        public Sites(string site)
        {
            this.Site = site;
        }

        public Sites(Sites value)
        {
            this.Site = value.Site;
        }
    }
}
