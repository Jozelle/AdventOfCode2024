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
        bool increasing = true;
        bool safe = true;

        for (int i = 0; i < split.Length; i++)
        {
            if (i == 0)
            {
                int comparison = split[i].CompareTo(split[i + 1]);
                if (comparison > 0)
                {
                    increasing = false;
                }
            }

            int difference = split[i] - split[i + 1];

            if (difference == 0 || difference > 3)
            {
                safe = false;
            }


        }
    }
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