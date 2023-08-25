using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FixedAssets_BarCode.Models.Models
{
    public class Item
    {
        public string Item_ { get; set; }
        public string Description { get; set; }
        public Item()
        {
        }
        public Item(string item_, string description)
        {
            this.Item_ = item_;
            this.Description = description;
        }
        public Item(Item value)
        {
            this.Item_ = value.Item_;
            this.Description = value.Description;
        }
    }
}
