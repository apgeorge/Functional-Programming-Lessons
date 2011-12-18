module ch4

open Xunit

let safetail1 xs = if List.isEmpty xs then [] else List.tail xs

let safetail2 = function
    | xs when List.isEmpty xs -> []
    | xs -> List.tail xs

let safetail3  = function
    | [] -> []
    | xs -> List.tail xs 

let pairs xs = Seq.zip xs (List.tail xs) |> Seq.toList

let sorted1 xs =  [ for (x,y) in pairs xs -> x <= y ] |> List.forall ((=) true)
let sorted2 xs =  xs |> pairs |> List.forall (fun (x,y) -> x <=y)

let positions x xs = [ for (e,i) in  List.zip xs [1..xs.Length] do if e = x then yield i ]           

[<Fact>]
let safetail_returns_tail_for_non_empty_list() =
    let xs = [1..10]
    Assert.Equal([2..10], safetail1 xs)
    Assert.Equal([2..10], safetail2 xs)
    Assert.Equal([2..10], safetail3 xs)

[<Fact>]
let safetail_returns_empty_for_empty_list() =
    let xs = []
    Assert.Equal([], safetail1 xs)
    Assert.Equal([], safetail2 xs)
    Assert.Equal([], safetail3 xs)
    
[<Fact>]
let retuns_adjacent_pairs_using_zip() =
    Assert.Equal([(1,2);(2,3);(3,4)], pairs [1..4])

[<Fact>]
let returns_true_if_list_sorted() =
    Assert.False(sorted1 [1;5;2;4;3])
    Assert.True(sorted1 [1..5])

    Assert.False(sorted2 [1;5;2;4;3])
    Assert.True(sorted2 [1..5])

[<Fact>]
let returns_all_positions_of_an_item_in_a_list() =
    Assert.Equal([1;2;5], positions 1 [1;1;2;3;1;4])





