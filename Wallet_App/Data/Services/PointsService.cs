namespace Wallet_App.Data.Services
{
    public class PointsService : IPointsService
    {
        private readonly DateTime _springStart = new DateTime(DateTime.Now.Year, 3, 1);
        private readonly DateTime _summerStart = new DateTime(DateTime.Now.Year, 6, 1);
        private readonly DateTime _autumnStart = new DateTime(DateTime.Now.Year, 9, 1);
        private readonly DateTime _winterStart = new DateTime(DateTime.Now.Year, 12, 1);

        public string GetDaypoints()
        {
            DateTime currentDate = DateTime.Now;
            double seasonPoints = 0;
            int daysPassed;

            if (currentDate < _summerStart)
                daysPassed = (currentDate - _springStart).Days;
            else if (currentDate < _autumnStart)
                daysPassed = (currentDate - _summerStart).Days;
            else if (currentDate < _winterStart)
                daysPassed = (currentDate - _autumnStart).Days;
            else
                daysPassed = (currentDate - _winterStart).Days;

            if (daysPassed == 0)
                seasonPoints = 2;
            else if (daysPassed == 1)
                seasonPoints = 3;
            else
            {
                double previousDayPoints = 3;
                double dayBeforePreviousPoints = 2;

                for (int i = 2; i <= daysPassed; i++)
                {
                    double currentDayPoints = ((double)previousDayPoints / 100 * 60) + dayBeforePreviousPoints;
                    dayBeforePreviousPoints = previousDayPoints;
                    previousDayPoints = currentDayPoints;
                }

                seasonPoints = previousDayPoints;
            }

            return FormatPoints((ulong)seasonPoints);
        }

        private static string FormatPoints(ulong points)
        {

            if (points >= 1000)
            {
                ulong remainder = points % 1000;
                ulong newpoints = points % 1000 >= 500 ? points + (1000 - remainder) : points - remainder;
                return $"{newpoints / 1000}K";
            }
            else
                return points.ToString();
        }
    }
}
