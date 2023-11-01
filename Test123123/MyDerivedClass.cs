namespace Test123123;

internal class MyDerivedClass : MyBaseClass
{
    private string _name;
    private int? _number;

    // Override auto-implemented property with ordinary property
    // to provide specialized accessor behavior.
    public override string Name
    {
        get => _name;
        set
        {
            if (!string.IsNullOrEmpty(value))
                _name = value;
            else
                _name = "Unknown";
        }
    }

    public override int? Number
    {
        get => base.Number;
        set
        {
            if (value == null)
                _number = 0;
            else
                _number = value;
        }
    }
}