using System.Windows.Controls;

namespace HudControls;
/// <summary>
/// Interaction logic for MasterCaution.xaml
/// </summary>
public partial class MasterCaution : UserControl
{
    private bool _isOn = false;
    public bool IsOn
    {
        get => _isOn;
        set
        {
            _isOn = value;
            if (_isOn)
                this.Dispatcher.BeginInvoke(() => this.RGlow.Visibility = System.Windows.Visibility.Visible);
            else
                this.Dispatcher.BeginInvoke(() => this.RGlow.Visibility = System.Windows.Visibility.Hidden);
        }
    }

    public MasterCaution()
    {
        InitializeComponent();
    }
}
