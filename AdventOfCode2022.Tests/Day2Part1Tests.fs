module AdventOfCode2022.Tests.Day2Part1Tests

open System.IO
open AdventOfCode2022.Day2.RockPaperScissorsPart1
open Xunit
open FsUnit

[<Fact>]
let ``Can correctly translate elf rock-paper-scissors code`` () =
    "A" |> decryptCode |> should equal Selection.Rock
    "X" |> decryptCode |> should equal Selection.Rock
    "B" |> decryptCode |> should equal Selection.Paper
    "Y" |> decryptCode |> should equal Selection.Paper
    "C" |> decryptCode |> should equal Selection.Scissors
    "Z" |> decryptCode |> should equal Selection.Scissors
    
[<Fact>]
let ``Correctly score your rock-paper-scissors selection`` () =
    Selection.Rock |> scoreMySelection |> should equal 1
    Selection.Paper |> scoreMySelection |> should equal 2
    Selection.Scissors |> scoreMySelection |> should equal 3
    
[<Fact>]
let ``Correctly determine of round`` () =
    (Rock, Paper) |> determineRoundOutcome |> should equal Won
    (Rock, Scissors) |> determineRoundOutcome |> should equal Lost
    (Rock, Rock) |> determineRoundOutcome |> should equal Draw
    (Paper, Scissors) |> determineRoundOutcome |> should equal Won
    (Paper, Rock) |> determineRoundOutcome |> should equal Lost
    (Paper, Paper) |> determineRoundOutcome |> should equal Draw
    (Scissors, Rock) |> determineRoundOutcome |> should equal Won
    (Scissors, Paper) |> determineRoundOutcome |> should equal Lost
    (Scissors, Scissors) |> determineRoundOutcome |> should equal Draw

[<Fact>]
let ``Can calculate correct score for round`` () =
    "A Y" |> scoreRound |> should equal 8
    "B X" |> scoreRound |> should equal 1
    "C Z" |> scoreRound |> should equal 6
    
[<Fact>]
let ``Can correctly score tournament strategy guide`` () =
    File.ReadAllText("TestData/day2-small.txt") |> scoreTournament |> should equal 15
    
