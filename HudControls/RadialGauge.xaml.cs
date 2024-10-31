using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls;
/// <summary>
/// Interaction logic for UserControl1.xaml
/// </summary>
public partial class RadialGauge : UserControl
{
    public double Value
    {
        get => this.needle.Value;
        set => this.needle.Value = value;
    }

    public double NeedleLength
    {
        get => this.needle.NeedleLength;
        set => this.needle.NeedleLength = value;
    }

    public double NeedleWidth
    {
        get => this.needle.NeedleWidth;
        set => this.needle.NeedleWidth = value;
    }

    public double StartAngle
    {
        get => this.needle.StartAngle;
        set
        {
            this.needle.StartAngle = value;
            this.display.StartAngle = value;
        }
    }

    public double EndAngle
    {
        get => this.needle.EndAngle;
        set
        {
            this.needle.EndAngle = value;
            this.display.EndAngle = value;
        }
    }

    public double MaxValue
    {
        get => this.needle.MaxValue;
        set
        {
            this.needle.MaxValue = value;
            this.display.MaxValue = value;
        }
    }

    public int MinorTickInterval
    {
        get => this.display.MinorTickInterval;
        set => this.display.MinorTickInterval = value;
    }

    public Point MinorTickWidthAndHeight
    {
        get => this.display.MinorTickWidthAndHeight;
        set => this.display.MinorTickWidthAndHeight = value;
    }

    public SolidColorBrush MinorTickColor
    {
        get => this.display.MinorTickColor;
        set => this.display.MinorTickColor = value;
    }

    public int MajorTickInterval
    {
        get => this.display.MajorTickInterval;
        set => this.display.MajorTickInterval = value;
    }

    public Point MajorTickWidthAndHeight
    {
        get => this.display.MajorTickWidthAndHeight;
        set => this.display.MajorTickWidthAndHeight = value;
    }

    public SolidColorBrush MajorTickColor
    {
        get => this.display.MajorTickColor;
        set => this.display.MajorTickColor = value;
    }

    public double MajorTickLabelOffset
    {
        get => this.display.MajorTickLabelOffset;
        set => this.display.MajorTickLabelOffset = value;
    }

    public FontFamily TitleFontFamily
    {
        get => this.display.TitleFontFamily;
        set => this.display.TitleFontFamily = value;
    }

    public double TitleFontSize
    {
        get => this.display.TitleFontSize;
        set => this.display.TitleFontSize = value;
    }

    public FontStyle TitleFontStyle
    {
        get => this.display.TitleFontStyle;
        set => this.display.TitleFontStyle = value;
    }

    public FontWeight TitleFontWeight
    {
        get => this.display.TitleFontWeight;
        set => this.display.TitleFontWeight = value;
    }

    public string Title
    {
        get => this.display.Title;
        set => this.display.Title = value;
    }

    public ImageSource BackgroundImage
    {
        get => this.display.BackgroundImage;
        set => this.display.BackgroundImage = value;
    }
    
    public new Brush Background
    {
        get => this.display.Background;
        set 
        {
            this.display.Background = value;
            this.display.InvalidateVisual();
        }
    }

    public RadialGauge()
    {
        InitializeComponent();

        this.display.needle = this.needle;
        this.Loaded += this.RadialGauge_Loaded;
    }

    private void RadialGauge_Loaded(object sender, RoutedEventArgs e)
    {
        this.display.Background = base.Background;
        this.display.InvalidateVisual();
        base.Background = Brushes.Transparent;
    }
}

