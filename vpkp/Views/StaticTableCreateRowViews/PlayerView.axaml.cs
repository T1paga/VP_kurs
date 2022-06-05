using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using vpkp.ViewModels;
using vpkp.ViewModels.StaticTableCreateRowViewModels;

namespace vpkp.Views.StaticTableCreateRowViews
{
    public partial class PlayerView : Window
    {
        public PlayerView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("Confirm").Click += button_Confirm_Click;
            this.FindControl<Button>("Cancel").Click += button_Cancel_Click;
        }
        public PlayerView(MainWindowViewModel? mainContext) : this()
        {
            this.DataContext = new PlayerViewModel(mainContext);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void button_Confirm_Click(object? sender, RoutedEventArgs e)
        {
            var dc = (this.DataContext as PlayerViewModel);
            dc.MainContext.Data.Players.Add(dc.Player);
            dc.MainContext.Data.SaveChanges();
            this.Close();
        }
        private void button_Cancel_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}