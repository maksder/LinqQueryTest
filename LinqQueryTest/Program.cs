using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryTest
{
	internal class Program
	{
		#region Private
		private static IEnumerable<string> GetAllSequences(IEnumerable<char> chars)
		{
			chars = chars.ToList();
			if (chars.Count() == 1)
			{
				return chars.Select(p => p.ToString());
			}

			var output = new List<string>();
			for (var i = 0; i < chars.Count(); i++)
			{
				foreach (var sequence in GetAllSequences(chars.Take(i)
															  .Concat(chars.Skip(i + 1)
																		   .Take(chars.Count() - i - 1)))
							 .Where(sequence => !output.Contains(chars.ElementAt(i) + sequence)))
				{
					output.Add(chars.ElementAt(i) + sequence);
				}
			}

			return output;
		}

		private static void Main(string[] args)
		{
			var chars = new[]
			{
				'A',
				'B',
				'C'
			};

			var result = GetAllSequences(chars);

			foreach (var str in result)
			{
				Console.WriteLine(str);
			}
		}
		#endregion
	}
}
