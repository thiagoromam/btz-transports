namespace General.Helpers
{
    public static class StringHelper
    {
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static string IfEmptyThenNull(this string input)
        {
            return input.IsNullOrWhiteSpace() ? null : input;
        }
    }
}
