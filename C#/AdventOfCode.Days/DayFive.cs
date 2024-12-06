using System.Globalization;
using Xunit.Abstractions;

namespace AdventOfCode.Days;

public class DayFive
{
    private readonly ITestOutputHelper _output;
    private const string InputFile = @"Data/DayFive";

    public DayFive(ITestOutputHelper output)
    {
        _output = output;
        _output.WriteLine("Day Five");
    }

    [Fact]
    public void PartOne()
    {
        var solution = 0;
        var ruleSet = new Dictionary<string, List<string>>();
        var inputLines = File.ReadAllLines(InputFile);
        var ruleLines = inputLines.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).ToList();
        var updateLines = inputLines.SkipWhile(line => !string.IsNullOrWhiteSpace(line)).Skip(1).ToList();
        foreach (var line in ruleLines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var rule = line.Split("|");
            if (ruleSet.TryGetValue(rule[0], out var rules))
            {
                rules.Add(rule[1]);
            }
            else
            {
                ruleSet.Add(rule[0], [rule[1]]);
            }

            if (!ruleSet.ContainsKey(rule[1]))
            {
                ruleSet.Add(rule[1], []);
            }
        }

        foreach (var update in updateLines)
        {
            var validUpdate = true;
            var pages = update.Split(",");
            var middlePage = pages[pages.Length / 2];

            for (var pageIndex = 0; pageIndex < pages.Length; pageIndex++)
            {
                var succPages = pages.Length - pageIndex - 1;
                var pageRuleSet = ruleSet[pages[pageIndex]];

                foreach (var succPage in pages[pageIndex..].ToList())
                {
                    if (pageRuleSet.Contains(succPage))
                    {
                        succPages--;
                    }
                }

                if (succPages > 0)
                {
                    validUpdate = false;
                    break;
                }
            }

            if (validUpdate)
            {
                solution += int.Parse(middlePage, CultureInfo.InvariantCulture);
            }
        }

        _output.WriteLine($"\tPart One: {solution}");
        Assert.Equal(7024, solution);
    }

    [Fact]
    public void PartTwo()
    {
        var solution = 0;
        var ruleSet = new Dictionary<string, List<string>>();
        var inputLines = File.ReadAllLines(InputFile);
        var ruleLines = inputLines.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).ToList();
        var updateLines = inputLines.SkipWhile(line => !string.IsNullOrWhiteSpace(line)).Skip(1).ToList();
        var invalidUpdates = new List<string>();

        foreach (var line in ruleLines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var rule = line.Split("|");
            if (ruleSet.TryGetValue(rule[0], out var rules))
            {
                rules.Add(rule[1]);
            }
            else
            {
                ruleSet.Add(rule[0], [rule[1]]);
            }

            if (!ruleSet.ContainsKey(rule[1]))
            {
                ruleSet.Add(rule[1], []);
            }
        }

        foreach (var update in updateLines)
        {
            var validUpdate = true;
            var pages = update.Split(",");

            for (var pageIndex = 0; pageIndex < pages.Length; pageIndex++)
            {
                var succPages = pages.Length - pageIndex - 1;
                var pageRuleSet = ruleSet[pages[pageIndex]];

                foreach (var succPage in pages[pageIndex..].ToList())
                {
                    if (pageRuleSet.Contains(succPage))
                    {
                        succPages--;
                    }
                }

                if (succPages > 0)
                {
                    validUpdate = false;
                    break;
                }
            }

            if (!validUpdate)
            {
                invalidUpdates.Add(update);
            }
        }

        foreach (var update in invalidUpdates)
        {
            var validUpdate = true;
            var pages = update.Split(",");

            for (var pageIndex = 0; pageIndex < pages.Length; pageIndex++)
            {
                var succPages = pages.Length - pageIndex - 1;
                var pageRuleSet = ruleSet[pages[pageIndex]];

                foreach (var succPage in pages[pageIndex..].ToList())
                {
                    if (pageRuleSet.Contains(succPage))
                    {
                        succPages--;
                    }
                }

                if (succPages > 0)
                {
                    validUpdate = false;
                    break;
                }
            }

            if (!validUpdate)
            {
                invalidUpdates.Add(update);
            }
        }

        _output.WriteLine($"\tPart Two: {solution}");
        Assert.Equal(7024, solution);
    }
}