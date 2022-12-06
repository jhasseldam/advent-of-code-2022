namespace AdventOfCode2022.Day4

open System

module CampCleanupPart2 =
    
    
    let hasSomeRangeOverlap (range1, range2) =
       let set1 = Set.ofList range1
       let set2 = Set.ofList range2
       (Set.difference set1 set2 |> fun diff -> diff.Count < range1.Length) ||
       (Set.difference set2 set1 |> fun diff -> diff.Count < range2.Length)
    
    let findAnyOverlappingAssigmentPairsSum (assignmentPairsList : string) = 
        assignmentPairsList.Split(Environment.NewLine)
        |> Array.map CampCleanupPart1.createCollectionsFromAssignmentPair
        |> Array.map hasSomeRangeOverlap
        |> Array.filter id
        |> Array.length
        
    let prettyPrint sum =
        printfn $"{sum} elves had assigment lists which contains some overlapping"
        

