// See https://aka.ms/new-console-template for more information



Console.WriteLine("Heaps");
Heaps();
Console.WriteLine();

static void Heaps()
{
    var solution = new LyftLeetCode.Heaps.Solution();
    //var n = 3;
    //var cabTravelTime = new int[] { 3, 4, 8};
    Console.WriteLine("Taxi scheduling");
    var n = 10;
    var cabTravelTime = new int[] { 1, 3, 8, 3, 5 };
    var minTime = solution.TaxiScheduling.TaxiScheduling(n, cabTravelTime);

    Console.WriteLine(minTime);
    Console.WriteLine();

    Console.WriteLine("Meeting rooms scheduling");
    //var intervals = new int[3][]
    //{
    //    new int[] { 0, 30 },
    //    new int[] { 5, 10 },
    //    new int[] { 15, 25 }

    //};

    //var intervals = new int[2][]
    //{
    //    new int[] { 7, 10 },
    //    new int[] { 2, 4 }        

    //};

    // var intervals = new int[5][]
    //{
    //     new int[] { 4, 8 },
    //     new int[] { 6, 8 },
    //     new int[] { 9, 16 },
    //     new int[] { 15, 16 },
    //     new int[] { 17, 20 }
    //};

    var intervals = new int[7][]
   {
        new int[] { 2, 4 },
        new int[] { 4, 5 },
        new int[] { 4, 6 },
        new int[] { 5, 6 },
        new int[] { 7, 10 },
        new int[] { 8, 9 },
        new int[] { 8, 10 },
   };
    var rooms = solution.MeetingRoomsAdjusted.MinMeetingRooms(intervals);

    for (int i = 0; i < rooms.Length; i++)
    {
        Console.WriteLine($"{rooms[i][0]} {rooms[i][1]}");
    }

    Console.WriteLine();


    Console.WriteLine("K closest");
    var points = new int[3][]
    {
        new int[] { -5, 4 },
        new int[] { -6, -5 },
        new int[] { 4, 6 }
    };
    solution.KClosest.KClosest(points, 2);
    Console.WriteLine();

}