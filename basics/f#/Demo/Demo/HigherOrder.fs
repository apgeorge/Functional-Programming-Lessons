module higherorder
open System

let nums = [1 .. 100]

let squares = List.map (fun i -> i *i) nums
let sum1 = List.sum squares
printf "%d " sum1

let cubes = List.map (fun i -> i *i *i) nums
let sum2 = List.sum cubes
printf "%d " sum2












let sum3 = List.sum (List.map (fun i -> i *i) nums)
printf "%d " sum3

let sum4 = nums |> List.map (fun i -> i *i) |> List.sum
printf "%d " sum4

