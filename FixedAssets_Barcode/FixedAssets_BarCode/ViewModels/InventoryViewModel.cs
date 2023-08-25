using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedAssets_BarCode.Data;
using FixedAssets_BarCode.Models.Models;
using FixedAssets_BarCode.Views;
using Location = FixedAssets_BarCode.Models.Models.Location;

namespace FixedAssets_BarCode.ViewModels
{
    class InventoryViewModel : INotifyPropertyChanged
    {
        //les attributs ici
        private static Page page = new Page();
        public List<Sites> allSites;
        public List<Item> allItems;
        public List<Location> allLocations;
        //public Task<List<Inventory>> allInventory;
        public List<InventoryItem> allInventory;
        Inventory inventory;
        Inventory inventorySelected;
        Sites siteSelected;
        Item itemSelected;
        Location locationSelected;
        int count;

        private Color _backgroundColor;

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }
        //int indexLocationSelected;

        string assetNo;
        string binLoc;
        string serialNumber;
        string site;
        string item_;
        string description;
        byte createdOnHH;

        public event PropertyChangedEventHandler PropertyChanged;

        public Func<string, ICollection<string>, ICollection<string>> SortingAlgorithm { get; } =
(text, values) => values
 .Where(x => x.ToLower().Contains(text.ToLower()))
 .OrderBy(x => x)
 .ToList();

        public List<Location> AllLocations
        {
            get => allLocations;
            set
            {
                if (allLocations != value)
                {
                    allLocations = value;
                    var args = new PropertyChangedEventArgs(nameof(AllLocations));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public int Count
        {
            get => count;
            set
            {
                if (count != value)
                {
                    count = value;
                    var args = new PropertyChangedEventArgs(nameof(Count));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public List<InventoryItem> AllInventory
        {
            get => allInventory;
            set
            {
                if (allInventory != value)
                {
                    allInventory = value;
                    var args = new PropertyChangedEventArgs(nameof(allInventory));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public Item ItemSelected
        {
            get => itemSelected;
            set
            {
                if (value != null)
                {
                    itemSelected = value;
                    Item_ = ItemSelected.Item_;
                    Description = ItemSelected.Description;
                    var args = new PropertyChangedEventArgs(nameof(ItemSelected));
                    PropertyChanged?.Invoke(this, args);
                }

            }
        }

        async void getInventoryByBinLoc(string site, string binloc)
        {
            AllInventory = new List<InventoryItem>();
            InventoryDatabaseController inventoryDatabaseController = new InventoryDatabaseController();
            AllInventory = await inventoryDatabaseController.GetListInventoryBySiteBinLoc(site, binloc);
        }

        public Location LocationSelected
        {
            get => locationSelected;
            set
            {
                if (value != null)
                {
                    locationSelected = value;
                    BinLoc = locationSelected.BinLoc;
                    getInventoryByBinLoc(SiteSelected.Site, LocationSelected.BinLoc);
                    var args = new PropertyChangedEventArgs(nameof(LocationSelected));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public List<Item> AllItems
        {
            get => allItems;
            set
            {
                if (allItems != value)
                {
                    allItems = value;

                    var args = new PropertyChangedEventArgs(nameof(AllItems));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        async void setAllLocation(string site)
        {
            AllLocations = new List<Location>();
            LocationDatabaseController locationdatabasecontroller = new LocationDatabaseController();
            AllLocations = await locationdatabasecontroller.GetLocationBySite(Site);
        }
        public Sites SiteSelected
        {
            get => siteSelected;
            set
            {
                if (value != null)
                {
                    siteSelected = value;
                    Site = siteSelected.Site;
                    setAllLocation(Site);
                    LocationSelected = null;
                    var args = new PropertyChangedEventArgs(nameof(SiteSelected));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }


        public List<Sites> AllSites
        {
            get => allSites;
            set
            {
                if (allSites != value)
                {
                    allSites = value;
                    var args = new PropertyChangedEventArgs(nameof(AllSites));
                    PropertyChanged?.Invoke(this, args);
                }
            }
        }

        public Inventory InventorySelected
        {
            get => inventorySelected;
            set
            {
                inventorySelected = new Inventory(value);
                var args = new PropertyChangedEventArgs(nameof(InventorySelected));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Inventory Inventory
        {
            get => inventory;
            set
            {
                inventory = new Inventory(value);
                var args = new PropertyChangedEventArgs(nameof(Inventory));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string AssetNo
        {
            get => assetNo;
            set
            {
                assetNo = value;
                var args = new PropertyChangedEventArgs(nameof(AssetNo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string BinLoc
        {
            get => binLoc;
            set
            {
                binLoc = value;
                var args = new PropertyChangedEventArgs(nameof(BinLoc));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string SerialNumber
        {
            get => serialNumber;
            set
            {
                serialNumber = value;
                var args = new PropertyChangedEventArgs(nameof(SerialNumber));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Site
        {
            get => site;
            set
            {
                site = value;
                var args = new PropertyChangedEventArgs(nameof(Site));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string Item_
        {
            get => item_;
            set
            {
                item_ = value;
                var args = new PropertyChangedEventArgs(nameof(Item_));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                var args = new PropertyChangedEventArgs(nameof(Description));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public byte CreatedOnHH
        {
            get => createdOnHH;
            set
            {
                createdOnHH = value;
                var args = new PropertyChangedEventArgs(nameof(CreatedOnHH));
                PropertyChanged?.Invoke(this, args);
            }
        }

        async void getListInventoryItem()
        {
            AllInventory = new List<InventoryItem>();
            InventoryDatabaseController inventorydatabasecontroller = new InventoryDatabaseController();
            AllInventory = await inventorydatabasecontroller.GetAllInventory();
        }

        async void getListSites()
        {
            AllSites = new List<Sites>();
            SitesDatabaseController sitesdatabasecontroller = new SitesDatabaseController();
            AllSites = await sitesdatabasecontroller.GetAllSites();
        }

        async void getListItem()
        {
            AllItems = new List<Item>();
            ItemDatabaseController itemdatabasecontroller = new ItemDatabaseController();
            AllItems = await itemdatabasecontroller.GetAllItem();
        }

        // le constructeur ici
        public InventoryViewModel()
        {
            InventoryDatabaseController inventorydatabasecontroller = new InventoryDatabaseController();
            getListInventoryItem();
            getListSites();
            getListItem();

            AddInventory = new Command(async () =>
            {
                if (SiteSelected != null && ItemSelected != null && LocationSelected != null)
                {
                    Site = SiteSelected.Site;
                    Item_ = ItemSelected.Item_;
                    BinLoc = LocationSelected.BinLoc;

                    if (AssetNo != null && BinLoc != null && Site != null && Item_ != null && AssetNo != "" && BinLoc != "" && Site != "" && Item_ != "")
                    {
                        inventory = new Inventory(AssetNo, BinLoc, Site, Item_, CreatedOnHH, SerialNumber);
                        Inventory = inventory;
                        if (inventorydatabasecontroller.SaveInventory(Inventory).Result > 0)
                        {
                            await Application.Current.MainPage.DisplayAlert("Add", "Add Succes ", "Ok");
                            AllInventory = await inventorydatabasecontroller.GetAllInventory();
                            Application.Current.MainPage = new InventoryList();
                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Add", "Add Echec ", "Ok");
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Add", "Add Echec, empty Information ", "Ok");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Add", "Add Echec, empty Information ", "Ok");

            }
           );

            DeleteInventory = new Command(async (parameter) =>
            {
                inventorySelected = (Inventory)parameter;
                InventorySelected = inventorySelected;
                AssetNo = InventorySelected.AssetNo;
                BinLoc = InventorySelected.BinLoc;
                Site = InventorySelected.Site;
                Item_ = InventorySelected.Item_;
                CreatedOnHH = InventorySelected.CreatedOnHH;
                serialNumber = InventorySelected.SerialNumber;
                if (InventorySelected.AssetNo != null && inventorydatabasecontroller.GetInventoryById(InventorySelected.AssetNo) != null)
                {
                    if (inventorydatabasecontroller.DeleteInventory(InventorySelected.AssetNo).Result > 0)
                    {
                        await Application.Current.MainPage.DisplayAlert("Delete", "Delete Succes ", "Ok");
                        AssetNo = "";
                        BinLoc = "";
                        Site = "";
                        Item_ = "";
                        serialNumber = "";
                        CreatedOnHH = 0;
                        siteSelected = new Sites();
                        SiteSelected = siteSelected;
                        inventory = new Inventory();
                        Inventory = inventory;
                        inventorySelected = new Inventory();
                        InventorySelected = inventory;
                        AllInventory = await inventorydatabasecontroller.GetAllInventory();
                        Application.Current.MainPage = new InventoryList();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Delete", "Delete Echec ", "Ok");
                    }
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Delete", "Delete Echec, empty Information ", "Ok");
            }
           );
        }
        //l'entet de commande ici  
        public Command AddInventory { get; set; }
        public Command DeleteInventory { get; set; }
    }
}


