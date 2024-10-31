using HudControls;
using System.Windows;
using System.Windows.Input;
using Timer = System.Timers.Timer;

namespace Torito;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Timer mtimer = new Timer()
        {
            Enabled = true,
            Interval = 25,
        };

        mtimer.Elapsed += (s, e) =>
        {
            Dispatcher.Invoke(() =>
            {
                // Update the needle value
                this.Gauge.Value++;

                if (this.Gauge.Value > this.Gauge.MaxValue)
                    this.Gauge.Value = 0;

                this.VerticalGaugeA.Value++;
                if (this.VerticalGaugeA.Value > this.VerticalGaugeA.MaxValue)
                    this.VerticalGaugeA.Value = 0;
            });
        };

        var mtimer2 = new Timer()
        {
            Enabled = true,
            Interval = 3000,
        };

        mtimer2.Elapsed += (s, e) =>
        {
            Dispatcher.Invoke(() =>
            {
                this.MasterCaution.IsOn = !this.MasterCaution.IsOn;
            });
        };

        var mtimer3 = new Timer()
        {
            Enabled = true,
            Interval = 1500,
        };

        mtimer3.Elapsed += (s, e) =>
        {
            Dispatcher.Invoke(() =>
            {
                this.LED.State += 1;
                if (this.LED.State > LedState.Success)
                    this.LED.State = LedState.Error;
            });
        };

        var mtimer4 = new Timer()
        {
            Enabled = true,
            Interval = 2000,
        };

        mtimer4.Elapsed += (s, e) =>
        {
            Dispatcher.Invoke(() =>
            {
                this.LED0.State += 1;
                if (this.LED0.State > LedState.Success)
                    this.LED0.State = LedState.Error;
            });
        };

        var mtimer5 = new Timer()
        {
            Enabled = true,
            Interval = 2500,
        };

        mtimer5.Elapsed += (s, e) =>
        {
            Dispatcher.Invoke(() =>
            {
                this.LED1.State += 1;
                if (this.LED1.State > LedState.Success)
                    this.LED1.State = LedState.Error;
            });
        };

        var mtimer7 = new Timer()
        {
            Enabled = true,
            Interval = 3500,
        };

        mtimer7.Elapsed += (s, e) =>
        {
            Dispatcher.Invoke(() =>
            {
                this.LED3.State += 1;
                if (this.LED3.State > LedState.Success)
                    this.LED3.State = LedState.Error;
            });
        };
    }

    private void Window_StateChanged(object sender, EventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            this.WindowStyle = WindowStyle.None;
        }
    }

    private void ToggleSwitch_OnToggle(object sender, MouseButtonEventArgs e)
    {
        if (sender is ToggleSwitch ts)
        {
            this.LaunchButton.IsReady = ts.SwitchState;
        }
    }
}