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
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private bool _isBusy;
    private readonly IProfileService _service;

    public ProfileViewModel(IProfileService service)
    {
        _service = service;
    }

    public async Task Initialize()
    {
        try
        {
            IsBusy = true;
            var profile = await _service.GetAsync();
            FullName = profile.FullName;
            Street = profile.Street;
            Zip = profile.Zip;
            City = profile.City;
            Phone = profile.Phone;
        }
        finally
        {
            await Task.Delay(3000); // Nur zu Demozwecken!
            IsBusy = false;
        }
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        try
        {
            IsBusy = true;
            var profile = new Profile
            {
                FullName = FullName,
                Street = Street,
                Zip = Zip,
                City = City,
                Phone = Phone
            };

            await _service.SaveAsync(profile);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private bool CanSave()
    {
        return !IsBusy;
    }
}
