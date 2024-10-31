using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HudControls;
public class HardContainer : ContentControl
{
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(HardContainer), new PropertyMetadata(new CornerRadius(5)));
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public HardContainer()
    {
        this.Padding = new Thickness(2);

        // Create a FrameworkElementFactory for the Border
        var border = new FrameworkElementFactory(typeof(Border));
        border.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(CornerRadius)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(HardContainer), 1) });
        border.SetBinding(Border.BackgroundProperty, new Binding(nameof(Background)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(HardContainer), 1) });
        border.SetBinding(Border.BorderBrushProperty, new Binding(nameof(BorderBrush)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(HardContainer), 1) });
        border.SetBinding(Border.BorderThicknessProperty, new Binding(nameof(BorderThickness)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(HardContainer), 1) });

        // Create a FrameworkElementFactory for the ContentControl
        var contentControl = new FrameworkElementFactory(typeof(ContentControl));
        contentControl.SetBinding(ContentControl.ContentProperty, new Binding(nameof(this.Content)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(HardContainer), 1) });
        border.AppendChild(contentControl);

        var mainGrid = new FrameworkElementFactory(typeof(Grid));
        mainGrid.SetBinding(Border.MarginProperty, new Binding(nameof(Padding)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(HardContainer), 1) });
        mainGrid.AppendChild(border);

        this.Template = new ControlTemplate(typeof(HardContainer)) { VisualTree = mainGrid };
    }
}
