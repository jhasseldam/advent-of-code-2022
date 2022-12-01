module Program
open System.IO
open AdventOfCode2022.Day1

[<EntryPoint>]
let main args =
    // Day 1 
    File.ReadAllText "PuzzleInput/day1.txt" |> ElfCalories.findMaxCaloriesAmongElves |> ElfCalories.prettyPrint
    0