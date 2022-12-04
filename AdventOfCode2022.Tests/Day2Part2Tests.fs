module AdventOfCode2022.Tests.Day2Part2Tests

open System.IO
open AdventOfCode2022.Day2
open AdventOfCode2022.Day2.RockPaperScissorsPart2
open AdventOfCode2022.Day2.RockPaperScissorsPart1
open Xunit
open FsUnit

[<Fact>]
let ``Can correctly decrypt elf rock-paper-scissors selection`` () =
    "A" |> decryptElfSelection |> should equal Rock
    "B" |> decryptElfSelection |> should equal Paper
    "C" |> decryptElfSelection |> should equal Scissors
    
[<Fact>]
let ``Can correctly decrypt expected round outcome`` () =
    "X" |> decryptExpectedRoundOutcome |> should equal Lost
    "Y" |> decryptExpectedRoundOutcome |> should equal Draw
    "Z" |> decryptExpectedRoundOutcome |> should equal Won
    
[<Fact>]
let ``Can correctly determine my selection based on elf selection an expected outcome`` () =
    determineMySelection Rock Won |> should equal Paper
    determineMySelection Rock Lost |> should equal Scissors
    determineMySelection Rock Draw |> should equal Rock
    determineMySelection Paper Won |> should equal Scissors
    determineMySelection Paper Lost |> should equal Rock
    determineMySelection Paper Draw |> should equal Paper
    determineMySelection Scissors Won |> should equal Rock
    determineMySelection Scissors Lost |> should equal Paper
    determineMySelection Scissors Draw |> should equal Scissors

[<Fact>]
let ``Can correctly score a round`` () =
    "A Y" |> RockPaperScissorsPart2.scoreRound |> should equal 4
    "B X" |> RockPaperScissorsPart2.scoreRound |> should equal 1
    "C Z" |> RockPaperScissorsPart2.scoreRound |> should equal 7

[<Fact>]
let ``Can correctly score tournament using strategy guide with elf explanation`` () =
    File.ReadAllText("TestData/day2-small.txt") |> RockPaperScissorsPart2.scoreTournament |> should equal 12
