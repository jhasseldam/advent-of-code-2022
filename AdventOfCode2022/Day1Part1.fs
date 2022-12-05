namespace AdventOfCode2022.Day1

open System

module ElfCaloriesPart1 =
    
    let splitOnEmptyLine (input : string) =
        input.Split([|Environment.NewLine + Environment.NewLine|] , StringSplitOptions.RemoveEmptyEntries)
        
    let splitOnNewLine (input : string) = input.Split([|Environment.NewLine|], StringSplitOptions.RemoveEmptyEntries)
        
    let findMaxCaloriesAmongElves (itemsList : string) =
        itemsList
        |> splitOnEmptyLine
        |> Array.map (splitOnNewLine >> Array.map Int32.Parse >> Array.sum)
        |> Array.max
        
    let prettyPrint result =
        printfn $"The maximum calories carried by a single elf is: {result}"