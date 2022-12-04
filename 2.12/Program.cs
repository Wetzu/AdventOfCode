using _2._12;

var plays = Util.LoadStrategiesPart2(@"C:\Users\jessig\Desktop\AdventOfCode\2.12\input.txt");

var adjustedPlays = new List<(Move Challenge, Move Response)>();

foreach (var play in plays)
{
    adjustedPlays.Add(Util.FigureOutMove(play));
}

var totalScore = 0;

foreach (var play in adjustedPlays)
{
    var score = Util.CalculateMoveScore(play.Challenge, play.Response);
    totalScore += score;
    Console.WriteLine($"Enemy played {play.Challenge.ToString(), 6}. You played {play.Response.ToString(), 6}. Score {score, 2}");
}

Console.WriteLine(new String('-', 15));
Console.WriteLine($"Total Score {totalScore}");