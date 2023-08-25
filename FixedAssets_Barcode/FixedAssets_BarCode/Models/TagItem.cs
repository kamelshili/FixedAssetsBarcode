using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FixedAssets_BarCode
{
	public class TagItem : INotifyPropertyChanged
    {
        private int _count;
        private int _rssi;
        private int _rdistance;
        private string serialNumber;
        public string SerialNumber
        {
            get { return serialNumber; }
            set
            {
                serialNumber = value;
                OnPropertyChanged();
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public string InvID { get; set; }
        public int TagCount { get { return _count; } set { _count = value; OnPropertyChanged(); } }
		public int RSSI { get { return _rssi; } set { _rssi = value; OnPropertyChanged(); } }
        public int RelativeDistance { get { return _rdistance; } set { _rdistance = value;  OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}