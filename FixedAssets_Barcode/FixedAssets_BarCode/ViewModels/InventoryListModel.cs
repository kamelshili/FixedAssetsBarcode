using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedAssets_BarCode.Data;
using FixedAssets_BarCode.Models;
using FixedAssets_BarCode.Models.Models;
using Location = FixedAssets_BarCode.Models.Models.Location;

namespace FixedAssets_BarCode.ViewModels
{
    public class InventoryListModel : BaseViewModel
    {
        private string _description;
        string assetNo;
        private string lib_etat;
        private string num_serie;
        private List<string> listetats;
        private string selectedetat;
        private static ObservableCollection<TagItem> _staticallItems;
        private List<Item> listItems;
        private Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        private void AllEtats()
        {
            ListEtats = new List<string>();
            listetats.Add("Neuf");
            listetats.Add("Bon");
            listetats.Add("Moyen");
            listetats.Add("Mauvais");
            listetats.Add("Rebus");
            ListEtats = listetats;
        }
        private async void AllItemItems()
        {
            ListItems = new List<Item>();
            ItemDatabaseController ItemDatabaseController = new ItemDatabaseController();
            ListItems = await ItemDatabaseController.GetAllItem();
        }

        public List<Item> ListItems
        {
            get => listItems;
            set
            {
                listItems = value;
                OnPropertyChanged();
            }
        }

        public string AssetNo
        {
            get => assetNo;
            set
            {
                assetNo = value;
                OnPropertyChanged();

            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public string Num_Serie
        {
            get => num_serie;
            set

            {
                num_serie = value;
                OnPropertyChanged();
            }
        }
        public List<string> ListEtats
        {
            get => listetats;
            set
            {
                listetats = value;
                OnPropertyChanged();
            }
        }
        public string SelectedEtat
        {
            get => selectedetat;
            set
            {
                selectedetat = value;
                OnPropertyChanged();
            }
        }
        private int _valide = 0;
        public int Valide
        {
            get { return _valide; }
            set
            {
                _valide = value;
                OnPropertyChanged();
            }
        }
        private int _new = 0;
        public int New
        {
            get { return _new; }
            set
            {
                _new = value;
                OnPropertyChanged();
            }
        }

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
        
        private void valider(string site, string binloc)
        {

            InventoryDatabaseController inventoryDatabaseController = new InventoryDatabaseController();
            var inventory = inventoryDatabaseController.GetInventoryById(AssetNo);
            var InvID = string.Empty;
            var TransType = string.Empty;

            if (inventory != null)
            {
                InvID = AssetNo;
                if (inventory.Result.Site == site && inventory.Result.BinLoc == binloc)
                {
                    TransType = "PI";
                }
                else
                    TransType = "MO";

                ItemDatabaseController itemDatabaseController = new ItemDatabaseController();
                var descrep = itemDatabaseController.GetDescriptionByItem(inventory.Result.Item_).Result.Description;
                DateTime dt = DateTime.Now;
                string userid = LoginViewModel.UserId;
                var sn = inventory.Result.SerialNumber;
                if (String.IsNullOrEmpty(sn))
                {
                    sn = Num_Serie;
                }
                Upload upload = new Upload(TransType, userid, inventory.Result.Item_, descrep, inventory.Result.Site, inventory.Result.BinLoc, site, binloc, dt.ToString("yyyy-MM-dd HH:mm:ss"), InvID, selectedetat, sn);
                UploadDatabaseController uploadDatabaseController = new UploadDatabaseController();
                int x = uploadDatabaseController.SaveUpload(upload).Result;
            }
            else
            {
                InvID = AssetNo;
                DateTime dt = DateTime.Now;
                string userid = LoginViewModel.UserId;
                TransType = "New";
                Upload upload = new Upload(TransType, userid, SelectedItem.Item_, selectedItem.Description, site, binloc, site, binloc, dt.ToString("yyyy-MM-dd HH:mm:ss"), InvID, selectedetat, Num_Serie);
                UploadDatabaseController uploadDatabaseController = new UploadDatabaseController();
                int x = uploadDatabaseController.SaveUpload(upload).Result;
            }
        }


        public InventoryListModel()
        {
            AllEtats();
            AllItemItems();
            // ValidateTagItem = new Command(async (parameter) =>
            // {
            //     StackLayout pickersitebinloc = (StackLayout)parameter;
            //     StackLayout stackpickersite = (StackLayout)pickersitebinloc.Children[0];
            //     Picker pickersite = (Picker)stackpickersite.Children[1];
            //     StackLayout stackpickerbinloc = (StackLayout)pickersitebinloc.Children[1];
            //     Picker pickerbinloc = (Picker)stackpickerbinloc.Children[1];
            //     string newSite = ((Sites)pickersite.SelectedItem).Site;
            //     string newBinLoc = ((Location)pickerbinloc.SelectedItem).BinLoc;
            //     valider(newSite, newBinLoc);
            //     OnCancel();
            // });
            // CancelCommand = new Command(async (parameter) =>
            // {
            //     OnCancel();
            // }
            //);
            ValidateTagItem = new Command(async (parameter) =>
            {
               StackLayout pickersitebinloc = (StackLayout)parameter;
               if (pickersitebinloc.Children.Count >= 2)
               {
                 StackLayout stackpickersite = (StackLayout)pickersitebinloc.Children[0];
                 StackLayout stackpickerbinloc = (StackLayout)pickersitebinloc.Children[1];

                   if (stackpickersite.Children.Count >= 2 && stackpickerbinloc.Children.Count >= 2)
                   {
                     Picker pickersite = (Picker)stackpickersite.Children[1];
                     Picker pickerbinloc = (Picker)stackpickerbinloc.Children[1];

                        if (pickersite.SelectedItem is Sites selectedSite && pickerbinloc.SelectedItem is Location selectedLocation)
                        {
                         string newSite = selectedSite.Site;
                         string newBinLoc = selectedLocation.BinLoc;
                         valider(newSite, newBinLoc);
                         OnCancel();
                        }
                   }
               }
                OnCancel();
            });
            CancelCommand = new Command(async (parameter) =>
            {
                OnCancel();
            }
           );

            string getDescription(string tagID)
            {
                ItemDatabaseController itemDatabaseController = new ItemDatabaseController();
                InventoryDatabaseController inventoryDatabaseController = new InventoryDatabaseController();
                tagID = tagID.Substring(0, 5);
                var inventory = inventoryDatabaseController.GetInventoryById(tagID);
                if (inventory == null)
                {
                    return "Inconnue";
                }
                return itemDatabaseController.GetDescriptionByItem(inventory.Result.Item_).Result.Description;
            }

            string getSerialNumber(string tagID)
            {
                ItemDatabaseController itemDatabaseController = new ItemDatabaseController();
                InventoryDatabaseController inventoryDatabaseController = new InventoryDatabaseController();
                tagID = tagID.Substring(0, 5);
                var inventory = inventoryDatabaseController.GetInventoryById(tagID);
                if (inventory == null)
                {
                    return "Serial Number Inconnue";
                }
                return inventory.Result.SerialNumber;
            }
        }


        public Command ValidateTagItem { get; set; }
        public Command ValidateList { get; set; }
        public Command SaveSetting { get; set; }
        public Command CancelCommand { get; }

        private void OnCancel()
        {
            // This will pop the current page off the navigation stack
            // await Application.Current.("..");
            assetNo = "";
            AssetNo = "";
            Num_Serie = "";
            num_serie = "";
            SelectedEtat = null;
            selectedetat = null;
            SelectedItem = null;
            selectedItem = null;
        }
    }
}
