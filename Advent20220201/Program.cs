var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var total = 0;
foreach (var line in read)
{
    var basePoint = line.Split(" ")[1] switch
    {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => 0,
    };
    var split = line.Split(" ");
    var hen = split[0];
    var me = split[1];
    var meValue = ReturnValue(me);
    var henValue = ReturnValue(hen);
    var scorePoint = CalcWon(henValue, meValue);

    total += basePoint;
    total += scorePoint; 

    int CalcWon(string one, string two, bool away = true)
    {
        if (one == two)
            return 3;

        if (one == "Rock" && two == "Scissors")
            return 0;
        if (one == "Rock" && two == "Paper")
            return 6;

        if (one == "Scissors" && two == "Rock")
            return 6;
        if (one == "Scissors" && two == "Paper")
            return 0;

        if (one == "Paper" && two == "Rock")
            return 0;
        if (one == "Paper" && two == "Scissors")
            return 6;
        
        return 3;
    }

    string ReturnValue(string rawValue)
    {
        return rawValue switch
        {
            "X" or "A" => "Rock",
            "Y" or "B" => "Paper",
            _ => "Scissors",
        };
    }
}

Console.WriteLine($"Total Points: {total}");

