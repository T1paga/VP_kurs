namespace vpkp.ViewModels.StaticTableCreateRowViewModels
{
    public class MatchViewModel : ViewModelBase
    {
        public MatchViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            Match = new vpkp.Models.Database.Match();
        }
        public vpkp.Models.Database.Match Match { get; set; }
        public MainWindowViewModel? MainContext { get; set; }
    }
}
