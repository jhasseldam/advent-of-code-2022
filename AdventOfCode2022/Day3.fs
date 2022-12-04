namespace AdventOfCode2022.Day3

open System
open Microsoft.FSharp.Collections

module RucksackOrganizationPart1 =
    
    let splitContentIntoCompartments (rucksackContent : string) =
        let length = rucksackContent.Length
        let compartment1 = rucksackContent.Substring(0, length / 2)
        let compartment2 = rucksackContent.Substring(length / 2)
        compartment1, compartment2
        
    let findSharedItem (compartment1 : string, compartment2 : string) =
        let compartment1 = compartment1.ToCharArray() |> Set.ofArray
        let compartment2 = compartment2.ToCharArray() |> Set.ofArray
        Set.intersect compartment1 compartment2 |> Seq.head
        
    let priority = ['a'..'z'] @ ['A' .. 'Z']
    
    let findPriority char = (List.findIndex((=) char) priority) + 1
    
    let findDuplicateItemsAndSumPriority (listOfContent : string) =
        listOfContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        |> Array.map splitContentIntoCompartments
        |> Array.map findSharedItem
        |> Array.map findPriority
        |> Array.sum
    let prettyPrint sum =
        printfn $"The sum of the duplicate item priorities in the elf rucksacks is: {sum}"