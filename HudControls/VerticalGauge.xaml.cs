using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls;
/// <summary>
/// Interaction logic for VerticalGauge.xaml
/// </summary>
public partial class VerticalGauge : UserControl
{
    public double MinValue
    {
        get => this.Ticker.MinValue;
        set
        {
            this.Ticker.MinValue = value;
            this.Indicator.MinValue = value;
        }
    }

    public double Value
    {
        get => this.Indicator.Value;
        set => this.Indicator.Value = value;
    }

    public double MaxValue
    {
        get => this.Ticker.MaxValue;
        set
        {
            this.Ticker.MaxValue = value;
            this.Indicator.MaxValue = value;
        }
    }

    public double NeedleHeight
    {
        get => this.Indicator.NeedleHeight;
        set => this.Indicator.NeedleHeight = value;
    }

    public double MajorTickHeight
    {
        get => this.Ticker.MajorTickHeight;
        set => this.Ticker.MajorTickHeight = value;
    }

    public double MinorTickHeight
    {
        get => this.Ticker.MinorTickHeight;
        set => this.Ticker.MinorTickHeight = value;
    }

    public double MajorTickInterval
    {
        get => this.Ticker.MajorTickInterval;
        set => this.Ticker.MajorTickInterval = value;
    }

    public double MinorTickInterval
    {
        get => this.Ticker.MinorTickInterval;
        set => this.Ticker.MinorTickInterval = value;
    }

    public Brush MajorTickColor
    {
        get => this.Ticker.MajorTickColor;
        set => this.Ticker.MajorTickColor = value;
    }

    public Brush MinorTickColor
    {
        get => this.Ticker.MinorTickColor;
        set => this.Ticker.MinorTickColor = value;
    }

    public bool MajorTextLabel
    {
        get => this.Ticker.MajorTextLabel;
        set => this.Ticker.MajorTextLabel = value;
    }

    public HorizontalAlignment MajorTextAlign
    {
        get => this.Ticker.MajorTextAlign;
        set => this.Ticker.MajorTextAlign = value;
    }

    public double NeedleLength
    {
        get => this.Indicator.NeedleLength;
        set => this.Indicator.NeedleLength = value;
    }

    public new Brush Foreground
    {
        get => this.Ticker.Foreground;
        set => this.Ticker.Foreground = value;
    }

    public new FontFamily FontFamily
    {
        get => this.Ticker.FontFamily;
        set
        {
            this.Ticker.FontFamily = value;
            this.Indicator.FontFamily = value;
        }
    }

    public new double FontSize
    {
        get => this.Ticker.FontSize;
        set
        {
            this.Ticker.FontSize = value;
            this.Indicator.FontSize = value;
        }
    }

    public VerticalGauge()
    {
        InitializeComponent();
        this.Indicator.ticker = this.Ticker;
    }
}
