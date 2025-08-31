using System.Text;

namespace Password_Generator;

abstract class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🔐 Password Generator");

        Console.Write("Enter the password length: ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("❌ Length is not valid!");
            return;
        }

        Console.Write("Should it include uppercase letters? (y/n): ");
        bool includeUpper = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Should it include numbers? (y/n): ");
        bool includeDigits = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Should it contain special characters? (y/n):");
        bool includeSymbols = Console.ReadLine()?.ToLower() == "y";

        string password = GeneratePassword(length, includeUpper, includeDigits, includeSymbols);
        Console.WriteLine($"\n✅ Created password: {password}");
    }

    static string GeneratePassword(int length, bool upper, bool digits, bool symbols)
    {
        string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digitChars = "0123456789";
        string symbolChars = "!@#$%^&*()-_=+[]{};:,.<>?";

        string allChars = lowerChars;
        if (upper) allChars += upperChars;
        if (digits) allChars += digitChars;
        if (symbols) allChars += symbolChars;

        StringBuilder result = new StringBuilder();
        Random rnd = new Random();

        for (int i = 0; i < length; i++)
        {
            int index = rnd.Next(allChars.Length);
            result.Append(allChars[index]);
        }

        return result.ToString();
    }
}