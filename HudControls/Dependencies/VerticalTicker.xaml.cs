using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls.Dependencies;
/// <summary>
/// Interaction logic for VerticalTicker.xaml
/// </summary>
internal partial class VerticalTicker : UserControl
{
    static VerticalTicker()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(VerticalTicker),
            new FrameworkPropertyMetadata(typeof(VerticalTicker)));
    }

    public static readonly DependencyProperty MajorTickHeightProperty =
        DependencyProperty.Register(nameof(MajorTickHeight), typeof(double), typeof(VerticalTicker), new FrameworkPropertyMetadata(2.0, FrameworkPropertyMetadataOptions.AffectsRender));
    
    public static readonly DependencyProperty MinorTickHeightProperty =
        DependencyProperty.Register(nameof(MinorTickHeight), typeof(double), typeof(VerticalTicker), new FrameworkPropertyMetadata(2.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTickIntervalProperty =
        DependencyProperty.Register(nameof(MajorTickInterval), typeof(double), typeof(VerticalTicker), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MinorTickIntervalProperty =
        DependencyProperty.Register(nameof(MinorTickInterval), typeof(double), typeof(VerticalTicker), new FrameworkPropertyMetadata(2.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MinValueProperty =
        DependencyProperty.Register(nameof(MinValue), typeof(double), typeof(VerticalTicker), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MaxValueProperty =
        DependencyProperty.Register(nameof(MaxValue), typeof(double), typeof(VerticalTicker), new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTickColorProperty =
        DependencyProperty.Register(nameof(MajorTickColor), typeof(Brush), typeof(VerticalTicker), new FrameworkPropertyMetadata(Brushes.DimGray, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MinorTickColorProperty =
        DependencyProperty.Register(nameof(MinorTickColor), typeof(Brush), typeof(VerticalTicker), new FrameworkPropertyMetadata(Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTextLabelProperty =
    DependencyProperty.Register(nameof(MajorTextLabel), typeof(bool), typeof(VerticalTicker),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTextAlignProperty =
        DependencyProperty.Register(nameof(MajorTextAlign), typeof(HorizontalAlignment), typeof(VerticalTicker),
            new FrameworkPropertyMetadata(HorizontalAlignment.Right, FrameworkPropertyMetadataOptions.AffectsRender));


    public double MinValue
    {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public double MajorTickHeight
    {
        get => (double)GetValue(MajorTickHeightProperty);
        set => SetValue(MajorTickHeightProperty, value);
    }

    public double MinorTickHeight
    {
        get => (double)GetValue(MinorTickHeightProperty);
        set => SetValue(MinorTickHeightProperty, value);
    }

    public double MajorTickInterval
    {
        get => (double)GetValue(MajorTickIntervalProperty);
        set => SetValue(MajorTickIntervalProperty, value);
    }

    public double MinorTickInterval
    {
        get => (double)GetValue(MinorTickIntervalProperty);
        set => SetValue(MinorTickIntervalProperty, value);
    }

    public Brush MajorTickColor
    {
        get => (Brush)GetValue(MajorTickColorProperty);
        set => SetValue(MajorTickColorProperty, value);
    }

    public Brush MinorTickColor
    {
        get => (Brush)GetValue(MinorTickColorProperty);
        set => SetValue(MinorTickColorProperty, value);
    }

    public bool MajorTextLabel
    {
        get => (bool)GetValue(MajorTextLabelProperty);
        set => SetValue(MajorTextLabelProperty, value);
    }

    public HorizontalAlignment MajorTextAlign
    {
        get => (HorizontalAlignment)GetValue(MajorTextAlignProperty);
        set => SetValue(MajorTextAlignProperty, value);
    }

    internal Point PlacementOffset { get; private set; }
    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);

        double range = this.MaxValue - this.MinValue;
        if (range <= 0) return;

        double controlHeight = this.ActualHeight;
        double pixelsPerUnit = controlHeight / range;

        int totalTicks = (int)((this.MaxValue - this.MinValue) / this.MinorTickInterval);
        var typeface = new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch);

        double labelPadding = 0;
        if (this.MajorTextLabel)
        {
            labelPadding = new FormattedText(
                    this.MaxValue.ToString("F0"),
                    System.Globalization.CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    typeface, this.FontSize, this.Foreground, 1).Width; // Padding to avoid overlap
            this.MinWidth = labelPadding + 6;
        }
        else
        {
            this.MinWidth = 1;
        }

        if (this.MajorTextLabel)
        {
            this.PlacementOffset = this.MajorTextAlign switch
            {
                HorizontalAlignment.Left => new(labelPadding + 5, this.ActualWidth),
                HorizontalAlignment.Right => new(0, this.ActualWidth - labelPadding - 5),
                _ => new(0, this.ActualWidth),
            };
        }

        for (int i = 0; i <= totalTicks; i++)
        {
            double value = this.MinValue + (i * this.MinorTickInterval);
            bool isMajorTick = (i % (int)(this.MajorTickInterval / this.MinorTickInterval)) == 0;
            Brush tickBrush = isMajorTick ? this.MajorTickColor : this.MinorTickColor;
            double tickYPosition = controlHeight - ((value - this.MinValue) * pixelsPerUnit);
            double tickHeight = isMajorTick ? this.MajorTickHeight : this.MinorTickHeight;

            // Draw tick line with thickness based on tickHeight, within the adjusted left and right bounds
            dc.DrawLine(
                new Pen(tickBrush, tickHeight),
                new Point(this.PlacementOffset.X, tickYPosition),
                new Point(this.PlacementOffset.Y, tickYPosition));
            
            if (isMajorTick && MajorTextLabel)
            {
                var formattedText = new FormattedText(
                    value.ToString("F0"),
                    System.Globalization.CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    typeface, this.FontSize, this.Foreground, 1);

                Point textPosition = MajorTextAlign switch
                {
                    HorizontalAlignment.Left => new Point((labelPadding -formattedText.Width), tickYPosition - (formattedText.Height / 2)),
                    HorizontalAlignment.Right => new Point(ActualWidth - labelPadding, tickYPosition - (formattedText.Height / 2)),
                    _ => new Point((ActualWidth / 2) - (formattedText.Width / 2), tickYPosition - tickHeight - (formattedText.Height /2)),
                };
                dc.DrawText(formattedText, textPosition);
            }
        }
    }

}