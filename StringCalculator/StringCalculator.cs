using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string delimiters = ",|\n";
            var customDelimiterMatch = Regex.Match(numbers, @"^//(\[.*\])+\n");
            var numberList = new List<int>();

            // Match custom delimiters starting with // followed by repeating patterns enclosed 
            // in []. The delimiter patterns could be of varying lengths
            if (customDelimiterMatch.Success)
            {
                numbers = numbers.Substring(customDelimiterMatch.Length);
                delimiters = ParseDelimiters(customDelimiterMatch.Groups[1].Value);

                numberList = numbers.Split( new[] { delimiters }, StringSplitOptions.None)
                                    .Select(n => ParseNumber(n))
                                    .ToList();
            }
            // Match custom delimiter starting with // followed by a single character delimiter
            else if (numbers.StartsWith("//"))
            {
                int delimiterEndIndex = numbers.IndexOf('\n');
                delimiters = Regex.Escape(numbers.Substring(2, delimiterEndIndex - 2));
                numbers = numbers.Substring(delimiterEndIndex + 1);

                numberList = numbers.Split(new[] { delimiters }, StringSplitOptions.None)
                                    .Select(n => ParseNumber(n))
                                    .ToList();
            }
            //Use default delimiter
            else
            {
                numberList = numbers.Split(delimiters.ToCharArray(), StringSplitOptions.None)
                                    .Select(n => ParseNumber(n))
                                    .ToList();
            }            

            ValidateNumbers(numberList);

            return numberList.Where(n => n <= 1000).Sum();
        }

        private string ParseDelimiters(string delimiterSection)
        {
            var delimiters = new List<string>();
            var matches = Regex.Matches(delimiterSection, @"\[(.*?)\]");
            foreach (Match match in matches)
            {
                delimiters.Add(match.Groups[1].Value);
            }
            return string.Join("|", delimiters);
        }

        private int ParseNumber(string numberString)
        {
            if (int.TryParse(numberString, out int number))
            {
                return number;
            }
            throw new ArgumentException($"Invalid number format: {numberString}");
        }

        private void ValidateNumbers(List<int> numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }
        }
    }
}


