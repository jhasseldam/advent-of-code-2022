module AdventOfCode2022.Tests.Day1Tests

open System.IO
open Xunit
open AdventOfCode2022.Day1

[<Fact>]
let ``Correctly split input on empty line`` () =
    let given = File.ReadAllText "TestData/Day1/day1-small.txt"
    
    let expected =
        [|
            "1000
             2000
             3000"
            "4000"
            "5000
             6000"
            "7000
             8000
             9000"
            "10000"
        |]
        
    ElfCalories.splitOnEmptyLine given |> (=) expected
    
[<Fact>]
let ``Correctly split input on newline with multiple values`` () =
    let given =
        "7000
         8000
         9000"
    
    let expected = [|"7000"; "8000"; "9000"|]

    ElfCalories.splitOnNewLine given |> (=) expected
    
[<Fact>]
let ``Correctly split input on newline with single value`` () =
    let given = "7000"
    
    let expected = [|"7000"|]

    ElfCalories.splitOnNewLine given |> (=) expected
    
[<Fact>]
let ``Correctly identify the highest sum of calories among elves`` () =
    let given = File.ReadAllText "TestData/Day1/day1-small.txt"
    
    let expected = 24000
    
    ElfCalories.findMaxCaloriesAmongElves given |> (=) expected
