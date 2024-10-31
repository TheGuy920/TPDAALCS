using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HudControls;
/// <summary>
/// Interaction logic for DialSwitch.xaml
/// </summary>
public partial class DialSwitch : UserControl
{
    public DialSwitch()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    private bool switchState = false;
    private void GridMouseDown(object sender, MouseButtonEventArgs e)
    {
        this.switchState = !this.switchState;
        DoubleAnimation anim = new()
        {
            From = this.switchState ? 25 : 180 - 25,
            To = this.switchState ? 180 - 25 : 25,
            Duration = new Duration(TimeSpan.FromMilliseconds(50))
        };
        SwitchNeedleTransform.BeginAnimation(RotateTransform.AngleProperty, anim);
    }
}
