module Program
open System.IO
open AdventOfCode2022.Day1
open AdventOfCode2022.Day2
open AdventOfCode2022.Day3
open AdventOfCode2022.Day4

[<EntryPoint>]
let main args =
    // Day 1
    printfn "#### DAY 1 part 1"
    File.ReadAllText "PuzzleInput/day1.txt" |> ElfCaloriesPart1.findMaxCaloriesAmongElves |> ElfCaloriesPart1.prettyPrint
    printfn "#### DAY 1 part 1"
    File.ReadAllText "PuzzleInput/day1.txt" |> ElfCaloriesPart2.topThreeCaloriesSum |> ElfCaloriesPart2.prettyPrint
    printfn "#### DAY 2 part 1"
    File.ReadAllText "PuzzleInput/day2.txt" |> RockPaperScissorsPart1.scoreTournament |> RockPaperScissorsPart1.prettyPrint
    printfn "#### DAY 2 part 2"
    File.ReadAllText "PuzzleInput/day2.txt" |> RockPaperScissorsPart2.scoreTournament |> RockPaperScissorsPart2.prettyPrint
    printfn "#### DAY 3 part 1"
    File.ReadAllText "PuzzleInput/day3.txt" |> RucksackOrganizationPart1.findDuplicateItemsAndSumPriority |> RucksackOrganizationPart1.prettyPrint
    printfn "#### DAY 3 part 2"
    File.ReadAllText "PuzzleInput/day3.txt" |> RucksackOrganizationPart2.sumOfBadgeItemPriorities |> RucksackOrganizationPart2.prettyPrint
    printfn "#### DAY 4 part 1"
    File.ReadAllText "PuzzleInput/day4.txt" |> CampCleanupPart1.findOverlappingAssignmentPairsSum |> CampCleanupPart1.prettyPrint
    0