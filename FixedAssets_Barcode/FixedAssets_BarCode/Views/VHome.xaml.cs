namespace FixedAssets_BarCode.Views;

public partial class VHome : ContentPage
{
	public VHome()
	{
		InitializeComponent();
	}

    private async void OnInventoryList()
    {
        await Navigation.PushAsync(new InventoryList(), false);
    }
    private async void OnUploadList()
    {
        await Navigation.PushAsync(new UploadList(), false);
    }

    private async void OnSetting()
    {
        await Navigation.PushAsync(new VSetting(), false);
    }
    private void OnLogOut()
    {
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }



    private void BTN_Inventaire_Clicked(object sender, EventArgs e)
    {
        OnInventoryList();
    }

    private void Btn_LogOut_Clicked(object sender, EventArgs e)
    {
        OnLogOut();
    }

    private void imgbtn_ListUploads_Clicked(object sender, EventArgs e)
    {
        OnUploadList();
    }

    private void Btn_Setting_Clicked(object sender, EventArgs e)
    {
        OnSetting();
    }
}