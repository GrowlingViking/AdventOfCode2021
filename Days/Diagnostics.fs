module Diagnostics

open System
open System.IO

/// PART 1
let calculatePowerConsumption = 

    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day03_Diagnostics.txt")
    
    // Convert lines into a list
    let list = lines |> Seq.toList

    let decideBit bit counter = 
        if bit = '1' then counter + 1 else counter - 1

    let mostCommonBit (binaryNumber: string) a b c d e f g h i j k l = 
        let m = decideBit binaryNumber.[0] a
        let n = decideBit binaryNumber.[1] b
        let o = decideBit binaryNumber.[2] c
        let p = decideBit binaryNumber.[3] d
        let q = decideBit binaryNumber.[4] e
        let r = decideBit binaryNumber.[5] f
        let s = decideBit binaryNumber.[6] g
        let t = decideBit binaryNumber.[7] h
        let u = decideBit binaryNumber.[8] i
        let v = decideBit binaryNumber.[9] j
        let w = decideBit binaryNumber.[10] k
        let x = decideBit binaryNumber.[11] l
        m, n, o, p, q, r, s, t, u, v, w, x

    let findGammaBinary decidingBits =
        let rec loop list output =
            match list with
            | [] -> output
            | head :: tail -> 
                let binaryString = if head > 0 then output + "1" else output + "0"
                loop tail binaryString
        loop decidingBits ""

    let findEpsilonBinary decidingBits =
        let rec loop list output =
            match list with
            | [] -> output
            | head :: tail -> 
                let binaryString = if head > 0 then output + "0" else output + "1"
                loop tail binaryString
        loop decidingBits ""

    let getDecidingBits list = 
        let rec loop list a b c d e f g h i j k l =
            match list with
            | [] -> a :: b :: c :: d :: e :: f :: g :: h :: i :: j :: k :: l :: []
            | head :: tail -> 
                let (m, n, o, p, q, r, s, t, u, v, w, x) = mostCommonBit head a b c d e f g h i j k l
                loop tail m n o p q r s t u v w x
        loop list 0 0 0 0 0 0 0 0 0 0 0 0
        
    let decidingBits = getDecidingBits list
    let gammaBinaryString = findGammaBinary decidingBits
    let epsilonBinaryString = findEpsilonBinary decidingBits
    let gammaRate = Convert.ToInt32(gammaBinaryString, 2)
    let epsilonRate = Convert.ToInt32(epsilonBinaryString, 2)

    gammaRate * epsilonRate

// PART 2
let calculateLifeSupport = 
    
    let lines = File.ReadAllLines(@"C:\AdventOfCode2021\Data\Day03_Diagnostics.txt")
    
    // Convert lines into a list
    let list = lines |> Seq.toList

    let findDecidingBitInPosition (list: string list) (position: int) (mostCommon: bool)= 
        let rec loop (list: string list) (position: int) (counter: int) = 
            match list with
            | [] -> counter
            | head :: tail -> 
                let counter = if head.[position] = '1' then counter + 1 else counter - 1
                loop tail position counter
        let firstValue = if mostCommon then '1' else '0'
        let secondValue = if mostCommon then '0' else '1'
        if (loop list position 0) >= 0 then firstValue else secondValue

    let findRating (list: string list) (oxygen: bool) = 
        let rec loop list position oxygen = 
            match list with 
            | [rating] -> rating
            | remainingList -> 
                let mostCommon = findDecidingBitInPosition remainingList position oxygen
                let filteredList = remainingList |> List.filter (fun x -> x.[position] = mostCommon)
                loop filteredList (position + 1) oxygen
        loop list 0 oxygen

    let oxygenBinary = findRating list true
    let oxygenRate = Convert.ToInt32(oxygenBinary, 2)
    let CO2Binary = findRating list false
    let CO2Rate = Convert.ToInt32(CO2Binary, 2)

    oxygenRate * CO2Rate