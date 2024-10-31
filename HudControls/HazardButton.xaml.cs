using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HudControls;
/// <summary>
/// Interaction logic for HazardButton.xaml
/// </summary>
public partial class HazardButton : UserControl
{
    private bool _isReady = false;
    public bool IsReady
    {
        get => _isReady;
        set
        {
            _isReady = value;
            this.Dispatcher.BeginInvoke(this.ButtonReady, this._isReady);
        }
    }

    // click event
    public event MouseButtonEventHandler? OnClick;

    public HazardButton()
    {
        InitializeComponent();
    }

    private void ButtonReady(bool readyState)
    {
        if (readyState)
        {
            this.GBackground.Opacity = 0;
            this.RGlow.Visibility = System.Windows.Visibility.Visible;
        }
        else
        {
            this.GBackground.Opacity = 0.5;
            this.RGlow.Visibility = System.Windows.Visibility.Hidden;
        }
    }

    private Point? beforeSizeTL;
    private Point? beforeSizeBR;
    private readonly ConcurrentDictionary<AnimationTimeline, byte> animations = [];

    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (!this._isReady || this.animations.Keys.Count > 0)
            return;

        this.beforeSizeTL = new Point(TopLeftCorner.ActualWidth, TopLeftCorner.ActualHeight);
        this.beforeSizeBR = new Point(BottomRightCorner.ActualWidth, BottomRightCorner.ActualHeight);

        AnimateGrid(-5, 4);
        AnimateCornerSize(TopLeftCorner, 0, 0);
        AnimateCornerSize(BottomRightCorner, 0, 0);
    }

    private void Grid_MouseLeave(object sender, MouseEventArgs e)
    {
        this.Grid_MouseUp(sender, null);
    }

    private void Grid_MouseUp(object sender, MouseButtonEventArgs? e)
    {
        animations.Clear();

        AnimateGrid(0, 0, true);

        AnimateCornerSize(TopLeftCorner, this.beforeSizeTL?.X ?? 50, this.beforeSizeTL?.Y ?? 50);
        AnimateCornerSize(BottomRightCorner, this.beforeSizeBR?.X ?? 50, this.beforeSizeBR?.Y ?? 50);

        // Raise the click event
        this.OnClick?.Invoke(this, e);
    }

    // Method to animate the grid's position
    private void AnimateGrid(double toX, double toY, bool isLast = false)
    {
        // Animate X-axis translation
        var xAnimation = new DoubleAnimation
        {
            To = toX,                 // Target position on X-axis
            Duration = TimeSpan.FromMilliseconds(150),  // Duration of the animation
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut } // Smooth transition
        };

        // Animate Y-axis translation
        var yAnimation = new DoubleAnimation
        {
            To = toY,                 // Target position on Y-axis
            Duration = TimeSpan.FromMilliseconds(150),  // Duration of the animation
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut } // Smooth transition
        };

        // make sure the target and current values are different (or exit)
        if (GridTranslateTransform.X == toX && GridTranslateTransform.Y == toY)
            return;

        animations.TryAdd(xAnimation, 1);
        xAnimation.Completed += (s, e) => animations.Remove(xAnimation, out _);
        xAnimation.RemoveRequested += (s, e) => animations.Remove(xAnimation, out _);

        GridTranslateTransform.BeginAnimation(TranslateTransform.XProperty, xAnimation);
        GridTranslateTransform.BeginAnimation(TranslateTransform.YProperty, yAnimation);
    }

    // Animate corner elements' size (Width and Height)
    private void AnimateCornerSize(FrameworkElement corner, double toWidth, double toHeight)
    {
        // Animate Width
        var widthAnimation = new DoubleAnimation
        {
            From = corner.ActualWidth,  // Start from current width
            To =  toWidth,
            Duration = TimeSpan.FromMilliseconds(150),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
        };

        // Animate Height
        var heightAnimation = new DoubleAnimation
        {
            From = corner.ActualHeight,  // Start from current height
            To = toHeight,
            Duration = TimeSpan.FromMilliseconds(150),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
        };

        // Apply animations to both Width and Height
        corner.BeginAnimation(FrameworkElement.MaxWidthProperty, widthAnimation);
        corner.BeginAnimation(FrameworkElement.MaxHeightProperty, heightAnimation);
    }
}
