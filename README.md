# How-to-Add-Data-Points-on-Interactions-in-.NET-MAUI-Chart-SfCartesianChart-
In [.NET MAUI Chart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts), you can personalize touch behavior by overriding the [OnTouchUp]() method in the [ChartInteractiveBehavior]() class to add data points to the chart through touch interactions.
**Step 1:** Create the extension class ChartInteractionExt with inherited from the [ChartInteractiveBehavior]() class. Personalize the touch behavior by overriding the  [OnTouchUp]() method within the ChartInteractionExt class to handle the touch-up events on a chart.
Use the [PointToValue]() method to convert the touch coordinates (pointX and pointY) into corresponding data values on the X and Y axes of the [SfCartesianChart]((https://www.syncfusion.com/maui-controls/maui-cartesian-charts)).   
**[C#]**
```
public class ChartInteractionExt : ChartInteractiveBehavior
{
    protected override void OnTouchUp(ChartBase chart, float pointX, float pointY)
    {
        base.OnTouchUp(chart, pointX, pointY);

        if (chart is SfCartesianChart cartesianChart)
        {
            var x = cartesianChart.PointToValue(cartesianChart.XAxes[0], pointX, pointY);
            var y = cartesianChart.PointToValue(cartesianChart.YAxes[0], pointX, pointY);

            if (cartesianChart.BindingContext is ViewModel viewModel)
            {
                viewModel.Data.Add(new Model(x, y));
            }
        }
    }
}
``` 
**Step 2:**  
Assign the extension class ChartInteractionExt to the [InteractiveBehavior]() property of the [SfCartesianChart]((https://www.syncfusion.com/maui-controls/maui-cartesian-charts)).   
**[XAML]**
```
</chart:SfCartesianChart>
    . . .
    <chart:SfCartesianChart.InteractiveBehavior>
        <local:ChartInteractionExt/>
    </chart:SfCartesianChart.InteractiveBehavior>
</chart:SfCartesianChart>
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();
    . . .
ChartInteractionExt interaction = new ChartInteractionExt();
chart.InteractiveBehavior = interaction;
    . . .
```    
**Output**
![Add-data-point-output.gif](https://support.syncfusion.com/kb/agent/attachment/article/13602/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjExMTk1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.10Pmr0vvOgtlMOBhWT9oPMX-2qnDib1qOnwk6mORenU)
Now you can add data points to the chart anywhere you prefer through touch input.
