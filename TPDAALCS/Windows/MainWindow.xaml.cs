using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TPDAAC.Windows.Modes;

namespace TPDAALCS;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.PageDisplay.Navigate(new SelectorMode(ChangePageDisplay));
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        => this.WindowState = WindowState.Minimized;

    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        => this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

    private void CloseButton_Click(object sender, RoutedEventArgs e)
        => this.Close();

    private Point? GrapplePoint = null;

    private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton != MouseButton.Left)
            return;

        this.GrapplePoint = e.GetPosition(this);
        e.Handled = true;
    }

    private void Window_MouseUp(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton != MouseButton.Left)
            return;

        this.GrapplePoint = null;
    }

    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
        if (GrapplePoint is null)
            return;

        if (e.LeftButton == MouseButtonState.Pressed)
        {
            Point p = e.GetPosition(this);
            this.Left += p.X - GrapplePoint.Value.X;
            this.Top += p.Y - GrapplePoint.Value.Y;
        }
    }

    private void ChangePageDisplay(Page p)
    {
        this.PageDisplay.Navigate(p);
        this.PageDisplay.Navigated += (s, e) => this.PageDisplay.RemoveBackEntry();
    }
}