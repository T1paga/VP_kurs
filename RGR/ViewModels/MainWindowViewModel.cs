using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive.Linq;
using RGR.Models;

namespace RGR.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateTabs();
            CreateGrid();
            CreateRequests();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
        }

        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }

        ObservableCollection<Tabs> tab;
        public ObservableCollection<Tabs> Tab
        {
            get { return tab; }
            set { this.RaiseAndSetIfChanged(ref tab, value); }
        }
        private void CreateTabs()
        {
            Tab = new ObservableCollection<Tabs>();
            Tab.Add(new Tabs("Players", false));
            Tab.Add(new Tabs("Team", false));
            Tab.Add(new Tabs("Match", false));
            Tab.Add(new Tabs("Statist's match", false));
            Tab.Add(new Tabs("Statist's players", false));
            Tab.Add(new Tabs("Transfers", false));
            Tab.Add(new Tabs("Request 1", false));
            Tab.Add(new Tabs("Request 2", false));
        }

        ObservableCollection<Tabs> request;
        public ObservableCollection<Tabs> Request
        {
            get { return request; }
            set { this.RaiseAndSetIfChanged(ref request, value); }
        }

        private void CreateRequests()
        {
            Request = new ObservableCollection<Tabs>();
            Request.Add(new Tabs("Request 1", true));
            Request.Add(new Tabs("Request 2", true));
        }

        ObservableCollection<Grids> grid;
        public ObservableCollection<Grids> Grid
        {
            get { return grid; }
            set { this.RaiseAndSetIfChanged(ref grid, value); }
        }
        private void CreateGrid()
        {
            Grid = new ObservableCollection<Grids>();
            Grid.Add(new Grids("1", "12", "F", "41", "20", "21", "42", "8"));
            Grid.Add(new Grids("2", "22", "F", "42", "10", "32", "42", "7"));
            Grid.Add(new Grids("3", "11", "F", "43", "18", "25", "42", "-1"));
            Grid.Add(new Grids("4", "1", "D", "11", "0", "11", "42", "11"));
            Grid.Add(new Grids("5", "8", "D", "21", "10", "11", "42", "-4"));
            Grid.Add(new Grids("6", "16", "D", "31", "20", "11", "42", "2"));
            Grid.Add(new Grids("7", "41", "D", "1", "1", "1", "42", "2"));
            Grid.Add(new Grids("8", "7", "G", "1", "1", "1", "42", "1"));
        }
    }
}
