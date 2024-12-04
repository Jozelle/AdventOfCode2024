//string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//string filename = "input2.txt";

//string filepath = Path.Combine(folderpath, filename);

string filepath = "test2.txt";

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the second day of Advent of Code 2024! " +
        "\n[1] Part 1" +
        "\n[2] Part 2" +
        "\n");

    if (int.TryParse(Console.ReadLine(), out int result))
    {
        switch (result)
        {
            case 1:
                Part1(filepath);
                break;
            case 2:
                //Part2(leftList, rightList);
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

static void Part1(string filepath)
{
    List<string> testdata = GetTestdata(filepath);

    int safeCount = 0;  
    foreach (var item in testdata)
    {
        int[] split = item.Split(' ').Select(int.Parse).ToArray();

        if (IsLevelSafe(split).Item1)
        {
            safeCount++;

        }
    }

    Console.WriteLine(safeCount);
}

static void Part2()
{

}

static List<string> GetTestdata(string filepath)
{
    using (StreamReader sr = new StreamReader(filepath))
    {
        List<string> testdata = new List<string>();
        while (!sr.EndOfStream)
        {
            testdata.Add(sr.ReadLine());
        }

        return testdata;
    }
}

static (bool, int) IsLevelSafe(int[] values)
{
    var (increasing, safeDifference) = CheckDifference(values[0], values[1]);

    if (!safeDifference)
    {
        return (false, 0);
    }

    for (int i = 1; i < values.Length - 1; i++)
    {
        var (increase, safeDifference) = CheckDifference(values[i], values[i + 1]);
        if (!safeDifference ||increase != increasing)
        {
            return (false, i);
        }
    }

    return (true, -1);
}

static (bool, bool) CheckDifference (int x, int y)
{
    int difference = x - y;

    bool isIncreasing = Math.Sign(difference) == 1;     // Check if the difference is positive or negative
    int amount = Math.Abs(difference);                  // Get the absolute value of the difference

    return (isIncreasing, amount is 1 or 2 or 3);       // Return a tuple with the results, second value is a boolean that returns true if the amount is 1, 2 or 3
}