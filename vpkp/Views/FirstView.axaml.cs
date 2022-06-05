using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using vpkp.Models;
using vpkp.Models.StaticTabs;
using vpkp.ViewModels;
using vpkp.Views.StaticTableCreateRowViews;
using vpkp.Models.Database;

namespace vpkp.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            this.Find<DataGrid>("DataTable").AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            this.FindControl<TabControl>("DataTabs").SelectionChanged += tabControl_SelectionChanged;
            this.FindControl<Button>("NewString").Click += button_NewString_Click;
            this.FindControl<Button>("RemoveString").Click += button_RemoveString_Click;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void changeDataGridItems()
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            if (selectedTab != null)
            {
                if (selectedTab is DynamicTab)
                {
                    var selectedItems = (selectedTab as DynamicTab).ObjectList;
                    if (selectedItems != null)
                        this.Find<DataGrid>("DataTable").Items = selectedItems;
                }
                else
                {
                    if (selectedTab is CityTab)
                    {
                        var selectedItems = (selectedTab as CityTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is ClubTab)
                    {
                        var selectedItems = (selectedTab as ClubTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is MatchTab)
                    {
                        var selectedItems = (selectedTab as MatchTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is MatchStatisticTab)
                    {
                        var selectedItems = (selectedTab as MatchStatisticTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is PlayerTab)
                    {
                        var selectedItems = (selectedTab as PlayerTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is PlayerStatisticInMatchTab)
                    {
                        var selectedItems = (selectedTab as PlayerStatisticInMatchTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else throw new System.ArgumentException();
                }
            }
        }
        private void refreshDataGridItems()
        {
            this.Find<DataGrid>("DataTable").Items = null;
            changeDataGridItems();
        }
        private void tabControl_SelectionChanged(object? sender,
           SelectionChangedEventArgs e)
        {
            changeDataGridItems();
        }
        private void dataGrid_AutoGeneratingColumn(object? sender,
        DataGridAutoGeneratingColumnEventArgs e)
        {
            var tab = (this.FindControl<TabControl>("DataTabs").SelectedItem as MyTab);
            if (!tab.DataColumns.Contains(e.Column.Header.ToString()))
                e.Column.IsVisible = false;
        }

        async private void button_NewString_Click(object? sender, RoutedEventArgs e)
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            Window window;
            if (selectedTab != null)
            {
                if (selectedTab is CityTab)
                {
                    window = new CityView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is ClubTab)
                {
                    window = new ClubView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is MatchTab)
                {
                    window = new MatchView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is MatchStatisticTab)
                {
                    window = new MatchStatisticView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is PlayerTab)
                {
                    window = new PlayerView((this.DataContext as FirstViewModel).MainContext);
                }
                else if (selectedTab is PlayerStatisticInMatchTab)
                {
                    window = new PlayerStatisticInMatchView((this.DataContext as FirstViewModel).MainContext);
                }
                else throw new System.ArgumentException();
                await window.ShowDialog((Window)this.VisualRoot);
                refreshDataGridItems();
            }
        }
        private void button_RemoveString_Click(object? sender, RoutedEventArgs e)
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            var dgItem = this.Find<DataGrid>("DataTable").SelectedItem;
            if (selectedTab != null && dgItem != null)
            {
                if (selectedTab is CityTab)
                {
                    (selectedTab as CityTab).DBS.Remove(dgItem as City);
                }
                else if (selectedTab is ClubTab)
                {
                    (selectedTab as ClubTab).DBS.Remove(dgItem as Club);
                }
                else if (selectedTab is MatchTab)
                {
                    (selectedTab as MatchTab).DBS.Remove(dgItem as Match);
                }
                else if (selectedTab is MatchStatisticTab)
                {
                    (selectedTab as MatchStatisticTab).DBS.Remove(dgItem as MatchStatistic);
                }
                else if (selectedTab is PlayerTab)
                {
                    (selectedTab as PlayerTab).DBS.Remove(dgItem as Player);
                }
                else if (selectedTab is PlayerStatisticInMatchTab)
                {
                    (selectedTab as PlayerStatisticInMatchTab).DBS.Remove(dgItem as PlayerStatisticInMatch);
                }
                else throw new System.ArgumentException();
                (this.DataContext as FirstViewModel).MainContext.Data.SaveChanges();
                refreshDataGridItems();
            }
        }
    }
}