namespace AdventOfCode2022.Day1

open System

module ElfCaloriesPart2 =
    
    let topThreeCaloriesSum itemsList =
        itemsList
        |> ElfCaloriesPart1.splitOnEmptyLine
        |> Array.map (ElfCaloriesPart1.splitOnNewLine >> Array.map Int32.Parse >> Array.sum)
        |> Array.sortDescending
        |> Array.take 3
        |> Array.sum

    let prettyPrint sum =
        printfn $"The sum of calories carried by the top three elves are : {sum}"
        
