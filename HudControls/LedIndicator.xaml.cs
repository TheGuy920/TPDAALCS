using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HudControls;
/// <summary>
/// Interaction logic for LedIndicator.xaml
/// </summary>
public partial class LedIndicator : UserControl
{
    public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(LedState), typeof(LedIndicator), new PropertyMetadata(LedState.Success));
    public LedState State
    {
        get { return (LedState)GetValue(StateProperty); }
        set { SetValue(StateProperty, value); }
    }

    public LedIndicator()
    {
        InitializeComponent();
        this.DataContext = this;
    }
}

public class LedColorToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is LedState ledColor)
        {
            switch (ledColor)
            {
                case LedState.Error:
                    return Brushes.Red;
                case LedState.Warning:
                    return Brushes.Gold;
                case LedState.Success:
                    return Brushes.LimeGreen;
            }
        }

        return Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}


public enum LedState
{
    Error,
    Warning,
    Success,
}
