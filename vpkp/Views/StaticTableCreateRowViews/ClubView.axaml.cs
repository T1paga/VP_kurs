using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using vpkp.ViewModels.StaticTableCreateRowViewModels;
using vpkp.ViewModels;

namespace vpkp.Views.StaticTableCreateRowViews
{
    public partial class ClubView : Window
    {
        public ClubView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("Confirm").Click += button_Confirm_Click;
            this.FindControl<Button>("Cancel").Click += button_Cancel_Click;
        }
        public ClubView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new ClubViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void button_Confirm_Click(object? sender, RoutedEventArgs e)
        {
            var dc = (this.DataContext as ClubViewModel);
            dc.MainContext.Data.Clubs.Add(dc.Club);
            dc.MainContext.Data.SaveChanges();
            this.Close();
        }
        private void button_Cancel_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}