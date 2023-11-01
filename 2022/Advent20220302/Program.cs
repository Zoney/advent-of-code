var read = File.ReadLines(Directory.GetCurrentDirectory() + "/input.txt");
var readList = new List<List<string>>();
var readCount = 0;
var readInnerList = new List<string>();
foreach (var line in read)
{
    readInnerList.Add(line);
    readCount++;
    if (readCount == 3)
    {
        readList.Add(readInnerList);
        readCount = 0;
        readInnerList = new List<string>();
    }
}

var total = 0;
var commonChars = new List<string>();

foreach (var lineOf3 in readList)
{
    var commonCharsInLine = new List<string>();
    var part1 = lineOf3[0];
    var part2 = lineOf3[1];
    var part3 = lineOf3[2];
    Console.WriteLine(part1);
    Console.WriteLine(part2);
    foreach (var charin1 in part1)
        if (part2.Contains(charin1) && part3.Contains(charin1) && !commonCharsInLine.Contains(charin1.ToString()))
            commonCharsInLine.Add(charin1.ToString());
    commonChars.AddRange(commonCharsInLine);
    foreach (var line in lineOf3) Console.WriteLine(line);
}

// foreach (var line in read)
// {
//     var commonCharsInLine = new List<string>();
//     var part1 = line.ToCharArray(0, line.Length / 2);
//     var part2 = line.ToCharArray(line.Length / 2, line.Length / 2);
//     Console.WriteLine(part1);
//     Console.WriteLine(part2);
//     foreach (var charin1 in part1)
//     {
//         if (part2.Contains(charin1) && !commonCharsInLine.Contains(charin1.ToString())) 
//             commonCharsInLine.Add(charin1.ToString());
//     }
//     commonChars.AddRange(commonCharsInLine);
// }
//
var sum = 0;
foreach (var commonChar in commonChars)
{
    // char c = 'A';
//char c = 'b'; you may use lower case character.
    var index = char.ToUpper(commonChar.ToCharArray()[0]) - 64; //index == 1
    if (commonChar.ToUpper() == commonChar)
        sum += index + 26;
    else
        sum += index;
    Console.WriteLine($"{commonChar} {index}");
}

commonChars.ForEach(x => Console.WriteLine(x));
Console.WriteLine(sum);