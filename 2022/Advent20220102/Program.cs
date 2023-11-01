Console.WriteLine("Reading");
var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var best = new List<int>();
var test = 0;
foreach (var line in read)
{
    Console.WriteLine(line);
    if (!string.IsNullOrWhiteSpace(line))
    {
        test += int.Parse(line);
    }
    else
    {
        best.Add(test);
        test = 0;
    }
}

Console.WriteLine($"Sum of top 3: {best.OrderDescending().Take(3).Sum()}");