using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using vpkp.ViewModels;
using vpkp.ViewModels.StaticTableCreateRowViewModels;

namespace vpkp.Views.StaticTableCreateRowViews
{
    public partial class MatchStatisticView : Window
    {
        public MatchStatisticView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("Confirm").Click += button_Confirm_Click;
            this.FindControl<Button>("Cancel").Click += button_Cancel_Click;
        }
        public MatchStatisticView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new MatchStatisticViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void button_Confirm_Click(object? sender, RoutedEventArgs e)
        {
            var dc = (this.DataContext as MatchStatisticViewModel);
            dc.MainContext.Data.MatchStatistics.Add(dc.MatchStatistic);
            dc.MainContext.Data.SaveChanges();
            this.Close();
        }
        private void button_Cancel_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}