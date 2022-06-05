namespace vpkp.ViewModels.StaticTableCreateRowViewModels
{
    public class CityViewModel : ViewModelBase
    {
        public CityViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            City = new vpkp.Models.Database.City();
        }
        public vpkp.Models.Database.City City { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}
