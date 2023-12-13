namespace General.Helpers
{
    public static class ByteHelper
    {
        public static bool SlowEquals(this byte[] a, byte[] b)
        {
            var diff = a.Length ^ b.Length;

            for (var i = 0; i < a.Length && i < b.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }
    }
}
