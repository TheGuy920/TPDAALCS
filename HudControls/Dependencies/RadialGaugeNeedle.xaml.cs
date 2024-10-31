using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls.Dependencies;
/// <summary>
/// Interaction logic for RadialGaugeNeedle.xaml
/// </summary>
internal partial class RadialGaugeNeedle : UserControl
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(double), typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(50.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty NeedleWidthProperty =
        DependencyProperty.Register(nameof(NeedleWidth), typeof(double), typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(4d, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty NeedleLengthProperty =
        DependencyProperty.Register(nameof(NeedleLength), typeof(double), typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(4d, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty StartAngleProperty =
        DependencyProperty.Register(nameof(StartAngle), typeof(double), typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty EndAngleProperty =
        DependencyProperty.Register(nameof(EndAngle), typeof(double), typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(315.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MaxValueProperty =
        DependencyProperty.Register(nameof(MaxValue), typeof(double), typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public double NeedleLength
    {
        get => (double)GetValue(NeedleLengthProperty);
        set => SetValue(NeedleLengthProperty, value);
    }

    public double NeedleWidth
    {
        get => (double)GetValue(NeedleWidthProperty);
        set => SetValue(NeedleWidthProperty, value);
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

    static RadialGaugeNeedle()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(RadialGaugeNeedle),
            new FrameworkPropertyMetadata(typeof(RadialGaugeNeedle)));
    }

    internal double SmallestRadius;
    public RadialGaugeNeedle()
    {
        InitializeComponent();
    }

    // Override OnRender to do the drawing
    protected override void OnRender(DrawingContext drawingContext)
    {
        // Call the base class method
        base.OnRender(drawingContext);
        this.DrawNeedle(drawingContext, this.ActualWidth / 2, this.ActualHeight / 2);
    }

    private void DrawNeedle(DrawingContext dc, double centerX, double centerY)
    {
        // Define needle size and position
        double needleLength = Math.Max(this.SmallestRadius + ((this.NeedleLength - 4) * 25), 0.01);
        double needleWidth = this.NeedleWidth;

        // Create the needle geometry. This is a sword shape. (A long rectangle with a triangle on the end pointing at the tick marks)
        var needleGeometry = new StreamGeometry();
        using (StreamGeometryContext ctx = needleGeometry.Open())
        {
            ctx.BeginFigure(new Point(centerX, centerY - (needleWidth / 2)), true, true);
            ctx.LineTo(new Point(centerX + needleLength - 10, centerY - (needleWidth / 2)), true, false);
            //ctx.LineTo(new Point(centerX + needleLength, centerY - needleWidth), true, false);
            ctx.LineTo(new Point(centerX + needleLength + needleWidth, centerY), true, false);
            //ctx.LineTo(new Point(centerX + needleLength, centerY + needleWidth), true, false);
            ctx.LineTo(new Point(centerX + needleLength - 10, centerY + (needleWidth / 2)), true, false);
            ctx.LineTo(new Point(centerX, centerY + (needleWidth / 2)), true, false);
        }

        // Calculate the angle for the current needle value
        double angleDeg = ValueToAngle(this.Value) + 90;
        //double angleRad = angleDeg * (Math.PI / 180);

        // Save the drawing context state before applying the transform
        dc.PushTransform(new RotateTransform(angleDeg, centerX, centerY));

        // Draw the needle as a red triangle
        dc.DrawGeometry(Brushes.Red, null, needleGeometry);

        // Restore the drawing context state (remove the transform)
        dc.Pop();
    }

    // Convert the needle value into an angle between StartAngle and EndAngle
    private double ValueToAngle(double value)
    {
        // Normalize the value to a proportion between 0 and 1
        double valueNormalized = value / this.MaxValue;

        // Convert the normalized value to the correct angle range (StartAngle to EndAngle)
        return this.StartAngle + ((this.EndAngle - this.StartAngle) * valueNormalized);
    }
}
