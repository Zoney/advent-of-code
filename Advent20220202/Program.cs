using Advent20220202;

var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var total = 0;
foreach (var line in read)
{
    // var basePoint = line.Split(" ")[1] switch
    // {
    //     "X" => 1,
    //     "Y" => 2,
    //     "Z" => 3,
    //     _ => 0,
    // };
    var split = line.Split(" ");
    var hen = split[0];
    var me = split[1];
    var resultWanted = ResultWanted(me);


    

    var henValue = ReturnValue(hen);
    var meCalcValue = WinnerCalc.CalcHand(henValue, resultWanted);
    var scorePoint = WinnerCalc.CalcWon(henValue, meCalcValue);
    var basePoint = meCalcValue switch
    {
        HandEnum.Rock => 1,
        HandEnum.Paper => 2,
        HandEnum.Scissors => 3,
        _ => 0,
    };
    total += basePoint;
    total += scorePoint;

    
    ResultEnum ResultWanted(string s)
    {
        return s switch
        {
            "X" => ResultEnum.Loss,
            "Y" => ResultEnum.Draw,
            "Z" => ResultEnum.Win,
            _ => ResultEnum.Win,
        };
    }

    HandEnum ReturnValue(string rawValue)
    {
        return rawValue switch
        {
            "A" => HandEnum.Rock,
            "B" => HandEnum.Paper,
            "C" => HandEnum.Scissors,
            _ => HandEnum.Scissors,
        };
    }
}

Console.WriteLine($"Total Points: {total}");