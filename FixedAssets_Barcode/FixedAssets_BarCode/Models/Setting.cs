using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FixedAssets_BarCode.Models
{
    public class Setting
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string TransmitPowerIndex { get; set; }
        public string VolumePowerIndex { get; set; }
        public Setting(int id,string TransmitPowerIndex, string VolumePowerIndex)
        {
            this.Id = id;
            this.TransmitPowerIndex = TransmitPowerIndex;
            this.VolumePowerIndex = VolumePowerIndex;
        }
        public Setting(string VolumePowerIndex)
        {
            this.Id = 1;
            this.VolumePowerIndex = VolumePowerIndex;
        }
        public Setting()
        {

        }
    }
}
