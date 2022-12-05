module AdventOfCode2022.Tests.Day3Part1Tests

open System.IO
open Xunit
open FsUnit
open AdventOfCode2022.Day3.RucksackOrganizationPart1

[<Fact>]
let ``Can split rucksack content into compartments`` () =
    "vJrwpWtwJgWrhcsFMMfFFhFp" |> splitContentIntoCompartments |> should equal ("vJrwpWtwJgWr", "hcsFMMfFFhFp")
    
[<Fact>]
let ``Can identify the shared item in each compartment`` () =
    ("vJrwpWtwJgWr", "hcsFMMfFFhFp") |> findSharedItem |> should equal 'p'

[<Fact>]
let ``Can find the correct priority of a rucksack item`` () =
    // 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s)
    'p' |> findPriority |> should equal 16
    'L' |> findPriority |> should equal 38
    'P' |> findPriority |> should equal 42
    'v' |> findPriority |> should equal 22
    't' |> findPriority |> should equal 20
    's' |> findPriority |> should equal 19
    'a' |> findPriority |> should equal 1
    
[<Fact>]
let ``Can find correct duplicate items in content list and sum their priority`` () =
   File.ReadAllText("TestData/Day3/day3-small.txt") |> findDuplicateItemsAndSumPriority |> should equal 157 
    