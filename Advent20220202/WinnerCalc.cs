namespace Advent20220202;

public static class WinnerCalc
{
    public static int CalcWon(string one, string two)
    {
        if (one == two)
            return 3;

        return one switch
        {
            "Rock" when two == "Scissors" => 0,
            "Rock" when two == "Paper" => 6,
            "Scissors" when two == "Rock" => 6,
            "Scissors" when two == "Paper" => 0,
            "Paper" when two == "Rock" => 0,
            "Paper" when two == "Scissors" => 6,
            _ => 3,
        };
    }
    
    public static HandEnum CalcHand(HandEnum one, ResultEnum result)
    {
        return one switch
        {
            HandEnum.Rock when result == ResultEnum.Loss => HandEnum.Scissors,
            HandEnum.Rock when result == ResultEnum.Win => HandEnum.Paper,
            HandEnum.Rock when result == ResultEnum.Draw => HandEnum.Rock,
            HandEnum.Scissors when result == ResultEnum.Win => HandEnum.Rock,
            HandEnum.Scissors when result == ResultEnum.Loss => HandEnum.Paper,
            HandEnum.Scissors when result == ResultEnum.Draw => HandEnum.Scissors,
            HandEnum.Paper when result == ResultEnum.Loss => HandEnum.Rock,
            HandEnum.Paper when result == ResultEnum.Win => HandEnum.Scissors,
            HandEnum.Paper when result == ResultEnum.Draw => HandEnum.Paper,
        };
    }
    
    public static int CalcWon(HandEnum one, HandEnum two)
    {
        
        if (one == two)
            return 3;

        return one switch
        {
            HandEnum.Rock when two == HandEnum.Scissors => 0,
            HandEnum.Rock when two == HandEnum.Paper => 6,
            HandEnum.Scissors when two == HandEnum.Rock => 6,
            HandEnum.Scissors when two == HandEnum.Paper => 0,
            HandEnum.Paper when two == HandEnum.Rock => 0,
            HandEnum.Paper when two == HandEnum.Scissors => 6,
            _ => 3,
        };
    }
}

public enum ResultEnum
{
    Loss,
    Draw,
    Win,
}

public enum HandEnum
{
    Rock,
    Paper,
    Scissors,
}