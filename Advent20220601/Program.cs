var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");

var signals = read.Select(x => new Signal(x));


public class Signal
{
    private readonly string _rawSignal;

    public Signal(string rawSignal)
    {
        _rawSignal = rawSignal;
    }

    public int GetSartOfSignal()
    {
        _rawSignal.TakeWhile(x => x.)
    }
}