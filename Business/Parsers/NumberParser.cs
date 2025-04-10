using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Parsers
{
	public static class NumberParser
	{
		public static int StringToInt(string str)
		{

			str = removeMessFromString(str);
			str = removeUselessSeparatorsAll(str);
			int result = 0;

			result = Convert.ToInt32(str);

			return result;
		}


		private static string removeMessFromString(string input)
		{
			input = input.Trim();
			input = input.Replace(",", ".");
			return Regex.Replace(input, @"[^0-9,\.]", "");
		}

		private static string removeUselessSeparatorsAll(string input)
		{
			input = input.Trim();
			input = input.Replace(",", ".");
			var result = input.Replace(".", "");

			return result;
		}

		private static string removeUselessSeparatorsExcepFirst(string input)
		{
			input = input.Trim();
			input = input.Replace(",", ".");
			int firstDotIndex = input.IndexOf('.');

			// no dots
			if (firstDotIndex < 0)
			{
				
				return input;
			}

			var result = input.Remove(firstDotIndex).Replace(".", "");
			// return dot on position
			result = result.Insert(firstDotIndex, ".");

			return result;
		}


	}
}
