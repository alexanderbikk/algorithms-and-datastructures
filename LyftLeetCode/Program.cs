// See https://aka.ms/new-console-template for more information

Console.WriteLine("Heaps");
Heaps();
Console.WriteLine();

static void Heaps()
{
    var solution = new LyftLeetCode.Heaps.Solution();
    //var n = 3;
    //var cabTravelTime = new int[] { 3, 4, 8};

    var n = 10;
    var cabTravelTime = new int[] { 1, 3, 8, 3, 5 };
    var minTime = solution.TaxiScheduling(n, cabTravelTime);
    Console.WriteLine(minTime);
}