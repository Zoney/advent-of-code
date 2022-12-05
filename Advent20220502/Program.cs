using System.Text;

var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var stackLists = new Dictionary<(int Pos, string Value), List<(int Row, string Letter)>>();
var stacks = "";
var rowNumber = 0;
foreach (var row in read)
{
    rowNumber++;
    if (row.StartsWith(" ") && !row.Contains("["))
    {
        stacks = row;
        break;
    }
}

// var stacks = read.First(x=>x.StartsWith(" ") && !x.Contains("["));
var pos = 0;
foreach (var stackId in stacks)
{
    pos++;
    if (stackId.Equals(' '))
        continue;
    stackLists.Add((pos, stackId.ToString()), new List<(int, string)>());
}

pos = 0;
for (var i = rowNumber - 2; i >= 0; i--)
    foreach (var stackList in stackLists)
    {
        var item = read.ToArray()[i].Skip(stackList.Key.Pos - 1).Take(1).First().ToString();
        if (string.IsNullOrWhiteSpace(item))
            continue;
        stackLists[(stackList.Key.Pos, stackList.Key.Value)].Add((i, item));
    }

foreach (var commandRow in read.Skip(rowNumber + 1))
{
    var commandRowArray = commandRow.Split(" ");
    var howManyToMove = int.Parse(commandRowArray[1]);
    var moveFromColumn = commandRowArray[3];
    var moveToColumn = commandRowArray[5];
    // for (int i = 0; i < howManyToMove; i++)
    // {
    var posFromValue = stackLists.Keys.First(x => x.Value == moveFromColumn).Pos;
    var toMove = stackLists[(posFromValue, moveFromColumn)].TakeLast(howManyToMove).ToList();
    stackLists[(posFromValue, moveFromColumn)]
        .RemoveRange(stackLists[(posFromValue, moveFromColumn)].Count() - howManyToMove, howManyToMove);
    var posToFromValue = stackLists.Keys.First(x => x.Value == moveToColumn).Pos;
    var rowOnNew = stackLists[(posToFromValue, moveToColumn)].Count();
    stackLists[(posToFromValue, moveToColumn)].AddRange(toMove);
    // }
}

var sb = new StringBuilder();
foreach (var stackList in stackLists) sb.Append(stackList.Value.LastOrDefault().Letter);
Console.WriteLine($"{sb}");

Console.WriteLine("done");