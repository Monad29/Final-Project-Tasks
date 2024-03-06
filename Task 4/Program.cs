using System.Numerics;
using System.Security.Principal;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string file = @"../../../dataJson.json";
            const string logger = @"../../../dataLog.json";
            string data = File.ReadAllText(file); 
            var json = Data.Parse(data); 
            int number = 0;

            Console.WriteLine("Hello press 1 to Log in or Press 2 for registration");
            try
            {
                char input = Convert.ToChar(Console.ReadLine());

                if (input == '1')
                {
                    Console.WriteLine("ID number");
                    string input2 = Console.ReadLine();
                    if (input2.Length != 11 ) 
                    {
                        throw new Exception("Id number Must be 11 digits");
                    }
                    Console.WriteLine("Password");
                    string input3 = Console.ReadLine();
                    if (input3.Length != 4 )
                    {
                        throw new Exception("Password Must be 4 digits");
                    }
                    bool check = false;

                    for (int i = 0; i < json.Count; i++)
                    {
                        if (json[i].Idnumber == input2 && json[i].Password == input3)
                        {
                            check = true;
                            number = i;
                            break;
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("User not found, please, start over to register.");
                    }

                    if (check)
                    {
                        Console.WriteLine("Choose an action:");
                        Console.WriteLine("1 - Deposit");
                        Console.WriteLine("2 - Check Amount");
                        Console.WriteLine("3 - Withdraw");
                        Console.WriteLine("4 - View operation history");
                        char input4 = Convert.ToChar(Console.ReadLine());

                        switch (input4)
                        {
                            case '1':
                                Console.WriteLine("Enter Amount");
                                int amount = int.Parse(Console.ReadLine());

                                var x = Data.Parse(File.ReadAllText(file));

                                if (number >= 0 && number < x.Count)
                                {
                                    x[number].Balance += amount;
                                }
                                string updated = JsonSerializer.Serialize(x, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(file, updated);

                                string log1 = $"User {json[number].Firstname} {json[number].Surname} - Made a deposit of {amount} Gel on {DateTime.Now}- current baance:{json[number].Balance} Gel";
                                Data.SaveLog(log1);
                                break;
                            case '2':
                                var ballance = json[number].Balance;
                                Console.WriteLine($"{ballance} GEL");

                                string log2 = $"User {json[number].Firstname} {json[number].Surname} -Checked Balance: {DateTime.Now}";
                                Data.SaveLog(log2);
                                break;
                            case '3':
                                Console.WriteLine("Enter the amount of money");
                                int money = int.Parse(Console.ReadLine());

                                var y = Data.Parse(File.ReadAllText(file));

                                if (number >= 0 && number < y.Count)
                                {
                                    y[number].Balance -= money;
                                }

                                string updated1 = JsonSerializer.Serialize(y, new JsonSerializerOptions { WriteIndented = true });
                                File.WriteAllText(file, updated1);

                                string log3 = $"User {json[number].Firstname} {json[number].Surname} - Withdrawed aount of 50: {DateTime.Now}.- Current Balance: {json[number].Balance} Gel";
                                Data.SaveLog(log3);
                                break;
                            case '4':

                                string log4 = File.ReadAllText(logger);
                                List<string> objj = JsonSerializer.Deserialize<List<string>>(log4);

                                foreach (var item in objj)
                                {
                                    if (item.Contains(json[number].Firstname))
                                    {
                                        Console.WriteLine(item);
                                    }
                                }
                                break;
                        }
                    }
                    
                }
                else if (input == '2')
                {
                    User user = new User();
                    Console.WriteLine("Enter your Name");
                    user.Firstname = Console.ReadLine();
                    Console.WriteLine("Surname");
                    user.Surname = Console.ReadLine();
                    Console.WriteLine("ID number, must be 11 digits long.");
                    user.Idnumber = Console.ReadLine();
                    Console.WriteLine("Set up Passcode, must be 4 digits long.");
                    user.Password = Console.ReadLine();
                    Console.WriteLine($"Your Passcode:{user.Password}");
                    Console.WriteLine($"Your ID: {user.Idnumber}");
                    Data.AddNewUser(user);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
