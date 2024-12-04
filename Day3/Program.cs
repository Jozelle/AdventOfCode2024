using System.Text.RegularExpressions;

//Code heavily inspired by ryanheath/aoc2024 on github

//string filepath = "test3.txt";

string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string filename = "input3.txt";

string filepath = Path.Combine(folderpath, filename);

string[] input = File.ReadAllLines(filepath);

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the third day of Advent of Code 2024! " +
        "\n[1] Part 1" +
        "\n[2] Part 2" +
        "\n");
    if (int.TryParse(Console.ReadLine(), out int result))
    {
        switch (result)
        {
            case 1:
                Console.WriteLine(Part1(input));
                
                break;
            case 2:
                Console.WriteLine(Part2(input));

                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
        continue;
    }
    Console.Read();
}

long Part1(string[] lines) => RunRegex(lines, ignore: true);
long Part2(string[] lines) => RunRegex(lines, ignore: false);

long RunRegex(string[] lines, bool ignore)
{
    Regex mulRegex = new(
        @$"(?<mul>mul)\((?<mul1>\d+),(?<mul2>\d+)\)|(?<do>do)\(\)|(?<dont>don't)\(\)",
        RegexOptions.Compiled
    );

    long sum = 0;
    bool doSum = true;

    foreach (string line in lines)
    {
        foreach (Match match in mulRegex.Matches(line))
        {
            if (match.Groups["mul"].Success && doSum)
            {
                //MUL(match.Groups[xMUL1].Value, match.Groups[xMUL2].Value);
                sum += long.Parse(match.Groups["mul1"].Value) * long.Parse(match.Groups["mul2"].Value);
            }
            else if (match.Groups["do"].Success && !ignore)
            {
                doSum = true;

            }
            else if (match.Groups["dont"].Success && !ignore)
            {
                doSum = false;
            }
        }
    }

    return sum;
}
