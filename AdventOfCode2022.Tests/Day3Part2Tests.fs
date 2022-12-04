module AdventOfCode2022.Tests.Day3Part2Tests

open System.IO
open Xunit
open FsUnit
open AdventOfCode2022.Day3.RucksackOrganizationPart2

[<Fact>]
let ``Can correctly divide simple elf example content into groups of three`` () =
   let groupOne = [""; ""; ""]
   let groupTwo = [""; ""; ""]
   let groupedContentLines = File.ReadAllText("TestData/Day3/day3-small.txt") |> divideIntoGroupsOfThree 
