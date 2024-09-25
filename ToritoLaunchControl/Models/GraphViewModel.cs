using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace ToritoLaunchControl.Models;

public class GraphViewModel
{
    public PlotModel Model { get; private set; }

    public GraphViewModel()
    {
        this.Model = new PlotModel()
        {
            TextColor = OxyColors.White,
            SubtitleColor = OxyColors.White,
            TitleColor = OxyColors.White,
            PlotAreaBackground = OxyColors.Transparent,
            Background = OxyColors.Transparent,
            SelectionColor = OxyColors.Transparent,
            PlotAreaBorderColor = OxyColors.Transparent,
            DefaultColors =
            [
                OxyColors.Red,
                OxyColors.Blue,
                OxyColors.Green,
                OxyColors.Purple,
                OxyColors.Violet,
                OxyColors.Orange,
                OxyColors.Cyan,
            ],
            Axes =
            {
                new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Key = "Flow Rate",
                    Title = "Flow Rate",
                    AbsoluteMaximum = 20,
                    Maximum = 20,
                    AbsoluteMinimum = 0,
                    IsZoomEnabled = false,
                    TitleColor = OxyColors.White,
                    TextColor = OxyColors.White,
                    MajorGridlineColor = OxyColors.Gray,
                    MinorGridlineColor = OxyColors.Gray,
                    TicklineColor = OxyColors.Gray,
                    EdgeRenderingMode = EdgeRenderingMode.PreferSpeed,
                    Selectable = false,
                    CropGridlines = true,
                    Unit = "L/s",
                },
                new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Key = "Time",
                    Title = "Time",
                    AbsoluteMinimum = 0,
                    TitleColor = OxyColors.White,
                    TextColor = OxyColors.White,
                    MajorGridlineColor = OxyColors.Gray,
                    MinorGridlineColor = OxyColors.Gray,
                    TicklineColor = OxyColors.White,
                    EdgeRenderingMode = EdgeRenderingMode.PreferSpeed,
                    CropGridlines = true,
                    Selectable = false,
                    IsZoomEnabled = true,
                    Unit = "s",
                },
            },
        };

        this.Model.SelectionColor = OxyColors.Transparent;
    }
}
