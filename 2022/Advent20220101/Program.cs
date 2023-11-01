// See https://aka.ms/new-console-template for more information

Console.WriteLine("Reading");
var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var best = 0;
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
        if (test > best)
            best = test;
        test = 0;
    }
}

Console.WriteLine($"Best was: {best}");