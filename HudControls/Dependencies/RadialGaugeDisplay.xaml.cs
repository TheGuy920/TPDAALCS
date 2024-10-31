using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls.Dependencies;
/// <summary>
/// Interaction logic for RadialGaugeDisplay.xaml
/// </summary>
internal partial class RadialGaugeDisplay : UserControl
{
    public static readonly DependencyProperty MinorTickIntervalProperty =
        DependencyProperty.Register(nameof(MinorTickInterval), typeof(int), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(2, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MinorTickWidthAndHeightProperty =
        DependencyProperty.Register(nameof(MinorTickWidthAndHeight), typeof(Point), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(new Point(1, 5), FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MinorTickColorProperty =
        DependencyProperty.Register(nameof(MinorTickColor), typeof(SolidColorBrush), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTickIntervalProperty =
        DependencyProperty.Register(nameof(MajorTickInterval), typeof(int), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(10, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTickWidthAndHeightProperty =
        DependencyProperty.Register(nameof(MajorTickWidthAndHeight), typeof(Point), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(new Point(3, 15), FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTickColorProperty =
        DependencyProperty.Register(nameof(MajorTickColor), typeof(SolidColorBrush), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata("Radial Gauge", FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty TitleFontFamilyProperty =
        DependencyProperty.Register(nameof(TitleFontFamily), typeof(FontFamily), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(new FontFamily("Arial"), FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty TitleFontSizeProperty =
        DependencyProperty.Register(nameof(TitleFontSize), typeof(double), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty TitleFontStyleProperty =
        DependencyProperty.Register(nameof(TitleFontStyle), typeof(FontStyle), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(FontStyles.Normal, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty TitleFontWeightProperty =
        DependencyProperty.Register(nameof(TitleFontWeight), typeof(FontWeight), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(FontWeights.Normal, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty BackgroundImageProperty =
        DependencyProperty.Register(nameof(BackgroundImage), typeof(ImageSource), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MajorTickLabelOffsetProperty =
        DependencyProperty.Register(nameof(MajorTickLabelOffset), typeof(double), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty StartAngleProperty =
        DependencyProperty.Register(nameof(StartAngle), typeof(double), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty EndAngleProperty =
        DependencyProperty.Register(nameof(EndAngle), typeof(double), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(315.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MaxValueProperty =
        DependencyProperty.Register(nameof(MaxValue), typeof(double), typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public int MinorTickInterval
    {
        get => (int)GetValue(MinorTickIntervalProperty);
        set => SetValue(MinorTickIntervalProperty, value);
    }

    public Point MinorTickWidthAndHeight
    {
        get => (Point)GetValue(MinorTickWidthAndHeightProperty);
        set => SetValue(MinorTickWidthAndHeightProperty, value);
    }

    public SolidColorBrush MinorTickColor
    {
        get => (SolidColorBrush)GetValue(MinorTickColorProperty);
        set => SetValue(MinorTickColorProperty, value);
    }

    public int MajorTickInterval
    {
        get => (int)GetValue(MajorTickIntervalProperty);
        set => SetValue(MajorTickIntervalProperty, value);
    }

    public Point MajorTickWidthAndHeight
    {
        get => (Point)GetValue(MajorTickWidthAndHeightProperty);
        set => SetValue(MajorTickWidthAndHeightProperty, value);
    }

    public SolidColorBrush MajorTickColor
    {
        get => (SolidColorBrush)GetValue(MajorTickColorProperty);
        set => SetValue(MajorTickColorProperty, value);
    }

    public double MajorTickLabelOffset
    {
        get => (double)GetValue(MajorTickLabelOffsetProperty);
        set => SetValue(MajorTickLabelOffsetProperty, value);
    }

    public FontFamily TitleFontFamily
    {
        get => (FontFamily)GetValue(TitleFontFamilyProperty);
        set => SetValue(TitleFontFamilyProperty, value);
    }

    public double TitleFontSize
    {
        get => (double)GetValue(TitleFontSizeProperty);
        set => SetValue(TitleFontSizeProperty, value);
    }

    public FontStyle TitleFontStyle
    {
        get => (FontStyle)GetValue(TitleFontStyleProperty);
        set => SetValue(TitleFontStyleProperty, value);
    }

    public FontWeight TitleFontWeight
    {
        get => (FontWeight)GetValue(TitleFontWeightProperty);
        set => SetValue(TitleFontWeightProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ImageSource BackgroundImage
    {
        get => (ImageSource)GetValue(BackgroundImageProperty);
        set => SetValue(BackgroundImageProperty, value);
    }

    public double StartAngle
    {
        get => (double)GetValue(StartAngleProperty);
        set => SetValue(StartAngleProperty, value);
    }

    public double EndAngle
    {
        get => (double)GetValue(EndAngleProperty);
        set => SetValue(EndAngleProperty, value);
    }

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    static RadialGaugeDisplay()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(RadialGaugeDisplay),
            new FrameworkPropertyMetadata(typeof(RadialGaugeDisplay)));
    }

    public RadialGaugeNeedle? needle;
    public RadialGaugeDisplay()
    {
        InitializeComponent();
    }

    // Override OnRender to do the drawing
    protected override void OnRender(DrawingContext drawingContext)
    {
        double centerX = this.ActualWidth / 2;
        double centerY = this.ActualHeight / 2;
        double radius = this.Radius;

        // Call the base class method
        base.OnRender(drawingContext);

        // Draw the background circle
        this.DrawBackground(drawingContext, centerX, centerY, radius);

        // Call a method to draw the tick marks
        this.DrawTicks(drawingContext, centerX, centerY, radius);

        // Draw the title
        this.DrawTitle(drawingContext, centerX, radius);
    }

    private void DrawBackground(DrawingContext dc, double centerX, double centerY, double radius)
    {
        // Draw the background circle
        dc.DrawEllipse(Brushes.Black, null, new Point(centerX, centerY), radius+2, radius+2);
        dc.DrawEllipse(this.Background, null, new Point(centerX, centerY), radius, radius);
    }

    private double Radius => Math.Min(this.ActualWidth / 2, this.ActualHeight / 2);

    private void DrawTitle(DrawingContext drawingContext, double centerX, double radius)
    {
        var text = new FormattedText(this.Title, System.Globalization.CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight, new Typeface(this.TitleFontFamily, this.TitleFontStyle, this.TitleFontWeight, this.FontStretch), this.TitleFontSize, this.Foreground, 3.0);

        double textPositionX = centerX - (text.Width / 2);
        var textPosition = new Point(textPositionX, (radius * 1.75) - text.Height);

        drawingContext.DrawText(text, textPosition);
    }

    private double SmallestRadius { get => needle.SmallestRadius; set => needle.SmallestRadius = value; }
    private Pen? majorPen;
    private Pen? minorPen;

    private void DrawTicks(DrawingContext dc, double centerX, double centerY, double radius)
    {
        // Calculate the number of ticks based on the angle range and interval
        double minorTickInterval = this.MinorTickInterval;

        int minorTickCount = (int)Math.Ceiling(this.MaxValue / minorTickInterval);
        // int majorTickCount = (int)Math.Ceiling(this.MaxValue / this.MajorTickInterval);
        double angleIncrement = (this.EndAngle - this.StartAngle) / minorTickCount;
        this.SmallestRadius = double.MaxValue;
        double factor = this.MajorTickLabelOffset;

        double minorTickLength = this.MinorTickWidthAndHeight.Y;
        double minorTickWidth = this.MinorTickWidthAndHeight.X;
        SolidColorBrush minorTickColor = this.MinorTickColor;

        double majorTickLength = this.MajorTickWidthAndHeight.Y;
        double majorTickWidth = this.MajorTickWidthAndHeight.X;
        SolidColorBrush majorTickColor = this.MajorTickColor;
        double majorTickInterval = this.MajorTickInterval;

        double fontSize = this.FontSize;
        Brush foreground = this.Foreground;
        var typeface = new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch);

        double startAngle = this.StartAngle;
        // double endAngle = this.EndAngle;

        majorPen = new Pen(majorTickColor, majorTickWidth);
        minorPen = new Pen(minorTickColor, minorTickWidth);
        double radConst = Math.PI / 180;

        double x1;
        double y1;

        double x2;
        double y2;

        for (int index = 0; index < minorTickCount; index++)
        {
            double angleDeg = startAngle + (index * angleIncrement);

            // Calculate the current angle in radians
            double angleRad = (angleDeg + 90) * radConst;

            // Start and end points of each tick (you can adjust for minor/major ticks)
            x1 = centerX + (radius * Math.Cos(angleRad));
            y1 = centerY + (radius * Math.Sin(angleRad));

            double tickValue = Math.Round((angleDeg - startAngle) / angleIncrement) * minorTickInterval;
            if (tickValue % majorTickInterval == 0)
            {
                var text = new FormattedText(tickValue.ToString(), System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, typeface, fontSize, foreground, 3.0);

                double textPositionX = centerX + ((radius - majorTickLength - text.Width + factor) * Math.Cos(angleRad)) - (text.Width / 2);
                double textPositionY = centerY + ((radius - majorTickLength - text.Height + factor) * Math.Sin(angleRad)) - (text.Height / 2);
                var textPosition = new Point(textPositionX + 1, textPositionY);

                double distance = Math.Sqrt(Math.Pow(centerX - (textPositionX + 1), 2) + Math.Pow(centerY - textPositionY, 2));
                if (distance < this.SmallestRadius)
                    this.SmallestRadius = distance;

                x2 = centerX + ((radius - majorTickLength) * Math.Cos(angleRad));
                y2 = centerY + ((radius - majorTickLength) * Math.Sin(angleRad));

                dc.DrawText(text, textPosition);

                // Draw the tick
                dc.DrawLine(majorPen, new Point(x1, y1), new Point(x2, y2));
            }
            else
            {
                x2 = centerX + ((radius - minorTickLength) * Math.Cos(angleRad));
                y2 = centerY + ((radius - minorTickLength) * Math.Sin(angleRad));

                // Draw the tick
                dc.DrawLine(minorPen, new Point(x1, y1), new Point(x2, y2));
            }
        }
    }
}
