using FixedAssets_BarCode.Models.Models;
using FixedAssets_BarCode.ViewModels;
using FixedAssets_BarCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssets_BarCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDesc : ContentPage
    {
        public ListDesc()
        {
            InitializeComponent();
        }

        public static List<Item> ListItem { get; set; } = new List<Item>();
        public static Item MyItem { get; set; } = new Item();
        public static bool Close { get; set; } = false;
        //on va faire les initialisation suivant avec les valeurs de la page  inventaire
        public ListDesc(InventoryListModel inventoryListModel, Item Item)
        {
            //on faire cette valeur sur false car le compilateur compile la méthode listDesc_ItemSelected la premiére méthode et si on a exécute la méthode OnDisappearing la valeur close sera true et il ne va pas exécute la méthode listDesc_ItemSelected  donc on initialise close avec false.
            Close = false;
            InitializeComponent();
            BindingContext = inventoryListModel;
            List<Item> list = ((List<Item>)listDesc.ItemsSource);
            ListItem = list;
            MyItem = Item;
        }

        //cette méthode fonctionne a chaque fois la page apparait
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        //on va changer la liste avec le contenu de txt_search si on n'écrit rien la liste sera chargée une autre fois c'est on écrit de donées n'existe pas dans la base la liste sera vide
        public async void lstchanged(string keyword)
        {
            if (keyword == "")
            {
                listDesc.ItemsSource = ListItem;
            }
            else
            {
                ItemDatabaseController ItemDatabaseController = new ItemDatabaseController();
                int nbr = ItemDatabaseController.GetItemByDescrip(keyword);
                if (nbr > 0)
                {
                    listDesc.ItemsSource =
                     ListItem.Where(i => i.Description.ToLower().Contains(keyword.ToLower()));
                }
                else
                {
                    listDesc.ItemsSource = new List<Item>();
                }
            }
        }

        //cette méthode fonctionne a chaque fois quand on quitte la page avec une condition si la valeur sélectionner quand on quitte null changer la valeur MyItem de la page Inventaire qui est changé dans le constrecture on faire cétte opération pour ne perdre pas aucune donnée. 
        protected override void OnDisappearing()
        {
            var selc = listDesc.SelectedItem;
            if (selc == null)
            {
                //je faire cette initialisation pour faire un appele indirecte a méthode txt_search_TextChanged et initialiser la liste des Items avec tous les données existe dans la bdd
                txt_search.Text = "";
                listDesc.IsVisible = false;
                if (selc == null)
                {
                    selc = MyItem;
                    Close = true;
                    //la liste est maintenant chargée comme le début donc on peut metrre la valeur sélectionner avec succée
                    listDesc.SelectedItem = selc;
                    //on va fiare une animation lors de quitter la page
                    base.OnDisappearing();
                    // this.Animate("anim", (s) => Layout(new Rectangle((s * Width) * -1, Y, Width, Height)), 16, 600, Easing.Linear, null, null);
                }
            }
            else
            {
                base.OnDisappearing();
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            listDesc.SelectedItem = stackLayout.BindingContext;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            listDesc.SelectedItem = stackLayout.BindingContext;
            var selc = listDesc.SelectedItem;
            if (selc != null && Close == false)
            {
                await Navigation.PopAsync();
            }
            else if (selc == null)
            {
            }
        }

        private void txt_search_Focused(object sender, FocusEventArgs e)
        {
            txt_search.BackgroundColor = Colors.Yellow;
        }

        private void txt_search_Unfocused(object sender, FocusEventArgs e)
        {
            txt_search.BackgroundColor = Colors.White;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            var keyword = txt_search.Text;
            lstchanged(keyword);
        }

        private async void listDesc_ItemSelected(object sender, DevExpress.Maui.DataGrid.DataGridGestureEventArgs e)
        {
            var selc = listDesc.SelectedItem;
            if (selc != null && Close == false)
            {
                var entry = listDesc.SelectedItem;
                await Navigation.PopAsync();
            }
        }
        //private async void listDesc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var selc = listDesc.SelectedItem;
        //    if (selc != null && Close == false)
        //    {
        //        await Navigation.PopAsync();
        //    }
        //    else if (selc == null)
        //    {
        //    }
        //    var selc = listDesc.SelectedItem;
        //        if (selc != null && Close == false)
        //        {
        //            // listDesc.SelectedItem = ub;
        //            var entry = listDesc.SelectedItem;
        //    await Navigation.PopAsync();
        //}
        //}
    }
}