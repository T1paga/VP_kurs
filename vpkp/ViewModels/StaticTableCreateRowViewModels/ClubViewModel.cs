namespace vpkp.ViewModels.StaticTableCreateRowViewModels
{
    public class ClubViewModel : ViewModelBase
    {
        public ClubViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            Club = new vpkp.Models.Database.Club();
        }
        public vpkp.Models.Database.Club Club { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}
