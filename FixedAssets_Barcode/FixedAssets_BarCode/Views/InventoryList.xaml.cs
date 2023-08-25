using FixedAssets_BarCode.Data;
using FixedAssets_BarCode.Models.Models;
using FixedAssets_BarCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssets_BarCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryList : TabbedPage
    {
        private InventoryListModel viewmodel;
        private bool Change { get; set; } = false;
        private InventoryDatabaseController inventoryDatabaseController = new InventoryDatabaseController();
        private LocationDatabaseController locationDatabaseController = new LocationDatabaseController();
        public static List<InventoryItem> ListInv { get; set; } = new List<InventoryItem>();
        public InventoryList()
        {
            InitializeComponent();
            BindingContext = viewmodel = new InventoryListModel();
            Title = "Inventaire";
            searchResultsBinLoc.SelectionChanged += (s, e) => OnListViewLocationItemSelected(s, e);
            searchResultsSite.SelectionChanged += (s, e) => OnListViewSiteItemSelected(s, e);
            txt_search.TextChanged += (s, e) => OnTxtChanged(s, e);
            Picker_Etat.SelectionChanged += (s, e) => Picker_Etat_SelectedIndexChanged(s, e);

        }
        public InventoryList(string ch)
        {
            listView.ItemsSource = new List<InventoryItem>();
        }
        async void OnListViewLocationItemSelected(object sender, EventArgs e)
        {
            ////if (((Xamarin.Forms.Picker)sender).SelectedItem != null)
            ////{
            ////    listView.ItemsSource = await inventoryDatabaseController.GetListInventoryBySiteBinLoc(((Models.Models.Location)((Xamarin.Forms.Picker)sender).SelectedItem).Site, ((Location)((Xamarin.Forms.Picker)sender).SelectedItem).BinLoc);
            ////    Change = true;
            ////    List<InventoryItem> list = ((List<InventoryItem>)listView.ItemsSource);
            ////    ListInv = list;
            ////    var count = list.Count;
            ////    lbl_Count.Text = count + "";
            ////}
            if (((Picker)sender).SelectedItem != null)
            {
                listView.ItemsSource = await inventoryDatabaseController.GetListInventoryBySiteBinLoc(((Models.Models.Location)((Picker)sender).SelectedItem).Site, ((Models.Models.Location)((Picker)sender).SelectedItem).BinLoc);
                Change = true;
                List<InventoryItem> list = ((List<InventoryItem>)listView.ItemsSource);
                ListInv = list;
                var count = list.Count;
                lbl_Count.Text = count + "";
            }
        }


        void OnListViewSiteItemSelected(object sender, EventArgs e)
        {
            Change = false;
        }

        void Picker_Etat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entry_NSerie.IsEnabled = true;
            Entry_NSerie.Focus();
            btn_save.IsEnabled = true;
        }
       
        public static int maxSize { get; set; } = 0;
        public static ObservableCollection<TagItem> ListALLItems { get; set; } = new ObservableCollection<TagItem>();

        void lstAllItems_SizeChanged(object sender, EventArgs e)
        {

        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Entry_Immo.Focus();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void Btn_Filter_Site_Clicked(object sender, EventArgs e)
        {
        }

        private async void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var i = this.Children.IndexOf(this.CurrentPage);
            if (i == 0)
                this.CurrentPage = this.Children[i];
            else if (Change == false)
            {
                await App.Current.MainPage.DisplayAlert("Error", "You have to finish the page one before navigating this page", "Ok");
                this.CurrentPage = this.Children[0];
            }
            else
            {
                this.CurrentPage = this.Children[i];
            }
        }
        private void valider(object sender, EventArgs e)
        {
            
        }
        public void OnMore(object sender, EventArgs e)
        {

        }
        public int GetCountInventoryItemById(string keyword)
        {
            return ListInv.Where(i => i.AssetNo.ToLower().Contains(keyword.ToLower())).Count();
        }
        public async void lstchanged(string keyword)
        {
            if (keyword == "")
            {
                listView.ItemsSource = ListInv;
            }
            else
            {
                int nbr = GetCountInventoryItemById(keyword);
                if (nbr > 0)
                {
                    listView.ItemsSource =
                     ListInv.Where(i => i.AssetNo.ToLower().Contains(keyword.ToLower()));
                    var lstInventory = await inventoryDatabaseController.GetInventoryItemById(keyword);
                }
                else
                {
                    listView.ItemsSource = new List<InventoryItem>();
                }
            }
        }

        public int GetCountByInvID(string keyword)
        {
            return (ListALLItems).Where(i => i.InvID.ToLower().Contains(keyword.ToLower())).Count();
        }
        public void lstchanged2(string keyword)
        {

        }
        void OnTxtChanged(object sender, EventArgs ea)
        {
            var keyword = txt_search.Text;
            if (keyword != null)
                lstchanged(keyword);
        }
        private async void Entry_Immo_Completed(object sender, EventArgs e)
        {
            if (Entry_Immo != null && !String.IsNullOrWhiteSpace(Entry_Immo.Text))
            {
                InventoryDatabaseController inventoryDatabaseController = new InventoryDatabaseController();
                var numimmo = Entry_Immo.Text;
                if (inventoryDatabaseController.GetCountInventoryById(numimmo) == 0)
                {
                    var action = await DisplayAlert("Nouveau?", " Êtes - vous sûr de saisir un nouveau inventaire", "Oui", "Non");
                    if (action)
                    {
                        btn_save.IsEnabled = true;
                    }
                    else
                    {
                       // Entry_Immo.Text = "";
                       // Entry_Immo.Focus();
                    }
                }
                else
                {
                    var inv = await inventoryDatabaseController.GetInventoryById(numimmo);
                    ItemDatabaseController ItemDatabaseController = new ItemDatabaseController();
                    int index = ItemDatabaseController.GetIndexItemById(inv.Item_);
                    Picker_Disc.SelectedIndex = index;
                    Picker_Etat.IsEnabled = true;
                    btn_save.IsEnabled = true;
                }
            }
            else
                    btn_save.IsEnabled = false;
        }
        private void Entry_Immo_Focused(object sender, FocusEventArgs e)
        {
            Entry_Immo.BackgroundColor = Colors.Yellow;
        }

        private void Entry_Immo_Unfocused(object sender, FocusEventArgs e)
        {
            Entry_Immo.BackgroundColor = Colors.White;
        }

        private void Picker_Etat_Focused(object sender, FocusEventArgs e)
        {
            Picker_Etat.BackgroundColor = Colors.Yellow;
        }

        private void Picker_Etat_Unfocused(object sender, FocusEventArgs e)
        {
            Picker_Etat.BackgroundColor = Colors.White;
        }
        private void Entry_NSerie_Focused(object sender, FocusEventArgs e)
        {
            Entry_NSerie.BackgroundColor = Colors.Yellow;
        }

        private void Entry_NSerie_Unfocused(object sender, FocusEventArgs e)
        {
            Entry_NSerie.BackgroundColor = Colors.White;
        }

        void OnTxtChanged2(object sender, EventArgs ea)
        {

        }

        private void btn_cancel_Clicked(object sender, EventArgs e)
        {
            Entry_Immo.Focus();
        }

        private void btn_save_Clicked(object sender, EventArgs e)
        {
            Picker_Etat.IsEnabled = false;
            Entry_NSerie.IsEnabled = false;
            btn_save.IsEnabled = false;
            Picker_Disc.IsEnabled = false;
            listView.SelectedItem = new InventoryItem();
            Entry_Immo.Focus();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Entry_Immo.Text = ((InventoryItem)listView.SelectedItem).AssetNo;
        }

        private void Picker_Disc_Focused(object sender, FocusEventArgs e)
        {
            Picker_Disc.BackgroundColor = Colors.Yellow;
        }

        private void Picker_Disc_Unfocused(object sender, FocusEventArgs e)
        {
            Picker_Disc.BackgroundColor = Colors.White;
        }
        private async void Img_Button_Filter_Desc_Clicked(object sender, EventArgs e)
        {
            var desc = Picker_Disc.SelectedItem;
            Page page = (Page)Activator.CreateInstance(typeof(ListDesc), viewmodel, desc);
            await Navigation.PushAsync(page, false);
        }

        private void Picker_Disc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Picker_Disc.SelectedIndex != -1)
            {
                Picker_Etat.IsEnabled = true;
            }
        }

        private void listView_ItemSelected(object sender, DevExpress.Maui.DataGrid.DataGridGestureEventArgs e)
        {
            bool change = true;
            //Entry_Immo.Text = ((InventoryItem)listView.SelectedItem).AssetNo;
            if (listView.SelectedItem != null)
            {
                Entry_Immo.Text = ((InventoryItem)listView.SelectedItem).AssetNo;
            }
            else
            {
                change = false;
            }
        }
    }
}