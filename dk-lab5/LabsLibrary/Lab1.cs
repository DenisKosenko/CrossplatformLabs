using System;

namespace LabsLibrary
{
	public class Lab1Runner
	{
		public Lab1Runner(string inputNumber)
		{
			_inputNumber = inputNumber;
		}
		private readonly string _inputNumber;

		public string RunLab()
		{
			int inputNumber = Convert.ToInt32(_inputNumber.Trim());
			if (inputNumber >= 1 && inputNumber <= 109)
			{
				int result = 0;
				for (int i = 1; i <= inputNumber; i += 2)
				{
					if (i % 3 != 0 && i % 5 != 0)
					{
						result++;
					}
				}

				return result.ToString();
			}
			else
			{
				return "Number is out of range";
			}
		}
	}
}