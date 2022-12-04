namespace AdventOfCode2022.Day3

open System

module RucksackOrganizationPart2 =
    
    
    let divideIntoGroupsOfThree (listOfContent : string) =
        let rec takeLines input output =
            match input with
            | x::y::z::rest -> takeLines rest ([x; y; z]::output)
            | [] -> output
            | _ -> raise (ArgumentException("Invalid input, not divisible by three"))
        let contentLines = listOfContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries) |> List.ofArray
        takeLines contentLines []
                          

