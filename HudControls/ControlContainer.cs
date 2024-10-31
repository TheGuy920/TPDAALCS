using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace HudControls;
public class ControlContainer : ContentControl
{
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ControlContainer), new PropertyMetadata(new CornerRadius(5)));
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    // <image> source for image binding
    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(ImageSource), typeof(ControlContainer), new PropertyMetadata(null));
    public ImageSource Source
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register(nameof(ImageWidth), typeof(double), typeof(ControlContainer), new PropertyMetadata(10.0));
    public double ImageWidth
    {
        get => (double)GetValue(ImageWidthProperty);
        set => SetValue(ImageWidthProperty, value);
    }

    public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register(nameof(ImageHeight), typeof(double), typeof(ControlContainer), new PropertyMetadata(10.0));
    public double ImageHeight
    {
        get => (double)GetValue(ImageHeightProperty);
        set => SetValue(ImageHeightProperty, value);
    }

    public ControlContainer()
    {
        this.Padding = new Thickness(2);

        // Create a Grid with 3 Columns and 3 Rows
        var imageGrid = new FrameworkElementFactory(typeof(Grid));
        imageGrid.SetValue(Grid.MarginProperty, new Thickness(3));

        imageGrid.AppendChild(NewColumnDef(GridUnitType.Auto));
        imageGrid.AppendChild(NewColumnDef(GridUnitType.Star));
        imageGrid.AppendChild(NewColumnDef(GridUnitType.Auto));

        imageGrid.AppendChild(NewRowDef(GridUnitType.Auto));
        imageGrid.AppendChild(NewRowDef(GridUnitType.Star));
        imageGrid.AppendChild(NewRowDef(GridUnitType.Auto));

        FrameworkElementFactory topLeft = NewImage(0, 0);
        FrameworkElementFactory topRight = NewImage(0, 2);
        FrameworkElementFactory bottomLeft = NewImage(2, 0);
        FrameworkElementFactory bottomRight = NewImage(2, 2);

        imageGrid.AppendChild(topLeft);
        imageGrid.AppendChild(topRight);
        imageGrid.AppendChild(bottomLeft);
        imageGrid.AppendChild(bottomRight);

        // Create a FrameworkElementFactory for the Border
        var border = new FrameworkElementFactory(typeof(Border));
        border.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(CornerRadius)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });
        border.SetBinding(Border.BackgroundProperty, new Binding(nameof(Background)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });

        // Create a FrameworkElementFactory for the ContentControl
        var contentControl = new FrameworkElementFactory(typeof(ContentControl));
        contentControl.SetBinding(ContentControl.ContentProperty, new Binding(nameof(this.Content)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });
        border.AppendChild(contentControl);

        var mainGrid = new FrameworkElementFactory(typeof(Grid));
        mainGrid.SetBinding(Border.MarginProperty, new Binding(nameof(Padding)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });
        mainGrid.AppendChild(border);
        mainGrid.AppendChild(imageGrid);

        var ctemp = new ControlTemplate(typeof(ControlContainer)) { VisualTree = mainGrid };
        //this.Style = new Style() { Setters = { new Setter(ControlContainer.TemplateProperty, ctemp), } };
        this.Template = ctemp;
    }

    private static FrameworkElementFactory NewColumnDef(GridUnitType ut)
    {
        var cd = new FrameworkElementFactory(typeof(ColumnDefinition));
        cd.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, ut));
        return cd;
    }

    private static FrameworkElementFactory NewRowDef(GridUnitType ut)
    {
        var rd = new FrameworkElementFactory(typeof(RowDefinition));
        rd.SetValue(RowDefinition.HeightProperty, new GridLength(1, ut));
        return rd;
    }

    private FrameworkElementFactory NewImage(int row, int column)
    {
        var image = new FrameworkElementFactory(typeof(Image));
        image.SetValue(Image.SourceProperty, new Binding(nameof(Source)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });
        image.SetValue(Image.HeightProperty, new Binding(nameof(ImageHeight)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });
        image.SetValue(Image.WidthProperty, new Binding(nameof(ImageWidth)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ControlContainer), 1) });

        // Create and set a DropShadowEffect on the Image
        var shadowEffect = new DropShadowEffect
        {
            Color = Colors.Black,         // Shadow color
            Opacity = 1,                // Shadow transparency
            BlurRadius = 5,               // Amount of blur
            Direction = 270,              // Shadow direction (in degrees, where 270 is bottom)
            ShadowDepth = 2               // Distance of the shadow from the image
        };
        image.SetValue(Image.EffectProperty, shadowEffect);

        var topLeft = new FrameworkElementFactory(typeof(ContentControl));
        topLeft.SetValue(Grid.ColumnProperty, row);
        topLeft.SetValue(Grid.RowProperty, column);
        topLeft.AppendChild(image);

        return topLeft;
    }
}
