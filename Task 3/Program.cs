using System.Diagnostics.Contracts;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to Wordle");
            Console.WriteLine("Rules are simple. Guess the word, you have 6 attempts");

            Console.WriteLine("Enter your Username to begin");

            string input = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Nice to meet you, {input}");
            //Console.WriteLine("type any character to begin");
            //char input1 = Convert.ToChar(Console.ReadLine());

            List<string> words = new List<string>
            {
            "apple", "banana", "orange", "grape", "kiwi",
            "strawberry", "pineapple", "blueberry", "peach", "watermelon"
            };
            try
            {
                Random random = new Random();
                int guessNumber = random.Next(0, words.Count);
                string randomWord = words[guessNumber];
                string newWord = new string('*', randomWord.Length);

                bool shot = false;
                int attempts = 0;
                bool check = false;

                Console.WriteLine(randomWord);//delete later
                Console.WriteLine(newWord);


                for (int i = 0; i < 6; i++)
                {
                    attempts ++;
                    Console.WriteLine($"Attempt number {attempts} Enter a character");
                    char input2 = Convert.ToChar(Console.ReadLine());

                    if (randomWord.Contains(input2))
                    {
                        for (int j = 0; j < randomWord.Length; j++)
                        {
                            if (randomWord[j] == input2)
                            {
                                newWord = newWord.Remove(j, 1).Insert(j, input2.ToString());
                                shot = true;
                            }
                        }
                        Console.WriteLine(newWord);
                    }
                    if (newWord == randomWord)
                    {
                        Console.WriteLine("Victory");
                        check = true;
                        break;
                    }
                }
                if (shot == true && check == false)
                {
                    Console.WriteLine("Your final guess? Enter the word:");
                    string input3 = Console.ReadLine();
                    if (input3 == randomWord)
                    {
                        Console.WriteLine("Victory");
                    }
                }
                else if (shot == false)
                {

                    Console.WriteLine("Defeat");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }

}
