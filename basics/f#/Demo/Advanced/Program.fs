module primes
//http://lorgonblog.spaces.live.com/blog/cns!701679AD17B6D310!193.entry

open System
open System.Diagnostics  

let stopWatch = new Stopwatch()
let ResetStopWatch() = stopWatch.Reset(); stopWatch.Start()
let ShowTime() = printfn "took %d ms" stopWatch.ElapsedMilliseconds 

let IsPrime x =
        // extremely naive approach - good because we want it to be slow
        let mutable i = 2
        let mutable foundFactor = false
        while not foundFactor && i < x do
            if x % i = 0 then
                foundFactor <- true
            i <- i + 1
        not foundFactor
        
let nums = [| for i in 10000000..10004000 -> i |] 

ResetStopWatch()
let primeInfo = nums |> Array.map (fun x -> (x,IsPrime x)) 
stopWatch.Stop() 
ShowTime() 

ResetStopWatch()
primeInfo |> Array.filter (fun (x,b) -> b) |> Array.iter (fun (x,b) -> printf "%d," x) 
stopWatch.Stop() 
ShowTime() 
