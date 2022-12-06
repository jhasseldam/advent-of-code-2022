namespace AdventOfCode2022.Day4

open System

module CampCleanupPart1 =
    
    let createCollectionFromAssignmentRange (assignmentRange : string) =
        assignmentRange.Split('-')
        |> Array.map Int32.Parse
        |> fun assignmentIds -> [assignmentIds[0]..assignmentIds[1]]
        
    let createCollectionsFromAssignmentPair (pair : string) =
        pair.Split(',')
        |> Array.map createCollectionFromAssignmentRange
        |> fun ranges -> ranges[0], ranges[1]
        
    let completeRangeOverlap (range1, range2) =
        let set1 = Set.ofList range1 
        let set2 = Set.ofList range2
        Set.isSubset set1 set2 ||
        Set.isSubset set2 set1
        
    let findCompleteOverlappingAssignmentPairsSum (assignmentPairsList : string) =
        assignmentPairsList.Split(Environment.NewLine)
        |> Array.map createCollectionsFromAssignmentPair
        |> Array.map completeRangeOverlap
        |> Array.filter id
        |> Array.length
        
    let prettyPrint sum =
        printfn $"{sum} elves had assigment lists which were completely overlapping"
        
        
   
        

