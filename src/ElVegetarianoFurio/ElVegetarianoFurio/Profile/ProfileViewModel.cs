using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ElVegetarianoFurio.Profile;

[INotifyPropertyChanged]
public partial class ProfileViewModel
{

    [ObservableProperty]
    private string _city = string.Empty;

    [ObservableProperty]
    private string _fullName = string.Empty;

    [ObservableProperty]
    private string _phone = string.Empty;

    [ObservableProperty]
    private string _street = string.Empty;

    [ObservableProperty]
    private string _zip = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

    public async Task Initialize()
    {
        IsBusy = true;
        await Task.Delay(3000);
        IsBusy = false;
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        IsBusy = true;
        await Task.Delay(3000);
        IsBusy = false;
    }

    private bool CanSave()
    {
        return !IsBusy;
    }
}
