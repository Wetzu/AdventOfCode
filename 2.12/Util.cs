namespace _2._12;

public static class Util
{
    public static IEnumerable<(Move Challenge, Move Response)> LoadStrategies(string path)
    {
        var result = new List<(Move Challenge, Move Response)>();

        if (File.Exists(path))
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(' ');
                    var challenge = parts[0] switch
                    {
                        "A" => Move.Rock,
                        "B" => Move.Paper,
                        "C" => Move.Scissors
                    };
                    var response = parts[1] switch
                    {
                        "Y" => Move.Paper,
                        "X" => Move.Rock,
                        "Z" => Move.Scissors
                    };
                    result.Add((challenge, response));
                }
            }

        }

        return result;
    }

    public static IEnumerable<(Move Challenge, Outcome Response)> LoadStrategiesPart2(string path)
    {
        var result = new List<(Move Challenge, Outcome Response)>();

        if (File.Exists(path))
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(' ');
                    var challenge = parts[0] switch
                    {
                        "A" => Move.Rock,
                        "B" => Move.Paper,
                        "C" => Move.Scissors
                    };
                    var response = parts[1] switch
                    {
                        "Y" => Outcome.Draw,
                        "X" => Outcome.Lost,
                        "Z" => Outcome.Won
                    };
                    result.Add((challenge, response));
                }
            }

        }

        return result;
    }

    public static (Move Challenge, Move Response) FigureOutMove((Move Challenge, Outcome Outcome) play)
    {
        var response = (play.Challenge, play.Outcome) switch
        {
            (Move.Rock, Outcome.Won) => Move.Paper,
            (Move.Rock, Outcome.Draw) => Move.Rock,
            (Move.Rock, Outcome.Lost) => Move.Scissors,
            (Move.Paper, Outcome.Won) => Move.Scissors,
            (Move.Paper, Outcome.Draw) => Move.Paper,
            (Move.Paper, Outcome.Lost) => Move.Rock,
            (Move.Scissors, Outcome.Won) => Move.Rock,
            (Move.Scissors, Outcome.Draw) => Move.Scissors,
            (Move.Scissors, Outcome.Lost) => Move.Paper,
        };
        return (play.Challenge, response);
    }

    public static int CalculateMoveScore(Move challenge, Move response)
    {
        var score = 0;
        score += response switch
        {
            Move.Rock => 1,
            Move.Paper => 2,
            Move.Scissors => 3,
        };
        score += GetOutcome(challenge, response) switch
        {
            Outcome.Won => 6,
            Outcome.Draw => 3,
            Outcome.Lost => 0,
        };
        return score;
    }

    private static Outcome GetOutcome(Move challenge, Move response)
    {
        return (challenge, response) switch
        {
            (Move.Rock, Move.Paper) => Outcome.Won,
            (Move.Paper, Move.Scissors) => Outcome.Won,
            (Move.Scissors, Move.Rock) => Outcome.Won,
            (Move.Rock, Move.Rock) => Outcome.Draw,
            (Move.Paper, Move.Paper) => Outcome.Draw,
            (Move.Scissors, Move.Scissors) => Outcome.Draw,
            _ => Outcome.Lost
        };
    }
}