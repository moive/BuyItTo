using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyItTo
{
    /// <summary>
    /// Performs objects high level validation
    /// </summary>
    public static class Validate
    {
        public static void AreEqual(object A, object B, string message)
        {
            if (!A.Equals(B))
                ThrowEx(message);
        }

        public static void isTrue(bool p, string message)
        {
            if (!p)
                ThrowEx(message);
        }

        public static void isFalse(bool p, string message)
        {
            if (p)
                ThrowEx(message);
        }

        public static void NotEqual<T>(T A, T B, string message)
        {
            if (A.Equals(B))
                ThrowEx(message);
        }

        public static void NotNullEmpty<T>(IList<T> lst, string message)
        {
            if (lst == null || lst.Count == 0)
                ThrowEx(message);
        }

        public static void Regex(string value, string regex, string message)
        {
            if (string.IsNullOrEmpty(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, regex))
                ThrowEx(message);
        }

        public static void KeyExists<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey ID, string message){
            if (!dict.ContainsKey(ID))
                ThrowEx(message);
        }

        public static void KeyNotExists<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey ID, string messagse)
        {
            if (dict.ContainsKey(ID))
                ThrowEx(messagse);
        }

        public static void MaxLength(string p1, int maxlength, string message)
        {
            if (p1 != null && p1.Length > maxlength)
                ThrowEx(message);
        }

        private static void ThrowEx(string message)
        {
            throw new BusinessRuleException(message);
        }
    }
}