namespace Undo_Operations_in_a_Calculator
{
    internal class Program
    {
        class clsUndoH
        {


            public int num1 { get; set; }
            public int num2 { get; set; }

            public string op { get; set; }

            public decimal result { get; set; }

            public override string ToString()
            {


                Console.WriteLine($"( {num1} {op} {num2} = {result} )");
                return base.ToString();
            }

        }
        static void Main(string[] args)
        {
            Stack<clsUndoH> stack = new Stack<clsUndoH>();
            while (true)
            {
                caluculter(stack);
            }




            Console.ReadKey();

        }

        private static void caluculter(Stack<clsUndoH> stack)
        {
            Console.Write("Enter number 1 :");
            if (int.TryParse(Console.ReadLine(), out int num1))
            {
                Console.Write("Enter number 2 :");
                if (int.TryParse(Console.ReadLine(), out int num2))
                {
                    op(stack, num1, num2);

                    udoo(stack);
                }
                else
                {
                    Console.WriteLine("N/A");
                }

            }
            else
            {
                Console.WriteLine("N/A");
            }
        }

        private static void udoo(Stack<clsUndoH> stack)
        {
            Console.Write("type Undo to Undo op : / eter to skip");
            string Undo = Console.ReadLine();

            if (Undo == "Undo")
            {

                stack.Pop();
                if (stack.Count != 0)
                {
                    stack.Peek().ToString();
                }
            }
        }

        private static void op(Stack<clsUndoH> stack, int num1, int num2)
        {
            Console.Write("type op (sum | sub | mult | Div) : ");
            string op = Console.ReadLine();
            decimal r = 0;

            switch (op)
            {
                case "sum":
                    r = num1 + num2;
                    break;

                case "sub":
                    r = num1 - num2;
                    break;
                case "mult":
                    r = num1 * num2;
                    break;
                case "Div":
                    if (num1 != 0)
                    {
                        r = num1 / num2;
                    }
                    else
                    {
                        r = 0;
                        Console.WriteLine("N/A");
                    }
                    break;

                default:
                    break;
            }
            var data = new clsUndoH { num1 = num1, num2 = num2, op = op, result = r };
            data.ToString();

            stack.Push(data);
        }
    }
}
