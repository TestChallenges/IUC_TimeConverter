using _TimeConverter;

var millisecondsSince1970ToDateConverter = new TimeConverter(startingYear: 1970);

while (true)
{
    try
    {
        Console.Write("Enter milliseconds passed since 1970: ");
        var millisecondsString = Console.ReadLine();
        var millisecondsNumber = ulong.Parse(millisecondsString);
        var computedDate = millisecondsSince1970ToDateConverter.ConvertPassedMillisecondsToDate(
            millisecondsNumber
        );

        Console.WriteLine($"{computedDate}\n");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
