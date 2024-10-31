using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HudControls;
/// <summary>
/// Interaction logic for HardLabel.xaml
/// </summary>
public partial class HardLabel : UserControl
{
    // LabelText property
    public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(nameof(LabelText), typeof(string), typeof(HardLabel), new PropertyMetadata("Label"));
    public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    // background image
    public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register(nameof(BackgroundImage), typeof(ImageSource), typeof(HardLabel), new PropertyMetadata(null));
    public ImageSource BackgroundImage
    {
        get { return (ImageSource)GetValue(BackgroundImageProperty); }
        set { SetValue(BackgroundImageProperty, value); }
    }

    public HardLabel()
    {
        InitializeComponent();
        this.DataContext = this;
    }
}
