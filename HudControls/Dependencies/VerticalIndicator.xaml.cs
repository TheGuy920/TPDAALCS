using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls.Dependencies;
/// <summary>
/// Interaction logic for VerticalIndicator.xaml
/// </summary>
internal partial class VerticalIndicator : UserControl
{
    public static readonly DependencyProperty MinValueProperty =
    DependencyProperty.Register(nameof(MinValue), typeof(double), typeof(VerticalIndicator),
        new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MaxValueProperty =
        DependencyProperty.Register(nameof(MaxValue), typeof(double), typeof(VerticalIndicator),
            new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(double), typeof(VerticalIndicator),
            new FrameworkPropertyMetadata(50.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty NeedleHeightProperty =
        DependencyProperty.Register(nameof(NeedleHeight), typeof(double), typeof(VerticalIndicator),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty NeedleLengthProperty =
        DependencyProperty.Register(nameof(NeedleLength), typeof(double), typeof(VerticalIndicator),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double MinValue
    {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public double NeedleHeight
    {
        get => (double)GetValue(NeedleHeightProperty);
        set => SetValue(NeedleHeightProperty, value);
    }

    public double NeedleLength
    {
        get => (double)GetValue(NeedleLengthProperty);
        set => SetValue(NeedleLengthProperty, value);
    }

    internal VerticalTicker? ticker;
    public VerticalIndicator()
    {
        InitializeComponent();
        this.Foreground = Brushes.Red;
    }

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);

        double range = this.MaxValue - this.MinValue;
        if (range <= 0) return;

        double controlHeight = this.ActualHeight;
        double relativePosition = (this.Value - this.MinValue) / range;
        double yPosition = controlHeight - (relativePosition * controlHeight);

        var linePen = new Pen(this.Foreground, this.NeedleHeight);

        if (this.ticker is null)
            throw new InvalidOperationException("The VerticalIndicator must be a child of a VerticalTicker");

        int xn = (int)Math.Floor(this.ticker.PlacementOffset.X);
        double x1 = xn == 0 ? this.ticker.PlacementOffset.X : this.ticker.PlacementOffset.X-this.NeedleLength;
        double x2 = xn == 0 ? this.ticker.PlacementOffset.Y+this.NeedleLength : this.ticker.PlacementOffset.Y;

        // Draw a vertical line across the control width at the calculated Y position
        dc.DrawLine(
            linePen,
            new Point(x1, yPosition),
            new Point(x2, yPosition));
    }
}
