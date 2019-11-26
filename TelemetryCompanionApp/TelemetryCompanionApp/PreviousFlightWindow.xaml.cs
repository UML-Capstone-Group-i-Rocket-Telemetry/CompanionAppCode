using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using LiveCharts;
using LiveCharts.Wpf;

namespace TelemetryCompanionApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowPrevFlight : Window
    {
        //Array corresponds to time
        public String FileName { get; set; }
        //Refresh Rate of DataGrid
        public int RefreshRate { get; set; }
        //Timer
        public System.Windows.Threading.DispatcherTimer Timer{ get; set; }

        public WindowPrevFlight()
        {
            InitializeComponent();
            this.RefreshRate = 0;
            this.Timer = SetTimer();
        }

        protected SeriesCollection seriesCollectionLeft = new SeriesCollection {
            new LineSeries
            {
                Values = new ChartValues<LiveCharts.Defaults.ObservablePoint> { }
            },
        };

        //Refreshes grid data on timer tick
        protected void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(Option1.IsSelected == true)
            {
                this.RefreshRate = 0;
            } 
            else if (Option2.IsSelected == true) 
            {
                this.RefreshRate = 2;
            }
            else if (Option3.IsSelected == true)
            {
                this.RefreshRate = 5;
            }
            else if (Option4.IsSelected == true)
            {
                this.RefreshRate = 10;
            }
            else if (Option5.IsSelected == true)
            {
                this.RefreshRate = 30;
            }
            this.Timer.Interval = new TimeSpan(0, 0, this.RefreshRate);
            if (this.RefreshRate != 0)
            {
                RebindData();
            }
        }

        //Get data and bind to the grid
        private void RebindData()
        {
            if (this.FileName != null)
            {
                List<TelemetryData> dataFromCSV = TelemetryData.ReadFile(this.FileName);
                dataGrid.ItemsSource = dataFromCSV;
                ResetCharts();
                for (int i = 0; i < dataFromCSV.Count; i++)
                {
                    seriesCollectionLeft[0].Values.Add(new LiveCharts.Defaults.ObservablePoint(dataFromCSV[i].Time, dataFromCSV[i].Velocity));
                }
                leftGraph.Series = seriesCollectionLeft;
            }
        }

        //Set and start the timer
        private System.Windows.Threading.DispatcherTimer SetTimer()
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, this.RefreshRate);
            dispatcherTimer.Start();
            return dispatcherTimer;
        }

        //Open file browser to select flight file
        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) { 
                this.FileName = openFileDialog.FileName;
                RebindData();
            }
        }

        private void ResetCharts()
        {
            seriesCollectionLeft[0].Values = new ChartValues<LiveCharts.Defaults.ObservablePoint> { };
        }
    }
}
