using System.Security.Principal;
using System.Text.Json;

namespace Task_4
{
    public static class Data 
    { 
        public const string file = @"../../../dataJson.json";
        public const string logger = @"../../../dataLog.json";
        public static List<User> data = new();
        public static List<User> Parse(string input)
        {
            List<User> result = JsonSerializer.Deserialize<List<User>>(input);

            if (result == null)
            {
                throw new FormatException("Invalid format while deserialization");
            }
            return result;
        }
        public static string ToJson(User user)
        {
            string obj = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
            return obj;
        }
        public static void AddNewUser(User user)
        {
            data = Parse(File.ReadAllText(file));
            user.Id = data.Max(x => x.Id) + 1;
            var result = ToJson(user);
            Save(result);
        }
        public static void Save(string input)
        {
            if (!input.StartsWith("{") || !input.EndsWith("}"))
            {
                throw new FormatException("Input is not valid JSON format");
            }

            if (!File.Exists(file))
            {
                File.WriteAllText(file, "[]");
            }

            string json = File.ReadAllText(file);

            if (!string.IsNullOrWhiteSpace(json))
            {
                json = json.Trim(']');
            }

            input = $",{input}";

            File.WriteAllText(file, $"{json}{input}]");
        }
        public static void SaveLog(string input)
        {
            string json = File.ReadAllText(logger);

            if (!string.IsNullOrWhiteSpace(json))
            {
                json = json.Trim(']');
            }
            File.WriteAllText(logger, $"{json},\"{input}\"\n]");
        }
    }
}
