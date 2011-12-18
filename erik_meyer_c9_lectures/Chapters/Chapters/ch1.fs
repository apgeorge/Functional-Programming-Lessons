module ch1_test

open Xunit

let last1 xs = xs |> List.rev |> List.head
let last2 xs = List.nth xs (xs.Length - 1) 
let last3 (xs:'a list) = xs.[xs.Length - 1] 

let rec last4  = function
        | [] -> failwith "Empty List!"
        | head :: [] -> head
        | head :: tail -> last4 tail 

let last5 xs = xs |> List.fold (fun _ x -> x ) 0  
    
let remove_last1 xs = xs |> List.rev |> List.tail |> List.rev
//TODO: Do we need the conversions to seq and list?
let remove_last2 xs = xs |> Seq.take( Seq.length xs - 1) |> Seq.toList

let abs n = match n with
                | _ when n >= 0 -> n
                | otherwise -> -n
  
let abs1 = function
            | n when n >= 0 -> n
            | n -> -n


[<Fact>]
let test_finds_last_element_of_a_list() = 
    let xs = [1..10]
    Assert.Equal(10,last1 xs)
    Assert.Equal(10,last2 xs)
    Assert.Equal(10,last3 xs)
    Assert.Equal(10,last4 xs)
    Assert.Equal(10,last5 xs)


[<Fact>]
let removes_last_element_of_a_list() =
    let xs = [1..10]
    Assert.Equal([1..9], remove_last1 xs) 
    Assert.Equal([1..9], remove_last2 xs) 


[<Fact>]
let finds_absolute_value_of_a_number() =
    Assert.Equal(12, abs 12)
    Assert.Equal(12, abs -12)
    Assert.Equal(0, abs 0)
    
    Assert.Equal(12, abs1 12)
    Assert.Equal(12, abs1 -12)
    Assert.Equal(0, abs1 0)
    
    
