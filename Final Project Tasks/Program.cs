namespace Final_Project_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string condition = string.Empty;
            bool program = true;

            while (program)
            {


                try
                {


                    while (true)


                    {

                        Console.WriteLine("Enter the first number: ");
                        double num1 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the second number: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the operation [+ - * /]: ");
                        char operation = Convert.ToChar(Console.ReadLine());

                        double result = 0;


                        switch (operation)
                        {
                            case '+':
                                result = num1 + num2;
                                break;


                            case '-':
                                result = num1 - num2;
                                break;


                            case '*':
                                result = num1 * num2;
                                break;




                            case '/':



                                if (num2 != 0)
                                {
                                    result = num1 / num2;
                                }
                                else
                                {
                                    Console.WriteLine("Cannot divide by zero.");
                                    return;
                                }
                                break;


                        }

                        Console.WriteLine($"Result: {result}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
                Console.WriteLine("do you want to continue? Enter [yes] or [no]");
                condition = Console.ReadLine();
               
                if (condition.Equals("No", StringComparison.OrdinalIgnoreCase))

                {
                    program = false;
                }
            }

        }
    }
}



            
            
            



        
        
        
        
        
       
        
    

