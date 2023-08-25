using FixedAssets_BarCode.Data;
using FixedAssets_BarCode.Models.Models;
namespace FixedAssets_BarCode.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class UploadList : ContentPage
{
    public UploadList()
    {
        InitializeComponent();
        UploadDatabaseController uploadDatabaseController = new UploadDatabaseController();
        listViewUploads.ItemsSource = uploadDatabaseController.GetAllUpload().Result;
        Title = "Uploads";
        Btn_Delete_All.Clicked += (s, e) => Btn_Delete_All_Clicked(s, e);
        Btn_Delete_One.Clicked += (s, e) => Btn_Delete_One_Clicked(s, e);
        txt_search.TextChanged += (s, e) => OnTxtChanged(s, e);
    }

    async void Btn_Delete_All_Clicked(object sender, EventArgs e)
    {
        if (listViewUploads != null && listViewUploads.ItemsSource != null && ((List<Upload>)listViewUploads.ItemsSource).Count > 0)
        {
            var action = await DisplayAlert("Exit?", " Êtes - vous sûr d'enregistrer et de fermer l'application ", "Oui", "Non");
            if (action)
            {
                UploadDatabaseController uploadDatabaseController = new UploadDatabaseController();
                int x = await uploadDatabaseController.DeleteAllUpload();
                if (x > 0)
                {
                    ((List<Upload>)listViewUploads.ItemsSource).Clear();
                    listViewUploads.ItemsSource = uploadDatabaseController.GetAllUpload().Result;
                }
            }
        }
    }

    async void Btn_Delete_One_Clicked(object sender, EventArgs e)
    {
        if (listViewUploads != null && listViewUploads.ItemsSource != null && ((List<Upload>)listViewUploads.ItemsSource).Count > 0 && listViewUploads.SelectedItem != null)
        {
            var action = await DisplayAlert("Exit?", " Êtes - vous sûr d'enregistrer et de fermer l'application ", "Oui", "Non");
            if (action)
            {
                UploadDatabaseController uploadDatabaseController = new UploadDatabaseController();
                Upload upload = ((Upload)listViewUploads.SelectedItem);
                int x = await uploadDatabaseController.DeleteUpload(upload.TransID);
                if (x > 0)
                {
                    ((List<Upload>)listViewUploads.ItemsSource).Remove(upload);
                    uploadDatabaseController = new UploadDatabaseController();
                    listViewUploads.ItemsSource = uploadDatabaseController.GetAllUpload().Result;
                    listViewUploads.SelectedItem = null;
                }
            }
        }
    }

    public async void lstchanged(string keyword)
    {
        UploadDatabaseController uploadDatabaseController = new UploadDatabaseController();

        if (keyword == "")
        {
            listViewUploads.ItemsSource = await uploadDatabaseController.GetAllUpload();
        }
        else
        {
            //List<InventoryItem> lst = new List<InventoryItem>();
            int nbr = uploadDatabaseController.GetCountUploadByIdSearch(keyword);
            if (nbr > 0)
            {
                listViewUploads.ItemsSource = await uploadDatabaseController.GetUploadByIdSearch(keyword);
            }
            else
            {
                listViewUploads.ItemsSource = new List<Upload>();
            }
        }
    }
    void OnTxtChanged(object sender, EventArgs ea)
    {
        var keyword = txt_search.Text;
        if (keyword != null)
            lstchanged(keyword);
    }
}