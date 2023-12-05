using _Constants;
using _Date;

namespace _TimeConverter;

public class TimeConverter
{
    private readonly uint startingYear;

    public TimeConverter(uint startingYear)
    {
        this.startingYear = startingYear;
    }

    public Date ConvertPassedMillisecondsToDate(ulong milliseconds)
    {
        var date = new Date(startingYear);
        date.AddMilliseconds(milliseconds);

        return date;
    }
}
