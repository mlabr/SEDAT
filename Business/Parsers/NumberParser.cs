using System;
using System.Collections.Generic;
using System.Globalization;
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

		public static float StringToFloat(string str)
		{
			str = removeMessFromString(str);
			str = removeUselessSeparatorsExceptFirst(str);
			float result = 0.0f;

			result = Convert.ToSingle(str, new CultureInfo("en-US"));

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

		private static string removeUselessSeparatorsExceptFirst(string input)
		{
			input = input.Trim();
			input = input.Replace(",", ".");
			int firstDotIndex = input.IndexOf('.');

			// no dots
			if (firstDotIndex < 0)
			{
				return input;
			}

			char[] resultArray = input.ToCharArray();
			for (int i = 0; i < resultArray.Length; i++)
			{
				if (i != firstDotIndex && resultArray[i] == '.')
				{
					resultArray[i] = '\0'; // Odebereme ostatní tečky (nahradíme nulovým znakem)
				}
			}

			// Vytvoříme finální čistý řetězec
			string result = new string(resultArray).Replace("\0", "");

			return result;
		}


	}
}
