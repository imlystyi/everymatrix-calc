namespace EveryMatrixCalc;

internal class Calculator
{
    private readonly int _precision;

    public Calculator()
    {
        Console.WriteLine("""
                          Calculator app is running.
                          Instruction:
                          1. Enter an expression in the following format: [operand] [operator] [operand]
                             Supported operators: +, -, *, /
                             Supported operands: any number or NaN
                          2. Separate each part of the expression with a whitespace
                          3. Press Enter to calculate the expression

                          Enter the precision of the result (number of decimal places)
                          """);

        Console.Write("> ");

        if (!int.TryParse(Console.ReadLine(), out _precision))
        {
            Console.WriteLine("Precision is invalid. Precision will be set to default (3 decimal places)");

            _precision = 3;
        }

        Console.WriteLine("\nNow you can enter the expression");
    }

    public void Loop()
    {
        while (true)
        {
            Console.Write("> ");

            string input = Console.ReadLine();

            this.ProcessExpression(input);
        }
    }

    private void ProcessExpression(in string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Error: expression is empty");

            return;
        }

        string[] inputSplit = input.Split(' ');

        if (inputSplit.Length != 3)
        {
            Console.WriteLine("Error: invalid expression");

            return;
        }

        if (!double.TryParse(inputSplit.First(), out double firstOperand))
            Console.WriteLine("Error: first operand is invalid");
        if (!double.TryParse(inputSplit.Last(), out double secondOperand))
            Console.WriteLine("Error: second operand is invalid");

        this.CalculateExpression(firstOperand, secondOperand, inputSplit[1]);
    }

    private void CalculateExpression(in double firstOperand, in double secondOperand, in string @operator)
    {
        double result;

        switch (@operator)
        {
            case "+":
                result = firstOperand + secondOperand;

                break;
            case "-":
                result = firstOperand - secondOperand;

                break;
            case "*":
                result = firstOperand * secondOperand;

                break;
            case "/":
                result = firstOperand / secondOperand;

                break;
            default:
                Console.WriteLine("Error: invalid operation");

                return;
        }

        string format = $"N{_precision}";
        Console.WriteLine($"{firstOperand.ToString(format)} {@operator} {secondOperand.ToString(format)} = {result.ToString(format)}");
    }
}
