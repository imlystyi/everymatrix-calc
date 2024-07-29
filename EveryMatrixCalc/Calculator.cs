namespace EveryMatrixCalc;

internal class Calculator
{
    public Calculator()
    {
        Console.WriteLine(""); // TODO: Write instruction
    }

    public void StartLoop()
    {
        while (true)
        {
            Console.Write("Enter an expression\n> ");

            string input = Console.ReadLine();

            if (input == null)
                Console.WriteLine("Error: expression cannot be empty");

            input = string.Join("", input.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            string[] inputSplit = input.Split('+');

            if (inputSplit.Length != 2)
            {
                Console.WriteLine("Error: invalid expression");

                continue;
            }

            if (!double.TryParse(inputSplit.First(), out double firstOperand))
            {
                Console.WriteLine("Error: first operand is invalid");

                continue;
            }

            if (!double.TryParse(inputSplit.Last(), out double secondOperand))
            {
                Console.WriteLine("Error: second operand is invalid");

                continue;
            }

            Console.WriteLine($"{firstOperand} + {secondOperand} = {firstOperand + secondOperand}");
        }
    }
}
