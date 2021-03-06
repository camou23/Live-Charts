﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart
{
    /// <summary>
    /// Interaction logic for StackedLine.xaml
    /// </summary>
    public partial class StackedAreaExample : UserControl
    {
        public StackedAreaExample()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(6),
                        new ObservableValue(2)
                    },
                    DataLabels = true
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(4),
                        new ObservableValue(1),
                        new ObservableValue(7),
                        new ObservableValue(9)
                    },
                    DataLabels = true
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(2),
                        new ObservableValue(8),
                        new ObservableValue(2),
                        new ObservableValue(9)
                    },
                    DataLabels = true
                }
            };

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public StackMode StackMode { get; set; }

        private void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            foreach (var series in SeriesCollection)
            {
                foreach (var observable in series.Values.Cast<ObservableValue>())
                {
                    observable.Value = r.Next(1, 10);
                }
            }
        }

        private void ChangeStackModeOnClick(object sender, RoutedEventArgs e)
        {
            foreach (var series in SeriesCollection.Cast<StackedAreaSeries>())
            {
                series.StackMode = series.StackMode == StackMode.Percentage
                    ? StackMode.Values
                    : StackMode.Percentage;
            }
        }
    }
}
