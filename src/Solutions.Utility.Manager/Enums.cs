namespace Solutions.Utility.Manager
{

    public enum TypeReturnNullToValue
    {
        ReturnString = 1,
        ReturnNumeric = 2,
        ReturnBoolean = 3,
        ReturnDate = 4
    }

    public enum TypeDateFormat
    {
        NotZero = 0,
        Day_Month_Year = 1,
        Day_MonthName_Year = 2,
        DayName_MonthName_Year = 3,
        Day_Month_YearTwoDigits = 4
    }

    public enum TypeTimeFormat
    {
        HourComplete_Minute = 1,
        Hour_Minute = 2,
        HourComplete_Minute_AMPM = 3,
        Hour_Minute_AMPM = 4,
        HourComplete_Minute_Second = 5,
        Hour_Minute_Second = 6,
        HourComplete_Minute_Second_AMPM = 7,
        Hour_Minute_Second_AMPM = 8
    }

}
