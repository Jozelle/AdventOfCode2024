//string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//string filename = "input2.txt";

//string filepath = Path.Combine(folderpath, filename);

string filepath = "test2.txt";

StreamReader sr = new StreamReader(filepath);

//Inläsningslogik

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
                //Part1(leftList, rightList);
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

static void Part1()
{

}

static void Part2()
{

}