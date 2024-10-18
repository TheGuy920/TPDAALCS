using System.Windows;
using System.Windows.Controls;
namespace TPDAAC.Windows.Modes;
/// <summary>
/// Interaction logic for SelectorMode.xaml
/// </summary>
public partial class SelectorMode : Page
{
    private readonly Action<Page> _npage;

    public SelectorMode(Action<Page> npage)
    {
        _npage = npage;
        InitializeComponent();
    }

    private void StaticFireModeButton_Click(object sender, RoutedEventArgs e)
        => this.ChangePageDisplay<StaticFireMode>();

    private void LaunchModeButton_Click(object sender, RoutedEventArgs e)
        => this.ChangePageDisplay<LaunchMode>();

    private void ControlBuilderModeButton_Click(object sender, RoutedEventArgs e)
        => this.ChangePageDisplay<ControlBuilderMode>();

    private void CalibrationModeButton_Click(object sender, RoutedEventArgs e)
        => this.ChangePageDisplay<CalibrateMode>();

    private void ChangePageDisplay<T>() where T : Page, new()
        => _npage(new T());
}
