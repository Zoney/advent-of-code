namespace Advent20222401;

public struct ExpeditionMap
{
    public List<ExpeditionMapTile>? Pos { get; set; }
}

public class ExpeditionMapTile
{
    public int PointId { get; set; }
    public int XPos { get; set; }
    public int YPos { get; set; }
    public BlizzardEnum? PosValue { get; set; }
}

public class SkipMove
{
    public int MoveNumber { get; set; }
    public Expedition? MoveDetail { get; set; }
}