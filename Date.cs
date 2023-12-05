using _Constants;

namespace _Date;

public class Date
{
    private ulong year;
    private ulong month;
    private ulong day;
    private ulong hour;
    private ulong minutes;
    private ulong seconds;
    private ulong milliseconds;

    public Date(
        uint year = 1970,
        byte month = 1,
        byte day = 1,
        byte hour = 0,
        byte minutes = 0,
        byte seconds = 0,
        byte milliseconds = 0
    )
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = hour;
        this.minutes = minutes;
        this.seconds = seconds;
        this.milliseconds = milliseconds;
    }

    public Date AddYears(ulong yearsToAdd)
    {
        year += yearsToAdd;
        return this;
    }

    public Date AddMonths(ulong monthsToAdd)
    {
        var yearsToAdd = monthsToAdd / Constants.MONTHS_IN_YEAR;
        monthsToAdd %= Constants.MONTHS_IN_YEAR;

        var totalMonths = month + monthsToAdd;

        if (totalMonths > Constants.MONTHS_IN_YEAR)
        {
            month = (totalMonths % Constants.MONTHS_IN_YEAR);
            yearsToAdd++;
        }
        else
        {
            month = totalMonths;
        }

        if (yearsToAdd > 0)
        {
            AddYears(yearsToAdd);
        }

        return this;
    }

    public Date AddDays(ulong daysToAdd)
    {
        bool isFullYear;
        do
        {
            var daysCountInCurrentYear = GetDaysCountInCurrentYear();
            isFullYear = daysToAdd >= daysCountInCurrentYear;

            if (isFullYear)
            {
                daysToAdd -= daysCountInCurrentYear;
                AddYears(1);
            }
        } while (isFullYear);

        bool isFullMonth;
        uint daysInCurrentMonth;
        do
        {
            daysInCurrentMonth = GetDaysCountInCurrentMonth();
            isFullMonth = daysToAdd >= daysInCurrentMonth;

            if (isFullMonth)
            {
                daysToAdd -= daysInCurrentMonth;
                AddMonths(1);
            }
        } while (isFullMonth);

        do
        {
            daysInCurrentMonth = GetDaysCountInCurrentMonth();
            var daysToMonthEnd = daysInCurrentMonth - day;
            isFullMonth = daysToAdd > daysToMonthEnd;

            if (isFullMonth)
            {
                daysToAdd -= daysToMonthEnd + 1;
                day = 1;
                AddMonths(1);
            }
            ;
        } while (isFullMonth);
        day += daysToAdd;

        return this;
    }

    public Date AddHours(ulong hoursToAdd)
    {
        var daysToAdd = hoursToAdd / Constants.HOURS_IN_DAY;
        hoursToAdd %= Constants.HOURS_IN_DAY;

        var totalHours = hour + hoursToAdd;
        hour = totalHours % Constants.HOURS_IN_DAY;
        if (totalHours >= Constants.HOURS_IN_DAY)
        {
            daysToAdd++;
        }

        if (daysToAdd > 0)
        {
            AddDays(daysToAdd);
        }

        return this;
    }

    public Date AddMinutes(ulong minutesToAdd)
    {
        var hoursToAdd = minutesToAdd / Constants.MINUTES_IN_HOUR;
        minutesToAdd %= Constants.MINUTES_IN_HOUR;

        var totalMinutes = minutes + minutesToAdd;
        if (totalMinutes > Constants.MINUTES_IN_HOUR)
        {
            minutes = totalMinutes % Constants.MINUTES_IN_HOUR;
            hoursToAdd++;
        }
        else
        {
            minutes = totalMinutes;
        }

        if (hoursToAdd > 0)
        {
            AddHours(hoursToAdd);
        }

        return this;
    }

    public Date AddSeconds(ulong secondsToAdd)
    {
        var minutesToAdd = secondsToAdd / Constants.SECONDS_IN_MINUTE;
        secondsToAdd %= Constants.SECONDS_IN_MINUTE;

        var totalSeconds = seconds + secondsToAdd;
        if (totalSeconds > Constants.SECONDS_IN_MINUTE)
        {
            seconds = totalSeconds % Constants.SECONDS_IN_MINUTE;
            minutesToAdd++;
        }
        else
        {
            seconds = totalSeconds;
        }

        if (minutesToAdd > 0)
        {
            AddMinutes(minutesToAdd);
        }

        return this;
    }

    public Date AddMilliseconds(ulong millisecondsToAdd)
    {
        var secondsToAdd = millisecondsToAdd / Constants.MILLISECOND_IN_SECONDS;
        millisecondsToAdd %= Constants.MILLISECOND_IN_SECONDS;

        var totalMilliseconds = milliseconds + millisecondsToAdd;
        if (totalMilliseconds > Constants.MILLISECOND_IN_SECONDS)
        {
            milliseconds = totalMilliseconds % Constants.MILLISECOND_IN_SECONDS;
            secondsToAdd++;
        }
        else
        {
            milliseconds = totalMilliseconds;
        }

        if (secondsToAdd > 0)
        {
            AddSeconds(secondsToAdd);
        }

        return this;
    }

    public override string ToString()
    {
        return $"{day:D2}.{month:D2}.{year} {hour:D2}:{minutes:D2}:{seconds:D2}.{milliseconds:D3}";
    }

    private uint GetDaysCountInCurrentYear()
    {
        return IsLeapYear() ? Constants.DAYS_IN_LEAP_YEAR : Constants.DAYS_IN_USUAL_YEAR;
    }

    private uint GetDaysCountInCurrentMonth()
    {
        var monthIndex = month - 1;
        return IsLeapYear()
            ? Constants.DAYS_IN_MONTHS_OF_LEAP_YEAR[monthIndex]
            : Constants.DAYS_IN_MONTHS_OF_USUAL_YEAR[monthIndex];
    }

    private bool IsLeapYear()
    {
        bool result = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        return result;
    }
}
