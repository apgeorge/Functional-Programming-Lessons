module threads
//http://lorgonblog.spaces.live.com/blog/cns!701679AD17B6D310!193.entry

open System
open System.Threading
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

// we need to "join" at the end to know when we're done, and these will help do that
let mutable numRemainingComputations = nums.Length
let mre = new ManualResetEvent(false)
// primeInfo = array<int * bool>   
let primeInfo = Array.create nums.Length (0,false)
nums 
|> Array.iteri (fun i x -> ignore (ThreadPool.QueueUserWorkItem(fun o -> 
            printfn "starting thread %d" Thread.CurrentThread.ManagedThreadId
            primeInfo.[i] <- (x, IsPrime x)
            printfn "fin thread %d" Thread.CurrentThread.ManagedThreadId
            // if we're the last one, signal that we're done
            if Interlocked.Decrement(&numRemainingComputations) = 0 then
                mre.Set() |> ignore)))    
// wait until all done
mre.WaitOne() |> ignore
stopWatch.Stop() 
ShowTime() 


