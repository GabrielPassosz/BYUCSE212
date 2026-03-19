/*
 * CSE 212 Lesson 6C 
 * 
 * This code analyzes NBA basketball data and creates a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        var topPlayers = players
            .OrderByDescending(player => player.Value)
            .Take(10)
            .ToArray();

        Console.WriteLine("Top 10 Players by Total Career Points");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Player ID\tTotal Points");

        foreach (var player in topPlayers)
        {
            Console.WriteLine($"{player.Key}\t{player.Value}");
        }
    }
}