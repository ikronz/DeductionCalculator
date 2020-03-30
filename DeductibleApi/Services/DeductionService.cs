using System;

namespace DeductibleApi.Logic
{
	public class DeductionService
	{
		public class Result
		{
			public double DeductionYearly { get; set; }
			public double DeductionPerPaycheck { get; set; }
			public double PayAfterDeductionYearly { get; set; }
			public double PayAfterDeductionPerPaycheck { get; set; }
		}

		public static Result Calculate(string name, string[] dependentNames)
		{
			Result result = new Result();
			result.DeductionYearly = Math.Round(CalculateYearly(name, dependentNames), 2);
			result.DeductionPerPaycheck = Math.Round(CalculatePerPaycheck(result.DeductionYearly), 2);
			result.PayAfterDeductionYearly = Math.Round(52000 - result.DeductionYearly, 2);
			result.PayAfterDeductionPerPaycheck = Math.Round(2000 - result.DeductionPerPaycheck, 2);

			return result;
		}

		public static double CalculatePerPaycheck(double total)
		{
			return total / 26;
		}

		public static double CalculateYearly(string name, string[] dependentNames)
		{
			int numOfDependents = dependentNames.Length;
			double totalDependents = 0;
			double totalEmployee = 0;

			for (int i = 0; i < numOfDependents; i++)
			{
				totalDependents += ApplyDiscount(500, dependentNames[i]);
			}

			totalEmployee = ApplyDiscount(1000, name);
			double total = totalEmployee + totalDependents;

			return total;
		}

		public static double ApplyDiscount(int benefitCost, string name)
		{
			if (WhoDiscount(name))
			{
				return PercentDiscount(benefitCost);
			}
			return benefitCost;
		}

		public static bool WhoDiscount(string name, char letter = 'A')
		{
			char letterLower = Char.ToLower(letter);
			if (name[0] == letterLower)
			{
				return true;
			}
			return false;
		}

		public static double PercentDiscount(double val, int discountPercent = 10)
		{
			double discountDecimal = discountPercent * 0.01;
			double subtractAmt = val * discountDecimal;
			val = val - subtractAmt;
			return val;
		}
	}
}
