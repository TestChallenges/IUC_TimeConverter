namespace _Constants;

public static class Constants
{
    public static readonly uint MILLISECOND_IN_SECONDS = 1000;
    public static readonly uint SECONDS_IN_MINUTE = 60;
    public static readonly uint MINUTES_IN_HOUR = 60;
    public static readonly uint HOURS_IN_DAY = 24;

    public static readonly uint DAYS_IN_USUAL_YEAR = 365;
    public static readonly uint DAYS_IN_LEAP_YEAR = 366;
    public static readonly uint MONTHS_IN_YEAR = 12;

    public static readonly uint[] DAYS_IN_MONTHS_OF_USUAL_YEAR =
    {
        31,
        28,
        31,
        30,
        31,
        30,
        31,
        31,
        30,
        31,
        30,
        31
    };
    public static readonly uint[] DAYS_IN_MONTHS_OF_LEAP_YEAR = new uint[MONTHS_IN_YEAR];

    public static readonly uint[] LAST_DAY_NUMBERS_OF_USUAL_YEAR_MONTHS = new uint[MONTHS_IN_YEAR];
    public static readonly uint[] LAST_DAY_NUMBERS_OF_LEAP_YEAR_MONTHS = new uint[MONTHS_IN_YEAR];

    static Constants()
    {
        DAYS_IN_MONTHS_OF_USUAL_YEAR.CopyTo(DAYS_IN_MONTHS_OF_LEAP_YEAR, 0);
        DAYS_IN_MONTHS_OF_LEAP_YEAR[1] = 29;

        LAST_DAY_NUMBERS_OF_USUAL_YEAR_MONTHS[0] = DAYS_IN_MONTHS_OF_USUAL_YEAR[0];
        for (var i = 1; i < MONTHS_IN_YEAR; ++i)
        {
            LAST_DAY_NUMBERS_OF_USUAL_YEAR_MONTHS[i] =
                LAST_DAY_NUMBERS_OF_USUAL_YEAR_MONTHS[i - 1] + DAYS_IN_MONTHS_OF_USUAL_YEAR[i];
        }

        LAST_DAY_NUMBERS_OF_LEAP_YEAR_MONTHS[0] = LAST_DAY_NUMBERS_OF_LEAP_YEAR_MONTHS[0];
        for (var i = 1; i < MONTHS_IN_YEAR; ++i)
        {
            LAST_DAY_NUMBERS_OF_LEAP_YEAR_MONTHS[i] =
                LAST_DAY_NUMBERS_OF_USUAL_YEAR_MONTHS[i - 1] + DAYS_IN_MONTHS_OF_LEAP_YEAR[i];
        }
    }
}
