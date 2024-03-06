namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guess the Num");

            Console.WriteLine("Enter your Username");
            string username = Console.ReadLine();


            Console.WriteLine($"Nice to meet you,   {username}");
            Console.WriteLine("Type E for Easy, M for Medium and H for Hard");
            try
            {
                char operation = char.Parse(Console.ReadLine());

              
                switch (operation)
                {
                    case 'E':

                        int numberEasy = Randomizer(1, 25);

                        
                        Console.WriteLine("Game on! guess the number between 1-25, you have 10 attempts");
                        bool condition = false;

                        for (int i = 0; i < 10; i++)
                        {
                            int input = Convert.ToInt32(Console.ReadLine());
                            if (input > numberEasy)
                            {
                                Console.WriteLine($"The number is too high!");
                            }
                            else if (input < numberEasy)
                            {
                                Console.WriteLine($"The number is low!");
                            }

                            if (input == numberEasy)
                            {
                                Console.WriteLine("Congrats! you Win, beginner's luck");
                                condition = true;
                                break;
                            }
                        }
                        if (condition == false)
                        {
                            Console.WriteLine("Game over.");
                        }

                        break;

                    case 'M':

                        int numberMedium = Randomizer(1, 50);
                        
                        Console.WriteLine("Game on! guess the number between 1-50, you have 10 attempts");
                        bool condition1 = false;

                        for (int i = 0; i < 10; i++)
                        {
                            int input = Convert.ToInt32(Console.ReadLine());
                            if (input > numberMedium)
                            {
                                Console.WriteLine($"The number is too high!");
                            }
                            else if (input < numberMedium)
                            {
                                Console.WriteLine($"The number is low!");
                            }
                            if (input == numberMedium)
                            {
                                Console.WriteLine("Congrats! you Win, beginner's luck");
                                condition = true;
                                break;
                            }
                        }
                        if (condition1 == false)
                        {
                            Console.WriteLine("Game over.");
                        }
                        break;

                    case 'H':
                        int numberHard = Randomizer(1, 100);

                        Console.WriteLine("Game on! guess the number between 1-100, you have 10 attempts");
                        bool condition2 = false;

                        for (int i = 0; i < 10; i++)
                        {
                            int input = Convert.ToInt32(Console.ReadLine());
                            if (input > numberHard)
                            {
                                Console.WriteLine($"The number is too high!");
                            }
                            else if (input < numberHard)
                            {
                                Console.WriteLine($"The number is low!");
                            }
                            if (input == numberHard)
                            {
                                Console.WriteLine("Congrats! you Win, beginner's luck");
                                condition = true;
                                break;
                            }
                        }
                        if (condition2 == false)
                        {
                            Console.WriteLine("Game over.");
                        }
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        static int Randomizer(int num1, int num2)
        {
            Random random = new Random();
            int number = random.Next(num1, num2);

            return number;
        }
    }
}
