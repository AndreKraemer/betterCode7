using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.Menu;
using System.Collections.ObjectModel;


namespace ElVegetarianoFurio;

[INotifyPropertyChanged]
public partial class MainViewModel
{
    private IDataService _dataService;

    [ObservableProperty]
    private bool _isBusy = false;

    public ObservableCollection<Category> Categories { get; } =
  new ObservableCollection<Category>();

    public MainViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    


    [RelayCommand]
    private async Task LoadData()
    {
        try
        {
            IsBusy = true;
            Categories.Clear();
            var categories = await _dataService.GetCategoriesAsync();

            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task Initialize()
    {
        await LoadData();
    }

}
