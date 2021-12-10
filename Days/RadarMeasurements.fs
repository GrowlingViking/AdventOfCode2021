module RadarMeasurements

open System.IO

// PART 1
let measureIncreases = 
    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day01_RadarInput.txt")

    // Convert lines into a list of ints
    let list = lines |> Seq.map System.Int32.Parse |> Seq.toList
    
    let CountAscendingDepths list =
        let rec loop list count =
            match list with
            | [] -> count
            | [a] -> count
            | head :: tail when head < tail.Head -> loop tail (count + 1)
            | head :: tail -> loop tail count
        loop list 0

    CountAscendingDepths list 

// PART 2
let threeMeasurement = 
    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day01_RadarInput.txt")
    
    // Convert lines into a list of ints
    let list = lines |> Seq.map System.Int32.Parse |> Seq.toList

    let CountAscendingDepths list =
        let rec loop list count =
            match list with
            | a :: b :: c :: d :: tail when (a + b + c) < (b + c + d) -> loop (b :: c :: d :: tail) (count + 1)
            | head :: tail -> loop tail count
            | _ -> count
        loop list 0

    CountAscendingDepths list 