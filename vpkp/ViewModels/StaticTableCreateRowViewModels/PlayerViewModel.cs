namespace vpkp.ViewModels.StaticTableCreateRowViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            Player = new vpkp.Models.Database.Player();
        }
        public vpkp.Models.Database.Player Player { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}
