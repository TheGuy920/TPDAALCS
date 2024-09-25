using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using ToritoLaunchControl.Controls;
using ToritoLaunchControl.Models;
using Timer = System.Timers.Timer;

namespace ToritoLaunchControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MainGraph.Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinHeight = Math.Max(this.ActualHeight + 500, 500);
            this.MinWidth = Math.Max(this.ActualWidth, 1000);

            this.LoadTanks();
            this.LoadDashboard();


            this.SizeToContent = SizeToContent.Manual;
            this.Height = 1080 / 2;
            this.Width = 1920 / 2;
            this.CenterWindowOnScreen();
            (this.Content as Grid).RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.ActualWidth;
            double windowHeight = this.ActualHeight;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void LoadDashboard()
        {
            this.AddElementToPanel(new UiControls());
        }

        private void LoadTanks()
        {
            GraphViewModel gmodel = (GraphViewModel)MainGraph.DataContext;
            PlotModel model = gmodel.Model;
            var series = new List<LineSeries>();

            for (int i = 0; i < 2; i++)
            {
                var tank = new LiquidStorageTank(i, 100);
                this.AddElementToPanel(tank);
                var line = new LineSeries()
                {
                    InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline,
                    MarkerType = MarkerType.None,
                    Title = $"Tank {i}",
                    XAxisKey = "Time",
                    YAxisKey = "Flow Rate",
                    Background = OxyColors.Transparent,
                    Points = { new DataPoint(0, 0) },
                };
                model.Series.Add(line);
                series.Add(line);
            }
        }

        private void AddElementToPanel(UIElement element)
        {
            this.BottomPanel.Children.Add(element);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
        }
    }
}