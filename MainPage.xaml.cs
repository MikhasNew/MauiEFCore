using EntityFremworkHelper.Context;
using System.Data.Common;

namespace MauiEFCore;

public partial class MainPage : ContentPage
{
    int count = 0;

    public  MainPage()
    {
        InitializeComponent();
        _ = DbAdapter.LoadDataFromDb();

    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        _ = DbAdapter.AddDataItem(new EntityFremworkHelper.Models.DataItem { Name = $"name {count}" });
        DataItemCountinBd.Text = "DataItem in BD "+ DbAdapter.DataItemsList.Count;
        SemanticScreenReader.Announce(DataItemCountinBd.Text);
    }
}

