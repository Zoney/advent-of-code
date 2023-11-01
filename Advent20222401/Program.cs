// See https://aka.ms/new-console-template for more information

using Advent20222401;

Console.WriteLine("Reading");
var skipMoves = new List<SkipMove>();
var movesDone = 0;
var simsRuns = 0;

int shortetsMoves = 99999999;
RunSimulation(skipMoves);

void RunSimulation(List<SkipMove> skipMoves)
{
    
    var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
    var expedition = new Expedition();
    var map = new ExpeditionMap
    {
        Pos = new List<ExpeditionMapTile>(),
    };
    var xPoint = 0;
    var yPoint = 0;
    var pointId = 1;
    foreach (var line in read)
    {
        // Console.WriteLine(line);
        xPoint = 0;
        foreach (var character in line.ToCharArray())
        {
            var blizzard = character.ToString() switch
            {
                "." => BlizzardEnum.None,
                "<" => BlizzardEnum.Left,
                ">" => BlizzardEnum.Right,
                "^" => BlizzardEnum.Up,
                "v" => BlizzardEnum.Down,
                "E" => BlizzardEnum.Expedition,
                "#" => BlizzardEnum.Wall,
                _ => BlizzardEnum.None,
            };
            map.Pos.Add(
                new ExpeditionMapTile
                {
                    PointId = pointId,
                    XPos = xPoint,
                    YPos = yPoint,
                    PosValue = blizzard,
                });
            // Console.WriteLine(character);
            xPoint++;
            pointId++;
        }

        pointId++;
        yPoint++;
    }

    var maxY = map.Pos.Max(x => x.YPos);
    var maxX = map.Pos.Max(x => x.XPos);

    // Console.WriteLine("And done");
    var currentPos = map.Pos.Where(x => x.PosValue == BlizzardEnum.Expedition).ToList();
    if (currentPos.Any())
    {
        var currentPosNow = currentPos.First();
        expedition.XPos = currentPosNow.XPos;
        expedition.YPos = currentPosNow.YPos;
    }
    else
    {
        var startPos = map.Pos.First(x => x.YPos == 0 && x.PosValue == BlizzardEnum.None);
        expedition.YPos = startPos.YPos;
        expedition.XPos = startPos.XPos;
    }

    var lastRow = map.Pos.Where(x => x.YPos == maxY);
    var goalPoint = lastRow.First(x => x.PosValue == BlizzardEnum.None);
    bool continueLoop = true;
    while (continueLoop)
    // while ((expedition.XPos != 6 && expedition.YPos != 2) || simsRuns < 2000)
    {
        
        // Console.WriteLine($"Expedition Pos: {expedition.XPos} {expedition.YPos}");
        // foreach (var skipMove in skipMoves)
        // {
        //     Console.WriteLine($"Skipping: {skipMove.MoveNumber} (current: {movesDone}");
        //     Console.WriteLine($"X: {skipMove.MoveDetail.XPos} Y: {skipMove.MoveDetail.YPos}");
        // }
        foreach (var pos in map.Pos)
        {
            if (pos.PosValue == BlizzardEnum.Wall)
                continue;
            if (pos.PosValue == BlizzardEnum.Down)
            {
                var possibleNextY = pos.YPos + 1;
                var possibleNext = map.Pos.FirstOrDefault(x => x.XPos == pos.XPos && x.YPos == possibleNextY);
                if (possibleNext?.PosValue == BlizzardEnum.Wall) possibleNextY = 1;
                var index = map.Pos.FindIndex(x => x.PointId == pos.PointId);
                map.Pos[index].YPos = possibleNextY;
            }

            if (pos.PosValue == BlizzardEnum.Up)
            {
                var possibleNextY = pos.XPos - 1;
                var possibleNext = map.Pos.FirstOrDefault(x => x.XPos == pos.XPos && x.YPos == possibleNextY);
                if (possibleNext?.PosValue == BlizzardEnum.Wall) possibleNextY = maxY - 2;
                var index = map.Pos.FindIndex(x => x.PointId == pos.PointId);
                map.Pos[index].YPos = possibleNextY;
            }

            if (pos.PosValue == BlizzardEnum.Left)
            {
                var possibleNextX = pos.XPos - 1;
                var possibleNext = map.Pos.FirstOrDefault(x => x.XPos == possibleNextX && x.YPos == pos.YPos);
                if (possibleNext?.PosValue == BlizzardEnum.Wall) possibleNextX = maxX - 2;
                var index = map.Pos.FindIndex(x => x.PointId == pos.PointId);
                map.Pos[index].XPos = possibleNextX;
            }

            if (pos.PosValue == BlizzardEnum.Right)
            {
                var possibleNextX = pos.XPos + 1;
                var possibleNext = map.Pos.FirstOrDefault(x => x.XPos == possibleNextX && x.YPos == pos.YPos);
                if (possibleNext?.PosValue == BlizzardEnum.Wall) possibleNextX = 1;
                var index = map.Pos.FindIndex(x => x.PointId == pos.PointId);
                map.Pos[index].XPos = possibleNextX;
            }
        }

        var possibleMoveX = expedition.XPos;
        var possibleMoveY = expedition.YPos;
        var allowedNewExpeditionMoves = new List<Expedition>();
        var possibleExpeditionMove = map.Pos.FirstOrDefault(x => x.XPos == possibleMoveX && x.YPos == possibleMoveY);
        if (possibleExpeditionMove?.PosValue is BlizzardEnum.None or null)
            if (possibleMoveY >= 0 && possibleMoveX >= 0)
                allowedNewExpeditionMoves.Add(new Expedition
                {
                    XPos = possibleMoveX,
                    YPos = possibleMoveY,
                });
        possibleMoveX++;
        possibleExpeditionMove = map.Pos.FirstOrDefault(x => x.XPos == possibleMoveX && x.YPos == possibleMoveY);
        if (possibleExpeditionMove?.PosValue is BlizzardEnum.None or null)
            if (possibleMoveY >= 0 && possibleMoveX >= 0)
                allowedNewExpeditionMoves.Add(new Expedition
                {
                    XPos = possibleMoveX,
                    YPos = possibleMoveY,
                });
        possibleMoveX--;
        possibleMoveX--;
        possibleExpeditionMove = map.Pos.FirstOrDefault(x => x.XPos == possibleMoveX && x.YPos == possibleMoveY);
        if (possibleExpeditionMove?.PosValue is BlizzardEnum.None or null)
            if (possibleMoveY >= 0 && possibleMoveX >= 0)
                allowedNewExpeditionMoves.Add(new Expedition
                {
                    XPos = possibleMoveX,
                    YPos = possibleMoveY,
                });
        possibleMoveX++;
        possibleMoveY++;
        possibleExpeditionMove = map.Pos.FirstOrDefault(x => x.XPos == possibleMoveX && x.YPos == possibleMoveY);
        if (possibleExpeditionMove?.PosValue is BlizzardEnum.None or null)
            if (possibleMoveY >= 0 && possibleMoveX >= 0)
                allowedNewExpeditionMoves.Add(new Expedition
                {
                    XPos = possibleMoveX,
                    YPos = possibleMoveY,
                });
        possibleMoveY--;
        possibleMoveY--;
        possibleExpeditionMove = map.Pos.FirstOrDefault(x => x.XPos == possibleMoveX && x.YPos == possibleMoveY);
        if (possibleExpeditionMove?.PosValue is BlizzardEnum.None or null)
            if (possibleMoveY >= 0 && possibleMoveX >= 0)
                allowedNewExpeditionMoves.Add(new Expedition
                {
                    XPos = possibleMoveX,
                    YPos = possibleMoveY,
                });
        // foreach (var possibleMove in allowedNewExpeditionMoves) Console.WriteLine($"X: {possibleMove.XPos} Y: {possibleMove.YPos}");

        if (skipMoves.Any(x => x.MoveNumber == movesDone))
        {
            var toRemove = skipMoves.Where(x => x.MoveNumber == movesDone);
            allowedNewExpeditionMoves.RemoveAll(x =>
                toRemove.Select(b => b.MoveDetail.XPos).Contains(x.XPos) && toRemove.Select(a => a.MoveDetail.YPos).Contains(x.YPos));
        }

        if (!allowedNewExpeditionMoves.Any())
        {
            var previousMove = movesDone - 1;
            var skipMove = new SkipMove
            {
                MoveDetail = new Expedition
                {
                    XPos = expedition.XPos,
                    YPos = expedition.YPos,
                },
                MoveNumber = previousMove,
            };
            skipMoves.Add(skipMove);
            movesDone = 0;
            RunSimulation(skipMoves);
        }
        else
        {
            if (movesDone >= 1800)
            {
                var previousMove = movesDone - 1;
                var skipMove = new SkipMove
                {
                    MoveDetail = new Expedition
                    {
                        XPos = expedition.XPos,
                        YPos = expedition.YPos,
                    },
                    MoveNumber = previousMove,
                };
                skipMoves.Add(skipMove);
                movesDone = 0;
                RunSimulation(skipMoves);
                break;
            }
            movesDone++;

            if (allowedNewExpeditionMoves.Select(x => x.XPos).Contains(goalPoint.XPos) &&
                allowedNewExpeditionMoves.Select(y => y.YPos).Contains(goalPoint.YPos))
            {
                expedition.YPos = goalPoint.YPos;
                expedition.XPos = goalPoint.XPos;
            }
            var closest = allowedNewExpeditionMoves.OrderByDescending(x => x.YPos)
                .ThenByDescending(item => Math.Abs(goalPoint.XPos - item.XPos)).First();

            expedition.YPos = closest.YPos;
            expedition.XPos = closest.XPos;

            // var bestNextMove = allowedNewExpeditionMoves.Where(y=> y.YPos == allowedNewExpeditionMoves.Max(x=>x.YPos) && y.XPos 

            // Console.WriteLine($"Expedition Now at: {expedition.XPos} {expedition.YPos}");
            // Console.WriteLine($"Moves done: {movesDone}");
            
            if (expedition.XPos == goalPoint.XPos && expedition.YPos == goalPoint.YPos)
            {
                if (shortetsMoves > movesDone)
                    shortetsMoves = movesDone;
                Console.WriteLine($"Moves done: {movesDone}");
                Console.WriteLine($"Found it at {expedition.XPos} {expedition.YPos}");
                continueLoop = false;
            }
        }
    }

    Console.WriteLine($"Goal is {goalPoint.XPos} {goalPoint.YPos}");

    Console.WriteLine($"Gave up at {expedition.XPos} {expedition.YPos}");
}
Console.WriteLine($"Moves done: {shortetsMoves}");
