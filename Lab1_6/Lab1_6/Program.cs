namespace Lab1_6
{
    public class Program
    {
        public static string InputFilePath = @"input.txt";
        public static string OutputFilePath = @"output.txt";

        static void Main(string[] args)
        {
            FileInfo outputFileInfo = new FileInfo(OutputFilePath);
            int inputNumber = Convert.ToInt32(File.ReadLines(InputFilePath).First().Trim());
            if (inputNumber >= 1 && inputNumber <= 109)
            {
                int result = 0;
                for(int i = 1; i <= inputNumber; i += 2)
                {
                    if (i % 3 != 0 && i % 5 != 0)
                    {
                        result++;
                    }
                }

                using (StreamWriter streamWriter = outputFileInfo.CreateText())
                {
                    streamWriter.WriteLine(result);
                }
            }
            else
            {
                using (StreamWriter streamWriter = outputFileInfo.CreateText())
                {
                    streamWriter.WriteLine("Number is out of range");
                }
            }
        }
    }
}