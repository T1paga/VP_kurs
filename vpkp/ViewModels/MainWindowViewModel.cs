using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using vpkp.Models;
using vpkp.Models.Database;
using vpkp.Models.StaticTabs;

namespace vpkp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateContext();
            CreateTabs();
            CreateQueries();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }
        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }
        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
            else throw new InvalidOperationException();
        }

        ObservableCollection<MyTab> tabs;
        public ObservableCollection<MyTab> Tabs
        {
            get { return tabs; }
            set { this.RaiseAndSetIfChanged(ref tabs, value); }
        }

        ObservableCollection<Query> queries;
        public ObservableCollection<Query> Queries
        {
            get { return queries; }
            set { this.RaiseAndSetIfChanged(ref queries, value); }
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        NBA1Context data;

        public NBA1Context Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new NBA1Context();
        }

        private void CreateTabs()
        {
            Tabs = new ObservableCollection<MyTab>();
            Tabs.Add(new CityTab("City", Data.Cities));
            Tabs.Add(new ClubTab("Club", Data.Clubs));
            Tabs.Add(new MatchTab("Match", Data.Matches));
            Tabs.Add(new MatchStatisticTab("MatchStatistic", Data.MatchStatistics));
            Tabs.Add(new PlayerTab("Player", Data.Players));
            Tabs.Add(new PlayerStatisticInMatchTab("PlayerStatisticInMatch", Data.PlayerStatisticInMatches));
        }
        private void CreateQueries()
        {
            Queries = new ObservableCollection<Query>();
        }
    }
}
