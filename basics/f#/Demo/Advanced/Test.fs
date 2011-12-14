module tests

let FindClosestSum (lst:int list) =
 let hsize = (List.length lst) / 2
 let rec MakeSubListsOfSize size l = 
    seq {
        match size with 
            | 0 ->  yield []
            | _ when (size <= List.length l) ->  
                    match l with 
                        | [] -> yield! []
                        | hd::tl -> 
                                let sublist = (MakeSubListsOfSize (size-1) tl)
                                yield! [ for x in sublist do yield hd::x ]
                                yield! MakeSubListsOfSize size tl
            | _ -> yield! [] 
         }
 let allSubLists = MakeSubListsOfSize hsize lst
 let total = List.sum lst
 let expectedValue = total/2
 let part1,part2,diff = allSubLists |> Seq.map (fun x -> List.sum x) |> Seq.map (fun y -> (y,total-y)) |> Seq.map (fun (a,b) -> (a,b, abs(expectedValue-a)+abs(expectedValue-b))) |> Seq.minBy (fun (p,q,r) -> r)
 (part1,part2)
 


//
//let FindClosestSum1 (lst:int list) =
// let hsize = (List.length lst) / 2
// let rec MakeSubListsOfSize size l = 
//    seq {
//        match size with 
//            | 0 ->  yield [||]
//            | 1 ->  yield! [| for x in l do yield [|x|] |]
//            | _ when (size = Array.length l) ->  yield l
//            | _ when (size <= Array.length l) ->  
//                    match l with 
//                        | [||] -> yield! [||]
//                        | _ -> 
//                                let tl = (l |> Seq.skip(1) |> Seq.toArray)
//                                let hd = Array.get l 0
//                                printfn "recursing with size %d and tail %A" (size-1) tl
//                                let sublist = (MakeSubListsOfSize (size-1) tl) 
//                                printfn "%A for element %d" (sublist |> Seq.toArray) hd
//                                yield! [| for e in l do  yield! [| for x in (sublist |> Seq.skipWhile (fun s -> e >= (Array.get s 0)) ) do yield ( x |> Array.append [|e|] ) |] ;  |]
//            | _ -> yield! [||] 
//         } |> Seq.cache
// let allSubLists = MakeSubListsOfSize hsize (lst |> List.toArray)
// let total = List.sum lst
// let expectedValue = total/2
// let part1,part2,diff = allSubLists |> Seq.map (fun x -> List.sum x) |> Seq.map (fun y -> (y,total-y)) |> Seq.map (fun (a,b) -> (a,b, abs(expectedValue-a)+abs(expectedValue-b))) |> Seq.minBy (fun (p,q,r) -> r)
// (part1,part2)


open NUnit.Framework


[<TestFixture>]
type TestClass = class
    new() = {}
  
    [<Test>]  
    member x.Test1() = 
        let l = [20;11;3;2;1;1]
        let s = List.sum l
        let l1 = [20;1;1]
        let l2 = [11;3;2]
        let sum1 = List.sum l1
        let sum2 = List.sum l2
        Assert.AreEqual((sum1,sum2),FindClosestSum(l))
        
    [<Test>]  
    member x.PerformanceTest() = 
        let l = [221; 349; 404; 404; 439; 331; 89; 420; 23; 397; 397; 17; 283; 144; 288; 204; 34; 53; 193; 302; 371; 404;79; 284; 272; 360; 17; 228; 122; 119; 329; 137; 136; 238; 444; 220; 450; 431; 291; 193; 380; 137; 410; 160; 100; 181; 395; 35; 431; 303; 5; 45; 264; 433; 322; 425; 334; 23; 249; 363; 214; 62; 225; 108; 153; 322; 161; 239; 272; 253; 388; 447; 124; 27; 144; 120; 228; 321; 105; 163; 394; 45; 428; 405; 348; 263; 431; 225; 77; 168; 33; 63; 35; 144; 35; 276; 347; 145; 309; 18]
        Assert.AreEqual((11688,11689),FindClosestSum(l))
end



let f l e contseq =
    seq {
        yield! [ for x in l do yield e::x ]
        yield! contseq
        }

let rec MakeSubListsOfSize size l = 
    seq {
        match size with 
            | 0 ->  yield []
            | _ when (size <= List.length l) ->  
                    match l with 
                        | [] -> yield! []
                        | hd::tl -> 
                                yield! f (MakeSubListsOfSize (size-1) tl) hd (seq { yield! MakeSubListsOfSize size tl })
                                
            | _ -> yield! [] 
         }
         
         
//let rec transpose haves =
//    match haves with
//        | (_::_)::_ -> map hd haves :: transpose (map tl haves)
//        | _         -> []
//        
//        
//        
//let rec nums =
//    seq {   printfn "yielding 1"
//            yield 1
//            printfn "yielded 1"
//            for n in nums do printfn "looping %d" n; yield n + 1; printfn "yield %d" (n+1); } |> Seq.cache;;
//            
////            