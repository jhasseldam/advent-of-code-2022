module Program
open System.IO
open AdventOfCode2022.Day1
open AdventOfCode2022.Day2
open AdventOfCode2022.Day3

[<EntryPoint>]
let main args =
    // Day 1
    printfn "#### DAY 1"
    File.ReadAllText "PuzzleInput/day1.txt" |> ElfCalories.findMaxCaloriesAmongElves |> ElfCalories.prettyPrint
    printfn "#### DAY 2 part 1"
    File.ReadAllText "PuzzleInput/day2.txt" |> RockPaperScissorsPart1.scoreTournament |> RockPaperScissorsPart1.prettyPrint
    printfn "#### DAY 2 part 2"
    File.ReadAllText "PuzzleInput/day2.txt" |> RockPaperScissorsPart2.scoreTournament |> RockPaperScissorsPart2.prettyPrint
    printfn "#### DAY 3"
    File.ReadAllText "PuzzleInput/day3.txt" |> RucksackOrganizationPart1.findDuplicateItemsAndSumPriority |> RucksackOrganizationPart1.prettyPrint
    0