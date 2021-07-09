using System;
using System.Collections.Generic;

namespace Helpers
{
    public static class Helpers
    {
        public static List<String> SplitChunks(this string str, int n)
        {
            List<String> ans = new List<String>();
            if (String.IsNullOrEmpty(str) || n < 1)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < str.Length; i += n)
            {
                ans.Add(str.Substring(i, Math.Min(n, str.Length - i)));
            }
            return ans;
        }

        public static string PadSides(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            "Amelia se bebe una soda".SplitChunks(5);
            return str.PadLeft(padLeft).PadRight(length);

        }

    }
}
