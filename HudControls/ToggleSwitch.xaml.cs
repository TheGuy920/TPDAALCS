using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HudControls;
/// <summary>
/// Interaction logic for ToggleSwitch.xaml
/// </summary>
public partial class ToggleSwitch : UserControl
{
    public static readonly DependencyProperty SwitchStateProperty = DependencyProperty.Register(nameof(SwitchState), typeof(bool), typeof(ToggleSwitch), new PropertyMetadata(false));
    public bool SwitchState
    {
        get { return (bool)GetValue(SwitchStateProperty); }
        set { SetValue(SwitchStateProperty, value); }
    }

    // background image
    public static readonly DependencyProperty BackgroundImageProperty = DependencyProperty.Register(nameof(BackgroundImage), typeof(ImageSource), typeof(ToggleSwitch), new PropertyMetadata(null));
    public ImageSource BackgroundImage
    {
        get { return (ImageSource)GetValue(BackgroundImageProperty); }
        set { SetValue(BackgroundImageProperty, value); }
    }

    // safety cover enabled
    public static readonly DependencyProperty SafetyCoverEnabledProperty = DependencyProperty.Register(nameof(SafetyCoverEnabled), typeof(bool), typeof(ToggleSwitch), new PropertyMetadata(false));
    public bool SafetyCoverEnabled
    {
        get { return (bool)GetValue(SafetyCoverEnabledProperty); }
        set { SetValue(SafetyCoverEnabledProperty, value); }
    }

    public event MouseButtonEventHandler? OnToggle;

    public ToggleSwitch()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    private void OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        => this.ToggleState(e);

    private void ToggleState(MouseButtonEventArgs? e = null)
    {
        this.SwitchState = !this.SwitchState;
        this.SwitchAnimation();
        this.OnToggle?.Invoke(this, e);
    }

    private void SwitchAnimation()
    {
        if (this.SwitchState)
        {
            // animate switch from off to on
            Task.Delay(25).ContinueWith(_ => this.Dispatcher.Invoke(() =>
            {
                this.buttonImageOff.Visibility = Visibility.Hidden;
                this.buttonImageNone.Visibility = Visibility.Visible;
            }));

            Task.Delay(50).ContinueWith(_ => this.Dispatcher.Invoke(() =>
            {
                this.buttonImageNone.Visibility = Visibility.Hidden;
                this.buttonImageOn.Visibility = Visibility.Visible;
            }));
        }
        else
        {
            // animate switch from on to off
            Task.Delay(25).ContinueWith(_ => this.Dispatcher.Invoke(() =>
            {
                this.buttonImageOn.Visibility = Visibility.Hidden;
                this.buttonImageNone.Visibility = Visibility.Visible;
            }));

            Task.Delay(50).ContinueWith(_ => this.Dispatcher.Invoke(() =>
            {
                this.buttonImageNone.Visibility = Visibility.Hidden;
                this.buttonImageOff.Visibility = Visibility.Visible;
            }));
        }
    }

    private bool _isDoorOpen = false; // Track door state

    // Function to toggle door state
    public void ToggleDoor()
    {
        // Create the animation for the TranslateTransform.Y property
        var animation = new DoubleAnimation
        {
            Duration = new Duration(TimeSpan.FromMilliseconds(100)),
            To = _isDoorOpen ? 0 : -40 // Move up if closed, move down if open
        };

        // Apply the animation to the door
        DoorTransform.BeginAnimation(TranslateTransform.YProperty, animation);

        // Toggle door state
        _isDoorOpen = !_isDoorOpen;
    }

    private void Door_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.ToggleDoor();
        e.Handled = true;
    }
}

// create converter class for bool -> Visibility
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool b && b ? Visibility.Visible : Visibility.Hidden;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is Visibility v && v == Visibility.Visible;
}

public class MarginToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool b && b ? new Thickness(0,15,0,7) : new Thickness(0);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}