module AdventOfCode2022.Tests.Day3Part2Tests

open System.IO
open Xunit
open FsUnit
open AdventOfCode2022.Day3.RucksackOrganizationPart2

[<Fact>]
let ``Can correctly divide simple elf example content into groups of three`` () =
   let expectedGroupOne = ["vJrwpWtwJgWrhcsFMMfFFhFp"; "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"; "PmmdzqPrVvPwwTWBwg"]
   let expectedGroupTwo = ["wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"; "ttgJtRGJQctTZtZT"; "CrZsJsPPZsGzwwsLwLmpwMDw"]
   let groupedContentLines = File.ReadAllText("TestData/Day3/day3-small.txt") |> divideIntoGroupsOfThree
   groupedContentLines |> List.contains expectedGroupOne |> should equal true
   groupedContentLines |> List.contains expectedGroupTwo |> should equal true
   
[<Fact>]
let ``Can correctly identify the correct badge item for elf group`` () =
   let groupOne = ["vJrwpWtwJgWrhcsFMMfFFhFp"; "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"; "PmmdzqPrVvPwwTWBwg"]
   let groupTwo = ["wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"; "ttgJtRGJQctTZtZT"; "CrZsJsPPZsGzwwsLwLmpwMDw"]
   groupOne |> findCommonBadgeItemForGroup |> should equal 'r' 
   groupTwo |> findCommonBadgeItemForGroup |> should equal 'Z'
   
[<Fact>]
let ``Can find the correct priority sum of badge items for elves in groups of three`` () =
   File.ReadAllText("TestData/Day3/day3-small.txt") |> sumOfBadgeItemPriorities |> should equal 70
  
