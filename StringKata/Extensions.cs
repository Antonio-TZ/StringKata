using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata {
    public static class Extensions {
        private static Func<int, bool> negativeNumbers() => number => number < 0;

        public static int asInt(this string value) {
            int parsed = 0;
            return int.TryParse(value, out parsed) ? parsed : 0;
        }

        public static IEnumerable<int> throwExceptionForNegatives(this IEnumerable<int> numbers) {
            if (numbers.Any(negativeNumbers())) {
                throw new ArgumentOutOfRangeException("Negatives not allowed : " + string.Join(",", numbers.Select(negativeNumbers())));
            }
            return numbers;
        }
    }
}
