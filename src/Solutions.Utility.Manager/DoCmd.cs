using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace Solutions.Utility.Manager
{
    public class DoCmd
    {

        #region DBNull

        public static object DBNullToValue(object value, TypeReturnNullToValue type)
        {
            object Retorno = new object();
            switch (type)
            {
                case TypeReturnNullToValue.ReturnString:
                    if (value == null) { Retorno = string.Empty; }
                    else { Retorno = value; }
                    break;
                case TypeReturnNullToValue.ReturnNumeric:
                    if (value == null) { Retorno = 0; }
                    else { Retorno = value; }
                    break;
                case TypeReturnNullToValue.ReturnDate:
                    if (value == null) { Retorno = DateTime.MinValue; }
                    else { Retorno = value; }
                    break;
                case TypeReturnNullToValue.ReturnBoolean:
                    if (value == null) { Retorno = false; }
                    else { Retorno = value; }
                    break;
            }
            return Retorno;
        }

        public static string DBNullString(object value)
        { return (value == null) ? string.Empty : value.ToString(); }

        public static int DBNullInteger(object value)
        { return (value == null) ? 0 : (int)value; }

        public static long DBNullLong(object value)
        { return (value == null) ? 0 : (long)value; }

        public static double DBNullDouble(object value)
        { return (value == null) ? 0 : (double)value; }

        public static bool DBNullBoolean(object value)
        { return (value == null) ? false : (bool)value; }

        public static DateTime DBNullDate(object value)
        { return (value == null) ? DateTime.MinValue : (DateTime)value; }

        #endregion DBNull

        #region DateAndTime

        public static string DateDayStr(DateTime date) => ("00" + date.Day.ToString().Trim()).Right(2);

        public static string DateMonthStr(DateTime date) => ("00" + date.Month.ToString().Trim()).Right(2);

        public static string DateYearStr(DateTime date) => ("0000" + date.Year.ToString().Trim()).Right(4);

        #endregion DateAndTime

        #region Format

        public static string FormatDateString(DateTime value, TypeDateFormat format)
        {
            string sFormat = string.Empty;
            if (format == TypeDateFormat.NotZero) { sFormat = "d/M/yy"; }
            if (format == TypeDateFormat.Day_Month_Year) { sFormat = "dd/MM/yyyy"; }
            if (format == TypeDateFormat.Day_MonthName_Year) { sFormat = "dd/MMMM/yyyy"; }
            if (format == TypeDateFormat.DayName_MonthName_Year) { sFormat = "dddd/MMMM/yyyy"; }
            if (format == TypeDateFormat.Day_Month_YearTwoDigits) { sFormat = "dd/MM/yy"; }
            return value.ToString(sFormat);
        }

        public static string FormatTimeString(DateTime value, TypeTimeFormat format)
        {
            string sFormat = string.Empty;
            if (format == TypeTimeFormat.HourComplete_Minute) { sFormat = "HH:mm"; }
            if (format == TypeTimeFormat.Hour_Minute) { sFormat = "hh:mm"; }
            if (format == TypeTimeFormat.HourComplete_Minute_AMPM) { sFormat = "HH:mm tt"; }
            if (format == TypeTimeFormat.Hour_Minute_AMPM) { sFormat = "hh:mm tt"; }
            if (format == TypeTimeFormat.HourComplete_Minute_Second) { sFormat = "HH:mm:ss"; }
            if (format == TypeTimeFormat.Hour_Minute_Second) { sFormat = "hh:mm:ss"; }
            if (format == TypeTimeFormat.HourComplete_Minute_Second_AMPM) { sFormat = "HH:mm:ss tt"; }
            if (format == TypeTimeFormat.Hour_Minute_Second_AMPM) { sFormat = "hh:mm:ss tt"; }
            return value.ToString(sFormat);
        }

        public static string FormatNumber(object value, int numdecimal, bool symbol)
        {
            string retorno;
            if (symbol) { retorno = decimal.Parse(value.ToString()).ToString("C" + numdecimal.ToString()); }
            else
            { retorno = decimal.Parse(value.ToString()).ToString("F" + numdecimal.ToString()); }
            return retorno;
        }

        #endregion Format

        #region Interaction

        public static object InteractionIIf(bool Expression, object TruePart, object FalsePart)
        { return (Expression) ? TruePart : FalsePart; }

        public static object InteractionChoose(double Index, params object[] Choice)
        { return Choice[(int)Index]; }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++) { values[i] = props[i].GetValue(item); }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion Interaction

        #region Information

        public static bool IsArray(object VarName)
        {
            Type at = VarName.GetType();
            return at.IsArray;
        }

        public static bool IsDate(object Expression)
        {
            return DateTime.TryParse(Expression.ToString(), out DateTime dt);
        }

        public static bool IsDBNull(object Expression)
        { return Convert.IsDBNull(Expression); }

        public static bool IsNumeric(object Expression)
        {
            return int.TryParse(Expression.ToString(), out int result);
        }

        #endregion Information

        #region Image

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.Image image;
            using (MemoryStream stream = new MemoryStream(byteArrayIn))
            {
                image = new Bitmap(stream);
            }
            return image;
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            return (byte[])TypeDescriptor.GetConverter(imageIn).ConvertTo(imageIn, typeof(byte[]));
        }

        #endregion Image

    }

}
