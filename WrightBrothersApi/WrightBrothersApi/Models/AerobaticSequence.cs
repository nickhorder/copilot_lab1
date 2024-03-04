using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Maneuver
{
    public string Type { get; set; }
    public int RepeatCount { get; set; }
    public char Difficulty { get; set; }
}

public class AerobaticSequence
{
    public List<Maneuver> Maneuvers { get; set; } = new List<Maneuver>();
    public double Difficulty { get; set; }

    public static AerobaticSequence Parse(string signature)
    {
        var sequence = new AerobaticSequence();
        var maneuvers = Regex.Matches(signature, @"([LHRTS]\d+[A-F])");

        for (int i = 0; i < maneuvers.Count; i++)
        {
            var maneuver = new Maneuver
            {
                Type = maneuvers[i].Value[0].ToString(),
                RepeatCount = int.Parse(maneuvers[i].Value.Substring(1, maneuvers[i].Value.Length - 2)),
                Difficulty = maneuvers[i].Value[^1]
            };

            sequence.Maneuvers.Add(maneuver);
        }

        sequence.CalculateDifficulty();

        return sequence;
    }

    private void CalculateDifficulty()
    {
        var difficultyMultipliers = new Dictionary<char, double>
        {
            { 'A', 1.0 },
            { 'B', 1.2 },
            { 'C', 1.4 },
            { 'D', 1.6 },
            { 'E', 1.8 },
            { 'F', 2.0 }
        };

        for (int i = 0; i < Maneuvers.Count; i++)
        {
            var multiplier = difficultyMultipliers[Maneuvers[i].Difficulty];
            var score = Maneuvers[i].RepeatCount * multiplier;

            if (i > 0)
            {
                if (Maneuvers[i].Type == "R" && Maneuvers[i - 1].Type == "L")
                    score *= 2;
                else if (Maneuvers[i].Type == "S" && Maneuvers[i - 1].Type == "T")
                    score *= 3;
            }

            Difficulty += score;
        }

        Difficulty = Math.Round(Difficulty, 2);
    }
}