# How-to-Add-Data-Points-on-Interactions-in-.NET-MAUI-Chart-SfCartesianChart-
This article in the Syncfusion Knowledge Base explains  how to add data points on interactions in the .NET MAUI Chart platform.
This article explains how to add data points on interactions in the [.NET MAUI Chart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts).
In .NET MAUI Chart, you can add data points to the chart using touch interactions.
The approach involves customizing the touch behavior by overriding the [OnTouchUp]() method of the [ChartInteractiveBehavior ]() class.
**Step 1:** Create the ChartInteractionExt class with inherited from the [ChartInteractiveBehavior]() class. Assign the ChartInteractionExt class to the ChartInteractiveBehavior property of the [SfCartesianChart]((https://www.syncfusion.com/maui-controls/maui-cartesian-charts)).   
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
chart.ChartInteractiveBehavior = interaction;
    . . .
```    
**Step 2:**  Customize the touch behavior by overriding the  [OnTouchUp]() method within the ChartInteractionExt class to handle the touch-up events on a chart.
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

**Output**
![Add-data-point-demo.gif](https://support.syncfusion.com/kb/agent/attachment/article/13602/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEwNjI3Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9._OepOF6PgN1lU1_08Qj-s9fCS8sjZ-Q_X3R3W4nfsnw)
Explore the runnable demo from this GitHub [location](https://github.com/SyncfusionExamples/How-to-Add-Data-Points-on-Interactions-in-.NET-MAUI-Chart-SfCartesianChart).
**Conclusion**
I hope you enjoyed learning about how to customize the axis grid line for the .NET MAUI Chart (SfCartesianChart).
You can refer to our [.NET MAUI Chart’s feature tour](https://www.syncfusion.com/maui-controls/maui-charts) page to know about its other groundbreaking feature representations. You can also explore our [.NET MAUI Chart documentation](https://help.syncfusion.com/maui/cartesian-charts/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI from the [License and Downloads](https://www.syncfusion.com/account/downloads) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our .NET MAUI Chart and other .NET MAUI components.
If you have any queries or require clarifications, please let us know in comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://www.syncfusion.com/support/directtrac/incidents/), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfcartesianchart). We are always happy to assist you!