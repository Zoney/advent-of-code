// See https://aka.ms/new-console-template for more information

using Advent20220401;

var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var elfPairList = new List<ElfWorkOrder>();

foreach (var line in read)
{
    var workOrders = line.Split(",");
    var newPairId = (elfPairList.MaxBy(x => x.PairId)?.PairId ?? 0) + 1;
    foreach (var workOrder in workOrders)
    {
        var startEnd = workOrder.Split("-");
        var newElfId = (elfPairList.MaxBy(x => x.ElfId)?.ElfId ?? 0) + 1;
        elfPairList.Add(new ElfWorkOrder(newElfId, newPairId, int.Parse(startEnd[0]), int.Parse(startEnd[1])));
    }
}

var workOrdersOverlap = new List<ElfWorkOrder>();
foreach (var scanWorOrder in elfPairList.SelectMany(
             elfWorkOrder => from scanWorOrder in elfPairList
                 where scanWorOrder.ElfId != elfWorkOrder.ElfId
                 where scanWorOrder.PairId == elfWorkOrder.PairId
                 where elfWorkOrder.StartSection >= scanWorOrder.StartSection &&
                       elfWorkOrder.StartSection <= scanWorOrder.StopSection
                 select scanWorOrder))
{
    workOrdersOverlap.Add(scanWorOrder);
    Console.WriteLine("FOUND!");
}

Console.WriteLine($"{workOrdersOverlap.DistinctBy(x => x.PairId).Count()}");
Console.WriteLine("done");