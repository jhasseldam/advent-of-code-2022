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
                          
    let findCommonBadgeItemForGroup (contentListForGroup : string list) =
        contentListForGroup
        |> Seq.map (fun (singleElfContentList : string) -> singleElfContentList.ToCharArray())
        |> Seq.map Set.ofArray
        |> Set.intersectMany
        |> Seq.exactlyOne
        
    let sumOfBadgeItemPriorities contentList =
        contentList
        |> divideIntoGroupsOfThree
        |> Seq.map findCommonBadgeItemForGroup
        |> Seq.map RucksackOrganizationPart1.findPriority
        |> Seq.sum
        
    let prettyPrint sum =
        printfn $"The sum of priorities for all badge items in groups of elves is : {sum}"
   