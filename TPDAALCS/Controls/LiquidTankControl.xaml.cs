using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TPDAAC.Controls;
/// <summary>
/// Interaction logic for LiquidTankControl.xaml
/// </summary>
public partial class LiquidTankControl : UserControl
{
    const int DANGER_TEMP = -20;
    const int DANGER_PRESSURE = 100;
    const int DANGE_RATE = 16;

    // level
    public static readonly DependencyProperty LiquidLevelProperty = DependencyProperty.Register("LiquidLevel", typeof(double), typeof(LiquidTankControl), new PropertyMetadata(0.0));
    public double LiquidLevel
    {
        get { return this.Dispatcher.Invoke(() => (double)GetValue(LiquidLevelProperty)); }
        set
        {
            this.Dispatcher.Invoke(() =>
            {
                SetValue(LiquidLevelProperty, value);
                this.ProgressBar?.SetValue(ProgressBar.ValueProperty, value / this.MaxFluidLevel);
            });
        }
    }

    // temperature
    public static readonly DependencyProperty TemperatureProperty = DependencyProperty.Register("Temperature", typeof(double), typeof(LiquidTankControl), new PropertyMetadata(0.0));
    private readonly SolidColorBrush TemperatureBarColor = new(Color.FromRgb(0, 255, 0));
    public double Temperature
    {
        get { return this.Dispatcher.Invoke(() => (double)GetValue(TemperatureProperty)); }
        set
        {
            this.Dispatcher.Invoke(() =>
            {
                SetValue(TemperatureProperty, value);
                double tratio = value / DANGER_TEMP;
                this.TemperatureBar?.SetValue(ProgressBar.ValueProperty, tratio);
                this.TemperatureBarColor.Color = MapValueToColor(tratio);
            });
        }
    }

    // pressure
    public static readonly DependencyProperty PressureProperty = DependencyProperty.Register("Pressure", typeof(double), typeof(LiquidTankControl), new PropertyMetadata(0.0));
    private readonly SolidColorBrush PressureBarColor = new(Color.FromRgb(0, 255, 0));
    public double Pressure
    {
        get { return this.Dispatcher.Invoke(() => (double)GetValue(PressureProperty)); }
        set
        {
            this.Dispatcher.Invoke(() =>
            {
                SetValue(PressureProperty, value);
                double pratio = value / DANGER_PRESSURE;
                this.PressureBar?.SetValue(ProgressBar.ValueProperty, pratio);
                this.PressureBarColor.Color = MapValueToColor(pratio);
            });
        }
    }

    // flow rate
    public static readonly DependencyProperty FlowRateProperty = DependencyProperty.Register("FlowRate", typeof(double), typeof(LiquidTankControl), new PropertyMetadata(0.0));
    private readonly SolidColorBrush FlowRateBarColor = new(Color.FromRgb(0, 255, 0));
    public double FlowRate
    {
        get { return this.Dispatcher.Invoke(() => (double)GetValue(FlowRateProperty)); }
        set
        {
            this.Dispatcher.Invoke(() =>
            {
                SetValue(FlowRateProperty, value);
                double fratio = value / DANGE_RATE;
                this.FlowRateBar?.SetValue(ProgressBar.ValueProperty, fratio);
                this.FlowRateBarColor.Color = MapValueToColor(fratio);
            });
        }
    }

    // valve state
    public static readonly DependencyProperty ValveStateProperty = DependencyProperty.Register("ValveState", typeof(bool), typeof(LiquidTankControl), new PropertyMetadata(false));
    public bool ValveState
    {
        get { return this.Dispatcher.Invoke(() => (bool)GetValue(ValveStateProperty)); }
        set { this.Dispatcher.Invoke(() => SetValue(ValveStateProperty, value)); }
    }

    public readonly double MaxFluidLevel = 100.0;

    public LiquidTankControl(string tankName, double maxFluidLevel)
    {
        InitializeComponent();

        this.PressureBar.Foreground = this.PressureBarColor;
        this.TemperatureBar.Foreground = this.TemperatureBarColor;
        this.FlowRateBar.Foreground = this.FlowRateBarColor;

        this.MaxFluidLevel = maxFluidLevel;
        this.LiquidLevel = this.MaxFluidLevel;
        this.FlowRate = 0;
        this.Title.Text = tankName;
    }

    public static Color MapValueToColor(double value)
    {
        byte green = 255;
        byte red = 255;

        // remap value from 0 -> 1.0 to be 0 -> 0.5 = 0 & 0.5 -> 1 = 0 -> 1
        value = (Math.Max(value, 0.5) - 0.5) * 2;
        value = Math.Min(value, 1);

        if (value <= 0.5)
            red = (byte)(255 * (value * 2));
        else
            green = (byte)(255 * (1 - value) * 2);


        return Color.FromRgb(red, green, 0);
    }
}
