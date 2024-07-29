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
        Console.CursorTop--;
        Console.Write($"> {firstOperand} {@operator} {secondOperand} = ");

        switch (@operator)
        {
            case "+":
                Console.Write($"{firstOperand + secondOperand}\n");

                break;
            case "-":
                Console.Write($"{firstOperand - secondOperand}\n");

                break;
            case "*":
                Console.Write($"{firstOperand * secondOperand}\n");

                break;
            case "/":
                Console.Write($"{firstOperand / secondOperand}\n");

                break;
            default:
                Console.Write("err\n");
                Console.WriteLine("Error: invalid operation");

                break;
        }
    }
}
