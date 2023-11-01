namespace Test123123;

internal class MyBaseClass
{
    private int? _number;

    // virtual auto-implemented property. Overrides can only
    // provide specialized behavior if they implement get and set accessors.
    public virtual string Name { get; set; }

    // ordinary virtual property with backing field
    public virtual int? Number
    {
        get => _number;
        set
        {
            if (value == null)
                _number = 1337;
            else
                _number = value;
        }
    }
}