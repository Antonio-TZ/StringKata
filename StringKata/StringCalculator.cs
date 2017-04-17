using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata {
    internal class StringCalculator {
        private string[] fixedDelimiters = new string[2] { ",", "\n" };
        private const string delimiterPattern = @"(?<=\[)[^\]]*(?=\])|(?<=//).(?=\n)";

        public int add(string input) {
            return input.Split(delimiters(input), StringSplitOptions.RemoveEmptyEntries)
                .Select(number => number.asInt())
                .throwExceptionForNegatives()
                .Where(number => number < 1001)
                .Sum();
        }

        private string[] delimiters(string input) {
            return Regex.Matches(input, delimiterPattern)
                .OfType<Match>()
                .Select(match => match.Value)
                .Union(fixedDelimiters)
                .ToArray();
        }
    }
}