using System.Globalization;

namespace Services.Task3
{
	internal class DateService
	{
		public static string GetDay(string date)
		{
			DateTime dateTime = DateTime.Parse(date, CultureInfo.GetCultureInfo("ru-RU"));
			return dateTime.ToString("dddd");
		}

		public static TimeSpan GetDaysSpan(int day, int month, int year)
		{
			return (DateTime.Now - new DateTime(year, month, day)).Duration();
		}
	}
}