string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string filename = "input1.txt";

string filepath = Path.Combine(folderpath, filename);

//string filepath = "test1.txt";

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the first day of Advent of Code 2024! " +
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
                Part2(filepath);
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
    List<List<int>> testdata = SplitLeftRight(filepath);

    List<int> leftList = testdata[1];
    List<int> rightList = testdata[2];

    leftList.Sort();
    rightList.Sort();
    List<int> resultList = new List<int>();
    for (int i = 0; i < leftList.Count; i++)
    {
        int absoluteValueResult = Math.Abs(leftList[i] - rightList[i]);
        resultList.Add(absoluteValueResult);
    }
    double sum = resultList.Sum();
    Console.WriteLine(sum);
}

static void Part2(string filepath)
{
    List<List<int>> testdata = SplitLeftRight(filepath);

    List<int> leftList = testdata[1];
    List<int> rightList = testdata[2];

    List<int> resultList = new List<int>();

    foreach (var item in leftList)
    {
        int appearances = rightList.Count(x => x == item);
        int similarityScore = item * appearances;

        resultList.Add(similarityScore);
    }
    double sum = resultList.Sum();
    Console.WriteLine(sum);
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

static List<List<int>> SplitLeftRight(string filepath)
{
    List<string> testdata = GetTestdata(filepath);

    List<int> leftList = new List<int>();
    List<int> rightList = new List<int>();

    foreach (var item in testdata)
    {
        string[] parts = item.Split("   ");
        leftList.Add(int.Parse(parts[0].Trim()));
        rightList.Add(int.Parse(parts[1].Trim()));
    }

    return new List<List<int>> { leftList, rightList };
}



