namespace Solutions.Utility.Manager
{

    public static class StringManager
    {

        public static string Left(this string source, int length)
        {
            return source.Substring(0, length);
        }

        public static string Right(this string source, int length)
        {
            return source.Substring(source.Length - length, length);
        }

        public static string Mid(this string source, int start, int end)
        {
            return source.Substring(start, end);
        }

        public static string Mid(this string source, int start)
        {
            return source.Substring(start, source.Length - start);
        }

    }

}
