

using Syncfusion.Maui.Charts;

namespace AddDataPoint
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

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
}