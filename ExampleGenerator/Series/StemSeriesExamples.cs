using System;

namespace ExampleGenerator
{
	using OxyPlot;
	using OxyPlot.Axes;
	using OxyPlot.Series;

	public class StemSeriesExamples
	{
		[Export(@"Series\StemSeries")]
		public static PlotModel StemSeries()
		{

			var model = new PlotModel{ Title = "Fun with Bats" };

			Func<double, double>[] batFn = new Func<double, double>[]
			{
				(x) => 2 * Math.Sqrt(-Math.Abs(Math.Abs(x) - 1) * Math.Abs(3 - Math.Abs(x)) / ((Math.Abs(x) - 1) * (3 - Math.Abs(x)))) * (1 + Math.Abs(Math.Abs(x) - 3) / (Math.Abs(x) - 3)) * Math.Sqrt(1 - Math.Pow((x / 7), 2)) + (5 + 0.97 * (Math.Abs(x - 0.5) + Math.Abs(x + 0.5)) - 3 * (Math.Abs(x - 0.75) + Math.Abs(x + 0.75))) * (1 + Math.Abs(1 - Math.Abs(x)) / (1 - Math.Abs(x))),
				(x) => -3 * Math.Sqrt(1 - Math.Pow((x / 7), 2)) * Math.Sqrt(Math.Abs(Math.Abs(x) - 4) / (Math.Abs(x) - 4)),
				(x) => Math.Abs(x / 2) - 0.0913722 * (Math.Pow(x, 2)) - 3 + Math.Sqrt(1 - Math.Pow((Math.Abs(Math.Abs(x) - 2) - 1), 2)),
				(x) => (2.71052 + (1.5 - .5 * Math.Abs(x)) - 1.35526 * Math.Sqrt(4 - Math.Pow((Math.Abs(x) - 1), 2))) * Math.Sqrt(Math.Abs(Math.Abs(x) - 1) / (Math.Abs(x) - 1)) + 0.9
			};

			for(int i = 0; i < batFn.Length; ++i)
			{
				var stemSeries = new StemSeries
				{
					Base = 0.0,
					//the minimal neccessary properties to display markers:
					MarkerStroke = OxyColors.Black,
					MarkerType = MarkerType.Circle
				};

				for(double x = -8.0; x < 8.0; x += 0.1)
				{
					stemSeries.Points.Add(new DataPoint(x, batFn[i](x)));
				}

				model.Series.Add(stemSeries);
			}

			return model;
		}
	}
}