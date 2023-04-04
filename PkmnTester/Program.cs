class Program
{
    static void Main(string[] args)
    {
        GetAppInfo();
        SetPokemon();
    }

    static void SetPokemon()
    {
        while (true)
        {
            Console.WriteLine("Name the pokemon attacker");

            string inputName = Console.ReadLine();

            Console.WriteLine("What's the level of {0} ?", inputName);

            string inputLevel = TestInput();

            Console.WriteLine("What's base attack ?");

            string inputBaseAttack = TestInput();


            Console.WriteLine("Which move will you use ?");

            string inputCapacity = Console.ReadLine();

            Console.WriteLine("Indicate the power of the move");

            string inputMovePower = TestInput();

            Console.WriteLine("Name the pokemon defender");

            string inputNameDefender = Console.ReadLine();

            Console.WriteLine("indicate his life point");

            string inputLP = TestInput();


            Console.WriteLine("Indicate the defense of the pokemon");

            string inputDefense = TestInput();

            Console.WriteLine("What's the sensibility of {0} to {1} ?", inputNameDefender, inputCapacity);

            string inputSensibillity = TestInputSensibility();

            int damage = AttackCalcul(inputLevel, inputMovePower, inputBaseAttack, inputDefense, inputSensibillity);

            Console.WriteLine("{0}'s {1} deals " + damage + " damage to {2}", inputName, inputCapacity, inputNameDefender);

            int result = Int32.Parse(inputLP) - damage;

            GetResult(result, inputNameDefender);

            Console.WriteLine("Try again ? [Y or N]");

            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                continue;
            }
            else if (answer == "N")
            {
                return;
            }
            else
            {
                return;
            }
        }
    }

    static int AttackCalcul(string lvl, string cPower, string bAttack, string def, string sensibility)
    {
        int level = Int32.Parse(lvl);
        int capacityPower = Int32.Parse(cPower);
        int baseAttack = Int32.Parse(bAttack);
        int defense = Int32.Parse(def);
        float sensibillity = float.Parse(sensibility);

        int damage = (int)(((((level*2/5+2)*capacityPower*baseAttack)/defense)/50+2)*sensibillity);

        return damage;
    }

    static void GetAppInfo()
    {
        string appName = "Number Guesser";
        string appversion = "1.0.0";
        string appAuthor = "Jonathan Rose";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("{0}: Version {1} by {2}", appName, appversion, appAuthor);

        Console.ResetColor();
    }

    static string TestInput()
    {
        string input = Console.ReadLine();

        while (!int.TryParse(input, out _))
        {
            Console.WriteLine("Please use an actual number");

            input = Console.ReadLine();

            continue;
        }
        return input;
    }

    static string TestInputSensibility()
    {
        string input = Console.ReadLine();

        while (!float.TryParse(input, out _))
        {
            Console.WriteLine("Please use an actual number");

            input = Console.ReadLine();

            continue;
        }
        return input;
    }

    static void GetResult(int result, string nameDefender)
    {
        if (result <= 0)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0} is K.O !", nameDefender);

            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("{0} still have " + result + " life points", nameDefender);

            Console.ResetColor();
        }
    }
}